using SaodCP.DataStructures;
using System.ComponentModel;

namespace SaodCP.Models
{
    /// <summary>
    /// Постоялец
    /// </summary>
    public class Lodger
    {
        public static readonly string PassportIdPattern = "NNNN-NNNNNN";

        private HashString passportId = string.Empty;

        [DisplayName("Номер паспорта")]
        public string PassportId
        {
            get => passportId;
            set
            {
                if (Utils.Utils.ValidateLodgerPassportId(value))
                {
                    passportId = value;
                }
                else
                {
                    throw new FormatException("Неверный формат номера паспорта!");
                }
            }
        }

        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Год рождения")]
        public int BirthYear { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; } = string.Empty;
    }
}
