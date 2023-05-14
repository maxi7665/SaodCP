
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace SaodCP.Models
{
    /// <summary>
    /// Данные о периоде проживания постояльца в номере
    /// </summary>
    public class Accommodation : ICloneable
    {
        /// <summary>
        /// Номер паспорта постояльца
        /// </summary>
        [DisplayName("Номер паспорта")]
        public string LodgerPassportId { get; set; } = string.Empty;

        /// <summary>
        /// Номер комнаты постояльца
        /// </summary>
        [DisplayName("Номер комнаты")]
        public string ApartmentNumber { get; set; } = string.Empty;

        /// <summary>
        /// Дата заселения постояльца
        /// </summary>
        [DisplayName("Дата С")]
        public DateOnly FromDate { get; set; }

        /// <summary>
        /// Дата выезда постояльца
        /// </summary>
        [DisplayName("Дата ПО")]
        public DateOnly ToDate { get;set; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string? ToString()
        {
            return $"Заселение постояльца " +
                $"{this.LodgerPassportId} в номер " +
                $"{this.ApartmentNumber} " +
                $"с {this.FromDate} по {this.ToDate}";
        }
    }
}
