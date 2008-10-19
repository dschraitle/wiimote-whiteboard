namespace WiimoteWhiteboard
{
    partial class CalibrationForm
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
            this.pbCalibrate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCalibrate)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCalibrate
            // 
            this.pbCalibrate.Location = new System.Drawing.Point(88, 77);
            this.pbCalibrate.Name = "pbCalibrate";
            this.pbCalibrate.Size = new System.Drawing.Size(100, 50);
            this.pbCalibrate.TabIndex = 0;
            this.pbCalibrate.TabStop = false;
            // 
            // CalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 260);
            this.Controls.Add(this.pbCalibrate);
            this.Name = "CalibrationForm";
            this.Text = "CalibrationForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbCalibrate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCalibrate;
    }
}