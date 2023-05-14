using SaodCP.Database;
using SaodCP.Models;

namespace SaodCP
{
    public partial class ApartmentForm : Form
    {
        public ApartmentForm()
        {
            InitializeComponent();
        }

        public Apartment? Apartment { get; set; }

        public ApartmentForm(Apartment apartment) : this()
        {
            this.Apartment = apartment;

            ApartmentNumberTextBox.Text = Apartment.Number;
            ApartmentNumberTextBox.ReadOnly = true;

            RoomNumberTextBox.Text = Apartment.RoomNumber.ToString();
            BedsNumberTextBox.Text = Apartment.BedsNumber.ToString();
            EquipmentTextBox.Text = Apartment.Equipment;

            HasToiletCheckBox.Checked = Apartment.HasToilet;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var apartmentNumber = ApartmentNumberTextBox.Text.Trim();

            string? error = null;

            if (!Utils.Utils.ValidateRoomNumberId(
                    apartmentNumber, 
                    ref error))
            {
                MessageBox.Show(error);

                return;
            }

            int bedsNumber;

            if (!int.TryParse(
                    BedsNumberTextBox.Text.Trim(),
                    out bedsNumber))
            {
                MessageBox.Show("Неправильный формат кол-ва кроватей");

                return;
            }

            int roomNumber;

            if (!int.TryParse(
                    BedsNumberTextBox.Text.Trim(),
                    out roomNumber))
            {
                MessageBox.Show("Неправильный формат кол-ва комнат");

                return;
            }

            var equipment = EquipmentTextBox.Text.Trim();

            var hasToilet = HasToiletCheckBox.Checked;

            Apartment apartment;

            if (Apartment == null)
            {
                apartment = new(apartmentNumber);
            }
            else
            {
                apartment = Apartment;
            }

            apartment.Equipment = equipment;
            apartment.RoomNumber = roomNumber;
            apartment.BedsNumber = bedsNumber;
            apartment.HasToilet = hasToilet;

            // если создаем новый номер - сохраняем
            if (Apartment == null)
            {
                if (HostelContext.Apartments.Find(apartment.Number) != null)
                {
                    MessageBox.Show($"Номер {apartment.Number} уже существует");

                    return;
                }

                HostelContext.Apartments.Add(
                    apartment.Number, 
                    apartment);
            }

            Close();
        }
    }
}
