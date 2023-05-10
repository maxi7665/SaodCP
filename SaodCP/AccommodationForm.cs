using SaodCP.Database;
using SaodCP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaodCP
{
    public partial class AccommodationForm : Form
    {
        public string PassportId { get; set; } = string.Empty;

        public string RoomNumber { get; set; } = string.Empty;

        public AccommodationForm()
        {
            InitializeComponent();            
        }

        private void SetLabel()
        {
            Text = "Заселения";

            if (!string.IsNullOrWhiteSpace(PassportId))
            {
                Text += $" Постоялец {PassportId}";
            }
            else if (!string.IsNullOrWhiteSpace(RoomNumber))
            {
                Text += $" Комната {RoomNumber}";
            }
        }

        public AccommodationForm(
            string? PassportId = null,
            string? RoomNumber = null) : this()
        {
            if (!string.IsNullOrWhiteSpace(PassportId))
            {
                this.PassportId = PassportId;
            }

            if (!string.IsNullOrWhiteSpace(RoomNumber))
            {
                this.RoomNumber = RoomNumber;
            }

            SetLabel();
        }

        private Accommodation[] FetchData()
        {
            int cnt = 0;

            foreach (var accommodation in HostelContext.Accommodations)
            {
                if ((string.IsNullOrEmpty(PassportId)
                    || PassportId == accommodation.LodgerPassportId)
                    && (string.IsNullOrEmpty(RoomNumber)
                    || RoomNumber == accommodation.ApartmentNumber))
                {
                    cnt++;
                }
            }

            var ret = new Accommodation[cnt];

            var i = 0;

            foreach (var accommodation in HostelContext.Accommodations)
            {
                if ((string.IsNullOrEmpty(PassportId)
                    || PassportId == accommodation.LodgerPassportId)
                    && (string.IsNullOrEmpty(RoomNumber)
                    || RoomNumber == accommodation.ApartmentNumber))
                {
                    if (i < ret.Length)
                    {
                        ret[i] = accommodation;
                    }
                }
            }

            return ret;
        }

        private void AccommodationForm_Load(object sender, EventArgs e)
        {
            AccommodationGrid.DataSource = FetchData();
        }
    }
}
