using System.Collections.Generic;
using System.ComponentModel;
using System;
using SaodCP.Models;
using SaodCP.Database;

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
            Apartment current =
                (Apartment)ApartmentsGrid.CurrentRow.DataBoundItem;

            new AccommodationForm(RoomNumber: current.Number).ShowDialog();
        }

        private void LodgerAccButton_Click(object sender, EventArgs e)
        {
            Lodger current =
                (Lodger)LodgersGrid.CurrentRow.DataBoundItem;

            new AccommodationForm(PassportId: current.PassportId).ShowDialog();
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
            var item = LodgersGrid.CurrentRow.DataBoundItem;

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
            var item = LodgersGrid.CurrentRow.DataBoundItem;

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
    }
}