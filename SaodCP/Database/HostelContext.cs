using SaodCP.DataStructures;
using SaodCP.Models;
using System.CodeDom;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SaodCP.Database
{
    public static class HostelContext
    {
        /// <summary>
        /// Постояльцы
        /// </summary>
        public static OpenHashTable<string, Lodger> Lodgers { get; set; } = new();

        /// <summary>
        /// Гостиничные номера
        /// </summary>
        public static Tree<string, Apartment> Apartments { get; set; } = new();

        /// <summary>
        /// Данные о заселении
        /// </summary>
        public static SortedOneWayCycledList<Accommodation> Accommodations { get; set; } = new(
            (a1, a2) => a1.ApartmentNumber.CompareTo(a2.ApartmentNumber));

        public static DataSerializationScheme ToDataSheme()
        {
            var data = new DataSerializationScheme();

            data.Accommodations.AddRange(Accommodations);
            data.Lodgers.AddRange(Lodgers.Values);
            data.Apartments.AddRange(Apartments.Select(kv => kv.Value));

            return data;
        }

        public static void FromDataScheme(DataSerializationScheme data)
        {
            Lodgers.Clear();

            foreach (var lodger in data.Lodgers)
            {
                Lodgers.Add(lodger.PassportId, lodger);
            }

            Accommodations.Clear();

            foreach (var accommodation in data.Accommodations)
            {
                Accommodations.Add(accommodation);
            }

            Apartments = new();

            foreach (var apartment in data.Apartments)
            {
                Apartments.Add(apartment.Number, apartment);
            }
        }

        /// <summary>
        /// Заполнить БД тестовыми данными
        /// </summary>
        public static void InitTestData()
        {
            var data = new DataSerializationScheme();

            data.Apartments.Add(new Apartment(Utils.Utils.GenerateRandomRoomNumber())
            {
                BedsNumber = 1,
                Equipment = "Телевизор, Микроволновка",
                HasToilet = true,
                RoomNumber = 2
            });

            data.Apartments.Add(new Apartment(Utils.Utils.GenerateRandomRoomNumber())
            {
                BedsNumber = 2,
                Equipment = "Микроволновка",
                HasToilet = true,
                RoomNumber = 3
            });

            data.Lodgers.Add(new Lodger()
            {
                PassportId = Utils.Utils.GenerateRandomPassportId(),
                Address = "LA 1151",
                BirthYear = 1951,
                Name = "Mike"
            });

            data.Lodgers.Add(new Lodger()
            {
                PassportId = Utils.Utils.GenerateRandomPassportId(),
                Address = "SaintP",
                BirthYear = 1976,
                Name = "Mikes"
            });

            FromDataScheme(data);
        }

        /// <summary>
        /// Получить сущность определенного типа по идентификатору
        /// </summary>
        /// <typeparam name="T">Тип сущности для поиска</typeparam>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public static T? FindById<T>(string id)
        {
            if (typeof(T) == typeof(Lodger))
            {
                Lodger? lodger = Lodgers[id];

                if (lodger == null)
                {
                    return default;
                }

                return (T?)(object?)lodger;
            }
            else if (typeof(T) == typeof(Apartment))
            {
                Apartment? apartment = Apartments.Find(id);

                if (apartment == null)
                {
                    return default;
                }

                return (T?)(object?)apartment;
            }
            else
            {
                return default;
            }
        }

        /// <summary>
        /// Добавление нового элемента 
        /// </summary>
        /// <typeparam name="T">Тип элемента</typeparam>
        /// <param name="entry">Новый элемент</param>
        public static void Add<T>(T entry)
        {
            if (entry is Lodger lodger)
            {
                Lodgers.Add(lodger.PassportId, lodger);
            }
            else if (entry is Apartment apartment)
            {
                Apartments.Add(apartment.Number, apartment);
            }
            else if (entry is Accommodation accommodation)
            {
                Accommodations.Add(accommodation);
            }
        }

        /// <summary>
        /// Выселить постояльца
        /// </summary>
        /// <param name="passportId">Номер паспорта постояльца</param>
        /// <param name="roomNumber">Номер комнаты</param>
        /// <param name="endDate">Дата выселения</param>
        /// <param name="error">Текст ошибки</param>
        /// <returns>Успех/неуспех</returns>
        public static bool EndAccomodation(
            string passportId,
            string roomNumber,
            DateOnly endDate,
            ref string error)
        {
            Accommodation? acc = null;

            foreach (var accommodation in Accommodations)
            {
                var fromDate = accommodation.FromDate;
                var toDate = accommodation.ToDate == DateOnly.MinValue
                    ? DateOnly.MaxValue
                    : accommodation.ToDate;

                if (endDate >= fromDate
                    && endDate <= toDate)
                {
                    acc = accommodation;

                    break;
                }

            }

            if (acc == null)
            {
                error = $"Период проживания на дату {endDate} " +
                    $"для постояльца {passportId} не найден";

                return false;
            }
            else if (acc.ToDate != DateOnly.MinValue)
            {
                error = $"{acc} " +
                    $"для постояльца {passportId} не является открытым. " +
                    $"Выселение невозможно";

                return false;
            }

            // с помощью копии объекта проверяем возможность записи
            var copy = (Accommodation)acc.Clone();

            copy.ToDate = endDate;

            var ret = ValidateAccomodationWrite(copy, out error, true);

            if (!ret)
            {
                return ret;
            }

            // все хорошо, меняем у оригинальной копии дату
            acc.ToDate = endDate;

            return ret;            
        }

        /// <summary>
        /// Заселить постояльца с даты
        /// </summary>
        /// <param name="passportId">Номер паспорта постояльца</param>
        /// <param name="roomNumber">Номер комнаты</param>
        /// <param name="fromDate">Дата заселения</param>
        /// <param name="error">Текст ошибки</param>
        /// <returns></returns>
        public static bool StartAccomodation(
        string passportId,
        string roomNumber,
        DateOnly fromDate,
        ref string error)
        {
            var acc = new Accommodation()
            {
                ApartmentNumber = roomNumber,
                LodgerPassportId = passportId,
                FromDate = fromDate
            };

            bool ret = ValidateAccomodationWrite(acc, out error);

            if (!ret)
            {
                return ret;
            }

            Accommodations.Add(acc);

            return true;
        }

        /// <summary>
        /// Проверка периода проживания для записи в БД
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool ValidateAccomodationWrite(
            Accommodation acc,
            out string error,
            bool existed = false)
        {
            bool ret = true;
            error = string.Empty;

            // клиент и комната, для которых создаем период проживания
            var lodger = FindById<Lodger>(acc.LodgerPassportId);
            var room = FindById<Apartment>(acc.ApartmentNumber);

            if (lodger == null)
            {
                error = $"Постоялец с номером {acc.LodgerPassportId}" +
                    $" не найден";

                return false;
            }

            if (room == null)
            {
                error = $"Комната с номером {acc.ApartmentNumber}" +
                    $" не найдена";

                return false;
            }

            var fromDate = acc.FromDate;
            var toDate = acc.ToDate;

            if (toDate == DateOnly.MinValue)
            {
                toDate = DateOnly.MaxValue;
            }

            var periodLength = toDate.DayNumber - fromDate.DayNumber;

            if (periodLength < 1)
            {
                ret = false;

                error = $"Период проживания {acc} имеет " +
                    $"некорректную продолжительность {periodLength} дн.";

                return ret;
            }

            // проверка на пересечение периодов проживания для клиента
            foreach (var accommodation in Accommodations)
            {
                var checkFromDate = accommodation.FromDate;
                var checkToDate = accommodation.ToDate;

                if (checkToDate == DateOnly.MinValue)
                {
                    checkToDate = DateOnly.MaxValue;
                }

                // если заселение уже существует,
                // проверяем по первичному ключу
                if (existed
                    && accommodation.FromDate == acc.FromDate
                    && accommodation.LodgerPassportId == acc.LodgerPassportId
                    && accommodation.ApartmentNumber == acc.ApartmentNumber)
                {
                    continue;
                }

                if (accommodation.LodgerPassportId == acc.LodgerPassportId
                    && checkFromDate <= toDate
                    && checkToDate >= fromDate)
                {
                    ret = false;

                    error = acc.ToString()
                        + "конфликтует с "
                        + accommodation.ToString();

                    break;
                }
            }

            if (!ret)
            {
                return ret;
            }

            byte[] dateLogdersNumArray = new byte[periodLength];

            // проверка на кол-во проживающих в комнате
            foreach (var accommodation in Accommodations)
            {
                var checkFromDate = accommodation.FromDate;
                var checkToDate = accommodation.ToDate;

                if (checkToDate == DateOnly.MinValue)
                {
                    checkToDate = DateOnly.MaxValue;
                }

                // если заселение уже существует,
                // проверяем по первичному ключу
                if (existed
                    && accommodation.FromDate == acc.FromDate
                    && accommodation.LodgerPassportId == acc.LodgerPassportId
                    && accommodation.ApartmentNumber == acc.ApartmentNumber)
                {
                    continue;
                }

                // если заселение по комнате не пересекается, пропускаем
                if (accommodation.ApartmentNumber != acc.ApartmentNumber
                    || checkFromDate > toDate
                    || checkToDate < fromDate)
                {
                    continue;
                }

                // период пересечения найденного заселения с проверяемым
                var periodFromDate = checkFromDate < fromDate
                    ? fromDate :
                    checkFromDate;

                var periodToDate = checkToDate > toDate
                    ? toDate
                    : checkToDate;

                // стартовая дата
                uint startIdx = (uint)(periodFromDate.DayNumber - fromDate.DayNumber);

                //длина периода
                uint length = (uint)(periodToDate.DayNumber - periodFromDate.DayNumber);

                if (startIdx + length > dateLogdersNumArray.Length)
                {
                    throw new ApplicationException("Checking internal error");
                }

                for (uint i = startIdx; i < startIdx + length; i++)
                {
                    dateLogdersNumArray[i]++;

                    // если кол-во уже заселенных + 1 (из нового заселения)
                    // больше чем кол-во кроватей,
                    // не разрешаем заселение
                    if (dateLogdersNumArray[i] + 1 > room.BedsNumber)
                    {
                        error = $"На дату {fromDate.AddDays((int)i)} " +
                            $"кол-во заселенных постояльцев : {dateLogdersNumArray[i] + 1}. \r\n" +
                            $"Макс. кол-во проживающих в номере {room.Number} : " +
                            $"{room.BedsNumber}. \r\nКонфликт с {accommodation}";

                        ret = false;

                        break;
                    }
                }

                if (!ret)
                {
                    break;
                }
            }

            return ret;
        }
    }
}
