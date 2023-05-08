namespace SaodCP
{
    partial class Hostel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            ApartmentsTab = new TabPage();
            ApartmentsGrid = new DataGridView();
            apartmentBindingSource = new BindingSource(components);
            LogdersTab = new TabPage();
            Accomodations = new TabPage();
            tabControl1.SuspendLayout();
            ApartmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ApartmentsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apartmentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(ApartmentsTab);
            tabControl1.Controls.Add(LogdersTab);
            tabControl1.Controls.Add(Accomodations);
            tabControl1.Location = new Point(10, 9);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(679, 320);
            tabControl1.TabIndex = 0;
            // 
            // ApartmentsTab
            // 
            ApartmentsTab.Controls.Add(ApartmentsGrid);
            ApartmentsTab.Location = new Point(4, 24);
            ApartmentsTab.Margin = new Padding(3, 2, 3, 2);
            ApartmentsTab.Name = "ApartmentsTab";
            ApartmentsTab.Padding = new Padding(3, 2, 3, 2);
            ApartmentsTab.Size = new Size(671, 292);
            ApartmentsTab.TabIndex = 0;
            ApartmentsTab.Text = "Номера";
            ApartmentsTab.UseVisualStyleBackColor = true;
            // 
            // ApartmentsGrid
            // 
            ApartmentsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApartmentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ApartmentsGrid.Location = new Point(6, 5);
            ApartmentsGrid.Name = "ApartmentsGrid";
            ApartmentsGrid.RowTemplate.Height = 25;
            ApartmentsGrid.Size = new Size(556, 266);
            ApartmentsGrid.TabIndex = 0;
            ApartmentsGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // apartmentBindingSource
            // 
            apartmentBindingSource.DataSource = typeof(Models.Apartment);
            // 
            // LogdersTab
            // 
            LogdersTab.Location = new Point(4, 24);
            LogdersTab.Margin = new Padding(3, 2, 3, 2);
            LogdersTab.Name = "LogdersTab";
            LogdersTab.Padding = new Padding(3, 2, 3, 2);
            LogdersTab.Size = new Size(671, 292);
            LogdersTab.TabIndex = 1;
            LogdersTab.Text = "Постояльцы";
            LogdersTab.UseVisualStyleBackColor = true;
            // 
            // Accomodations
            // 
            Accomodations.Location = new Point(4, 24);
            Accomodations.Margin = new Padding(3, 2, 3, 2);
            Accomodations.Name = "Accomodations";
            Accomodations.Size = new Size(671, 292);
            Accomodations.TabIndex = 2;
            Accomodations.Text = "Заселения";
            Accomodations.UseVisualStyleBackColor = true;
            // 
            // Hostel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Hostel";
            Text = "Регистрация постояльцев в гостинице";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ApartmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ApartmentsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)apartmentBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage ApartmentsTab;
        private TabPage LogdersTab;
        private TabPage Accomodations;
        private DataGridView ApartmentsGrid;
        private BindingSource apartmentBindingSource;
    }
}