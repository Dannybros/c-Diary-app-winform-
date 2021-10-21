using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Diary
{
    public partial class wiritingDiary2 : Form
    {   
        List<string> fonts = new List<string>();
        string DiaryID;
        bool bold, italic, under;

        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        
        ////////////////////
        ///////////////
        ////    Inserting values when Loading....
        ///
        public wiritingDiary2(string Date)
        {
            InitializeComponent();
            labelDate.Text = Date;
            DiaryID = generateGUID();
        }

        private void wiritingDiary2_Load(object sender, EventArgs e)
        {
            bold = false;
            italic = false;
            under = false;

            GetallImage();
            //lblFont.Text =Wording_Properties.Official_Font;
            ListFormats();
            cbbFontSize.Text = Wording_Properties.Official_FontSize.ToString();
            
            rtbMain.Font = new Font(Wording_Properties.Official_Font, float.Parse(cbbFontSize.Text));
            rtbMain.ForeColor = Wording_Properties.fontcolor;
            lblColor.ForeColor = Wording_Properties.fontcolor;
            rtbMain.AcceptsTab = true;
            //rtbMain.SelectionIndent = 15;
            picWeather.Image = Image.FromFile(Application.StartupPath + "\\weatherPic\\weatherIcon.jpg");
            
            
        }

        ////////////////////
        ///////////////
        ////    Functions......
        ///

        // generating GUID ID 
        private string generateGUID()
        {
            //string newGUID = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            string i = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            return i;
        }

        //Get weather icon images from debug and allocate to imagelist 
        //Adding imagelist to combobox and dynamically arrange location
        private void GetallImage()
        {
            string[] img = new string[this.imagelist.Images.Count - 1 + 1];

            for (int i = 0; i <= this.imagelist.Images.Count - 1; i++)
            {
                img[i] = "Item " + i.ToString();
            }
        
            this.comboWeather.Location = new Point(picWeather.Location.X, picWeather.Location.Y+picWeather.Height-comboWeather.Height);
            this.comboWeather.Items.AddRange(img);
            this.comboWeather.DrawMode = DrawMode.OwnerDrawVariable;
            this.comboWeather.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboWeather.Width = picWeather.Width + 20;
            this.comboWeather.MaxDropDownItems = this.imagelist.Images.Count;
            this.ComboIcon.Location = new Point(picEmoji.Location.X, picEmoji.Location.Y + picEmoji.Height - ComboIcon.Height);
        }

        private void ListFormats()
        {
            try { 
            string bold = "Non-Bold", italic= "Non-Italic", under="Non-Underline";
            if (rtbMain.SelectionFont.Bold == true)
            {
                bold = "Bold";
            }
           
            if (rtbMain.SelectionFont.Italic == true)
            {
                italic = "Italic";
            }

            if (rtbMain.SelectionFont.Underline == true)
            {
                under = "Underline";
            }


            string font = "#" + Wording_Properties.fontcolor.R.ToString("X2")+ Wording_Properties.fontcolor.G.ToString("X2")+ Wording_Properties.fontcolor.B.ToString("X2");

            lblFont.Text= string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Wording_Properties.Official_Font, Wording_Properties.Official_FontSize, 
                font, bold, italic, under);
            }
            catch
            {
                MessageBox.Show("Cant use bold");
            }
        }

        public void InsertStringToRTB(string s)
        {
            rtbMain.AppendText("  "+s);
        }

        // Openining Color Dialog and set background color of button_color
        private void OpenColorDialog()
        {
            var top = lblColor.PointToScreen(new Point(0, 0));
            ColorDialogPosition cd = new ColorDialogPosition(top.X-lblColor.Width/2, top.Y+ lblColor.Height);

            cd.AllowFullOpen = false;
            cd.ShowHelp = true;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SelectionColor = cd.Color;
                lblColor.ForeColor = cd.Color;
                Wording_Properties.fontcolor = cd.Color;
                ListFormats();
            }
        }
       
        private void refreshFont_Size()
        {
            Wording_Properties.Clicked_FontSize = float.Parse(cbbFontSize.Text);
            
            selectBold_Italic();
            rtbMain.Focus();
        }
        
        public async Task addPictures(Bitmap bm)
        {
            rtbMain.AppendText(Environment.NewLine);
            rtbMain.AppendText(Environment.NewLine);
            string rtf = rtbMain.Rtf;
            string imagetRtf = addImageRTF.ImageString(bm, rtbMain.Width);
            string para = string.Format(@"\par \par");
            rtbMain.Rtf = rtf.Trim().TrimEnd('}') + imagetRtf +para+ "}";

            //var orgdata = Clipboard.GetDataObject();
            //Clipboard.SetImage(pb);
            //rtbMain.AppendText(Environment.NewLine);
            //rtbMain.Paste();
            //Clipboard.SetDataObject(orgdata);


            ///////Extensive forcibly add it to richtextbox but won't get written well in rtf file
            //AddImageToRtb(pb);
        }

        private void selectBold_Italic()
    {
            if (bold == true && italic == true && under == true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Bold | FontStyle.Underline | FontStyle.Italic);
            }
            else if (bold == true && italic != true && under != true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Bold);
            }
            else if (bold != true && italic != true && under == true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Underline);
            }
            else if (bold != true && italic == true && under != true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Italic);
            }
            else if (bold == true && italic == true && under != true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Bold | FontStyle.Italic);
            }
            else if (bold == true && italic != true && under == true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Bold | FontStyle.Underline);
            }
            else if (bold != true && italic == true && under == true)
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Italic | FontStyle.Underline);
            }
            else
            {
                rtbMain.SelectionFont = new Font(lblFont.Text, float.Parse(cbbFontSize.Text), FontStyle.Regular);
            }
        }

        
        
        ////    When clicking the buttons & Labels & pictureBox...

        //////// Word properties
        private void lblColor_Click(object sender, EventArgs e)
        {
            OpenColorDialog();
        }
        
        private void cbbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFont_Size();
        }

        private void cbbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshFont_Size();
            ListFormats();
        }
        
        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectAll();
            rtbMain.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void btnMidAlign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectAll();
            rtbMain.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            rtbMain.SelectAll();
            rtbMain.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if(bold == true)
            {
                bold = false;
                btnBold.FlatAppearance.BorderSize = 0;
                btnBold.FlatAppearance.BorderColor = Color.FromArgb(6, 33, 52);
                btnBold.BackColor = Color.FromArgb(6, 33, 52);
            }
            else
            {
                bold = true;
                btnBold.FlatAppearance.BorderSize = 1;
                btnBold.BackColor = Color.FromArgb(35, 53, 77);
                btnBold.FlatAppearance.BorderColor = Color.FromArgb(87, 154, 185);
            }

            refreshFont_Size();
            ListFormats();
            rtbMain.Focus();
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (italic == true)
            {
                italic = false;
                btnItalic.FlatAppearance.BorderSize = 0;
                btnItalic.FlatAppearance.BorderColor = Color.FromArgb(6, 33, 52);
                btnItalic.BackColor = Color.FromArgb(6, 33, 52);
            }
            else
            {
                italic = true;
                btnItalic.FlatAppearance.BorderSize = 1;
                btnItalic.BackColor = Color.FromArgb(35, 53, 77);
                btnItalic.FlatAppearance.BorderColor = Color.FromArgb(87, 154, 185);
            }

            refreshFont_Size();
            ListFormats();
            rtbMain.Focus();
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (under == true)
            {
                under = false;
                btnUnderline.FlatAppearance.BorderSize = 0;
                btnUnderline.FlatAppearance.BorderColor = Color.FromArgb(6, 33, 52);
                btnUnderline.BackColor = Color.FromArgb(6, 33, 52);
            }
            else
            {
                under = true;
                btnUnderline.FlatAppearance.BorderSize = 1;
                btnUnderline.BackColor = Color.FromArgb(35, 53, 77);
                btnUnderline.FlatAppearance.BorderColor = Color.FromArgb(87, 154, 185);
                
            }

            refreshFont_Size();
            rtbMain.Focus();
            ListFormats();
        }

        private void btnBullet_Click(object sender, EventArgs e)
        {
            if(btnBullet.Tag.ToString() == "False")
            {
                rtbMain.SelectionBullet = true;
                rtbMain.BulletIndent = 5;
                btnBullet.Tag = "True";
            }
            else
            {
                rtbMain.SelectionBullet = false;
                btnBullet.Tag= "False";
            }
            
        }
        
        private void rtbMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                rtbMain.SelectionIndent = 15;
            }

            if (e.KeyCode == Keys.Enter)
            {
                //rtbMain.SelectionIndent = 15;
            }

        }

        // To add image to richTextBox 
        private async void btnPic_Click(object sender, EventArgs e)
        {
            Image pb;
            OpenFileDialog dlg = new OpenFileDialog();
            
            dlg.Filter = "Images |*.bmp;*.jpg;*.png;*.gif;*.ico";
            
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pb = Image.FromFile(dlg.FileName);

            ////////    dynamically modify rtf code to insert image 
                Bitmap pic = new Bitmap(pb);

                this.Cursor = Cursors.WaitCursor;
                await addPictures(pic);
                this.Cursor = this.DefaultCursor;
            }
            dlg.Dispose();
        }

        // lead drawing panel
        private void btnDrawing_Click(object sender, EventArgs e)
        {
            paint pt = new paint();
            pt.Show();
        }
        
        //to record audio
        private void btnMic_Click(object sender, EventArgs e)
        {
            AudioTest aw = new AudioTest();
            aw.Show();
            aw.StartPosition = FormStartPosition.CenterScreen;
        }
        
        //adding image to combobox of Weather icons
        private void comboWeather_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index >= 0)
            {
                e.Graphics.DrawImage(imagelist.Images[e.Index], e.Bounds.Left, e.Bounds.Top);
                e.Graphics.DrawString(this.imagelist.Images.Keys[e.Index].ToString(), new Font("Times News Roman", 13),
                   new SolidBrush(Color.White), e.Bounds.Left + imagelist.ImageSize.Width + 10, e.Bounds.Top + 20);
            }
        }

        private void comboWeather_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemWidth = imagelist.ImageSize.Width;
            e.ItemHeight = imagelist.ImageSize.Height;
        }

        private void comboWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = imagelist.Images.Keys[comboWeather.SelectedIndex];
            Image img = Image.FromFile(Application.StartupPath + "\\weatherPic\\" + name + ".jpg");
            picWeather.Image = img;
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            wordEmoji we = new wordEmoji();
            int width = we.Width - btnEmoji.Width;
            we.StartPosition = FormStartPosition.Manual;
            var topLeft = btnEmoji.PointToScreen(new Point(0, 0));
            we.Show();
            we.Location = new Point(topLeft.X - width, topLeft.Y + btnEmoji.Height);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            rtbMain.Text = "";
            rtbTitle.Text = "";
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `content_diary`(`ID`, `Title`,`Weather`, `Date`, `Content`) VALUES (@id, @title,@weather, @date, @content)", con);
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = DiaryID;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = rtbTitle.Text;

            MemoryStream ms = new MemoryStream();
            picWeather.Image.Save(ms, picWeather.Image.RawFormat);


            cmd.Parameters.AddWithValue("@weather",ms.ToArray());
            cmd.Parameters.Add("@Date", MySqlDbType.VarChar).Value = labelDate.Text; //Wording_Properties.Clicked_Date
            cmd.Parameters.Add("@content", MySqlDbType.LongBlob).Value = Encoding.ASCII.GetBytes(rtbMain.Rtf);

            //rtbMain.SaveFile("temp.rtf");
            //stream = new FileStream("temp.rtf", FileMode.Open, FileAccess.Read);
            //int size = Convert.ToInt32(stream.Length);

            //byte[] rtf = new byte[size];
            //stream.Read(rtf, 0, size);

            //MySqlParameter paramRFT = new MySqlParameter("@content", MySqlDbType.LongBlob, rtf.Length,
            //    ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, rtf);
            //cmd.Parameters.AddWithValue("@content", paramRFT);

            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Saved");

                //File.Delete("temp.rtf");
            }
            else
            {
                MessageBox.Show("Sorry, Register failed, try again.");
            }
            con.Close();
        }
    }
}