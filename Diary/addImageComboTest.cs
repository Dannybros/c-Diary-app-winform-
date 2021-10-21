using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Diary
{
    public partial class addImageComboTest : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        List<string> fonts = new List<string>();
        public addImageComboTest()
        {
            InitializeComponent();
            //loadrichtextBoxContent();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }

            for (int i = 0; i < fonts.Count; i++)
            {
                comboBox2.Items.Add(fonts[i]);
            }
        }

        private void SaveAudioName_Load(object sender, EventArgs e)
        {
            string[] img = new string[this.imagelist.Images.Count - 1 + 1];

            for(int i=0; i<=this.imagelist.Images.Count-1; i++)
            {
                img[i] = "Item " + i.ToString();
            }

            this.comboBox1.Items.AddRange(img);
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.Width = this.imagelist.ImageSize.Width +280;
            this.comboBox1.MaxDropDownItems = this.imagelist.Images.Count;
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.Graphics.DrawImage(this.imagelist.Images[e.Index], e.Bounds.Left, e.Bounds.Top);
                e.Graphics.DrawString(this.imagelist.Images.Keys[e.Index].ToString(), e.Font, 
                    new SolidBrush(Color.Green), e.Bounds.Left + imagelist.ImageSize.Width+10, e.Bounds.Top + 20);
            }
        }

        private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = this.imagelist.ImageSize.Height;
            e.ItemWidth = this.imagelist.ImageSize.Width;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = imagelist.Images.Keys[comboBox1.SelectedIndex];
            Image img = Image.FromFile(Application.StartupPath + "\\weatherPic\\" + name + ".jpg");
            pictureBox1.Image = img;
        }

        private void loadrichtextBoxContent()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT `Content` FROM `content_diary` WHERE `Title`=@no", con);
            cmd.Parameters.AddWithValue("@no", "exam");
            MySqlDataReader dr = null;
            string k ="";
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())   
                {
                    //k += dr["Content"].ToString();
                    //byte[] testRtf = Encoding.ASCII.GetBytes(k);

                    //MemoryStream ms = new MemoryStream(testRtf);
                    //rtbTest.LoadFile(ms, RichTextBoxStreamType.RichText);

                    byte[] rtf = new byte[Convert.ToInt32((dr.GetBytes(0, 0,
                                                   null, 0, Int32.MaxValue)))];
                    long bytesReceived = dr.GetBytes(0, 0, rtf, 0, rtf.Length);
                    rtbTest.Rtf = Encoding.ASCII.GetString(rtf, 0, Convert.ToInt32(bytesReceived));
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (null != dr) dr.Close();
                if (null != con) con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                rtbTest.LoadFile(openFile1.FileName);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            rtbTest.Font = new Font(comboBox2.Text, 14);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rtf = rtbTest.Rtf;
            rtbTest.Text = rtf;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtbTest.Rtf = rtbTest.Text;
        }
    }
} 
//string rtfText = dr["Content"].ToString();
//MemoryStream ms = new MemoryStream(rtf);
//rIchTextBox1.LoadFile(ms, RichTextBoxStreamType.RichText);

//ASCIIEncoding encoding = new ASCIIEncoding();
//rIchTextBox1.Rtf = encoding.GetString(rtf, 0, Convert.ToInt32(bytesReceived));
//string test = dr["Content"].ToString();
//rtbTest.Text = test;
