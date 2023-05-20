namespace SaodCP
{
    partial class EditAccommodationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LodgerPassportIdTextBox = new TextBox();
            ApartmentNumberComboBox = new ComboBox();
            label1 = new Label();
            SaveAccButton = new Button();
            DateCalendar = new MonthCalendar();
            SuspendLayout();
            // 
            // LodgerPassportIdTextBox
            // 
            LodgerPassportIdTextBox.Location = new Point(12, 17);
            LodgerPassportIdTextBox.Name = "LodgerPassportIdTextBox";
            LodgerPassportIdTextBox.PlaceholderText = "Номер паспорта";
            LodgerPassportIdTextBox.Size = new Size(176, 23);
            LodgerPassportIdTextBox.TabIndex = 0;
            // 
            // ApartmentNumberComboBox
            // 
            ApartmentNumberComboBox.FormattingEnabled = true;
            ApartmentNumberComboBox.Location = new Point(15, 67);
            ApartmentNumberComboBox.Name = "ApartmentNumberComboBox";
            ApartmentNumberComboBox.Size = new Size(172, 23);
            ApartmentNumberComboBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 47);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 2;
            label1.Text = "Код номера";
            // 
            // SaveAccButton
            // 
            SaveAccButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SaveAccButton.Location = new Point(98, 281);
            SaveAccButton.Name = "SaveAccButton";
            SaveAccButton.Size = new Size(81, 23);
            SaveAccButton.TabIndex = 3;
            SaveAccButton.Text = "Сохранить";
            SaveAccButton.UseVisualStyleBackColor = true;
            SaveAccButton.Click += SaveAccButton_Click;
            // 
            // DateCalendar
            // 
            DateCalendar.Location = new Point(15, 102);
            DateCalendar.MaxSelectionCount = 1;
            DateCalendar.Name = "DateCalendar";
            DateCalendar.TabIndex = 4;
            // 
            // EditAccommodationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 316);
            Controls.Add(DateCalendar);
            Controls.Add(SaveAccButton);
            Controls.Add(label1);
            Controls.Add(ApartmentNumberComboBox);
            Controls.Add(LodgerPassportIdTextBox);
            Name = "EditAccommodationForm";
            Text = "Заселение";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LodgerPassportIdTextBox;
        private ComboBox ApartmentNumberComboBox;
        private Label label1;
        private Button SaveAccButton;
        private MonthCalendar DateCalendar;
    }
}