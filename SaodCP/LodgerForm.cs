using SaodCP.Database;
using SaodCP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaodCP
{
    public partial class LodgerForm : Form
    {
        public LodgerForm()
        {
            InitializeComponent();
        }

        public Lodger? Lodger { get; set; }

        public LodgerForm(Lodger lodger) : this()
        {
            NameTextBox.Text = lodger.Name;
            BirhdayTextBox.Text = lodger.BirthYear.ToString();
            AddressTextBox.Text = lodger.Address;

            // первичный ключ не редактируется
            PassportTextBox.Text = lodger.PassportId;
            PassportTextBox.ReadOnly = true;

            this.Lodger = lodger;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var passport = PassportTextBox.Text;

            string? error = null;

            if (!Utils.Utils.ValidateLodgerPassportId(
                    passport,
                    ref error))
            {
                MessageBox.Show(error);

                return;
            }

            var year = BirhdayTextBox.Text;

            int onlyYear;

            if (!int.TryParse(year, out onlyYear))
            {
                MessageBox.Show("Неправильно введен год рождения");

                return;
            }
            else if (onlyYear < 0
                || onlyYear > DateOnly.FromDateTime(DateTime.Now).Year)
            {
                MessageBox.Show("Неправильно введен год рождения");

                return;
            }

            var address = AddressTextBox.Text;

            var name = NameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите имя");

                return;
            }
            else if (name.Length < 3)
            {
                MessageBox.Show("Имя должно быть длинее 3х символов");

                return;
            }

            Lodger editLodger;

            if (Lodger == null)
            {
                editLodger = new Lodger();

                editLodger.PassportId = passport;
            }
            else
            {
                editLodger = Lodger;
            }

            editLodger.Address = address;
            editLodger.Name = name;
            editLodger.BirthYear = onlyYear;

            // если не было постояльца, значит создаем
            if (Lodger == null)
            {
                HostelContext.Lodgers.Add(passport, editLodger);
            }

            this.Close();
        }
    }
}
