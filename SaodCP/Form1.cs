using SaodCP.Database;
using SaodCP.Models;
using System.Text;

namespace SaodCP
{
    public partial class Hostel : Form
    {
        public Hostel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получение данных
        /// </summary>
        private void BindData()
        {
            var apartmentsArray = HostelContext
                .Apartments
                .Select(kv => kv.Value)
                .ToArray();

            var lodgersGrid = HostelContext
                .Lodgers
                .Select(kv => kv.Value)
                .ToArray();

            ApartmentsGrid.DataSource = apartmentsArray;
            LodgersGrid.DataSource = lodgersGrid;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void AccButton_Click(object sender, EventArgs e)
        {
            var current = ApartmentsGrid.CurrentRow?.DataBoundItem;

            if (current == null)
            {
                MessageBox.Show("Данные не выбраны");
            }

            if (current is Apartment apartment)
            {
                new AccommodationForm(RoomNumber: apartment.Number).ShowDialog();
            }
            else
            {
                MessageBox.Show("Данные не выбраны");
            }
        }

        private void LodgerAccButton_Click(object sender, EventArgs e)
        {
            var current = LodgersGrid.CurrentRow?.DataBoundItem;

            if (current == null)
            {
                MessageBox.Show("Данные не выбраны");
            }

            if (current is Lodger lodger)
            {
                new AccommodationForm(PassportId: lodger.PassportId)
                    .ShowDialog();
            }
            else
            {
                MessageBox.Show("Данные не выбраны");
            }
        }

        /// <summary>
        /// При каждой активации формы обновляем данные
        /// </summary>
        private void Hostel_Activated(object sender, EventArgs e)
        {
            BindData();
        }

        private void CreateLodgerButton_Click(object sender, EventArgs e)
        {
            new LodgerForm().ShowDialog();
        }

        private void ChangeLodgerButton_Click(object sender, EventArgs e)
        {
            var item = LodgersGrid.CurrentRow?.DataBoundItem;

            if (item == null)
            {
                MessageBox.Show("Постоялец не выбран");

                return;
            }

            if (item is Lodger lodger)
            {
                new LodgerForm(lodger).ShowDialog();
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        private void ApartmentButton_Click(object sender, EventArgs e)
        {
            new ApartmentForm().ShowDialog();
        }

        private void ChangeApartmentButton_Click(object sender, EventArgs e)
        {
            var item = LodgersGrid.CurrentRow?.DataBoundItem;

            if (item == null)
            {
                MessageBox.Show("Комната не выбрана");

                return;
            }

            if (item is Apartment lodger)
            {
                new ApartmentForm(lodger).ShowDialog();
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        private void DeleteApartmentButton_Click(object sender, EventArgs e)
        {
            if (ApartmentsGrid.CurrentRow == null)
            {
                MessageBox.Show("Номер не выбран");
            }
            else
            {
                Apartment? apartment = ApartmentsGrid.CurrentRow.DataBoundItem as Apartment;

                if (apartment == null)
                {
                    MessageBox.Show("Номер не выбран");
                }
                else
                {
                    var hasAcc = false;

                    foreach (var acc in HostelContext.Accommodations)
                    {
                        if (acc.ApartmentNumber == apartment.Number)
                        {
                            hasAcc = true;

                            break;
                        }
                    }

                    if (hasAcc)
                    {
                        MessageBox.Show("Для комнаты существуют данные " +
                            "о звселении. " +
                            "Удаление невозможно");

                        return;
                    }

                    var ret = HostelContext.Apartments.Remove(apartment.Number);

                    if (!ret)
                    {
                        MessageBox.Show("Не удалось удалить номер");
                    }
                    else
                    {
                        BindData();
                    }
                }
            }
        }

        private void DeleteLodgerButton_Click(object sender, EventArgs e)
        {
            if (LodgersGrid.CurrentRow == null)
            {
                MessageBox.Show("Постоялец не выбран");
            }
            else
            {
                Lodger? lodger = LodgersGrid.CurrentRow.DataBoundItem as Lodger;

                if (lodger == null)
                {
                    MessageBox.Show("Постоялец не выбран");
                }
                else
                {
                    var hasAcc = false;

                    foreach (var acc in HostelContext.Accommodations)
                    {
                        if (acc.LodgerPassportId == lodger.PassportId)
                        {
                            hasAcc = true;

                            break;
                        }
                    }

                    if (hasAcc)
                    {
                        MessageBox.Show("Для постояльца существуют данные " +
                            "о звселении. " +
                            "Удаление невозможно");

                        return;
                    }

                    var ret = HostelContext.Lodgers.Remove(lodger.PassportId);

                    if (!ret)
                    {
                        MessageBox.Show("Не удалось удалить постояльца");
                    }
                    else
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// Поиск номера по коду номера
        /// </summary>
        private void ApartmentNumberFindButton_Click(object sender, EventArgs e)
        {
            var apartmentNumber = ApartmentNumberFindTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(apartmentNumber))
            {
                MessageBox.Show("Введен некорректный код номера");

                return;
            }

            var apartment = HostelContext.Apartments.Find(apartmentNumber);

            if (apartment == null)
            {
                MessageBox.Show($"Номер {apartmentNumber} не найден");

                return;
            }

            StringBuilder data = ApartmentToStringBuilder(apartment);

            var date = DateOnly.FromDateTime(DateTime.Today);

            data.AppendLine();

            data.AppendLine($"На дату {date} проживают:");

            int cnt = 0;

            foreach (var acc in HostelContext.Accommodations)
            {
                if (acc.ApartmentNumber != apartment.Number
                    || acc.FromDate > date
                    || (acc.ToDate < date
                    && acc.ToDate == DateOnly.MinValue))
                {
                    continue;
                }

                var lodger = HostelContext.Lodgers[acc.LodgerPassportId];

                if (lodger == null)
                {
                    continue;
                }

                cnt++;

                data.AppendLine($"{cnt}. {lodger.PassportId} - {lodger.Name}");
            }

            data.AppendLine($"Всего: {cnt} проживающих");

            MessageBox.Show(data.ToString());
        }

        /// <summary>
        /// Преобразовать apartment в текстовое представление
        /// </summary>
        private static StringBuilder ApartmentToStringBuilder(Apartment apartment)
        {
            var data = new StringBuilder();

            data.AppendLine($"Номер {apartment.Number}");

            data.AppendLine($"Число комнат - {apartment.RoomNumber}");
            data.AppendLine($"Число кроватей - {apartment.BedsNumber}");
            data.AppendLine($"Есть туалет - {apartment.HasToilet.ToString()}");
            data.AppendLine($"Оборудование - {apartment.Equipment}");

            return data;
        }

        /// <summary>
        /// Поиск номера по оборудованию
        /// </summary>
        private void ApartmentEquipmentFindButton_Click(object sender, EventArgs e)
        {
            var search = ApartmentEquipmentFindTextBox.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Введите строку для поиска");

                return;
            }

            var data = new StringBuilder();

            data.AppendLine($"Результаты поиска  '{search}'");
            data.AppendLine();

            int cnt = 0;

            foreach (var (key, apartment) in HostelContext.Apartments)
            {
                // поиск в тексте
                var found = Algorithms.BMTextSearch.TextSearch(
                    apartment.Equipment,
                    search);

                if (found < 1)
                {
                    continue;
                }

                cnt++;

                data.AppendLine($"{cnt}. \n{ApartmentToStringBuilder(apartment)}");
                data.AppendLine();
            }

            data.AppendLine($"Всего: {cnt} номеров.");

            MessageBox.Show(data.ToString());
        }

        /// <summary>
        /// Поиск постояльца по номеру паспорта
        /// </summary>
        private void LodgerPassportFindButton_Click(object sender, EventArgs e)
        {
            var passportId = LodgerPassportFindTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(passportId))
            {
                MessageBox.Show("Введите номер паспорта");

                return;
            }

            var lodger = HostelContext.Lodgers[passportId];

            if (lodger == null)
            {
                MessageBox.Show($"Постоялец {passportId} не найден");

                return;
            }

            var lodgerData = new StringBuilder();

            lodgerData.AppendLine($"Постоялец {lodger.PassportId} {lodger.Name}");
            lodgerData.AppendLine();
            lodgerData.AppendLine($"Адрес - {lodger.Address}");
            lodgerData.AppendLine($"Год рождения - {lodger.BirthYear}");
            lodgerData.AppendLine();

            var date = DateOnly.FromDateTime(DateTime.Today);

            Accommodation? accommodation = null;

            foreach (var acc in HostelContext.Accommodations)
            {
                if (acc.FromDate < date
                    && (acc.ToDate > date
                    || acc.ToDate == DateOnly.MinValue)
                    && acc.LodgerPassportId == lodger.PassportId)
                {
                    accommodation = acc;

                    break;
                }
            }

            if (accommodation == null)
            {
                lodgerData.AppendLine($"На {date} данных" +
                    $" о проживании не найдено");
            }
            else
            {
                lodgerData.AppendLine($"На {date} проживает в " +
                    $"номере {accommodation.ApartmentNumber}");
            }

            MessageBox.Show(lodgerData.ToString());
        }

        private void LodgerNameFindButton_Click(object sender, EventArgs e)
        {
            var name = LodgerNameFindTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите имя для поиска");

                return;
            }

            var data = new StringBuilder();

            data.AppendLine($"Поиск '{name}'");

            int cnt = 0;

            foreach (var (passportId, lodger) in HostelContext.Lodgers)
            {
                if (Algorithms.BMTextSearch.TextSearch(lodger.Name, name) > 0)
                {
                    cnt++;

                    data.AppendLine($"{cnt}. {passportId} - {lodger.Name}");
                }
            }

            MessageBox.Show(data.ToString());
        }

        /// <summary>
        /// Очистить данные о проживающих
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LodgerClearData_Click(object sender, EventArgs e)
        {
            HostelContext.Lodgers.Clear();

            BindData();
        }

        private void ClearApartmentsDataButton_Click(object sender, EventArgs e)
        {
            HostelContext.Apartments = new();

            BindData();
        }

        private void CreateLodgerAccButton_Click(object sender, EventArgs e)
        {
            var item = LodgersGrid.CurrentRow?.DataBoundItem;

            if (item == null)
            {
                MessageBox.Show("Постоялец не выбран");

                return;
            }

            if (item is Lodger lodger)
            {
                new EditAccommodationForm(
                    type: AccommodationOperationType.OpenAccommodation,
                    lodgerPassportId: lodger.PassportId)
                    .ShowDialog();
            }
            else
            {
                MessageBox.Show("Постоялец не выбран");
            }
        }

        private void DeleteLodgerAccButton_Click(object sender, EventArgs e)
        {
            var item = LodgersGrid.CurrentRow?.DataBoundItem;

            if (item == null)
            {
                MessageBox.Show("Постоялец не выбран");

                return;
            }

            if (item is Lodger lodger)
            {
                new EditAccommodationForm(
                    type: AccommodationOperationType.CloseAccomodation,
                    lodgerPassportId: lodger.PassportId)
                    .ShowDialog();
            }
            else
            {
                MessageBox.Show("Постоялец не выбран");
            }
        }
    }
}