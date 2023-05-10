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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}