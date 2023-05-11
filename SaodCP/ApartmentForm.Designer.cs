namespace SaodCP
{
    partial class ApartmentForm
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
            ApartmentNumberTextBox = new TextBox();
            BedsNumberTextBox = new TextBox();
            RoomNumberTextBox = new TextBox();
            EquipmentTextBox = new TextBox();
            HasToiletCheckBox = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // ApartmentNumberCheckBox
            // 
            ApartmentNumberTextBox.Location = new Point(12, 21);
            ApartmentNumberTextBox.Name = "ApartmentNumberCheckBox";
            ApartmentNumberTextBox.Size = new Size(100, 23);
            ApartmentNumberTextBox.TabIndex = 0;
            // 
            // BedsNumberCheckBox
            // 
            BedsNumberTextBox.Location = new Point(12, 64);
            BedsNumberTextBox.Name = "BedsNumberCheckBox";
            BedsNumberTextBox.Size = new Size(100, 23);
            BedsNumberTextBox.TabIndex = 1;
            // 
            // RoomNumberTextBox
            // 
            RoomNumberTextBox.Location = new Point(12, 111);
            RoomNumberTextBox.Name = "RoomNumberTextBox";
            RoomNumberTextBox.Size = new Size(100, 23);
            RoomNumberTextBox.TabIndex = 2;
            // 
            // EquipmentTextBox
            // 
            EquipmentTextBox.Location = new Point(12, 206);
            EquipmentTextBox.Multiline = true;
            EquipmentTextBox.Name = "EquipmentTextBox";
            EquipmentTextBox.Size = new Size(322, 92);
            EquipmentTextBox.TabIndex = 3;
            // 
            // HasToiletCheckBox
            // 
            HasToiletCheckBox.AutoSize = true;
            HasToiletCheckBox.Location = new Point(15, 146);
            HasToiletCheckBox.Name = "HasToiletCheckBox";
            HasToiletCheckBox.Size = new Size(101, 19);
            HasToiletCheckBox.TabIndex = 4;
            HasToiletCheckBox.Text = "Есть сан. узел";
            HasToiletCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 2);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 5;
            label1.Text = "Код номера";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 6;
            label2.Text = "Кол-во кроватей";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 93);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 7;
            label3.Text = "Кол-во комнат";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 188);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 8;
            label4.Text = "Оборудование";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(114, 310);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(104, 23);
            SaveButton.TabIndex = 9;
            SaveButton.Text = "Сохранить";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ApartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 341);
            Controls.Add(SaveButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(HasToiletCheckBox);
            Controls.Add(EquipmentTextBox);
            Controls.Add(RoomNumberTextBox);
            Controls.Add(BedsNumberTextBox);
            Controls.Add(ApartmentNumberTextBox);
            Name = "ApartmentForm";
            Text = "Номер";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ApartmentNumberTextBox;
        private TextBox BedsNumberTextBox;
        private TextBox RoomNumberTextBox;
        private TextBox EquipmentTextBox;
        private CheckBox HasToiletCheckBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button SaveButton;
    }
}