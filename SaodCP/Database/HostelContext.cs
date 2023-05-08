using SaodCP.DataStructures;
using SaodCP.Models;

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
    }
}
