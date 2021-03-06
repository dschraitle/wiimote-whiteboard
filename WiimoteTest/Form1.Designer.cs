namespace WiimoteWhiteboard
{
	partial class Form1
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
            this.pbBattery = new System.Windows.Forms.ProgressBar();
            this.lblBattery = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbBattery2 = new System.Windows.Forms.ProgressBar();
            this.lblBattery2 = new System.Windows.Forms.Label();
            this.cbCursorControl = new System.Windows.Forms.CheckBox();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.lblIRvisible = new System.Windows.Forms.Label();
            this.lblTrackingUtil = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.custombutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblSmoothing = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mousebtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.speedbox = new System.Windows.Forms.NumericUpDown();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBattery
            // 
            this.pbBattery.Location = new System.Drawing.Point(16, 20);
            this.pbBattery.Maximum = 200;
            this.pbBattery.Name = "pbBattery";
            this.pbBattery.Size = new System.Drawing.Size(64, 23);
            this.pbBattery.Step = 1;
            this.pbBattery.TabIndex = 6;
            // 
            // lblBattery
            // 
            this.lblBattery.AutoSize = true;
            this.lblBattery.Location = new System.Drawing.Point(83, 20);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(35, 13);
            this.lblBattery.TabIndex = 9;
            this.lblBattery.Text = "label1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.pbBattery2);
            this.groupBox4.Controls.Add(this.lblBattery2);
            this.groupBox4.Controls.Add(this.pbBattery);
            this.groupBox4.Controls.Add(this.lblBattery);
            this.groupBox4.Location = new System.Drawing.Point(10, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(121, 76);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Wiimote Battery";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "1";
            // 
            // pbBattery2
            // 
            this.pbBattery2.Location = new System.Drawing.Point(16, 49);
            this.pbBattery2.Maximum = 200;
            this.pbBattery2.Name = "pbBattery2";
            this.pbBattery2.Size = new System.Drawing.Size(64, 23);
            this.pbBattery2.Step = 1;
            this.pbBattery2.TabIndex = 10;
            // 
            // lblBattery2
            // 
            this.lblBattery2.AutoSize = true;
            this.lblBattery2.Location = new System.Drawing.Point(83, 49);
            this.lblBattery2.Name = "lblBattery2";
            this.lblBattery2.Size = new System.Drawing.Size(35, 13);
            this.lblBattery2.TabIndex = 11;
            this.lblBattery2.Text = "label1";
            // 
            // cbCursorControl
            // 
            this.cbCursorControl.AutoSize = true;
            this.cbCursorControl.Location = new System.Drawing.Point(155, 9);
            this.cbCursorControl.Margin = new System.Windows.Forms.Padding(2);
            this.cbCursorControl.Name = "cbCursorControl";
            this.cbCursorControl.Size = new System.Drawing.Size(92, 17);
            this.cbCursorControl.TabIndex = 22;
            this.cbCursorControl.Text = "Cursor Control";
            this.cbCursorControl.UseVisualStyleBackColor = true;
            this.cbCursorControl.CheckedChanged += new System.EventHandler(this.cbCursorControl_CheckedChanged);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(150, 102);
            this.btnCalibrate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(121, 52);
            this.btnCalibrate.TabIndex = 24;
            this.btnCalibrate.Text = "Calibrate Location (Wiimote A)";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // lblIRvisible
            // 
            this.lblIRvisible.AutoSize = true;
            this.lblIRvisible.Location = new System.Drawing.Point(7, 90);
            this.lblIRvisible.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIRvisible.Name = "lblIRvisible";
            this.lblIRvisible.Size = new System.Drawing.Size(80, 13);
            this.lblIRvisible.TabIndex = 25;
            this.lblIRvisible.Text = "Visible IR dots: ";
            // 
            // lblTrackingUtil
            // 
            this.lblTrackingUtil.AutoSize = true;
            this.lblTrackingUtil.Location = new System.Drawing.Point(7, 111);
            this.lblTrackingUtil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTrackingUtil.Name = "lblTrackingUtil";
            this.lblTrackingUtil.Size = new System.Drawing.Size(109, 13);
            this.lblTrackingUtil.TabIndex = 26;
            this.lblTrackingUtil.Text = "Tracking Utilization: --";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(5, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(85, 17);
            this.checkBox3.TabIndex = 29;
            this.checkBox3.Text = "2nd Wiimote";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // custombutton
            // 
            this.custombutton.Location = new System.Drawing.Point(22, 35);
            this.custombutton.Name = "custombutton";
            this.custombutton.Size = new System.Drawing.Size(75, 23);
            this.custombutton.TabIndex = 44;
            this.custombutton.Text = "Buttons";
            this.custombutton.UseVisualStyleBackColor = true;
            this.custombutton.Click += new System.EventHandler(this.custombutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.custombutton);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Location = new System.Drawing.Point(150, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 66);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2nd Wiimote";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 151);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 51;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lblSmoothing
            // 
            this.lblSmoothing.AutoSize = true;
            this.lblSmoothing.Location = new System.Drawing.Point(18, 135);
            this.lblSmoothing.Name = "lblSmoothing";
            this.lblSmoothing.Size = new System.Drawing.Size(63, 13);
            this.lblSmoothing.TabIndex = 52;
            this.lblSmoothing.Text = "Smoothing: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 53;
            // 
            // mousebtn
            // 
            this.mousebtn.Location = new System.Drawing.Point(116, 159);
            this.mousebtn.Name = "mousebtn";
            this.mousebtn.Size = new System.Drawing.Size(75, 23);
            this.mousebtn.TabIndex = 54;
            this.mousebtn.Text = "WiiMouse";
            this.mousebtn.UseVisualStyleBackColor = true;
            this.mousebtn.Click += new System.EventHandler(this.mousebtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Speed:";
            // 
            // speedbox
            // 
            this.speedbox.Location = new System.Drawing.Point(240, 157);
            this.speedbox.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.speedbox.Name = "speedbox";
            this.speedbox.Size = new System.Drawing.Size(35, 20);
            this.speedbox.TabIndex = 57;
            this.speedbox.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 194);
            this.Controls.Add(this.speedbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mousebtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSmoothing);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTrackingUtil);
            this.Controls.Add(this.lblIRvisible);
            this.Controls.Add(this.btnCalibrate);
            this.Controls.Add(this.cbCursorControl);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wiimote Whiteboard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ProgressBar pbBattery;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbCursorControl;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Label lblIRvisible;
        private System.Windows.Forms.Label lblTrackingUtil;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbBattery2;
        private System.Windows.Forms.Label lblBattery2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button custombutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblSmoothing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button mousebtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown speedbox;
	}
}

