using SaodCP.Models;
using System.Text.Json;

namespace SaodCP.Database
{
    /// <summary>
    /// Схема для сериализации хранимых данных 
    /// </summary>
    public class DataSerializationScheme
    {
        public List<Accommodation> Accommodations { get; set; } = new List<Accommodation>();

        public List<Apartment> Apartments { get; set; } = new List<Apartment>();

        public List<Lodger> Lodgers { get; set; } = new List<Lodger>();

        public async static Task<DataSerializationScheme?> FromStream(Stream stream)
        {
            var data = await JsonSerializer.DeserializeAsync<DataSerializationScheme>(stream);

            return data;
        }

        public async static Task<Stream?> ToStream(DataSerializationScheme data)
        {
            var stream = new MemoryStream();

            await JsonSerializer.SerializeAsync(stream, data);

            return stream;
        }
    }
}
