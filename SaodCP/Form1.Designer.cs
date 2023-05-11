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
            ApartmentButton = new Button();
            AccButton = new Button();
            ApartmentsGrid = new DataGridView();
            LogdersTab = new TabPage();
            ChanheLodgerButton = new Button();
            CreateLodgerButton = new Button();
            LodgerAccButton = new Button();
            LodgersGrid = new DataGridView();
            apartmentBindingSource = new BindingSource(components);
            ChangeApartmentButton = new Button();
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
            ApartmentsTab.Controls.Add(ChangeApartmentButton);
            ApartmentsTab.Controls.Add(ApartmentButton);
            ApartmentsTab.Controls.Add(AccButton);
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
            // ApartmentButton
            // 
            ApartmentButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ApartmentButton.Location = new Point(555, 34);
            ApartmentButton.Name = "ApartmentButton";
            ApartmentButton.Size = new Size(90, 23);
            ApartmentButton.TabIndex = 4;
            ApartmentButton.Text = "Создать";
            ApartmentButton.UseVisualStyleBackColor = true;
            ApartmentButton.Click += ApartmentButton_Click;
            // 
            // AccButton
            // 
            AccButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AccButton.Location = new Point(555, 5);
            AccButton.Name = "AccButton";
            AccButton.Size = new Size(90, 23);
            AccButton.TabIndex = 1;
            AccButton.Text = "Заселения";
            AccButton.UseVisualStyleBackColor = true;
            AccButton.Click += AccButton_Click;
            // 
            // ApartmentsGrid
            // 
            ApartmentsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApartmentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ApartmentsGrid.Location = new Point(0, 0);
            ApartmentsGrid.Name = "ApartmentsGrid";
            ApartmentsGrid.ReadOnly = true;
            ApartmentsGrid.RowTemplate.Height = 25;
            ApartmentsGrid.Size = new Size(549, 283);
            ApartmentsGrid.TabIndex = 0;
            // 
            // LogdersTab
            // 
            LogdersTab.Controls.Add(ChanheLodgerButton);
            LogdersTab.Controls.Add(CreateLodgerButton);
            LogdersTab.Controls.Add(LodgerAccButton);
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
            // ChanheLodgerButton
            // 
            ChanheLodgerButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ChanheLodgerButton.Location = new Point(555, 63);
            ChanheLodgerButton.Name = "ChanheLodgerButton";
            ChanheLodgerButton.Size = new Size(90, 23);
            ChanheLodgerButton.TabIndex = 4;
            ChanheLodgerButton.Text = "Изменить";
            ChanheLodgerButton.UseVisualStyleBackColor = true;
            ChanheLodgerButton.Click += ChangeLodgerButton_Click;
            // 
            // CreateLodgerButton
            // 
            CreateLodgerButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreateLodgerButton.Location = new Point(555, 34);
            CreateLodgerButton.Name = "CreateLodgerButton";
            CreateLodgerButton.Size = new Size(90, 23);
            CreateLodgerButton.TabIndex = 3;
            CreateLodgerButton.Text = "Создать";
            CreateLodgerButton.UseVisualStyleBackColor = true;
            CreateLodgerButton.Click += CreateLodgerButton_Click;
            // 
            // LodgerAccButton
            // 
            LodgerAccButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LodgerAccButton.Location = new Point(555, 5);
            LodgerAccButton.Name = "LodgerAccButton";
            LodgerAccButton.Size = new Size(90, 23);
            LodgerAccButton.TabIndex = 2;
            LodgerAccButton.Text = "Заселения";
            LodgerAccButton.UseVisualStyleBackColor = true;
            LodgerAccButton.Click += LodgerAccButton_Click;
            // 
            // LodgersGrid
            // 
            LodgersGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LodgersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            LodgersGrid.Location = new Point(0, 0);
            LodgersGrid.Name = "LodgersGrid";
            LodgersGrid.RowTemplate.Height = 25;
            LodgersGrid.Size = new Size(539, 292);
            LodgersGrid.TabIndex = 0;
            // 
            // apartmentBindingSource
            // 
            apartmentBindingSource.DataSource = typeof(Models.Apartment);
            // 
            // ChangeApartmentButton
            // 
            ChangeApartmentButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ChangeApartmentButton.Location = new Point(555, 63);
            ChangeApartmentButton.Name = "ChangeApartmentButton";
            ChangeApartmentButton.Size = new Size(90, 23);
            ChangeApartmentButton.TabIndex = 5;
            ChangeApartmentButton.Text = "Изменить";
            ChangeApartmentButton.UseVisualStyleBackColor = true;
            ChangeApartmentButton.Click += ChangeApartmentButton_Click;
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
            Activated += Hostel_Activated;
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
        private Button AccButton;
        private Button LodgerAccButton;
        private Button ChanheLodgerButton;
        private Button CreateLodgerButton;
        private Button ApartmentButton;
        private Button ChangeApartmentButton;
    }
}