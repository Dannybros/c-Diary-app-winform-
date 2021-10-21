namespace Diary
{
    partial class wiritingDiary2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wiritingDiary2));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.panelAll = new System.Windows.Forms.Panel();
            this.rtbMain = new Diary.RIchTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFont = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnMidAlign = new System.Windows.Forms.PictureBox();
            this.btnLeftAlign = new System.Windows.Forms.PictureBox();
            this.btnRightAlign = new System.Windows.Forms.PictureBox();
            this.btnBullet = new System.Windows.Forms.PictureBox();
            this.btnUnderline = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.cbbFontSize = new System.Windows.Forms.ComboBox();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEmoji = new System.Windows.Forms.Label();
            this.btnPic = new System.Windows.Forms.PictureBox();
            this.btnDrawing = new System.Windows.Forms.PictureBox();
            this.panelProperty = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picWeather = new System.Windows.Forms.PictureBox();
            this.ComboIcon = new System.Windows.Forms.ComboBox();
            this.comboWeather = new System.Windows.Forms.ComboBox();
            this.picEmoji = new System.Windows.Forms.PictureBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.imagelist = new System.Windows.Forms.ImageList(this.components);
            this.rtbTitle = new System.Windows.Forms.RichTextBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.panelAll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMidAlign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeftAlign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRightAlign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBullet)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDrawing)).BeginInit();
            this.panelProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmoji)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.btnSave);
            this.panelTop.Controls.Add(this.btnCancel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1044, 81);
            this.panelTop.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(964, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 66);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(12, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 66);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelAll
            // 
            this.panelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            this.panelAll.Controls.Add(this.rtbMain);
            this.panelAll.Controls.Add(this.panel1);
            this.panelAll.Controls.Add(this.panelProperty);
            this.panelAll.Controls.Add(this.panelTop);
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(1044, 1021);
            this.panelAll.TabIndex = 1;
            // 
            // rtbMain
            // 
            this.rtbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            this.rtbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMain.ForeColor = System.Drawing.Color.White;
            this.rtbMain.Location = new System.Drawing.Point(13, 321);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbMain.ShowSelectionMargin = true;
            this.rtbMain.Size = new System.Drawing.Size(998, 688);
            this.rtbMain.TabIndex = 11;
            this.rtbMain.Text = "";
            this.rtbMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbMain_KeyUp);
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblFont);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btnBullet);
            this.panel1.Controls.Add(this.btnUnderline);
            this.panel1.Controls.Add(this.lblColor);
            this.panel1.Controls.Add(this.cbbFontSize);
            this.panel1.Controls.Add(this.btnItalic);
            this.panel1.Controls.Add(this.btnBold);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1044, 57);
            this.panel1.TabIndex = 5;
            // 
            // lblFont
            // 
            this.lblFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFont.ForeColor = System.Drawing.Color.Transparent;
            this.lblFont.Location = new System.Drawing.Point(0, 0);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(184, 55);
            this.lblFont.TabIndex = 29;
            this.lblFont.Text = "label1";
            this.lblFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnMidAlign);
            this.panel4.Controls.Add(this.btnLeftAlign);
            this.panel4.Controls.Add(this.btnRightAlign);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(606, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(163, 55);
            this.panel4.TabIndex = 28;
            // 
            // btnMidAlign
            // 
            this.btnMidAlign.Image = ((System.Drawing.Image)(resources.GetObject("btnMidAlign.Image")));
            this.btnMidAlign.Location = new System.Drawing.Point(62, 11);
            this.btnMidAlign.Name = "btnMidAlign";
            this.btnMidAlign.Size = new System.Drawing.Size(35, 35);
            this.btnMidAlign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMidAlign.TabIndex = 16;
            this.btnMidAlign.TabStop = false;
            this.btnMidAlign.Click += new System.EventHandler(this.btnMidAlign_Click);
            // 
            // btnLeftAlign
            // 
            this.btnLeftAlign.Image = ((System.Drawing.Image)(resources.GetObject("btnLeftAlign.Image")));
            this.btnLeftAlign.Location = new System.Drawing.Point(9, 11);
            this.btnLeftAlign.Name = "btnLeftAlign";
            this.btnLeftAlign.Size = new System.Drawing.Size(35, 35);
            this.btnLeftAlign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLeftAlign.TabIndex = 17;
            this.btnLeftAlign.TabStop = false;
            this.btnLeftAlign.Click += new System.EventHandler(this.btnLeftAlign_Click);
            // 
            // btnRightAlign
            // 
            this.btnRightAlign.Image = ((System.Drawing.Image)(resources.GetObject("btnRightAlign.Image")));
            this.btnRightAlign.Location = new System.Drawing.Point(115, 11);
            this.btnRightAlign.Name = "btnRightAlign";
            this.btnRightAlign.Size = new System.Drawing.Size(35, 35);
            this.btnRightAlign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRightAlign.TabIndex = 18;
            this.btnRightAlign.TabStop = false;
            this.btnRightAlign.Click += new System.EventHandler(this.btnRightAlign_Click);
            // 
            // btnBullet
            // 
            this.btnBullet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBullet.Image = ((System.Drawing.Image)(resources.GetObject("btnBullet.Image")));
            this.btnBullet.Location = new System.Drawing.Point(548, 10);
            this.btnBullet.Name = "btnBullet";
            this.btnBullet.Size = new System.Drawing.Size(35, 35);
            this.btnBullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBullet.TabIndex = 27;
            this.btnBullet.TabStop = false;
            this.btnBullet.Tag = "False";
            this.btnBullet.Click += new System.EventHandler(this.btnBullet_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnderline.FlatAppearance.BorderSize = 0;
            this.btnUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnderline.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnderline.ForeColor = System.Drawing.Color.White;
            this.btnUnderline.Location = new System.Drawing.Point(309, 10);
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(38, 37);
            this.btnUnderline.TabIndex = 23;
            this.btnUnderline.Text = "U";
            this.btnUnderline.UseVisualStyleBackColor = true;
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // lblColor
            // 
            this.lblColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.ForeColor = System.Drawing.Color.White;
            this.lblColor.Location = new System.Drawing.Point(477, 12);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(53, 35);
            this.lblColor.TabIndex = 19;
            this.lblColor.Text = "A";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // cbbFontSize
            // 
            this.cbbFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFontSize.FormattingEnabled = true;
            this.cbbFontSize.Items.AddRange(new object[] {
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "32",
            "34",
            "36",
            "38",
            "40",
            "42",
            "44",
            "46",
            "48",
            "50"});
            this.cbbFontSize.Location = new System.Drawing.Point(366, 17);
            this.cbbFontSize.Name = "cbbFontSize";
            this.cbbFontSize.Size = new System.Drawing.Size(98, 26);
            this.cbbFontSize.TabIndex = 14;
            this.cbbFontSize.Text = "14";
            this.cbbFontSize.SelectedIndexChanged += new System.EventHandler(this.cbbFontSize_SelectedIndexChanged);
            // 
            // btnItalic
            // 
            this.btnItalic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItalic.FlatAppearance.BorderSize = 0;
            this.btnItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItalic.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItalic.ForeColor = System.Drawing.Color.White;
            this.btnItalic.Location = new System.Drawing.Point(254, 11);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(38, 33);
            this.btnItalic.TabIndex = 13;
            this.btnItalic.Text = "I";
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnBold
            // 
            this.btnBold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBold.FlatAppearance.BorderSize = 0;
            this.btnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBold.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBold.ForeColor = System.Drawing.Color.White;
            this.btnBold.Location = new System.Drawing.Point(203, 11);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(38, 33);
            this.btnBold.TabIndex = 12;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEmoji);
            this.panel2.Controls.Add(this.btnPic);
            this.panel2.Controls.Add(this.btnDrawing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(769, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 55);
            this.panel2.TabIndex = 26;
            // 
            // btnEmoji
            // 
            this.btnEmoji.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnEmoji.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmoji.ForeColor = System.Drawing.Color.White;
            this.btnEmoji.Location = new System.Drawing.Point(99, 9);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(43, 35);
            this.btnEmoji.TabIndex = 23;
            this.btnEmoji.Text = "^_^";
            this.btnEmoji.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEmoji.Click += new System.EventHandler(this.btnEmoji_Click);
            // 
            // btnPic
            // 
            this.btnPic.Image = ((System.Drawing.Image)(resources.GetObject("btnPic.Image")));
            this.btnPic.Location = new System.Drawing.Point(19, 9);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(35, 35);
            this.btnPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPic.TabIndex = 15;
            this.btnPic.TabStop = false;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnDrawing
            // 
            this.btnDrawing.Image = ((System.Drawing.Image)(resources.GetObject("btnDrawing.Image")));
            this.btnDrawing.Location = new System.Drawing.Point(194, 10);
            this.btnDrawing.Name = "btnDrawing";
            this.btnDrawing.Size = new System.Drawing.Size(35, 35);
            this.btnDrawing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDrawing.TabIndex = 22;
            this.btnDrawing.TabStop = false;
            this.btnDrawing.Click += new System.EventHandler(this.btnDrawing_Click);
            // 
            // panelProperty
            // 
            this.panelProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProperty.Controls.Add(this.rtbTitle);
            this.panelProperty.Controls.Add(this.label1);
            this.panelProperty.Controls.Add(this.picWeather);
            this.panelProperty.Controls.Add(this.ComboIcon);
            this.panelProperty.Controls.Add(this.comboWeather);
            this.panelProperty.Controls.Add(this.picEmoji);
            this.panelProperty.Controls.Add(this.labelDate);
            this.panelProperty.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProperty.Location = new System.Drawing.Point(0, 81);
            this.panelProperty.Name = "panelProperty";
            this.panelProperty.Size = new System.Drawing.Size(1044, 159);
            this.panelProperty.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(10, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "You can change font \r\nin setting";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picWeather
            // 
            this.picWeather.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picWeather.Location = new System.Drawing.Point(492, 17);
            this.picWeather.Name = "picWeather";
            this.picWeather.Size = new System.Drawing.Size(130, 128);
            this.picWeather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picWeather.TabIndex = 9;
            this.picWeather.TabStop = false;
            // 
            // ComboIcon
            // 
            this.ComboIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            this.ComboIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboIcon.FormattingEnabled = true;
            this.ComboIcon.Location = new System.Drawing.Point(735, 110);
            this.ComboIcon.Name = "ComboIcon";
            this.ComboIcon.Size = new System.Drawing.Size(29, 37);
            this.ComboIcon.TabIndex = 10;
            // 
            // comboWeather
            // 
            this.comboWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            this.comboWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboWeather.FormattingEnabled = true;
            this.comboWeather.Location = new System.Drawing.Point(494, 110);
            this.comboWeather.Name = "comboWeather";
            this.comboWeather.Size = new System.Drawing.Size(29, 37);
            this.comboWeather.TabIndex = 8;
            this.comboWeather.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboWeather_DrawItem);
            this.comboWeather.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.comboWeather_MeasureItem);
            this.comboWeather.SelectedIndexChanged += new System.EventHandler(this.comboWeather_SelectedIndexChanged);
            // 
            // picEmoji
            // 
            this.picEmoji.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picEmoji.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEmoji.Location = new System.Drawing.Point(733, 17);
            this.picEmoji.Name = "picEmoji";
            this.picEmoji.Size = new System.Drawing.Size(130, 128);
            this.picEmoji.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmoji.TabIndex = 7;
            this.picEmoji.TabStop = false;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelDate.Location = new System.Drawing.Point(886, 52);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(145, 53);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imagelist
            // 
            this.imagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelist.ImageStream")));
            this.imagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelist.Images.SetKeyName(0, "Sunny");
            this.imagelist.Images.SetKeyName(1, "Rainy");
            this.imagelist.Images.SetKeyName(2, "Cloudy");
            this.imagelist.Images.SetKeyName(3, "Stormy");
            this.imagelist.Images.SetKeyName(4, "Snowy");
            this.imagelist.Images.SetKeyName(5, "Night");
            // 
            // rtbTitle
            // 
            this.rtbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            this.rtbTitle.Font = new System.Drawing.Font("Times New Roman", 36F);
            this.rtbTitle.Location = new System.Drawing.Point(13, 39);
            this.rtbTitle.Name = "rtbTitle";
            this.rtbTitle.Size = new System.Drawing.Size(441, 76);
            this.rtbTitle.TabIndex = 12;
            this.rtbTitle.Text = "";
            // 
            // wiritingDiary2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 1021);
            this.Controls.Add(this.panelAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wiritingDiary2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wiritingDiary2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.wiritingDiary2_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.panelAll.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMidAlign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeftAlign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRightAlign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBullet)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDrawing)).EndInit();
            this.panelProperty.ResumeLayout(false);
            this.panelProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWeather)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmoji)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelAll;
        private System.Windows.Forms.Panel panelProperty;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboWeather;
        private System.Windows.Forms.PictureBox picEmoji;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox btnRightAlign;
        private System.Windows.Forms.PictureBox btnLeftAlign;
        private System.Windows.Forms.PictureBox btnMidAlign;
        private System.Windows.Forms.PictureBox btnPic;
        private System.Windows.Forms.ComboBox cbbFontSize;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnUnderline;
        private System.Windows.Forms.PictureBox btnDrawing;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnCancel;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox btnBullet;
        private System.Windows.Forms.PictureBox picWeather;
        private System.Windows.Forms.ImageList imagelist;
        private System.Windows.Forms.ComboBox ComboIcon;
        private RIchTextBox rtbMain;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnEmoji;
        private System.Windows.Forms.RichTextBox rtbTitle;
    }
}