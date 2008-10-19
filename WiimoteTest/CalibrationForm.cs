using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WiimoteWhiteboard
{
    public partial class CalibrationForm : Form
    {

        Bitmap bCalibration;
        Graphics gCalibration;

        int screenWidth = 1024;//defaults
        int screenHeight = 768;
        
        public CalibrationForm()
        {
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Left = 0;
            this.Top = 0;
            this.Size = new Size(rect.Width, rect.Height);
            this.Text = "Calibration - Working area:" + Screen.GetWorkingArea(this).ToString() + " || Real area: " + Screen.GetBounds(this).ToString();

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyPress);

            
            screenHeight = rect.Height;
            screenWidth = rect.Width;

            bCalibration = new Bitmap(screenWidth, screenHeight, PixelFormat.Format24bppRgb);
            gCalibration = Graphics.FromImage(bCalibration);
            pbCalibrate.Left = 0;
            pbCalibrate.Top = 0;
            pbCalibrate.Size = new Size(rect.Width, rect.Height);
            
            gCalibration.Clear(Color.White);

            BeginInvoke((MethodInvoker)delegate() { pbCalibrate.Image = bCalibration; });
        }

        private void OnKeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((int)(byte)e.KeyCode == (int)Keys.Escape)
            {
                this.Dispose(); // Esc was pressed
                return;
            }
        }

        public void drawCrosshair(int x, int y, int size, Pen p, Graphics g){
            g.DrawEllipse(p, x - size / 2, y - size / 2, size, size);
            g.DrawLine(p, x-size, y, x+size, y);
            g.DrawLine(p, x, y-size, x, y+size);
        }

        public void showCalibration(int x, int y, int size, Pen p){
            gCalibration.Clear(Color.White);
            drawCrosshair(x,y,size, p, gCalibration);
            BeginInvoke((MethodInvoker)delegate() { pbCalibrate.Image = bCalibration; });

        }
    }
}