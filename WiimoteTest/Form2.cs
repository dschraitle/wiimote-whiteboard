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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using WiimoteLib;
using Microsoft.Win32;

namespace WiimoteWhiteboard
{
    public partial class Form2 : Form
    {
        public const int NUMBOXES = 11;
        public object[] items = new object[] { "None", "Ctrl", "Alt", "Shift", "Tab", "Enter", "Esc", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Home", "End", "Delete", "PgDown", "PgUp", "Insert", "PrtScrn", "Backspace", "Space", "LeftClick", "RightClick", "Copy", "Paste", "DblClick", "Hover", "Play", "Pause", "Play/Pause", "Stop", "Prev Track", "Next Track", "Vol Up", "Vol Down", "Vol Mute", "Custom"};
        public int[] regitems = new int[] { 0, 25, 7, 8, 9, 10, 5, 22, 23, 0, 0, 0, 0, 0};   //default indexes
        public int[] shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public int[] prevselindex = new int[NUMBOXES];
        public int[] regprevselindex = new int[NUMBOXES];
        public int[] shiftprevselindex = new int[NUMBOXES];
        public string[] custom = new string[NUMBOXES];
        public string[] regcustom = new string[NUMBOXES];
        public string[] shiftcustom = new string[NUMBOXES];
        public ComboBox[] boxes;
        public bool start = true;
        public bool changeshift = false;
        public string motions = "";
        public bool recording = false;
        public bool gesturing = false;
        

        public Form2()
        {
            InitializeComponent();
            boxes = new ComboBox[] {boxb, boxa, boxup, boxdown, boxleft, boxright, boxhome, boxminus, boxplus, box1, box2};

            //creates item list for all boxes
            for (int i = 1; i <= NUMBOXES - 1; i++) boxes[i].Items.AddRange(items);

            //load data from registry
            try
            {
                for (int i = 0; i <= NUMBOXES - 1; i++)
                {
                    regcustom[i] = "";
                    shiftcustom[i] = "";
                }
                RegistryKey ourkey;
                ourkey = Registry.Users;
                ourkey = ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Whiteboard");
                for (int i = 1; i <= NUMBOXES-1; i++) regitems[i] = (int)ourkey.GetValue(boxes[i].Name);
                for (int i = 1; i <= NUMBOXES - 1; i++) regcustom[i] = (string)ourkey.GetValue(boxes[i].Name+"custom");
                for (int i = 1; i <= NUMBOXES - 1; i++) shiftitems[i] = (int)ourkey.GetValue("shift" + boxes[i].Name);
                for (int i = 1; i <= NUMBOXES - 1; i++) shiftcustom[i] = (string)ourkey.GetValue("shift" + boxes[i].Name + "custom");           
            }
            catch (Exception x) { x.Message.ToString(); }

            //sets indexes of boxes
            boxb.SelectedIndex = 0;
            custom = regcustom;
            for (int i = 1; i <= NUMBOXES-1; i++)
            {
                if (regitems[i] == 35)
                    {
                        boxes[i].Items.RemoveAt(35);
                        boxes[i].Items.Insert(35, regcustom[i]);
                    }
                boxes[i].SelectedIndex = regitems[i];
            }
            prevselindex = regitems;
            regprevselindex = regitems;

            start = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            regsave();
        }
        
        private void regsave()  //saves data to the registry
        {
            getstates(boxb.SelectedIndex == 1);
            RegistryKey ourkey = Registry.Users;
            ourkey = ourkey.CreateSubKey(@".DEFAULT\Software\Schraitle\Whiteboard");
            ourkey.OpenSubKey(@".DEFAULT\Software\Schraitle\Whiteboard", true);
            for (int i = 0; i <= NUMBOXES - 1; i++) ourkey.SetValue(boxes[i].Name, regitems[i]);
            for (int i = 0; i <= NUMBOXES - 1; i++) ourkey.SetValue(boxes[i].Name + "custom", regcustom[i]);
            for (int i = 1; i <= NUMBOXES - 1; i++) ourkey.SetValue("shift" + boxes[i].Name, shiftitems[i]);
            for (int i = 1; i <= NUMBOXES - 1; i++) ourkey.SetValue("shift" + boxes[i].Name + "custom", shiftcustom[i]);
            ourkey.Close();
        }

        private void save_Click(object sender, EventArgs e) //saves data to file
        {
            SaveFileDialog svfl = new SaveFileDialog();
            svfl.Filter = "Special Files (*.sch)|*.sch";
            if (svfl.ShowDialog() == DialogResult.OK)
            {
                object[] save = new object[4];
                save[0] = regitems;
                save[1] = custom;
                save[2] = shiftitems;
                save[3] = shiftcustom;
                BinaryFormatter b = new BinaryFormatter();
                Stream s = File.OpenWrite(svfl.FileName);
                b.Serialize(s, save);
                s.Close();
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
                    Stream s = File.OpenRead(opfl.FileName);
                    BinaryFormatter b = new BinaryFormatter();
                    object[] load = (object[])b.Deserialize(s);
                    s.Close();
                    regitems = (int[])load[0];
                    regcustom = (string[])load[1];
                    shiftitems = (int[])load[2];
                    shiftcustom = (string[])load[3];
                }
                catch (Exception x) { x.Message.ToString(); }
                setstates(false);
            }

        }

        void customize(ComboBox box, int i) //function to handle specific commands for each button
        {
            if (box.SelectedIndex == 35 && prevselindex[i] != 35 && !start && !changeshift)
            {
                box.Items.RemoveAt(35);
                box.Items.Insert(35, tb1.Text);
                custom[i] = tb1.Text;
                prevselindex[i] = 35;
                box.SelectedItem = tb1.Text;
            }
            if (box.SelectedIndex != 35 && prevselindex[i] == 35)
            {
                box.Items.RemoveAt(35);
                box.Items.Insert(35, "Custom");
                custom[i] = "";
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

        private void ges1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // customize(ges1, 11);
        }
        #endregion

        private void okbutton_Click(object sender, EventArgs e)
        {
            regsave();
            this.Hide();
        }

        public void setstates(bool shifted)   //sets the selected indexes of the boxes for shifted or not shifted
        {
            if (!shifted)
            {  
                prevselindex = regprevselindex;
                custom = regcustom;
                start = true;
                for (int i = 1; i < NUMBOXES; i++)
                {
                    if (regitems[i] == 35)
                    {
                        boxes[i].Items.RemoveAt(35);
                        boxes[i].Items.Insert(35, custom[i]);
                    } 
                    boxes[i].SelectedIndex = regitems[i];
                }
                start = false;
            }
            else
            {
                prevselindex = shiftprevselindex;
                custom = shiftcustom;
                for (int i = 1; i < NUMBOXES; i++)
                {
                    if (shiftitems[i] == 35)
                    {
                        boxes[i].Items.RemoveAt(35);
                        boxes[i].Items.Insert(35, custom[i]);
                    }
                    boxes[i].SelectedIndex = shiftitems[i];
                }
            }
        }

        private void getstates(bool shifted)  //gets the selected indexes of the boxes and saves them to the saving arrays
        {
            if (!shifted)
            {
                for (int i = 1; i < NUMBOXES; i++) regitems[i] = boxes[i].SelectedIndex;
                regprevselindex = prevselindex;
                regcustom = custom;
            }
            else
            {
                for (int i = 1; i < NUMBOXES; i++) shiftitems[i] = boxes[i].SelectedIndex;
                shiftprevselindex = prevselindex;
                shiftcustom = custom;
            }
        }

        private void boxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeshift = true;
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
            changeshift = false;
        }

        private void defaultpreset_Click(object sender, EventArgs e)  //resets saved arrays to default state and updates selected indexes of boxes
        {
            boxb.SelectedIndex = 0;
            regitems = new int[] { 0, 25, 7, 8, 9, 10, 5, 22, 23, 0, 0};
            shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            setstates(false);
        }

        private void mediapreset_Click(object sender, EventArgs e)
        {
            boxb.SelectedIndex = 0;
            regitems = new int[] { 0, 28, 32, 33, 0, 0, 29, 30, 31, 0, 0, 0, 0 };
            shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 19, 5, 0, 0 };
            setstates(false);
        }

        private void gomPlayer_Click(object sender, EventArgs e)
        {
            boxb.SelectedIndex = 0;
            regitems = new int[] { 0, 28, 7, 8, 9, 10, 5, 15, 14, 35, 35};
            shiftitems = new int[] { 0, 24, 35, 35, 35, 35, 0, 0, 0, 0, 0};
            regcustom = custom = new string[] { "", "", "", "", "", "", "", "", "", "!>", "!<", "", "" };
            shiftcustom = new string[] { "", "", "^{up}", "^{down}", "^{left}", "^{right}", "", "", "", "", "", "", "" };
            setstates(false);
        }
        #region bumping
        /*
        private void recbutton_Click(object sender, EventArgs e)
        {
            if (recbutton.Text != "Stop")
            {
                recording = true;
                recbutton.Text = "Stop";
                motions = "";
                gestb.Text = "";
            }
            else
            {
                recording = false;
                recbutton.Text = "Record";
            }
        }

        public void checkbump(ref byte[] temp, string c)
        {
            string toadd = "";
            int avg = 0;
            foreach (byte b in temp)
                avg += int.Parse(b.ToString());
            avg = avg - temp[temp.Length - 1];
            avg = avg / temp.Length;
            if (int.Parse(temp[0].ToString()) > avg + 30)
            {
                temp = new byte[50];
                toadd = c + "P";
                if (motions.Length > 2)
                    if (motions.Substring(motions.Length - 2) == toadd)
                        toadd = "";
                motions += toadd;
            }
            if (int.Parse(temp[0].ToString()) < avg - 30)
            {
                temp = new byte[50];
                toadd = c + "N";
                motions += toadd;
            }

            //if (int.Parse(temp[0].ToString()) > 150 && temp[49] > 10)
            //{
            //    foreach (byte b in temp)
            //        if (int.Parse(b.ToString()) < min)
            //            min = int.Parse(b.ToString());
            //    if (int.Parse(temp[0].ToString()) - min > 50)
            //    {
            //        temp = new byte[50];
            //        toadd = c + "P";
            //        motions += toadd;
            //    }
            //}
            //if (int.Parse(temp[0].ToString()) < 105 && temp[49] > 10)
            //{
            //    foreach (byte b in temp)
            //        if (int.Parse(b.ToString()) > max)
            //            max = int.Parse(b.ToString());
            //    if (max - int.Parse(temp[0].ToString()) > 50)
            //    {
            //        temp = new byte[50];
            //        toadd = c + "N";
            //        motions += toadd;
            //    }
            //}
            if (recording && toadd != "") gestb.Text += toadd;
            if (gesturing && toadd != "")
            {
                if (form3.label1.Text == "")
                    form3.label1.Text = toadd;
                else
                    form3.label1.Text += "-" + toadd;
                int gesnum;
                if ((gesnum = getgesture()) != -1)
                    form3.label2.Text = (string)items[gesnum];
                else
                    form3.label2.Text = "";
            }
        }

        private void ges1lbl_Click(object sender, EventArgs e)
        {
            ges1lbl.Text = gestb.Text;
            for (int i = 2; i < ges1lbl.Text.Length; i = 3 + i)
                ges1lbl.Text = ges1lbl.Text.Insert(i, "-");
            if (gestb.Text == "")
                ges1lbl.Text = "Gesture 1";
        }

        public int getgesture() //returns the index of the gesture box, or -1 if not found
        {
            string[] tofind = ges1lbl.Text.Split('-');
            foreach (string s in tofind)
                if (!form3.label1.Text.Contains(s))
                    return -1;
            return ges1.SelectedIndex;
        }
         * 
         * this goes in form1 in the remote2changed function
         * objects used need to be declared, ACCELDATA = 50
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
         * 
         * this goes in the translate function, must make a form3 and have it load and immediately
         * hide when the program starts, otherwise it will crash
         * form3.label1 is the string of gestures
         * form3.label2 is the text of the gesture that would happen
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
         * 
         * this is in the variable declaration section of form2
         * //variables for gesture boxes
        public const int GESBOXES = 1;
        public ComboBox[] gesboxes;
        public int[] gesprevindex = new int[GESBOXES];
        public int[] gescustom = new int[GESBOXES];
        public Form3 form3;
        public string gesture = "";
         * 
         * in form2 constructor
         * gesboxes = new ComboBox[] { ges1 };
         * for (int i = 0; i <= GESBOXES - 1; i++) gesboxes[i].Items.AddRange(items);
        */
        #endregion
    }
}