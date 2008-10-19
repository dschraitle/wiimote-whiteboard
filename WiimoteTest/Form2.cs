using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;//for saving the reading the calibration data
using WiimoteLib;
using Microsoft.Win32;

namespace WiimoteWhiteboard
{
    public partial class Form2 : Form
    {
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

        //declare consts for key scan codes
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
        public const byte VK_NUMPAD0 = 0x60;
        public const byte VK_NUMPAD1 = 0x61;
        public const byte VK_NUMPAD2 = 0x62;
        public const byte VK_NUMPAD3 = 0x63;
        public const byte VK_NUMPAD4 = 0x64;
        public const byte VK_NUMPAD5 = 0x65;
        public const byte VK_NUMPAD6 = 0x66;
        public const byte VK_NUMPAD7 = 0x67;
        public const byte VK_NUMPAD8 = 0x68;
        public const byte VK_NUMPAD9 = 0x69;
        public const byte VK_MULTIPLY = 0x6A;
        public const byte VK_ADD = 0x6B;
        public const byte VK_SEPARATOR = 0x6C;
        public const byte VK_SUBTRACT = 0x6D;
        public const byte VK_DECIMAL = 0x6E;
        public const byte VK_DIVIDE = 0x6F;
        public const byte VK_F1 = 0x70;
        public const byte VK_F2 = 0x71;
        public const byte VK_F3 = 0x72;
        public const byte VK_F4 = 0x73;
        public const byte VK_F5 = 0x74;
        public const byte VK_F6 = 0x75;
        public const byte VK_F7 = 0x76;
        public const byte VK_F8 = 0x77;
        public const byte VK_F9 = 0x78;
        public const byte VK_F10 = 0x79;
        public const byte VK_F11 = 0x7A;
        public const byte VK_F12 = 0x7B;
        public const byte VK_F13 = 0x7C;
        public const byte VK_F14 = 0x7D;
        public const byte VK_F15 = 0x7E;
        public const byte VK_F16 = 0x7F;
        public const byte VK_F17 = 0x80;
        public const byte VK_F18 = 0x81;
        public const byte VK_F19 = 0x82;
        public const byte VK_F20 = 0x83;
        public const byte VK_F21 = 0x84;
        public const byte VK_F22 = 0x85;
        public const byte VK_F23 = 0x86;
        public const byte VK_F24 = 0x87;
        public const byte VK_NUMLOCK = 0x90;
        public const byte VK_SCROLL = 0x91;
        public const byte VK_LSHIFT = 0xA0;
        public const byte VK_RSHIFT = 0xA1;
        public const byte VK_LCONTROL = 0xA2;
        public const byte VK_RCONTROL = 0xA3;
        public const byte VK_LMENU = 0xA4;
        public const byte VK_RMENU = 0xA5;
        public const byte VK_0 = 0x30;
        public const byte VK_1 = 0x31;
        public const byte VK_2 = 0x32;
        public const byte VK_3 = 0x33;
        public const byte VK_4 = 0x34;
        public const byte VK_5 = 0x35;
        public const byte VK_6 = 0x36;
        public const byte VK_7 = 0x37;
        public const byte VK_8 = 0x38;
        public const byte VK_9 = 0x39;
        public const byte VK_A = 0x41;
        public const byte VK_B = 0x42;
        public const byte VK_C = 0x43;
        public const byte VK_D = 0x44;
        public const byte VK_E = 0x45;
        public const byte VK_F = 0x46;
        public const byte VK_G = 0x47;
        public const byte VK_H = 0x48;
        public const byte VK_I = 0x49;
        public const byte VK_J = 0x4A;
        public const byte VK_K = 0x4B;
        public const byte VK_L = 0x4C;
        public const byte VK_M = 0x4D;
        public const byte VK_N = 0x4E;
        public const byte VK_O = 0x4F;
        public const byte VK_P = 0x50;
        public const byte VK_Q = 0x51;
        public const byte VK_R = 0x52;
        public const byte VK_S = 0x53;
        public const byte VK_T = 0x54;
        public const byte VK_U = 0x55;
        public const byte VK_V = 0x56;
        public const byte VK_W = 0x57;
        public const byte VK_X = 0x58;
        public const byte VK_Y = 0x59;
        public const byte VK_Z = 0x5A;

        public const int KEYEVENTF_EXTENDEDKEY = 0x01;
        public const int KEYEVENTF_KEYUP = 0x02;
        #endregion

        public object[] items = new object[] { "None", "Ctrl", "Alt", "Shift", "Tab", "Enter", "Esc", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Home", "End", "Delete", "PgDown", "PgUp", "Insert", "PrtScrn", "Backspace", "Space", "LeftClick", "RightClick", "Copy", "Paste", "DblClick", "Hover", "Play", "Pause", "Play/Pause", "Stop", "Prev Track", "Next Track", "Vol Up", "Vol Down", "Vol Mute", "Custom"};
        //{B, A, Up, Down, Left, Right, Home, Minus, Plus, 1, 2, ypos, yneg}
        public int[] regitems = new int[] { 0, 25, 7, 8, 9, 10, 5, 22, 23, 0, 0, 0, 0};   //default indexes
        public int[] shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};  
        public int[] prevselindex;
        public string[] custom = new string[13];
        public ComboBox[] boxes;
        public bool start = true;
        string[] registryvals = new string[] { "boxb", "boxa", "boxup", "boxdown", "boxleft", "boxright", "boxhome", "boxminus", "boxplus", "box1", "box2", "ypos", "yneg" };
        string[] registryshiftvals = new string[] { "shiftboxb", "shiftboxa", "shiftboxup", "shiftboxdown", "shiftboxleft", "shiftboxright", "shiftboxhome", "shiftboxminus", "shiftboxplus", "shiftbox1", "shiftbox2", "shiftypos", "shiftyneg" };

        public Form2()
        {
            InitializeComponent();
            boxes = new ComboBox[] {boxb, boxa, boxup, boxdown, boxleft, boxright, boxhome, boxminus, boxplus, box1, box2, ypos, yneg };
            prevselindex = new int[items.Length + 1];

            //creates item list for all boxes
            for (int i = 1; i <= 12; i++) boxes[i].Items.AddRange(items);

            //load data from registry
            try
            {
                RegistryKey ourkey;
                ourkey = Registry.Users;
                ourkey = ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Whiteboard");
                for(int i=0; i<=12;i++) regitems[i] = (int)ourkey.GetValue(registryvals[i]);
                for (int i = 1; i <= 12; i++) shiftitems[i] = (int)ourkey.GetValue(registryshiftvals[i]);
            }
            catch (Exception x) { x.Message.ToString(); }

            //sets indexes of boxes
            int[] saveo = regitems;
            boxb.SelectedIndex = 0;
            for (int i = 1; i <= 12; i++) boxes[i].SelectedIndex = saveo[i];

            start = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            regsave();
        }
        //saves data to the registry
        private void regsave()   
        {
            RegistryKey ourkey = Registry.Users;
            ourkey = ourkey.CreateSubKey(@".DEFAULT\Software\Schraitle\Whiteboard");
            ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Whiteboard", true);
            for (int i = 0; i <= 12; i++) ourkey.SetValue(registryvals[i], regitems[i]);
            for (int i = 1; i <= 12; i++) ourkey.SetValue(registryshiftvals[i], shiftitems[i]);
            ourkey.Close();
        }

        private void save_Click(object sender, EventArgs e) //saves data to file
        {
            SaveFileDialog svfl = new SaveFileDialog();
            svfl.Filter = "Special Files (*.sch)|*.sch";
            if (svfl.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw;
                sw = File.CreateText(svfl.FileName);
                sw.WriteLine(regitems[0]);
                sw.WriteLine(regitems[1]);
                for (int i = 2; i <= 12; i++) sw.WriteLine(regitems[i]);
                for(int i = 0; i < 12; i++) sw.WriteLine("");   //12 is the number of lines written by wiimote remote saves
                for (int i = 1; i <= 12; i++) sw.WriteLine(shiftitems[i]);
                sw.Close();
            }
        }

        private void load_Click(object sender, EventArgs e) //opens file of choice and loads in data to saved arrays then sets the states
        {
            OpenFileDialog opfl = new OpenFileDialog();
            opfl.Filter = "Special Files (*.sch)|*.sch";
            if (opfl.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr;
                    sr = File.OpenText(opfl.FileName);
                    sr.ReadLine();
                    regitems[1] = int.Parse(sr.ReadLine());
                    for (int i = 2; i <= 12; i++) regitems[i] = int.Parse(sr.ReadLine());
                    for (int i = 0; i < 12; i++) sr.ReadLine();
                    for (int i = 1; i <= 12; i++) shiftitems[i] = int.Parse(sr.ReadLine());
                    sr.Close();
                }
                catch (Exception x) { x.Message.ToString(); }

                setstates(false);
            }


        }

        void customize(ComboBox box, int i) //function to handle specific commands for each button
        {
            if (box.SelectedIndex == 35 && prevselindex[i] != 35 && !start)
            {
                box.Items.RemoveAt(35);
                box.Items.Insert(35, tb1.Text);
                custom[i] = tb1.Text;
                prevselindex[i] = 35;
                box.SelectedItem = tb1.Text;
            }
            if (box.SelectedIndex != 23 && prevselindex[i] == 23)
            {
                box.Items.RemoveAt(35);
                box.Items.Insert(35, "Custom");
            }

            if (boxb.SelectedIndex == 0) regitems[i] = box.SelectedIndex;   //sets values of the saved array of selected indexes
            else shiftitems[i] = box.SelectedIndex;
            prevselindex[i] = box.SelectedIndex;
        }
        #region dropdown events
        private void boxa_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxa, 1);
        }

        private void boxup_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxup, 2);
        }

        private void boxdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxdown, 3);
        }

        private void boxleft_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxleft, 4);
        }

        private void boxright_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxright, 5);
        }

        private void boxhome_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxhome, 6);
        }

        private void boxminus_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxminus, 7);
        }

        private void boxplus_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(boxplus, 8);
        }

        private void box1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(box1, 9);
        }

        private void box2_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(box2, 10);
        }

        private void ypos_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(ypos, 11);
        }

        private void yneg_SelectedIndexChanged(object sender, EventArgs e)
        {
            customize(yneg, 12);
        }
        #endregion
        private void okbutton_Click(object sender, EventArgs e)
        {
            regsave();
            this.Hide();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void setstates(bool shifted)   //sets the selected indexes of the boxes for shifted or not shifted
        {
            if (!shifted)for (int i = 1; i < regitems.Length; i++) boxes[i].SelectedIndex = regitems[i];
            else for (int i = 1; i < shiftitems.Length; i++) boxes[i].SelectedIndex = shiftitems[i];
        }

        private void getstates(bool shift)  //gets the selected indexes of the boxes and saves them to the saving arrays
        {
            if (!shift)for (int i = 1; i < regitems.Length; i++) regitems[i] = boxes[i].SelectedIndex;
            else for (int i = 1; i < shiftitems.Length; i++) shiftitems[i] = boxes[i].SelectedIndex;
        }

        private void boxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!start)
            {
                if (boxb.SelectedIndex == 0)    //sets the selected indexes of all other boxes depending on the state of boxb (shifted/not shifted)
                {
                    getstates(true);
                    setstates(false);
                }
                else
                {
                    getstates(false);
                    setstates(true);
                }
            }
        }

        private void defaultpreset_Click(object sender, EventArgs e)  //resets saved arrays to default state and updates selected indexes of boxes
        {
            regitems = new int[] { 0, 25, 7, 8, 9, 10, 5, 22, 23, 0, 0, 0, 0 };
            shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            setstates(false);
        }

        private void mediapreset_Click(object sender, EventArgs e)
        {
            regitems = new int[] { 0, 28, 32, 33, 0, 0, 29, 30, 31, 0, 0, 0, 0 };
            shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 19, 5, 0, 0 };
            setstates(false);
        }

        private void gomPlayer_Click(object sender, EventArgs e)
        {
            regitems = new int[] { 0, 19, 7, 8, 9, 10, 0, 15, 14, 0, 5, 0, 0 };
            shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            setstates(false);
        }

      }
}