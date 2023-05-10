namespace SaodCP
{
    partial class AccommodationForm
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
            AccommodationGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)AccommodationGrid).BeginInit();
            SuspendLayout();
            // 
            // AccommodationGrid
            // 
            AccommodationGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AccommodationGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AccommodationGrid.Location = new Point(12, 12);
            AccommodationGrid.Name = "AccommodationGrid";
            AccommodationGrid.RowTemplate.Height = 25;
            AccommodationGrid.Size = new Size(776, 426);
            AccommodationGrid.TabIndex = 0;
            // 
            // AccommodationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AccommodationGrid);
            Name = "AccommodationForm";
            Text = "AccommodationForm";
            Load += AccommodationForm_Load;
            ((System.ComponentModel.ISupportInitialize)AccommodationGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView AccommodationGrid;
    }
}