using SaodCP.Database;

namespace SaodCP
{
    public partial class EditAccommodationForm : Form
    {
        private readonly AccommodationOperationType _type;
        private readonly string? _lodgerPassportId;
        private readonly string? _apartmentNumber;

        public EditAccommodationForm(
            AccommodationOperationType type,
            string? lodgerPassportId = null,
            string? apartmentNumber = null)
        {
            InitializeComponent();

            var array = new string[HostelContext.Apartments.Count];

            int cnt = 0;

            foreach (var (number, apartement) in HostelContext.Apartments)
            {
                array[cnt] = number;

                cnt++;
            }

            ApartmentNumberComboBox.DataSource = array;

            if (!string.IsNullOrEmpty(apartmentNumber))
            {
                ApartmentNumberComboBox.Text = apartmentNumber;
            }

            if (!string.IsNullOrWhiteSpace(lodgerPassportId))
            {
                LodgerPassportIdTextBox.Text = lodgerPassportId;
            }

            switch (type)
            {
                case AccommodationOperationType.OpenAccommodation:

                    Text = "Заселить";

                    break;

                case AccommodationOperationType.CloseAccomodation:

                    Text = "Выселить";

                    break;
            }

            this._type = type;
            this._lodgerPassportId = lodgerPassportId;
            this._apartmentNumber = apartmentNumber;
        }

        private void SaveAccButton_Click(object sender, EventArgs e)
        {
            var passportId = LodgerPassportIdTextBox.Text.Trim();
            var apartmentNumber = ApartmentNumberComboBox.Text.Trim();
            var onDate = DateOnly.FromDateTime(DateCalendar.SelectionRange.Start);

            if (string.IsNullOrWhiteSpace(passportId)
                || string.IsNullOrWhiteSpace(apartmentNumber)
                || onDate == DateOnly.MinValue)
            {
                MessageBox.Show("Введены не все данные");

                return;
            }

            string error = string.Empty;
            var result = false;

            switch (_type)
            {
                case AccommodationOperationType.OpenAccommodation:

                    result = HostelContext.StartAccomodation(
                        passportId,
                        apartmentNumber,
                        onDate,
                        ref error);

                    break;

                case AccommodationOperationType.CloseAccomodation:

                    result = HostelContext.EndAccomodation(
                        passportId,
                        apartmentNumber,
                        onDate,
                        ref error);

                    break;
            }

            if (!result)
            {
                MessageBox.Show(error);
            }
            else
            {
                Close();
            }
        }
    }

    public enum AccommodationOperationType
    {
        None,
        OpenAccommodation,
        CloseAccomodation
    }
}
