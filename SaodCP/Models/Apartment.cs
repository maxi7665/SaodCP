using System.ComponentModel.DataAnnotations;

namespace SaodCP.Models
{
    /// <summary>
    /// Номер в гостинице
    /// </summary>
    public class Apartment
    {
        private string _number;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Apartment(string number)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        {
            Number = number;
        }

        public string Number
        {
            get => _number;
            set
            {
                if (!Utils.Utils.ValidateRoomNumberId(value))
                {
                    throw new ArgumentException(null, nameof(value));
                }

                _number = value;
            }
        }

        public int BedsNumber { get; set; }

        public int RoomNumber { get; set; }

        public bool HasToilet { get; set; }

        [StringLength(200)]
        public string Equipment { get; set; } = string.Empty;
    }
}
