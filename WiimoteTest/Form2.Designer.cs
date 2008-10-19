namespace WiimoteWhiteboard
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.box2 = new System.Windows.Forms.ComboBox();
            this.alabel = new System.Windows.Forms.Label();
            this.pluslabel = new System.Windows.Forms.Label();
            this.homepicture = new System.Windows.Forms.PictureBox();
            this.blabel = new System.Windows.Forms.Label();
            this.minuslabel = new System.Windows.Forms.Label();
            this.onelabel = new System.Windows.Forms.Label();
            this.twolabel = new System.Windows.Forms.Label();
            this.rightlabel = new System.Windows.Forms.Label();
            this.downlabel = new System.Windows.Forms.Label();
            this.uplabel = new System.Windows.Forms.Label();
            this.leftlabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.boxplus = new System.Windows.Forms.ComboBox();
            this.boxhome = new System.Windows.Forms.ComboBox();
            this.boxdown = new System.Windows.Forms.ComboBox();
            this.boxright = new System.Windows.Forms.ComboBox();
            this.boxup = new System.Windows.Forms.ComboBox();
            this.boxleft = new System.Windows.Forms.ComboBox();
            this.boxa = new System.Windows.Forms.ComboBox();
            this.boxminus = new System.Windows.Forms.ComboBox();
            this.box1 = new System.Windows.Forms.ComboBox();
            this.okbutton = new System.Windows.Forms.Button();
            this.boxb = new System.Windows.Forms.ComboBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.load = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultpreset = new System.Windows.Forms.ToolStripMenuItem();
            this.mediapreset = new System.Windows.Forms.ToolStripMenuItem();
            this.gomPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.customlbl = new System.Windows.Forms.Label();
            this.ypos = new System.Windows.Forms.ComboBox();
            this.yneg = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.homepicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(112, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 326);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // box2
            // 
            this.box2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box2.FormattingEnabled = true;
            this.box2.Location = new System.Drawing.Point(220, 303);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(77, 21);
            this.box2.TabIndex = 10;
            this.box2.SelectedIndexChanged += new System.EventHandler(this.box2_SelectedIndexChanged);
            // 
            // alabel
            // 
            this.alabel.AutoSize = true;
            this.alabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alabel.Location = new System.Drawing.Point(1, 130);
            this.alabel.Name = "alabel";
            this.alabel.Size = new System.Drawing.Size(23, 24);
            this.alabel.TabIndex = 11;
            this.alabel.Text = "A";
            // 
            // pluslabel
            // 
            this.pluslabel.AutoSize = true;
            this.pluslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pluslabel.Location = new System.Drawing.Point(197, 203);
            this.pluslabel.Name = "pluslabel";
            this.pluslabel.Size = new System.Drawing.Size(21, 24);
            this.pluslabel.TabIndex = 12;
            this.pluslabel.Text = "+";
            // 
            // homepicture
            // 
            this.homepicture.Image = ((System.Drawing.Image)(resources.GetObject("homepicture.Image")));
            this.homepicture.Location = new System.Drawing.Point(192, 164);
            this.homepicture.Name = "homepicture";
            this.homepicture.Size = new System.Drawing.Size(26, 26);
            this.homepicture.TabIndex = 13;
            this.homepicture.TabStop = false;
            // 
            // blabel
            // 
            this.blabel.AutoSize = true;
            this.blabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blabel.Location = new System.Drawing.Point(195, 133);
            this.blabel.Name = "blabel";
            this.blabel.Size = new System.Drawing.Size(22, 24);
            this.blabel.TabIndex = 14;
            this.blabel.Text = "B";
            // 
            // minuslabel
            // 
            this.minuslabel.AutoSize = true;
            this.minuslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuslabel.Location = new System.Drawing.Point(1, 180);
            this.minuslabel.Name = "minuslabel";
            this.minuslabel.Size = new System.Drawing.Size(26, 33);
            this.minuslabel.TabIndex = 15;
            this.minuslabel.Text = "-";
            // 
            // onelabel
            // 
            this.onelabel.AutoSize = true;
            this.onelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onelabel.Location = new System.Drawing.Point(1, 272);
            this.onelabel.Name = "onelabel";
            this.onelabel.Size = new System.Drawing.Size(20, 24);
            this.onelabel.TabIndex = 16;
            this.onelabel.Text = "1";
            // 
            // twolabel
            // 
            this.twolabel.AutoSize = true;
            this.twolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twolabel.Location = new System.Drawing.Point(195, 303);
            this.twolabel.Name = "twolabel";
            this.twolabel.Size = new System.Drawing.Size(20, 24);
            this.twolabel.TabIndex = 17;
            this.twolabel.Text = "2";
            // 
            // rightlabel
            // 
            this.rightlabel.AutoSize = true;
            this.rightlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightlabel.Location = new System.Drawing.Point(195, 71);
            this.rightlabel.Name = "rightlabel";
            this.rightlabel.Size = new System.Drawing.Size(21, 24);
            this.rightlabel.TabIndex = 18;
            this.rightlabel.Text = ">";
            // 
            // downlabel
            // 
            this.downlabel.AutoSize = true;
            this.downlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downlabel.Location = new System.Drawing.Point(195, 98);
            this.downlabel.Name = "downlabel";
            this.downlabel.Size = new System.Drawing.Size(19, 24);
            this.downlabel.TabIndex = 19;
            this.downlabel.Text = "v";
            // 
            // uplabel
            // 
            this.uplabel.AutoSize = true;
            this.uplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uplabel.Location = new System.Drawing.Point(3, 58);
            this.uplabel.Name = "uplabel";
            this.uplabel.Size = new System.Drawing.Size(19, 24);
            this.uplabel.TabIndex = 20;
            this.uplabel.Text = "^";
            // 
            // leftlabel
            // 
            this.leftlabel.AutoSize = true;
            this.leftlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftlabel.Location = new System.Drawing.Point(3, 85);
            this.leftlabel.Name = "leftlabel";
            this.leftlabel.Size = new System.Drawing.Size(21, 24);
            this.leftlabel.TabIndex = 21;
            this.leftlabel.Text = "<";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // boxplus
            // 
            this.boxplus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxplus.FormattingEnabled = true;
            this.boxplus.Location = new System.Drawing.Point(220, 206);
            this.boxplus.Name = "boxplus";
            this.boxplus.Size = new System.Drawing.Size(77, 21);
            this.boxplus.TabIndex = 24;
            this.boxplus.SelectedIndexChanged += new System.EventHandler(this.boxplus_SelectedIndexChanged);
            // 
            // boxhome
            // 
            this.boxhome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxhome.FormattingEnabled = true;
            this.boxhome.Location = new System.Drawing.Point(220, 166);
            this.boxhome.Name = "boxhome";
            this.boxhome.Size = new System.Drawing.Size(77, 21);
            this.boxhome.TabIndex = 25;
            this.boxhome.SelectedIndexChanged += new System.EventHandler(this.boxhome_SelectedIndexChanged);
            // 
            // boxdown
            // 
            this.boxdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxdown.FormattingEnabled = true;
            this.boxdown.Location = new System.Drawing.Point(220, 103);
            this.boxdown.Name = "boxdown";
            this.boxdown.Size = new System.Drawing.Size(77, 21);
            this.boxdown.TabIndex = 26;
            this.boxdown.SelectedIndexChanged += new System.EventHandler(this.boxdown_SelectedIndexChanged);
            // 
            // boxright
            // 
            this.boxright.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxright.FormattingEnabled = true;
            this.boxright.Location = new System.Drawing.Point(220, 74);
            this.boxright.Name = "boxright";
            this.boxright.Size = new System.Drawing.Size(77, 21);
            this.boxright.TabIndex = 27;
            this.boxright.SelectedIndexChanged += new System.EventHandler(this.boxright_SelectedIndexChanged);
            // 
            // boxup
            // 
            this.boxup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxup.FormattingEnabled = true;
            this.boxup.Location = new System.Drawing.Point(30, 58);
            this.boxup.Name = "boxup";
            this.boxup.Size = new System.Drawing.Size(77, 21);
            this.boxup.TabIndex = 28;
            this.boxup.SelectedIndexChanged += new System.EventHandler(this.boxup_SelectedIndexChanged);
            // 
            // boxleft
            // 
            this.boxleft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxleft.FormattingEnabled = true;
            this.boxleft.Location = new System.Drawing.Point(30, 88);
            this.boxleft.Name = "boxleft";
            this.boxleft.Size = new System.Drawing.Size(77, 21);
            this.boxleft.TabIndex = 29;
            this.boxleft.SelectedIndexChanged += new System.EventHandler(this.boxleft_SelectedIndexChanged);
            // 
            // boxa
            // 
            this.boxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxa.FormattingEnabled = true;
            this.boxa.Location = new System.Drawing.Point(30, 133);
            this.boxa.Name = "boxa";
            this.boxa.Size = new System.Drawing.Size(77, 21);
            this.boxa.TabIndex = 30;
            this.boxa.SelectedIndexChanged += new System.EventHandler(this.boxa_SelectedIndexChanged);
            // 
            // boxminus
            // 
            this.boxminus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxminus.FormattingEnabled = true;
            this.boxminus.Location = new System.Drawing.Point(32, 189);
            this.boxminus.Name = "boxminus";
            this.boxminus.Size = new System.Drawing.Size(77, 21);
            this.boxminus.TabIndex = 32;
            this.boxminus.SelectedIndexChanged += new System.EventHandler(this.boxminus_SelectedIndexChanged);
            // 
            // box1
            // 
            this.box1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box1.FormattingEnabled = true;
            this.box1.Location = new System.Drawing.Point(32, 272);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(77, 21);
            this.box1.TabIndex = 33;
            this.box1.SelectedIndexChanged += new System.EventHandler(this.box1_SelectedIndexChanged);
            // 
            // okbutton
            // 
            this.okbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okbutton.Location = new System.Drawing.Point(216, 354);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(75, 23);
            this.okbutton.TabIndex = 0;
            this.okbutton.Text = "OK";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // boxb
            // 
            this.boxb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxb.FormattingEnabled = true;
            this.boxb.Items.AddRange(new object[] {
            "RightClick",
            "BtnShift"});
            this.boxb.Location = new System.Drawing.Point(220, 135);
            this.boxb.Name = "boxb";
            this.boxb.Size = new System.Drawing.Size(77, 21);
            this.boxb.TabIndex = 45;
            this.boxb.SelectedIndexChanged += new System.EventHandler(this.boxb_SelectedIndexChanged);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.load});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 17);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // save
            // 
            this.save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.save.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.save.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.save.MergeIndex = 0;
            this.save.Name = "save";
            this.save.Padding = new System.Windows.Forms.Padding(0);
            this.save.Size = new System.Drawing.Size(98, 20);
            this.save.Text = "Save";
            this.save.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.save.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            this.load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.load.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.load.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.load.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.load.Name = "load";
            this.load.Padding = new System.Windows.Forms.Padding(0);
            this.load.Size = new System.Drawing.Size(98, 20);
            this.load.Text = "Load";
            this.load.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.load.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.presetsToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(303, 19);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // presetsToolStripMenuItem
            // 
            this.presetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultpreset,
            this.mediapreset,
            this.gomPlayer});
            this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            this.presetsToolStripMenuItem.Size = new System.Drawing.Size(55, 17);
            this.presetsToolStripMenuItem.Text = "Presets";
            // 
            // defaultpreset
            // 
            this.defaultpreset.Name = "defaultpreset";
            this.defaultpreset.Size = new System.Drawing.Size(128, 22);
            this.defaultpreset.Text = "Default";
            this.defaultpreset.Click += new System.EventHandler(this.defaultpreset_Click);
            // 
            // mediapreset
            // 
            this.mediapreset.Name = "mediapreset";
            this.mediapreset.Size = new System.Drawing.Size(128, 22);
            this.mediapreset.Text = "Media";
            this.mediapreset.Click += new System.EventHandler(this.mediapreset_Click);
            // 
            // gomPlayer
            // 
            this.gomPlayer.Name = "gomPlayer";
            this.gomPlayer.Size = new System.Drawing.Size(128, 22);
            this.gomPlayer.Text = "Gom Player";
            this.gomPlayer.Click += new System.EventHandler(this.gomPlayer_Click);
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(5, 356);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(100, 20);
            this.tb1.TabIndex = 46;
            // 
            // customlbl
            // 
            this.customlbl.AutoSize = true;
            this.customlbl.Location = new System.Drawing.Point(4, 340);
            this.customlbl.Name = "customlbl";
            this.customlbl.Size = new System.Drawing.Size(45, 13);
            this.customlbl.TabIndex = 47;
            this.customlbl.Text = "Custom:";
            // 
            // ypos
            // 
            this.ypos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ypos.FormattingEnabled = true;
            this.ypos.Location = new System.Drawing.Point(112, 17);
            this.ypos.Name = "ypos";
            this.ypos.Size = new System.Drawing.Size(77, 21);
            this.ypos.TabIndex = 48;
            this.ypos.SelectedIndexChanged += new System.EventHandler(this.ypos_SelectedIndexChanged);
            // 
            // yneg
            // 
            this.yneg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yneg.FormattingEnabled = true;
            this.yneg.Location = new System.Drawing.Point(112, 376);
            this.yneg.Name = "yneg";
            this.yneg.Size = new System.Drawing.Size(77, 21);
            this.yneg.TabIndex = 49;
            this.yneg.SelectedIndexChanged += new System.EventHandler(this.yneg_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 416);
            this.ControlBox = false;
            this.Controls.Add(this.yneg);
            this.Controls.Add(this.ypos);
            this.Controls.Add(this.customlbl);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.boxb);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.boxminus);
            this.Controls.Add(this.boxa);
            this.Controls.Add(this.boxleft);
            this.Controls.Add(this.boxup);
            this.Controls.Add(this.boxright);
            this.Controls.Add(this.boxdown);
            this.Controls.Add(this.boxhome);
            this.Controls.Add(this.boxplus);
            this.Controls.Add(this.leftlabel);
            this.Controls.Add(this.uplabel);
            this.Controls.Add(this.downlabel);
            this.Controls.Add(this.rightlabel);
            this.Controls.Add(this.twolabel);
            this.Controls.Add(this.onelabel);
            this.Controls.Add(this.minuslabel);
            this.Controls.Add(this.blabel);
            this.Controls.Add(this.homepicture);
            this.Controls.Add(this.pluslabel);
            this.Controls.Add(this.alabel);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Wiimote Remote";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.homepicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox box2;
        public System.Windows.Forms.Label alabel;
        public System.Windows.Forms.Label pluslabel;
        public System.Windows.Forms.PictureBox homepicture;
        public System.Windows.Forms.Label blabel;
        public System.Windows.Forms.Label minuslabel;
        public System.Windows.Forms.Label onelabel;
        public System.Windows.Forms.Label twolabel;
        public System.Windows.Forms.Label rightlabel;
        public System.Windows.Forms.Label downlabel;
        public System.Windows.Forms.Label uplabel;
        public System.Windows.Forms.Label leftlabel;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.ComboBox boxplus;
        public System.Windows.Forms.ComboBox boxhome;
        public System.Windows.Forms.ComboBox boxdown;
        public System.Windows.Forms.ComboBox boxright;
        public System.Windows.Forms.ComboBox boxleft;
        public System.Windows.Forms.ComboBox boxa;
        public System.Windows.Forms.ComboBox boxminus;
        public System.Windows.Forms.ComboBox box1;
        public System.Windows.Forms.Button okbutton;
        public System.Windows.Forms.ComboBox boxup;
        public System.Windows.Forms.ComboBox boxb;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem save;
        public System.Windows.Forms.ToolStripMenuItem load;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultpreset;
        private System.Windows.Forms.ToolStripMenuItem mediapreset;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.ToolStripMenuItem gomPlayer;
        private System.Windows.Forms.Label customlbl;
        public System.Windows.Forms.ComboBox ypos;
        public System.Windows.Forms.ComboBox yneg;


    }
}

