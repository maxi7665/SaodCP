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
            var bindingList = new BindingList<Apartment>(
                HostelContext.Apartments.Select(kv => kv.Value).ToList());

            var source = new BindingSource(bindingList, null);

            ApartmentsGrid.DataSource = source;
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