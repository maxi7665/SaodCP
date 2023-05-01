using SaodCP.Utils;
using System.Transactions;

namespace SaodCP.Models
{
    /// <summary>
    /// Постоялец
    /// </summary>
    public class Lodger
    {
        public static readonly string PassportIdPattern = "NNNN-NNNNNN";

        private string passportId = string.Empty;

        public string PassportId { 
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

        public string Name { get; set; } = string.Empty;

        public int BirthYear { get; set; }

        public string Address { get; set; } = string.Empty;        
    }
}
