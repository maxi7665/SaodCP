namespace SaodCP
{
    partial class LodgerForm
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
            label1 = new Label();
            PassportTextBox = new TextBox();
            label2 = new Label();
            NameTextBox = new TextBox();
            label3 = new Label();
            BirhdayTextBox = new TextBox();
            label4 = new Label();
            AddressTextBox = new TextBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Номер паспорта";
            // 
            // PassportTextBox
            // 
            PassportTextBox.Location = new Point(16, 27);
            PassportTextBox.MaxLength = 11;
            PassportTextBox.Name = "PassportTextBox";
            PassportTextBox.Size = new Size(136, 23);
            PassportTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 58);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 2;
            label2.Text = "Имя";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(18, 75);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(242, 23);
            NameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 108);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 4;
            label3.Text = "Год рождения";
            // 
            // BirhdayTextBox
            // 
            BirhdayTextBox.Location = new Point(19, 126);
            BirhdayTextBox.MaxLength = 4;
            BirhdayTextBox.Name = "BirhdayTextBox";
            BirhdayTextBox.Size = new Size(133, 23);
            BirhdayTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 157);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 6;
            label4.Text = "Адрес";
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(21, 175);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(239, 23);
            AddressTextBox.TabIndex = 7;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(108, 206);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 8;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // LodgerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 241);
            Controls.Add(SaveButton);
            Controls.Add(AddressTextBox);
            Controls.Add(label4);
            Controls.Add(BirhdayTextBox);
            Controls.Add(label3);
            Controls.Add(NameTextBox);
            Controls.Add(label2);
            Controls.Add(PassportTextBox);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LodgerForm";
            Text = "Постоялец";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox PassportTextBox;
        private Label label2;
        private TextBox NameTextBox;
        private Label label3;
        private TextBox BirhdayTextBox;
        private Label label4;
        private TextBox AddressTextBox;
        private Button SaveButton;
    }
}