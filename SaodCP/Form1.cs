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

            new AccommodationForm(RoomNumber: current.Number).Show();
        }

        private void LodgerAccButton_Click(object sender, EventArgs e)
        {
            Lodger current =
                (Lodger)LodgersGrid.CurrentRow.DataBoundItem;

            new AccommodationForm(PassportId: current.PassportId).Show();
        }

        /// <summary>
        /// При каждой активации формы обновляем данные
        /// </summary>
        private void Hostel_Activated(object sender, EventArgs e)
        {
            BindData();
        }
    }
}