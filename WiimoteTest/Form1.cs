using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;//for firing keyboard and mouse events (optional)
using System.IO;//for saving the reading the calibration data
using System.Windows;


using WiimoteLib;

namespace WiimoteWhiteboard
{
	public partial class Form1 : Form
	{
        //instance of the wii remote
		Wiimote wm;
        Wiimote remote2;
        List<Wiimote> wms = Wiimote.GetConnectedWiimotes();

        bool secondwiimote;
        bool cursorControl = false;

        const int smoothingBufferSize = 50;

        PointF[] smoothingBuffer = new PointF[smoothingBufferSize];
        int smoothingBufferIndex = 0;
        int smoothingAmount = 4;
        bool enableSmoothing = true;

        int screenWidth = 1024;//defaults, gets replaced by actual screen size
        int screenHeight = 768;

        int calibrationState = 0;
        float calibrationMargin = .1f;

        CalibrationForm cf = null;

        Warper warper = new Warper();
        float[] srcX = new float[4];
        float[] srcY = new float[4];
        float[] dstX = new float[4];
        float[] dstY = new float[4];

        #region constants
        //declare consts for mouse messages
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;

        public const int MOUSEEVENTF_MOVE = 0x01;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        public const int MOUSEEVENTF_MIDDLEUP = 0x40;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;


        public const int APPCOMMAND_VOLUME_MUTE = 524288;
        public const int APPCOMMAND_VOLUME_DOWN = 589824;
        public const int APPCOMMAND_VOLUME_UP = 655360;
        public const int APPCOMMAND_MEDIA_NEXTTRACK = 720896;
        public const int APPCOMMAND_MEDIA_PREVIOUSTRACK = 786432;
        public const int APPCOMMAND_MEDIA_PLAY = 3014656;
        public const int APPCOMMAND_MEDIA_PAUSE = 3080192;
        public const int APPCOMMAND_MEDIA_STOP = 851968;
        public const int APPCOMMAND_MEDIA_PLAY_PAUSE = 917504;
        public const int APPCOMMAND_BROWSER_BACKWARD = 65536;
        public const int APPCOMMAND_BROWSER_FORWARD = 131072;
        public const int APPCOMMAND_BROWSER_REFRESH = 196608;
        public const int WM_APPCOMMAND = 0x0319;
        public const int HWND_BROADCAST = 0xFFFF;
        //declare consts for virtual key scan codes http://msdn.microsoft.com/en-us/library/ms927178.aspx
        public const byte VK_LBUTTON = 0x01;
        public const byte VK_RBUTTON = 0x02;
        public const byte VK_CANCEL = 0x03;
        public const byte VK_MBUTTON = 0x04;
        public const byte VK_BACK = 0x08;
        public const byte VK_TAB = 0x09;
        public const byte VK_CLEAR = 0x0C;
        public const byte VK_RETURN = 0x0D;
        public const byte VK_SHIFT = 0x10;
        public const byte VK_CONTROL = 0x11;
        public const byte VK_MENU = 0x12;
        public const byte VK_PAUSE = 0x13;
        public const byte VK_CAPITAL = 0x14;
        public const byte VK_ESCAPE = 0x1B;
        public const byte VK_SPACE = 0x20;
        public const byte VK_PRIOR = 0x21;
        public const byte VK_NEXT = 0x22;
        public const byte VK_END = 0x23;
        public const byte VK_HOME = 0x24;
        public const byte VK_LEFT = 0x25;
        public const byte VK_UP = 0x26;
        public const byte VK_RIGHT = 0x27;
        public const byte VK_DOWN = 0x28;
        public const byte VK_SELECT = 0x29;
        public const byte VK_EXECUTE = 0x2B;
        public const byte VK_SNAPSHOT = 0x2C;
        public const byte VK_INS = 0x2D;
        public const byte VK_DELETE = 0x2E;
        public const byte VK_HELP = 0x2F;
        public const byte VK_LWIN = 0x5B;
        public const byte VK_RWIN = 0x5C;
        public const byte VK_APPS = 0x5D;
        public const byte VK_NUMLOCK = 0x90;
        public const byte VK_SCROLL = 0x91;
        public const byte VK_LSHIFT = 0xA0;
        public const byte VK_RSHIFT = 0xA1;
        public const byte VK_LCONTROL = 0xA2;
        public const byte VK_RCONTROL = 0xA3;
        public const byte VK_LMENU = 0xA4;
        public const byte VK_RMENU = 0xA5;
        public const int KEYEVENTF_EXTENDEDKEY = 0x01;
        public const int KEYEVENTF_KEYUP = 0x02;
        #endregion

        #region keyboard/mouse stuff
        //for firing mouse and keyboard events
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;//4
            public int dy;//4
            public uint mouseData;//4
            public uint dwFlags;//4
            public uint time;//4
            public IntPtr dwExtraInfo;//4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;//2
            public ushort wScan;//2
            public uint dwFlags;//4
            public uint time;//4
            public IntPtr dwExtraInfo;//4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)] //*
            public MOUSEINPUT mi;
            [FieldOffset(4)] //*
            public KEYBDINPUT ki;
            [FieldOffset(4)] //*
            public HARDWAREINPUT hi;
        }
        //imports mouse_event function from user32.dll

        [DllImport("user32.dll")]
        private static extern void mouse_event(
        long dwFlags, // motion and click options
        long dx, // horizontal position or change
        long dy, // vertical position or change
        long dwData, // wheel movement
        long dwExtraInfo // application-defined information
        );

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int X, int Y);

        //imports keybd_event function from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void keybd_event(byte bVk, byte bScan, long dwFlags, long dwExtraInfo);
        #endregion
        WiimoteState lastWiiState = new WiimoteState();//helps with event firing
        WiimoteState lastWiiState2 = new WiimoteState();

        int mouseclickd = MOUSEEVENTF_LEFTDOWN;
        int mouseclicku = MOUSEEVENTF_LEFTUP;
        int numclicks = 1;

        bool ledsfound = false;
        bool clicked = false;
        bool shifting;
        bool[] done;
        //end keyboard and mouse input emulation variables----------------------------------------

        public Form2 form2;
        Mutex mut = new Mutex();
        const int ACCELDATA = 50;
        byte[] xaccel = new byte[ACCELDATA];
        byte[] yaccel = new byte[ACCELDATA];
        byte[] zaccel = new byte[ACCELDATA];
        public string motions = "";
        public bool mouse = false;
        int speed = 15;
        int smoothing;

		public Form1()
		{
            screenWidth = Screen.GetBounds(this).Width;
            screenHeight = Screen.GetBounds(this).Height;
            InitializeComponent();

            for (int i = 0; i < smoothingBufferSize; i++)
                smoothingBuffer[i] = new PointF();

            setSmoothing(smoothingAmount);
            form2 = new Form2();
            form2.Location = new Point(this.Location.X + 149, this.Location.Y);
		}

		private void Form1_Load(object sender, EventArgs e)
		{          
            wm = wms[0];
            if (wms.Count > 1)
            {
                checkBox3.Checked = true;
                remote2 = wms[1];
                remote2.WiimoteChanged += new WiimoteChangedEventHandler(remote2_OnWiimoteChanged);
            }
            lblBattery2.Text = "---";
            //add event listeners to changes in the wiiremote
            //fired for every input report - usually 100 times per second if acclerometer is enabled
			wm.WiimoteChanged += new WiimoteChangedEventHandler(wm_OnWiimoteChanged); 
            //fired when the extension is attached on unplugged
			wm.WiimoteExtensionChanged += new WiimoteExtensionChangedEventHandler(wm_OnWiimoteExtensionChanged);
             
         
            try
            {
                //connect to wii remote

                ////set what features you want to enable for the remote, look at Wiimote.InputReport for options
                wm.SetReportType(Wiimote.InputReport.IRAccel, true);
                
                
                //set wiiremote LEDs with this enumerated ID
                wm.SetLEDs(true, false, false, false);

                if (wms.Count > 1)
                {
                    ////set what features you want to enable for the remote, look at Wiimote.InputReport for options
                    remote2.SetReportType(Wiimote.InputReport.IRAccel, true);
                    //set wiiremote LEDs with this enumerated ID
                    remote2.SetLEDs(false, true, false, false);
                }

                
            }
            catch (Exception x)
            {
                MessageBox.Show("Exception: " + x.Message);
                //this.Close();
            }
            loadCalibrationData();
            done = new bool[Form2.NUMBOXES];
            for (int i = 0; i < Form2.NUMBOXES - 1; i++) done[i] = false;
		}

        PointF getSmoothedCursor(int amount)
        {
            int start = smoothingBufferIndex - amount;
            if (start < 0)
                start = 0;
            PointF smoothed = new PointF(0, 0);
            int count = smoothingBufferIndex - start;
            for (int i = start; i < smoothingBufferIndex; i++)
            {
                smoothed.X += smoothingBuffer[i % smoothingBufferSize].X;
                smoothed.Y += smoothingBuffer[i % smoothingBufferSize].Y;
            }
            smoothed.X /= count;
            smoothed.Y /= count;
            return smoothed;
        }

		void wm_OnWiimoteExtensionChanged(object sender, WiimoteExtensionChangedEventArgs args)
		{

            //if extension attached, enable it
			if(args.Inserted)
				wm.SetReportType(Wiimote.InputReport.IRExtensionAccel, true);
			else
				wm.SetReportType(Wiimote.InputReport.IRAccel, true);
		}

        float UpdateTrackingUtilization()
        {
            //area of ideal calibration coordinates (to match the screen)
            float idealArea = (1 - 2*calibrationMargin) * 1024 * (1 - 2*calibrationMargin) * 768;
            
            //area of quadrliatera
            float actualArea = 0.5f * Math.Abs((srcX[1] - srcX[2]) * (srcY[0] - srcY[3]) - (srcX[0] - srcX[3]) * (srcY[1] - srcY[2]));
            float util = (actualArea / idealArea)*100;
            String utilstatus = "Tracking Utilization: " + util.ToString("f0")+"%";

            BeginInvoke((MethodInvoker)delegate() { lblTrackingUtil.Text = utilstatus; });
            return util;

        }

		void wm_OnWiimoteChanged(object sender, WiimoteChangedEventArgs args)
		{
            mut.WaitOne();
            ledsfound = false;
            //extract the wiimote state
            WiimoteState ws = args.WiimoteState;
            if (mouse)
            {
                double doublex = Math.Round(Convert.ToDouble(ws.NunchukState.X * (int)speedbox.Value), 0);
                double doubley = Math.Round(Convert.ToDouble(ws.NunchukState.Y * -1 * (int)speedbox.Value), 0);
                int X = int.Parse(doublex.ToString());
                int Y = int.Parse(doubley.ToString());
                Cursor.Position = new Point(Cursor.Position.X + X, Cursor.Position.Y + Y);

                if (!lastWiiState.NunchukState.Z && ws.NunchukState.Z)
                    mouse_event(mouseclickd, X, Y, 0, 0);
                if (lastWiiState.NunchukState.Z && !ws.NunchukState.Z)
                    mouse_event(mouseclicku, X, Y, 0, 0);
                lastWiiState.NunchukState.Z = ws.NunchukState.Z;

                if (!lastWiiState.NunchukState.C && ws.NunchukState.C)
                {
                    speed = (int)speedbox.Value;
                    speedbox.Value = speedbox.Value / 3;
                }
                if (lastWiiState.NunchukState.C && !ws.NunchukState.C)
                    speedbox.Value = speed;
                lastWiiState.NunchukState.C = ws.NunchukState.C;

                if (!lastWiiState2.ButtonState.A && ws.ButtonState.A)
                    translate(form2.regitems[1], true, 1);
                if (lastWiiState2.ButtonState.A && !ws.ButtonState.A)
                {
                    translate(form2.regitems[1], false, 1);
                    translate(form2.shiftitems[1], false, 1);
                }
                lastWiiState2.ButtonState.A = ws.ButtonState.A;
            }
            else
            {
                ledsfound = ws.IRState.Found1;
                int i = 0;
                do
                {
                    if (ws.IRState.Found1)
                    {
                        int x = ws.IRState.RawX1;
                        int y = ws.IRState.RawY1;
                        float warpedX = x;
                        float warpedY = y;
                        warper.warp(x, y, ref warpedX, ref warpedY);

                        smoothingBuffer[smoothingBufferIndex % smoothingBufferSize].X = warpedX;
                        smoothingBuffer[smoothingBufferIndex % smoothingBufferSize].Y = warpedY;
                        smoothingBufferIndex++;

                        if (!lastWiiState.IRState.Found1)//mouse down
                        {
                            lastWiiState.IRState.Found1 = ws.IRState.Found1;
                            smoothingBufferIndex = 0;//resets the count

                            if (cursorControl)
                            {
                                INPUT[] buffer = new INPUT[2];
                                buffer[0].type = INPUT_MOUSE;
                                buffer[0].mi.dx = (int)(warpedX * 65535.0f / screenWidth);
                                buffer[0].mi.dy = (int)(warpedY * 65535.0f / screenHeight);
                                buffer[0].mi.mouseData = 0;
                                buffer[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
                                buffer[0].mi.time = 0;
                                buffer[0].mi.dwExtraInfo = (IntPtr)0;

                                buffer[1].type = INPUT_MOUSE;
                                buffer[1].mi.dx = 0;
                                buffer[1].mi.dy = 0;
                                buffer[1].mi.mouseData = 0;
                                buffer[1].mi.dwFlags = (uint)mouseclickd;
                                buffer[1].mi.time = 1;
                                buffer[1].mi.dwExtraInfo = (IntPtr)0;

                                SendInput(2, buffer, Marshal.SizeOf(buffer[0]));

                            }//cusor control

                            switch (calibrationState)
                            {
                                case 1:
                                    srcX[calibrationState - 1] = x;
                                    srcY[calibrationState - 1] = y;
                                    calibrationState = 2;
                                    doCalibration();
                                    break;
                                case 2:
                                    srcX[calibrationState - 1] = x;
                                    srcY[calibrationState - 1] = y;
                                    calibrationState = 3;
                                    doCalibration();
                                    break;
                                case 3:
                                    srcX[calibrationState - 1] = x;
                                    srcY[calibrationState - 1] = y;
                                    calibrationState = 4;
                                    doCalibration();
                                    break;
                                case 4:
                                    srcX[calibrationState - 1] = x;
                                    srcY[calibrationState - 1] = y;
                                    calibrationState = 5;
                                    doCalibration();
                                    break;
                                default:
                                    break;
                            }//calibtation state
                        }//mouse down                
                        else
                        {
                            if (cursorControl)//dragging
                            {
                                INPUT[] buffer = new INPUT[1];
                                buffer[0].type = INPUT_MOUSE;
                                if (enableSmoothing)
                                {
                                    PointF s = getSmoothedCursor(smoothingAmount);
                                    buffer[0].mi.dx = (int)(s.X * 65535.0f / screenWidth);
                                    buffer[0].mi.dy = (int)(s.Y * 65535.0f / screenHeight);
                                }
                                else
                                {
                                    buffer[0].mi.dx = (int)(warpedX * 65535.0f / screenWidth);
                                    buffer[0].mi.dy = (int)(warpedY * 65535.0f / screenHeight);
                                }
                                buffer[0].mi.mouseData = 0;
                                buffer[0].mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;
                                buffer[0].mi.time = 0;
                                buffer[0].mi.dwExtraInfo = (IntPtr)0;
                                SendInput(1, buffer, Marshal.SizeOf(buffer[0]));
                            }
                        }
                    }//ir visible

                    else
                    {
                        if (lastWiiState.IRState.Found1)//mouse up
                        {
                            lastWiiState.IRState.Found1 = ws.IRState.Found1;
                            if (cursorControl)
                            {
                                INPUT[] buffer = new INPUT[2];
                                buffer[0].type = INPUT_MOUSE;
                                buffer[0].mi.dx = 0;
                                buffer[0].mi.dy = 0;
                                buffer[0].mi.mouseData = 0;
                                buffer[0].mi.dwFlags = (uint)mouseclicku;
                                buffer[0].mi.time = 0;
                                buffer[0].mi.dwExtraInfo = (IntPtr)0;

                                buffer[1].type = INPUT_MOUSE;
                                buffer[1].mi.dx = 0;
                                buffer[1].mi.dy = 0;
                                buffer[1].mi.mouseData = 0;
                                buffer[1].mi.dwFlags = MOUSEEVENTF_MOVE;
                                buffer[1].mi.time = 0;
                                buffer[1].mi.dwExtraInfo = (IntPtr)0;

                                SendInput(1, buffer, Marshal.SizeOf(buffer[0]));

                            }
                        }//ir lost
                    }
                    i++;
                    if (i < numclicks && ledsfound)
                    {
                        lastWiiState.IRState.Found1 = !ws.IRState.Found1;
                    }
                } while (i < numclicks);//numclicks must be 4 in order for a double click (down/up/down/up)
                if (numclicks > 1 && ledsfound)
                {
                    numclicks = 1;
                    clicked = true;
                }
                if (!lastWiiState.ButtonState.A && ws.ButtonState.A)
                {
                    BeginInvoke((MethodInvoker)delegate() { btnCalibrate.PerformClick(); });
                }
                lastWiiState.ButtonState.A = ws.ButtonState.A;

                if (!lastWiiState.ButtonState.B && ws.ButtonState.B)
                    keybd_event(VK_SPACE, 0x45, 0, 0);
                if (lastWiiState.ButtonState.B && !ws.ButtonState.B)
                    keybd_event(VK_SPACE, 0x45, KEYEVENTF_KEYUP, 0);
                lastWiiState.ButtonState.B = ws.ButtonState.B;

                if (!lastWiiState.ButtonState.Up && ws.ButtonState.Up)
                    keybd_event(VK_UP, 0x45, 0, 0);
                if (lastWiiState.ButtonState.Up && !ws.ButtonState.Up)
                    keybd_event(VK_UP, 0x45, KEYEVENTF_KEYUP, 0);
                lastWiiState.ButtonState.Up = ws.ButtonState.Up;

                if (!lastWiiState.ButtonState.Down && ws.ButtonState.Down)
                    keybd_event(VK_DOWN, 0x45, 0, 0);
                if (lastWiiState.ButtonState.Down && !ws.ButtonState.Down)
                    keybd_event(VK_DOWN, 0x45, KEYEVENTF_KEYUP, 0);
                lastWiiState.ButtonState.Down = ws.ButtonState.Down;

                if (!lastWiiState.ButtonState.Left && ws.ButtonState.Left)
                    keybd_event(VK_LEFT, 0x45, 0, 0);
                if (lastWiiState.ButtonState.Left && !ws.ButtonState.Left)
                    keybd_event(VK_LEFT, 0x45, KEYEVENTF_KEYUP, 0);
                lastWiiState.ButtonState.Left = ws.ButtonState.Left;

                if (!lastWiiState.ButtonState.Right && ws.ButtonState.Right)
                    keybd_event(VK_RIGHT, 0x45, 0, 0);
                if (lastWiiState.ButtonState.Right && !ws.ButtonState.Right)
                    keybd_event(VK_RIGHT, 0x45, KEYEVENTF_KEYUP, 0);
                lastWiiState.ButtonState.Right = ws.ButtonState.Right;


                lastWiiState.IRState.Found1 = ws.IRState.Found1;
                lastWiiState.IRState.RawX1 = ws.IRState.RawX1;
                lastWiiState.IRState.RawY1 = ws.IRState.RawY1;
                lastWiiState.IRState.Found2 = ws.IRState.Found2;
                lastWiiState.IRState.RawX2 = ws.IRState.RawX2;
                lastWiiState.IRState.RawY2 = ws.IRState.RawY2;
                lastWiiState.IRState.Found3 = ws.IRState.Found3;
                lastWiiState.IRState.RawX3 = ws.IRState.RawX3;
                lastWiiState.IRState.RawY3 = ws.IRState.RawY3;
                lastWiiState.IRState.Found4 = ws.IRState.Found4;
                lastWiiState.IRState.RawX4 = ws.IRState.RawX4;
                lastWiiState.IRState.RawY4 = ws.IRState.RawY4;

                //draw battery value on GUI
                BeginInvoke((MethodInvoker)delegate() { pbBattery.Value = (ws.Battery > 0xc8 ? 0xc8 : (int)ws.Battery); });
                float f = (((100.0f * 48.0f * (float)(ws.Battery / 48.0f))) / 192.0f);
                BeginInvoke((MethodInvoker)delegate() { lblBattery.Text = f.ToString("F"); });

                //check the GUI check boxes if the IR dots are visible
                String irstatus = "Visible IR dots: ";
                if (ws.IRState.Found1)
                    irstatus += "1 ";
                if (ws.IRState.Found2)
                    irstatus += "2 ";
                if (ws.IRState.Found3)
                    irstatus += "3 ";
                if (ws.IRState.Found4)
                    irstatus += "4 ";

                BeginInvoke((MethodInvoker)delegate() { lblIRvisible.Text = irstatus; });
            }

            mut.ReleaseMutex();        
        }

        void remote2_OnWiimoteChanged(object sender, WiimoteChangedEventArgs args)
		{ 
            
            if (secondwiimote)
            {
                mut.WaitOne();
                
                //extract the wiimote state
                WiimoteState ws = args.WiimoteState;

                //draw battery value on GUI
                for (int i = ACCELDATA - 2; i >= 0; i--)
                {
                    xaccel[i + 1] = xaccel[i];
                    yaccel[i + 1] = yaccel[i];
                    zaccel[i + 1] = zaccel[i];
                }
                xaccel[0] = ws.AccelState.RawX;
                yaccel[0] = ws.AccelState.RawY;
                zaccel[0] = ws.AccelState.RawZ;
                xlbl.Text = ws.AccelState.X.ToString();
                ylbl.Text = ws.AccelState.Y.ToString();
                zlbl.Text = ws.AccelState.Z.ToString();
                if (form2.recording || form2.gesturing)
                {
                    form2.checkbump(ref xaccel, "X");
                    form2.checkbump(ref yaccel, "Y");
                    form2.checkbump(ref zaccel, "Z");
                }
                BeginInvoke((MethodInvoker)delegate() { pbBattery2.Value = (ws.Battery > 0xc8 ? 0xc8 : (int)ws.Battery); });
                float f = (((100.0f * 48.0f * (float)(ws.Battery / 48.0f))) / 192.0f);
                BeginInvoke((MethodInvoker)delegate() { lblBattery2.Text = f.ToString("F"); });

                
                //when shift button is pressed, perform these functions
                if (ws.ButtonState.B)
                {
                    shifting = true;
                    setclick(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
                    if (ws.ButtonState.A) { if (!done[1]) translate(form2.shiftitems[1], true, 1); }
                    else if (ws.ButtonState.Up) { if (!done[2]) translate(form2.shiftitems[2], true, 2); }
                    else if (ws.ButtonState.Down) { if (!done[3]) translate(form2.shiftitems[3], true, 3); }
                    else if (ws.ButtonState.Left) { if (!done[4]) translate(form2.shiftitems[4], true, 4); }
                    else if (ws.ButtonState.Right) { if (!done[5]) translate(form2.shiftitems[5], true, 5); }
                    else if (ws.ButtonState.Home) { if (!done[6]) translate(form2.shiftitems[6], true, 6); }
                    else if (ws.ButtonState.Minus) { if (!done[7]) translate(form2.shiftitems[7], true, 7); }
                    else if (ws.ButtonState.Plus) { if (!done[8]) translate(form2.shiftitems[8], true, 8); }
                    else if (ws.ButtonState.One) { if (!done[9]) translate(form2.shiftitems[9], true, 9); }
                    else if (ws.ButtonState.Two) { if (!done[10]) translate(form2.shiftitems[10], true, 10); }
                    else setclick(MOUSEEVENTF_RIGHTDOWN, MOUSEEVENTF_RIGHTUP);
                    shifting = false;
                }
                else    //b button will right click when only it is held down
                {
                    if (lastWiiState2.ButtonState.B && !ws.ButtonState.B)
                        setclick(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP);
                }
                lastWiiState2.ButtonState.B = ws.ButtonState.B;

                //when the regular buttons are pressed and released, these functions will be performed
                if (!lastWiiState2.ButtonState.A && ws.ButtonState.A && !ws.ButtonState.B)
                    translate(form2.regitems[1], true, 1);
                if (lastWiiState2.ButtonState.A && !ws.ButtonState.A)
                {
                    translate(form2.regitems[1], false, 1);
                    translate(form2.shiftitems[1], false, 1);
                }
                lastWiiState2.ButtonState.A = ws.ButtonState.A;

                if (!lastWiiState2.ButtonState.Up && ws.ButtonState.Up && !ws.ButtonState.B)
                    translate(form2.regitems[2], true, 2);
                if (lastWiiState2.ButtonState.Up && !ws.ButtonState.Up)
                {
                    translate(form2.regitems[2], false, 2);
                    translate(form2.shiftitems[2], false, 2);
                }
                lastWiiState2.ButtonState.Up = ws.ButtonState.Up;

                if (!lastWiiState2.ButtonState.Down && ws.ButtonState.Down && !ws.ButtonState.B)
                    translate(form2.regitems[3], true, 3);
                if (lastWiiState2.ButtonState.Down && !ws.ButtonState.Down)
                {
                    translate(form2.regitems[3], false, 3);
                    translate(form2.shiftitems[3], false, 3);
                }
                lastWiiState2.ButtonState.Down = ws.ButtonState.Down;

                if (!lastWiiState2.ButtonState.Left && ws.ButtonState.Left && !ws.ButtonState.B)
                    translate(form2.regitems[4], true, 4);
                if (lastWiiState2.ButtonState.Left && !ws.ButtonState.Left)
                {
                    translate(form2.regitems[4], false, 4);
                    translate(form2.shiftitems[4], false, 4);
                }
                lastWiiState2.ButtonState.Left = ws.ButtonState.Left;

                if (!lastWiiState2.ButtonState.Right && ws.ButtonState.Right && !ws.ButtonState.B)
                    translate(form2.regitems[5], true, 5);
                if (lastWiiState2.ButtonState.Right && !ws.ButtonState.Right)
                {
                    translate(form2.regitems[5], false, 5);
                    translate(form2.shiftitems[5], false, 5);
                }
                lastWiiState2.ButtonState.Right = ws.ButtonState.Right;

                if (!lastWiiState2.ButtonState.Home && ws.ButtonState.Home && !ws.ButtonState.B)
                    translate(form2.regitems[6], true, 6);
                if (lastWiiState2.ButtonState.Home && !ws.ButtonState.Home)
                {
                    translate(form2.regitems[6], false, 6);
                    translate(form2.shiftitems[6], false, 6);
                }
                lastWiiState2.ButtonState.Home = ws.ButtonState.Home;

                if (!lastWiiState2.ButtonState.Minus && ws.ButtonState.Minus && !ws.ButtonState.B)
                    translate(form2.regitems[7], true, 7);
                if (lastWiiState2.ButtonState.Minus && !ws.ButtonState.Minus)
                {
                    translate(form2.regitems[7], false, 7);
                    translate(form2.shiftitems[7], false, 7);
                }
                lastWiiState2.ButtonState.Minus = ws.ButtonState.Minus;

                if (!lastWiiState2.ButtonState.Plus && ws.ButtonState.Plus && !ws.ButtonState.B)
                    translate(form2.regitems[8], true, 8);
                if (lastWiiState2.ButtonState.Plus && !ws.ButtonState.Plus)
                {
                    translate(form2.regitems[8], false, 8);
                    translate(form2.shiftitems[8], false, 8);
                }
                lastWiiState2.ButtonState.Plus = ws.ButtonState.Plus;

                if (!lastWiiState2.ButtonState.One && ws.ButtonState.One && !ws.ButtonState.B)
                    translate(form2.regitems[9], true, 9);
                if (lastWiiState2.ButtonState.One && !ws.ButtonState.One)
                {
                    translate(form2.regitems[9], false, 9);
                    translate(form2.shiftitems[9], false, 9);
                }
                lastWiiState2.ButtonState.One = ws.ButtonState.One;

                if (!lastWiiState2.ButtonState.Two && ws.ButtonState.Two && !ws.ButtonState.B)
                    translate(form2.regitems[10], true, 10);
                if (lastWiiState2.ButtonState.Two && !ws.ButtonState.Two)
                {
                    translate(form2.regitems[10], false, 10);
                    translate(form2.shiftitems[10], false, 10);
                }
                lastWiiState2.ButtonState.Two = ws.ButtonState.Two;
                mut.ReleaseMutex();
            }
        }

        //function for hover and right click
        void setclick(int down, int up)
        {
            mouseclickd = down;
            mouseclicku = up;
        }

        //takes index of box corresponding to button, up/down state of button, and which button calls function, and executes commands accordingly
        void translate(int i, bool down, int button)
        {
            if (i == 0) { }
            if (i == 1) //Ctrl
            {
                if (down) { keybd_event(VK_CONTROL, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 2)//Alt
            {
                if (down){ keybd_event(VK_MENU, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_MENU, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 3)//Shift key
            {
                if (down){ keybd_event(VK_SHIFT, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_SHIFT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 4)//Tab
            {
                if (down){ keybd_event(VK_TAB, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_TAB, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 5)//Enter
            {
                if (down){ keybd_event(VK_RETURN, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_RETURN, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 6)//Esc
            {
                if (down){ keybd_event(VK_ESCAPE, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_ESCAPE, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 7)//Up arrow
            {
                if (down){ keybd_event(VK_UP, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_UP, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 8)//Down arrow
            {
                if (down){ keybd_event(VK_DOWN, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_DOWN, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 9)//Left arrow
            {
                if (down) { keybd_event(VK_LEFT, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_LEFT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 10)//Right arrow
            {
                if (down) { keybd_event(VK_RIGHT, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_RIGHT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 11)//Home key
            {
                if (down){ keybd_event(VK_HOME, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_HOME, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 12)//End key
            {
                if (down){ keybd_event(VK_END, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_END, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 13)//Delete
            {
                if (down){ keybd_event(VK_DELETE, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_DELETE, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 14)//Page down
            {
                if (down){ keybd_event(VK_NEXT, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_NEXT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 15)//Page up
            {
                if (down){ keybd_event(VK_PRIOR, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_PRIOR, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 16)//Insert
            {
                if (down){ keybd_event(VK_INS, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_INS, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 17)//Print screen
            {
                if (down){ keybd_event(VK_SNAPSHOT, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_SNAPSHOT, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 18)//Backspace
            {
                if (down) { keybd_event(VK_BACK, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_BACK, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 19)//Space
            {
                if (down){ keybd_event(VK_SPACE, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_SPACE, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 20)//Left click (does not work)
            {
                if (down){ keybd_event(VK_LBUTTON, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_LBUTTON, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 21)//Right click (does not work)
            {
                if (down){ keybd_event(VK_RBUTTON, 0x45, 0, 0); done[button] = true; }
                else { keybd_event(VK_RBUTTON, 0x45, KEYEVENTF_KEYUP, 0); done[button] = false; }
            }
            if (i == 22)//Copy (Ctrl+c)
            {
                if (down)
                {
                    keybd_event(VK_CONTROL, 0x45, 0, 0);
                    keybd_event(0x43, 0x45, 0, 0);
                    done[button] = true;
                }//control + c
                else
                {
                    keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x43, 0x45, KEYEVENTF_KEYUP, 0);
                    done[button] = false;
                }
            }
            if (i == 23)//Paste (Ctrl+v)
            {
                if (down)
                {
                    keybd_event(VK_CONTROL, 0x45, 0, 0);
                    keybd_event(0x56, 0x45, 0, 0);
                    done[button] = true;
                }//control + v
                else
                {
                    keybd_event(VK_CONTROL, 0x45, KEYEVENTF_KEYUP, 0);
                    keybd_event(0x56, 0x45, KEYEVENTF_KEYUP, 0);
                    done[button] = false;
                    
                   
                }
            }
            if (i == 24)//Double click
            {
                if (down) { if (!clicked) numclicks = 4; done[button] = true; }
                else { numclicks = 1; clicked = false; done[button] = false; }
            }
            if (i == 25)//Hover
            {
                if (down){ setclick(0, 0); done[button] = true; }
                else { setclick(MOUSEEVENTF_LEFTDOWN, MOUSEEVENTF_LEFTUP); done[button] = false; }
            }
            if (i == 26) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PLAY)); done[button] = true; } else { done[button] = false; }
            if (i == 27) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PAUSE)); done[button] = true; } else { done[button] = false; }
            if (i == 28) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PLAY_PAUSE)); done[button] = true; } else { done[button] = false; }
            if (i == 29) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_STOP)); done[button] = true; } else { done[button] = false; }
            if (i == 30) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_PREVIOUSTRACK)); done[button] = true; } else { done[button] = false; }
            if (i == 31) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_MEDIA_NEXTTRACK)); done[button] = true; } else { done[button] = false; }
            if (i == 32) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_UP)); done[button] = true; } else { done[button] = false; }
            if (i == 33) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_DOWN)); done[button] = true; } else { done[button] = false; }
            if (i == 34) if (down) { SendMessage(GetForegroundWindow(), WM_APPCOMMAND, IntPtr.Zero, new IntPtr(APPCOMMAND_VOLUME_MUTE)); done[button] = true; } else { done[button] = false; }
            if (i == 35)
                if (down)
                {
                    if (shifting)
                        SendKeys.SendWait(form2.shiftcustom[button]);
                    else
                        SendKeys.SendWait(form2.regcustom[button]);
                    done[button] = true;
                }
                else { done[button] = false; }
            if(i == 36)
                if (down)
                {
                    form2.gesturing = true;
                    form2.motions = "";
                    form2.form3.label1.Text = "";
                    form2.form3.label2.Text = "";
                    form2.form3.Show();
                    done[button] = true;
                }
                else
                {
                    form2.gesturing = false;
                    form2.form3.Hide();
                    form2.gesture = form2.form3.label1.Text;
                    int ges = form2.getgesture();
                    if (ges != -1)
                    {
                        translate(ges, true, 0);
                        translate(ges, false, 0);
                    }
                    done[button] = false;
                }
                    
        }

        public void loadCalibrationData()
        {
            // create reader & open file
            try
            {
                TextReader tr = new StreamReader("calibration.dat");
                for (int i = 0; i < 4; i++)
                {
                    srcX[i] = float.Parse(tr.ReadLine());
                    srcY[i] = float.Parse(tr.ReadLine());
                }
                smoothingAmount = int.Parse(tr.ReadLine());

                // close the stream
                tr.Close();
            }
            catch (Exception x) 
            {
                x.ToString();
                //no prexsting calibration
                return;
            }

            warper.setDestination(  screenWidth * calibrationMargin,
                                    screenHeight * calibrationMargin,
                                    screenWidth * (1.0f-calibrationMargin),
                                    screenHeight * calibrationMargin,
                                    screenWidth * calibrationMargin,
                                    screenHeight * (1.0f - calibrationMargin),
                                    screenWidth * (1.0f - calibrationMargin),
                                    screenHeight * (1.0f - calibrationMargin));
            warper.setSource(srcX[0], srcY[0], srcX[1], srcY[1], srcX[2], srcY[2], srcX[3], srcY[3]);

            warper.computeWarp();
            setSmoothing(smoothingAmount);
            cursorControl = true;
            BeginInvoke((MethodInvoker)delegate() { cbCursorControl.Checked = cursorControl; });

            UpdateTrackingUtilization();
        }

        public void saveCalibrationData()
        {
            TextWriter tw = new StreamWriter("calibration.dat");

            // write a line of text to the file
            for (int i = 0; i < 4; i++)
            {
                tw.WriteLine(srcX[i]);
                tw.WriteLine(srcY[i]);
            }
            tw.WriteLine(smoothingAmount);
            // close the stream
            tw.Close();
        }

        public void doCalibration(){
            if (cf == null)
                return;
            int x = 0;
            int y = 0;
            int size = 25;
            Pen p = new Pen(Color.Red);
            switch (calibrationState)
            {
                case 1:
                    x = (int)(screenWidth * calibrationMargin);
                    y = (int)(screenHeight * calibrationMargin);
                    cf.showCalibration(x, y, size, p);
                    dstX[calibrationState - 1] = x;
                    dstY[calibrationState - 1] = y;
                    break;
                case 2:
                    x = screenWidth - (int)(screenWidth * calibrationMargin);
                    y = (int)(screenHeight * calibrationMargin);
                    cf.showCalibration(x, y, size, p);
                    dstX[calibrationState - 1] = x;
                    dstY[calibrationState - 1] = y;
                    break;
                case 3:
                    x = (int)(screenWidth * calibrationMargin);
                    y = screenHeight -(int)(screenHeight * calibrationMargin);
                    cf.showCalibration(x, y, size, p);
                    dstX[calibrationState - 1] = x;
                    dstY[calibrationState - 1] = y;
                    break;
                case 4:
                    x = screenWidth - (int)(screenWidth * calibrationMargin);
                    y = screenHeight -(int)(screenHeight * calibrationMargin);
                    cf.showCalibration(x, y, size, p);
                    dstX[calibrationState - 1] = x;
                    dstY[calibrationState - 1] = y;
                    break;
                case 5:
                    //compute warp
                    warper.setDestination(dstX[0], dstY[0], dstX[1], dstY[1], dstX[2], dstY[2], dstX[3], dstY[3]);
                    warper.setSource(srcX[0], srcY[0], srcX[1], srcY[1], srcX[2], srcY[2], srcX[3], srcY[3]);
                    warper.computeWarp();
                    cf.Close();
                    cf = null;
                    calibrationState = 0;
                    cursorControl = true;
                    BeginInvoke((MethodInvoker)delegate() { cbCursorControl.Checked = cursorControl; });
                    saveCalibrationData();
                    UpdateTrackingUtilization();
                    break;
                default:
                    break;
            }

        }

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
            TextWriter t = new StreamWriter("dump.txt");
            t.WriteLine(motions);
            t.Close();
            //disconnect the wiimote
            wm.Disconnect();
            if (wms.Count > 1)
            {
                remote2.Disconnect();
            }
            saveCalibrationData();
		}

        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            if (cf == null)
            {
                cf = new CalibrationForm();
                cf.Show();
            }
            if (cf.IsDisposed)
            {
                cf = new CalibrationForm();
                cf.Show();
            }
            cursorControl = false;
            calibrationState = 1;
            doCalibration();
        }

        private void cbCursorControl_CheckedChanged(object sender, EventArgs e)
        {
            cursorControl = cbCursorControl.Checked;
        }

        //will try to connect to a second wiimote if checked
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            secondwiimote = checkBox3.Checked;
            if (checkBox3.Checked)
            {
                wms = Wiimote.GetConnectedWiimotes();
                if (wms.Count > 1)
                {
                    remote2 = wms[1];
                    remote2.WiimoteChanged += new WiimoteChangedEventHandler(remote2_OnWiimoteChanged);
                    remote2.SetReportType(Wiimote.InputReport.IRAccel, true);
                    remote2.SetLEDs(false, true, false, false);
                }
                else
                {
                    MessageBox.Show("There is no second Wiimote connected");
                    checkBox3.Checked = false;
                }
            }
            if (!checkBox3.Checked)
            {
                if (wms.Count > 1)
                {
                    remote2.SetLEDs(true, true, true, true);
                    remote2.Disconnect();
                }
                lblBattery2.Text = "---";
                pbBattery2.Value = 0;
            }
        }

        //shows the form for customizing button mappings
        private void custombutton_Click(object sender, EventArgs e)
        {
            form2.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            form2.Focus();
        }

        private void setSmoothing(int smoothing)
        {
            smoothingAmount = smoothing;
            trackBar1.Value = smoothing;
            enableSmoothing = (smoothingAmount != 0);
            lblSmoothing.Text = "Smoothing: ";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
                smoothingAmount = trackBar1.Value;
                enableSmoothing = (smoothingAmount != 0);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            trackval.Text = trackBar1.Value.ToString();
        }

        private void mousebtn_Click(object sender, EventArgs e)
        {
            mouse = !mouse;
            if (mouse)
            {
                mousebtn.Text = "Whiteboard";
                btnCalibrate.Enabled = false;
            }
            else
            {
                mousebtn.Text = "WiiMouse";
                btnCalibrate.Enabled = true;
            }
        }
	}
}