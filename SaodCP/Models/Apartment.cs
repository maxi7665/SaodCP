using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

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

        /// <summary>
        /// Номер апартаментов
        /// </summary>
        [DisplayName("Номер")]
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

        /// <summary>
        /// Кол-во спальных мест
        /// </summary>
        [DisplayName("Кол-во спальных мест")]
        public int BedsNumber { get; set; }

        /// <summary>
        /// Кол-во комнат
        /// </summary>
        [DisplayName("Кол-во комнат")]
        public int RoomNumber { get; set; }

        /// <summary>
        /// Есть ли сан.узел
        /// </summary>
        [DisplayName("Сан. узел")]
        public bool HasToilet { get; set; }

        /// <summary>
        /// Список оборудования
        /// </summary>
        [StringLength(200)]
        [DisplayName("Оборудование")]
        public string Equipment { get; set; } = string.Empty;
    }
}
