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
            ClearApartmentsDataButton = new Button();
            ApartmentEquipmentFindButton = new Button();
            label2 = new Label();
            ApartmentEquipmentFindTextBox = new TextBox();
            ApartmentNumberFindButton = new Button();
            label1 = new Label();
            ApartmentNumberFindTextBox = new TextBox();
            DeleteApartmentButton = new Button();
            ChangeApartmentButton = new Button();
            ApartmentButton = new Button();
            AccButton = new Button();
            ApartmentsGrid = new DataGridView();
            LogdersTab = new TabPage();
            DeleteLodgerAccButton = new Button();
            CreateLodgerAccButton = new Button();
            LodgerClearDataButton = new Button();
            LodgerNameFindButton = new Button();
            label3 = new Label();
            LodgerNameFindTextBox = new TextBox();
            LodgerPassportFindButton = new Button();
            label4 = new Label();
            LodgerPassportFindTextBox = new TextBox();
            DeleteLodgerButton = new Button();
            ChanheLodgerButton = new Button();
            CreateLodgerButton = new Button();
            LodgerAccButton = new Button();
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
            tabControl1.Size = new Size(659, 341);
            tabControl1.TabIndex = 0;
            // 
            // ApartmentsTab
            // 
            ApartmentsTab.Controls.Add(ClearApartmentsDataButton);
            ApartmentsTab.Controls.Add(ApartmentEquipmentFindButton);
            ApartmentsTab.Controls.Add(label2);
            ApartmentsTab.Controls.Add(ApartmentEquipmentFindTextBox);
            ApartmentsTab.Controls.Add(ApartmentNumberFindButton);
            ApartmentsTab.Controls.Add(label1);
            ApartmentsTab.Controls.Add(ApartmentNumberFindTextBox);
            ApartmentsTab.Controls.Add(DeleteApartmentButton);
            ApartmentsTab.Controls.Add(ChangeApartmentButton);
            ApartmentsTab.Controls.Add(ApartmentButton);
            ApartmentsTab.Controls.Add(AccButton);
            ApartmentsTab.Controls.Add(ApartmentsGrid);
            ApartmentsTab.Location = new Point(4, 24);
            ApartmentsTab.Margin = new Padding(3, 2, 3, 2);
            ApartmentsTab.Name = "ApartmentsTab";
            ApartmentsTab.Padding = new Padding(3, 2, 3, 2);
            ApartmentsTab.Size = new Size(651, 313);
            ApartmentsTab.TabIndex = 0;
            ApartmentsTab.Text = "Номера";
            ApartmentsTab.UseVisualStyleBackColor = true;
            // 
            // ClearApartmentsDataButton
            // 
            ClearApartmentsDataButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ClearApartmentsDataButton.Location = new Point(555, 121);
            ClearApartmentsDataButton.Name = "ClearApartmentsDataButton";
            ClearApartmentsDataButton.Size = new Size(90, 23);
            ClearApartmentsDataButton.TabIndex = 20;
            ClearApartmentsDataButton.Text = "Очистить данные";
            ClearApartmentsDataButton.UseVisualStyleBackColor = true;
            ClearApartmentsDataButton.Click += ClearApartmentsDataButton_Click;
            // 
            // ApartmentEquipmentFindButton
            // 
            ApartmentEquipmentFindButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ApartmentEquipmentFindButton.Location = new Point(314, 284);
            ApartmentEquipmentFindButton.Name = "ApartmentEquipmentFindButton";
            ApartmentEquipmentFindButton.Size = new Size(75, 23);
            ApartmentEquipmentFindButton.TabIndex = 12;
            ApartmentEquipmentFindButton.Text = "OK";
            ApartmentEquipmentFindButton.UseVisualStyleBackColor = true;
            ApartmentEquipmentFindButton.Click += ApartmentEquipmentFindButton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(206, 266);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 11;
            label2.Text = "Поиск по оборудованию";
            // 
            // ApartmentEquipmentFindTextBox
            // 
            ApartmentEquipmentFindTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ApartmentEquipmentFindTextBox.Location = new Point(208, 285);
            ApartmentEquipmentFindTextBox.Name = "ApartmentEquipmentFindTextBox";
            ApartmentEquipmentFindTextBox.Size = new Size(100, 23);
            ApartmentEquipmentFindTextBox.TabIndex = 10;
            // 
            // ApartmentNumberFindButton
            // 
            ApartmentNumberFindButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ApartmentNumberFindButton.Location = new Point(112, 284);
            ApartmentNumberFindButton.Name = "ApartmentNumberFindButton";
            ApartmentNumberFindButton.Size = new Size(75, 23);
            ApartmentNumberFindButton.TabIndex = 9;
            ApartmentNumberFindButton.Text = "OK";
            ApartmentNumberFindButton.UseVisualStyleBackColor = true;
            ApartmentNumberFindButton.Click += ApartmentNumberFindButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(4, 266);
            label1.Name = "label1";
            label1.Size = new Size(156, 15);
            label1.TabIndex = 8;
            label1.Text = "Поиск по номеру комнаты";
            // 
            // ApartmentNumberFindTextBox
            // 
            ApartmentNumberFindTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ApartmentNumberFindTextBox.Location = new Point(6, 285);
            ApartmentNumberFindTextBox.Name = "ApartmentNumberFindTextBox";
            ApartmentNumberFindTextBox.Size = new Size(100, 23);
            ApartmentNumberFindTextBox.TabIndex = 7;
            // 
            // DeleteApartmentButton
            // 
            DeleteApartmentButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteApartmentButton.Location = new Point(555, 92);
            DeleteApartmentButton.Name = "DeleteApartmentButton";
            DeleteApartmentButton.Size = new Size(90, 23);
            DeleteApartmentButton.TabIndex = 6;
            DeleteApartmentButton.Text = "Удалить";
            DeleteApartmentButton.UseVisualStyleBackColor = true;
            DeleteApartmentButton.Click += DeleteApartmentButton_Click;
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
            ApartmentsGrid.Size = new Size(549, 263);
            ApartmentsGrid.TabIndex = 0;
            // 
            // LogdersTab
            // 
            LogdersTab.Controls.Add(DeleteLodgerAccButton);
            LogdersTab.Controls.Add(CreateLodgerAccButton);
            LogdersTab.Controls.Add(LodgerClearDataButton);
            LogdersTab.Controls.Add(LodgerNameFindButton);
            LogdersTab.Controls.Add(label3);
            LogdersTab.Controls.Add(LodgerNameFindTextBox);
            LogdersTab.Controls.Add(LodgerPassportFindButton);
            LogdersTab.Controls.Add(label4);
            LogdersTab.Controls.Add(LodgerPassportFindTextBox);
            LogdersTab.Controls.Add(DeleteLodgerButton);
            LogdersTab.Controls.Add(ChanheLodgerButton);
            LogdersTab.Controls.Add(CreateLodgerButton);
            LogdersTab.Controls.Add(LodgerAccButton);
            LogdersTab.Controls.Add(LodgersGrid);
            LogdersTab.Location = new Point(4, 24);
            LogdersTab.Margin = new Padding(3, 2, 3, 2);
            LogdersTab.Name = "LogdersTab";
            LogdersTab.Padding = new Padding(3, 2, 3, 2);
            LogdersTab.Size = new Size(651, 313);
            LogdersTab.TabIndex = 1;
            LogdersTab.Text = "Постояльцы";
            LogdersTab.UseVisualStyleBackColor = true;
            // 
            // DeleteLodgerAccButton
            // 
            DeleteLodgerAccButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteLodgerAccButton.Location = new Point(555, 179);
            DeleteLodgerAccButton.Name = "DeleteLodgerAccButton";
            DeleteLodgerAccButton.Size = new Size(90, 23);
            DeleteLodgerAccButton.TabIndex = 21;
            DeleteLodgerAccButton.Text = "Выселить";
            DeleteLodgerAccButton.UseVisualStyleBackColor = true;
            DeleteLodgerAccButton.Click += DeleteLodgerAccButton_Click;
            // 
            // CreateLodgerAccButton
            // 
            CreateLodgerAccButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreateLodgerAccButton.Location = new Point(555, 150);
            CreateLodgerAccButton.Name = "CreateLodgerAccButton";
            CreateLodgerAccButton.Size = new Size(90, 23);
            CreateLodgerAccButton.TabIndex = 20;
            CreateLodgerAccButton.Text = "Заселить";
            CreateLodgerAccButton.UseVisualStyleBackColor = true;
            CreateLodgerAccButton.Click += CreateLodgerAccButton_Click;
            // 
            // LodgerClearDataButton
            // 
            LodgerClearDataButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LodgerClearDataButton.Location = new Point(555, 121);
            LodgerClearDataButton.Name = "LodgerClearDataButton";
            LodgerClearDataButton.Size = new Size(90, 23);
            LodgerClearDataButton.TabIndex = 19;
            LodgerClearDataButton.Text = "Очистить данные";
            LodgerClearDataButton.UseVisualStyleBackColor = true;
            LodgerClearDataButton.Click += LodgerClearData_Click;
            // 
            // LodgerNameFindButton
            // 
            LodgerNameFindButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LodgerNameFindButton.Location = new Point(316, 287);
            LodgerNameFindButton.Name = "LodgerNameFindButton";
            LodgerNameFindButton.Size = new Size(75, 23);
            LodgerNameFindButton.TabIndex = 18;
            LodgerNameFindButton.Text = "OK";
            LodgerNameFindButton.UseVisualStyleBackColor = true;
            LodgerNameFindButton.Click += LodgerNameFindButton_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(208, 268);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 17;
            label3.Text = "Поиск по ФИО";
            // 
            // LodgerNameFindTextBox
            // 
            LodgerNameFindTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LodgerNameFindTextBox.Location = new Point(210, 286);
            LodgerNameFindTextBox.Name = "LodgerNameFindTextBox";
            LodgerNameFindTextBox.Size = new Size(100, 23);
            LodgerNameFindTextBox.TabIndex = 16;
            // 
            // LodgerPassportFindButton
            // 
            LodgerPassportFindButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LodgerPassportFindButton.Location = new Point(114, 286);
            LodgerPassportFindButton.Name = "LodgerPassportFindButton";
            LodgerPassportFindButton.Size = new Size(75, 23);
            LodgerPassportFindButton.TabIndex = 15;
            LodgerPassportFindButton.Text = "OK";
            LodgerPassportFindButton.UseVisualStyleBackColor = true;
            LodgerPassportFindButton.Click += LodgerPassportFindButton_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(6, 268);
            label4.Name = "label4";
            label4.Size = new Size(158, 15);
            label4.TabIndex = 14;
            label4.Text = "Поиск по номеру паспорта";
            // 
            // LodgerPassportFindTextBox
            // 
            LodgerPassportFindTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LodgerPassportFindTextBox.Location = new Point(8, 286);
            LodgerPassportFindTextBox.Name = "LodgerPassportFindTextBox";
            LodgerPassportFindTextBox.Size = new Size(100, 23);
            LodgerPassportFindTextBox.TabIndex = 13;
            // 
            // DeleteLodgerButton
            // 
            DeleteLodgerButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            DeleteLodgerButton.Location = new Point(555, 92);
            DeleteLodgerButton.Name = "DeleteLodgerButton";
            DeleteLodgerButton.Size = new Size(90, 23);
            DeleteLodgerButton.TabIndex = 7;
            DeleteLodgerButton.Text = "Удалить";
            DeleteLodgerButton.UseVisualStyleBackColor = true;
            DeleteLodgerButton.Click += DeleteLodgerButton_Click;
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
            LodgersGrid.ReadOnly = true;
            LodgersGrid.RowTemplate.Height = 25;
            LodgersGrid.Size = new Size(549, 262);
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
            ClientSize = new Size(678, 350);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Hostel";
            Text = "Регистрация постояльцев в гостинице";
            Activated += Hostel_Activated;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ApartmentsTab.ResumeLayout(false);
            ApartmentsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ApartmentsGrid).EndInit();
            LogdersTab.ResumeLayout(false);
            LogdersTab.PerformLayout();
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
        private Button DeleteApartmentButton;
        private Button DeleteLodgerButton;
        private Button ApartmentNumberFindButton;
        private Label label1;
        private TextBox ApartmentNumberFindTextBox;
        private Button ApartmentEquipmentFindButton;
        private Label label2;
        private TextBox ApartmentEquipmentFindTextBox;
        private Button LodgerNameFindButton;
        private Label label3;
        private TextBox LodgerNameFindTextBox;
        private Button LodgerPassportFindButton;
        private Label label4;
        private TextBox LodgerPassportFindTextBox;
        private Button LodgerClearDataButton;
        private Button ClearApartmentsDataButton;
        private Button CreateLodgerAccButton;
        private Button DeleteLodgerAccButton;
    }
}