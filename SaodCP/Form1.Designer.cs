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
            LogdersTab = new TabPage();
            LodgersGrid = new DataGridView();
            apartmentBindingSource = new BindingSource(components);
            tabControl1.SuspendLayout();
            ApartmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ApartmentsGrid).BeginInit();
            LogdersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LodgersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apartmentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(ApartmentsTab);
            tabControl1.Controls.Add(LogdersTab);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(659, 317);
            tabControl1.TabIndex = 0;
            // 
            // ApartmentsTab
            // 
            ApartmentsTab.Controls.Add(ApartmentsGrid);
            ApartmentsTab.Location = new Point(4, 24);
            ApartmentsTab.Margin = new Padding(3, 2, 3, 2);
            ApartmentsTab.Name = "ApartmentsTab";
            ApartmentsTab.Padding = new Padding(3, 2, 3, 2);
            ApartmentsTab.Size = new Size(651, 289);
            ApartmentsTab.TabIndex = 0;
            ApartmentsTab.Text = "Номера";
            ApartmentsTab.UseVisualStyleBackColor = true;
            // 
            // ApartmentsGrid
            // 
            ApartmentsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApartmentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ApartmentsGrid.Location = new Point(0, 0);
            ApartmentsGrid.Name = "ApartmentsGrid";
            ApartmentsGrid.ReadOnly = true;
            ApartmentsGrid.RowTemplate.Height = 25;
            ApartmentsGrid.Size = new Size(582, 283);
            ApartmentsGrid.TabIndex = 0;
            ApartmentsGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // LogdersTab
            // 
            LogdersTab.Controls.Add(LodgersGrid);
            LogdersTab.Location = new Point(4, 24);
            LogdersTab.Margin = new Padding(3, 2, 3, 2);
            LogdersTab.Name = "LogdersTab";
            LogdersTab.Padding = new Padding(3, 2, 3, 2);
            LogdersTab.Size = new Size(651, 289);
            LogdersTab.TabIndex = 1;
            LogdersTab.Text = "Постояльцы";
            LogdersTab.UseVisualStyleBackColor = true;
            // 
            // LodgersGrid
            // 
            LodgersGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LodgersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LodgersGrid.Location = new Point(0, 0);
            LodgersGrid.Name = "LodgersGrid";
            LodgersGrid.RowTemplate.Height = 25;
            LodgersGrid.Size = new Size(568, 292);
            LodgersGrid.TabIndex = 0;
            // 
            // apartmentBindingSource
            // 
            apartmentBindingSource.DataSource = typeof(Models.Apartment);
            // 
            // Hostel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 326);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Hostel";
            Text = "Регистрация постояльцев в гостинице";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ApartmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ApartmentsGrid).EndInit();
            LogdersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LodgersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)apartmentBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage ApartmentsTab;
        private TabPage LogdersTab;
        private DataGridView ApartmentsGrid;
        private BindingSource apartmentBindingSource;
        private DataGridView LodgersGrid;
    }
}