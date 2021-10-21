using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Diary
{
    public partial class saveDialog : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        Home hm = (Home)Application.OpenForms["Home"];
        string name, DiaryID;

        public saveDialog(string Date, string Title)
        {
            InitializeComponent();
            labelDate.Text = Date;
            name = Title;
            loadMysqldiaryContent();
            GetallImage();
            Empty_Clear();
        }

        private void GetallImage()
        {
            string[] img = new string[this.imagelist.Images.Count - 1 + 1];

            for (int i = 0; i <= this.imagelist.Images.Count - 1; i++)
            {
                img[i] = "Item " + i.ToString();
            }

            this.comboWeather.Location = new Point(picWeather.Location.X, picWeather.Location.Y + picWeather.Height - comboWeather.Height);
            this.comboWeather.Items.AddRange(img);
            this.comboWeather.DrawMode = DrawMode.OwnerDrawVariable;
            this.comboWeather.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboWeather.Width = picWeather.Width + 20;
            this.comboWeather.MaxDropDownItems = this.imagelist.Images.Count;
        }

        private void loadMysqldiaryContent()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT `Content`,`ID`, `Weather` FROM `content_diary` WHERE `Title`=@no AND `Date`=@date", con);
            cmd.Parameters.AddWithValue("@no", name);
            cmd.Parameters.AddWithValue("@date", labelDate.Text);
            MySqlDataReader dr = null;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //k += dr["Content"].ToString();
                    //byte[] rtf = Encoding.ASCII.GetBytes(k);
                    //DiaryID = dr["ID"].ToString();
                    DiaryID = dr["ID"].ToString();
                    byte[] rtf = (byte[])dr["Content"];
                    //byte[] rtf = new byte[Convert.ToInt32((dr.GetBytes(0, 0,null, 0, Int32.MaxValue)))];
                    long bytesReceived = dr.GetBytes(0, 0, rtf, 0, rtf.Length);
                    rtbMain.Rtf = Encoding.ASCII.GetString(rtf, 0, Convert.ToInt32(bytesReceived));

                    rtbTitle.Text = name;

                    byte[] img = (byte[])dr["Weather"];
                    MemoryStream ms = new MemoryStream(img);
                    Image image = new Bitmap(ms);
                    picWeather.Image = image;

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `content_diary` WHERE `Title`=@no AND `Date`=@date", con);
            cmd.Parameters.AddWithValue("@no", name);
            cmd.Parameters.AddWithValue("@date", labelDate.Text);
            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Diary has been deleted!");
                picEmoji.Image = null;
                picWeather.Image = null;
                rtbMain.Text = "";
                rtbTitle.Text = "";
                hm.Show();
                this.Close();
            }
            con.Close();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `content_diary` SET`Weather`=@weather,`Title`=@title,`Content`=@content WHERE `ID`=@id AND`Date`=@date", con);

            MemoryStream ms = new MemoryStream();
            picWeather.Image.Save(ms, picWeather.Image.RawFormat);

            cmd.Parameters.AddWithValue("@weather", ms.ToArray());
            cmd.Parameters.AddWithValue("@title", rtbTitle.Text);
            cmd.Parameters.Add("@content", MySqlDbType.LongBlob).Value = Encoding.ASCII.GetBytes(rtbMain.Rtf);
            cmd.Parameters.AddWithValue("@id", DiaryID);
            cmd.Parameters.AddWithValue("@date", labelDate.Text);

            con.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Updated successfully!");
                Empty_Clear(); 
               
            }
            else
            {
                MessageBox.Show("Failed.");
            }
            con.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableForSave();
        }

        private void Empty_Clear()
        {
            btnEdit.Enabled = true;
            btnEdit.Visible = true;

            btnSave.Visible = false;
            btnSave.Enabled = false;

            panel1.Visible = false;
            rtbMain.ReadOnly = true;
            rtbTitle.ReadOnly = true;
            comboWeather.Enabled = false;
            ComboIcon.Enabled = false;

            panelAll.BackColor = Color.FromArgb(6, 33, 40);
            panelProperty.BackColor = Color.FromArgb(6, 33, 40);

            rtbMain.BackColor = Color.FromArgb(6, 33, 40);
            rtbTitle.BackColor = Color.FromArgb(6, 33, 40);
        }

        private void EnableForSave()
        {
            btnEdit.Visible = false;
            btnEdit.Enabled = false;

            panel1.Visible = true;
            rtbMain.ReadOnly = false;
            rtbTitle.ReadOnly = false;
            comboWeather.Enabled = true;
            ComboIcon.Enabled = true;
            panelAll.BackColor = Color.FromArgb(6, 33, 52);
            panelProperty.BackColor = Color.FromArgb(6, 33, 52);

            rtbMain.BackColor = Color.FromArgb(6, 33, 52);
            rtbTitle.BackColor = Color.FromArgb(6, 33, 52);

            btnSave.Enabled = true;
            btnSave.Visible = true;
        }
        private void comboWeather_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            hm.Show();
            this.Close();
        }

        private void comboWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = imagelist.Images.Keys[comboWeather.SelectedIndex];
            Image img = Image.FromFile(Application.StartupPath + "\\weatherPic\\" + name + ".jpg");
            picWeather.Image = img;
        }
       
    }
}
