namespace Diary
{
    partial class showListDiary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(showListDiary));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LableDate = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnWriteDiary = new System.Windows.Forms.PictureBox();
            this.ContentList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWriteDiary)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LableDate);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 111);
            this.panel1.TabIndex = 0;
            // 
            // LableDate
            // 
            this.LableDate.AutoSize = true;
            this.LableDate.BackColor = System.Drawing.Color.Transparent;
            this.LableDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.LableDate.Location = new System.Drawing.Point(966, 44);
            this.LableDate.Name = "LableDate";
            this.LableDate.Size = new System.Drawing.Size(53, 21);
            this.LableDate.TabIndex = 2;
            this.LableDate.Text = "label2";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(51, 44);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(348, 36);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tiles",
            "Details"});
            this.comboBox1.Location = new System.Drawing.Point(662, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Tiles";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(18)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnWriteDiary);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 699);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 139);
            this.panel2.TabIndex = 2;
            // 
            // btnWriteDiary
            // 
            this.btnWriteDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnWriteDiary.Image = ((System.Drawing.Image)(resources.GetObject("btnWriteDiary.Image")));
            this.btnWriteDiary.Location = new System.Drawing.Point(528, 22);
            this.btnWriteDiary.Name = "btnWriteDiary";
            this.btnWriteDiary.Size = new System.Drawing.Size(94, 93);
            this.btnWriteDiary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnWriteDiary.TabIndex = 1;
            this.btnWriteDiary.TabStop = false;
            this.btnWriteDiary.Click += new System.EventHandler(this.btnWriteDiary_Click);
            // 
            // ContentList
            // 
            this.ContentList.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ContentList.BackgroundImage")));
            this.ContentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentList.ForeColor = System.Drawing.Color.White;
            this.ContentList.Location = new System.Drawing.Point(0, 111);
            this.ContentList.Name = "ContentList";
            this.ContentList.Size = new System.Drawing.Size(1132, 588);
            this.ContentList.TabIndex = 3;
            // 
            // showListDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1132, 838);
            this.Controls.Add(this.ContentList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "showListDiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "showListDiary";
            this.Load += new System.EventHandler(this.showListDiary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnWriteDiary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btnWriteDiary;
        private System.Windows.Forms.FlowLayoutPanel ContentList;
        private System.Windows.Forms.Label LableDate;
    }
}