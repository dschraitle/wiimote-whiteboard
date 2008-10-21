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
        public const int NUMBOXES = 13;
        public object[] items = new object[] { "None", "Ctrl", "Alt", "Shift", "Tab", "Enter", "Esc", "UpArrow", "DownArrow", "LeftArrow", "RightArrow", "Home", "End", "Delete", "PgDown", "PgUp", "Insert", "PrtScrn", "Backspace", "Space", "LeftClick", "RightClick", "Copy", "Paste", "DblClick", "Hover", "Play", "Pause", "Play/Pause", "Stop", "Prev Track", "Next Track", "Vol Up", "Vol Down", "Vol Mute", "Custom"};
        public int[] regitems = new int[] { 0, 25, 7, 8, 9, 10, 5, 22, 23, 0, 0, 0, 0};   //default indexes
        public int[] shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        public int[] prevselindex = new int[NUMBOXES];
        public int[] regprevselindex = new int[NUMBOXES];
        public int[] shiftprevselindex = new int[NUMBOXES];
        public string[] custom = new string[NUMBOXES];
        public string[] regcustom = new string[NUMBOXES];
        public string[] shiftcustom = new string[NUMBOXES];
        public ComboBox[] boxes;
        public bool start = true;
        public bool changeshift = false;

        public Form2()
        {
            InitializeComponent();
            boxes = new ComboBox[] {boxb, boxa, boxup, boxdown, boxleft, boxright, boxhome, boxminus, boxplus, box1, box2, ypos, yneg };

            //creates item list for all boxes
            for (int i = 1; i <= NUMBOXES-1; i++) boxes[i].Items.AddRange(items);

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
        //saves data to the registry
        private void regsave()
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
                    custom = (string[])load[1];
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

        public void setstates(bool shifted)   //sets the selected indexes of the boxes for shifted or not shifted
        {
            if (!shifted)
            {  
                prevselindex = regprevselindex;
                custom = regcustom;
                start = true;
                for (int i = 1; i < NUMBOXES-1; i++)
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
                for (int i = 1; i < NUMBOXES - 1; i++)
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
                for (int i = 1; i < regitems.Length; i++) regitems[i] = boxes[i].SelectedIndex;
                regprevselindex = prevselindex;
                regcustom = custom;
            }
            else
            {
                for (int i = 1; i < shiftitems.Length; i++) shiftitems[i] = boxes[i].SelectedIndex;
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
            regitems = new int[] { 0, 25, 7, 8, 9, 10, 5, 22, 23, 0, 0, 0, 0 };
            shiftitems = new int[] { 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
            regitems = new int[] { 0, 28, 7, 8, 9, 10, 5, 15, 14, 35, 35, 0, 0 };
            shiftitems = new int[] { 0, 24, 35, 35, 35, 35, 0, 0, 0, 0, 0, 0, 0 };
            regcustom = custom = new string[] { "", "", "", "", "", "", "", "", "", "!>", "!<", "", "" };
            shiftcustom = new string[] { "", "", "^{up}", "^{down}", "^{left}", "^{right}", "", "", "", "", "", "", "" };
            setstates(false);
        }
      }
}