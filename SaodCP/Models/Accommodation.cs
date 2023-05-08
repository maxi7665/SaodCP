﻿
namespace SaodCP.Models
{
    /// <summary>
    /// Данные о периоде проживания постояльца в номере
    /// </summary>
    public class Accommodation
    {
        /// <summary>
        /// Номер паспорта постояльца
        /// </summary>
        public string LodgerPassportId { get; set; } = string.Empty;

        /// <summary>
        /// Номер комнаты постояльца
        /// </summary>
        public string ApartmentNumber { get; set; } = string.Empty;

        /// <summary>
        /// Дата заселения постояльца
        /// </summary>
        public DateOnly FromDate { get; set; }

        /// <summary>
        /// Дата выезда постояльца
        /// </summary>
        public DateOnly ToDate { get;set; }
    }
}