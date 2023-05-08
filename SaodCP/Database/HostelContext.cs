using SaodCP.DataStructures;
using SaodCP.Models;
using System.CodeDom;

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
        public static SortedOneWayCycledList<Accommodation> Accommodations { get; set; } = new (
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

            data.Lodgers.Add(new Lodger()
            {
                PassportId = Utils.Utils.GenerateRandomPassportId(),
                Address = "LA 1151",
                BirthYear = 1951,
                Name = "Mike"
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

            return true;
        }

        public static bool ValidateAccomodationWrite(
            Accommodation acc,
            out string error)
        {
            bool ret = true;
            error = string.Empty;

            // кол-во периодов проживания в комнате, найденных за период
            int foundInRoom = 0;

            // todo делать дальше проверку
            // по кол-ву проживающих в комнате на дату

            // проверка на пересечение периодов проживания для клиента
            foreach (var accommodation in Accommodations)
            {
                if (accommodation.LodgerPassportId == acc.LodgerPassportId
                    && (accommodation.FromDate <= acc.ToDate
                    || acc.ToDate == DateOnly.MinValue)
                    && (accommodation.ToDate >= acc.FromDate
                    || accommodation.ToDate == DateOnly.MinValue))
                {
                    ret = false;

                    error = acc.ToString() 
                        + "конфликтует с " 
                        + accommodation.ToString();

                    break;
                }
            }

            return ret;
        }
    }
}
