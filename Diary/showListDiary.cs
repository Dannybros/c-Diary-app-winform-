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
    public partial class showListDiary : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        MySqlCommand cmd = new MySqlCommand("SELECT `ID`, `Weather`, `Title`, `Date`, `Content` FROM `content_diary`");

        public showListDiary()
        {
            InitializeComponent();
            comboBox1.Text = "Details";
           

            LableDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void showList(MySqlCommand cmd)
        {
            ContentList.Controls.Clear();
            cmd.Connection = con;
           
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);

            int count = DiaryCount();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (comboBox1.Text == "Tiles")
                    {

                        GradientFlowPanel box = new GradientFlowPanel();
                        box.Width = (int)(ContentList.Width * 0.9);
                        box.Height = 120;
                        box.BackColor = Color.FromArgb(119, 57, 135);
                        box.TopColor = Color.FromArgb(203, 43, 94);
                        box.angle = 180;
                        box.Tag = ds.Tables[0].Rows[i]["ID"].ToString();
                        box.BorderStyle = BorderStyle.FixedSingle;
                        box.Margin = new Padding(20, 30, 0, 0);

                        Label date = new Label();
                        date.Width = 100;
                        date.AutoSize = false;
                        date.TextAlign = ContentAlignment.MiddleCenter;
                        date.Height = box.Height;
                        date.Text = ds.Tables[0].Rows[i]["Date"].ToString();
                        date.ForeColor = Color.White;
                        date.BackColor = Color.Transparent;
                        date.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        box.Controls.Add(date);

                        PictureBox pb = new PictureBox();
                        pb.Width = box.Height;
                        pb.Height = box.Height - 10;
                        pb.Margin = new Padding(0, 5, 0, 0);
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        byte[] array = (byte[])ds.Tables[0].Rows[i]["Weather"];
                        MemoryStream ms = new MemoryStream();
                        ms.Write(array, 0, array.Length);
                        Image bt = Image.FromStream(ms, true);
                        pb.Image = bt;
                        box.Controls.Add(pb);


                        Label Title = new Label();
                        Title.Height = box.Height;
                        Title.Margin = new Padding(10, 0, 0, 10);
                        Title.Width = box.Width - pb.Width - date.Width - 30;
                        Title.Text = ds.Tables[0].Rows[i]["Title"].ToString();
                        Title.AutoSize = false;
                        Title.ForeColor = Color.White;
                        Title.BackColor = Color.Transparent;
                        Title.TextAlign = ContentAlignment.MiddleCenter;
                        Title.Font = new Font("Times New Roman", 30, FontStyle.Bold | FontStyle.Underline);

                        box.Controls.Add(Title);

                        foreach (Control control in box.Controls)
                        {
                            control.Click += (s, e) =>
                            {
                                saveDialog sv = new saveDialog(date.Text, Title.Text);

                                this.Hide();
                                sv.Show();
                            };
                        }

                        ContentList.Controls.Add(box);

                    }
                    else
                    {

                        FlowLayoutPanel box = new FlowLayoutPanel();
                        box.Width = 130;
                        box.Height = 130;
                        box.Tag = ds.Tables[0].Rows[i]["ID"].ToString();
                        box.Margin = new Padding(10, 10, 10, 10);

                        string date = ds.Tables[0].Rows[i]["Date"].ToString();
                        string[] mmdd = date.Split('-');
                        int month = Convert.ToInt32(mmdd[1]);
                        string day = (Convert.ToInt32(mmdd[2])).ToString("D2");

                        Label Month = new Label();
                        Month.AutoSize = false;
                        Month.Width = box.Width;
                        Month.TextAlign = ContentAlignment.MiddleCenter;
                        Month.Text = monthText(month);
                        Month.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        Month.Height = 25;
                        Month.ForeColor = Color.Black;
                        Month.BackColor = Color.FromArgb(235, 133, 133);
                        box.Controls.Add(Month);

                        Label Day = new Label();
                        Day.AutoSize = false;
                        Day.TextAlign = ContentAlignment.MiddleCenter;
                        Day.Width = box.Width;
                        Day.Text = day;
                        Day.Font = new Font("Times New Roman", 16, FontStyle.Bold);
                        Day.Height = 80;
                        Day.ForeColor = Color.Black;
                        Day.BackColor = Color.White;
                        box.Controls.Add(Day);

                        Label title = new Label();
                        title.AutoSize = false;
                        title.Width = box.Width;
                        title.ForeColor = Color.White;
                        title.TextAlign = ContentAlignment.MiddleCenter;
                        title.Text = ds.Tables[0].Rows[i]["Title"].ToString();
                        title.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                        title.Height = 25;
                        title.BackColor = Color.FromArgb(6, 33, 52);
                        box.Controls.Add(title);
                        ContentList.Controls.Add(box);

                        foreach (Control cont in box.Controls)
                        {
                            cont.Click += (s, e) =>
                            {
                                saveDialog sv = new saveDialog(date, title.Text);

                                this.Hide();
                                sv.Show();
                            };
                        }
                    }
                }
            }
            catch { }
        }

        private int DiaryCount()
        {
            int count;
            MySqlCommand cmd = new MySqlCommand("Select * From content_diary", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adp.Fill(dt);

            con.Open();

            count = dt.Tables[0].Rows.Count;
            
            con.Close();

            return count;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showList(cmd);
        }

        private string monthText(int s)
        {
            string text="";
            if (s == 1)
            {
                text = "January";
            }
            else if (s == 2)
            {
                text = "Feburary";
            }
            else if (s == 3) text = "March";
            else if (s == 4) text = "April";
            else if (s == 5) text = "May";
            else if (s == 6) text = "June";
            else if (s == 7) text = "July";
            else if (s == 8) text = "August";
            else if (s == 9) text = "September";
            else if (s == 10) text = "October";
            else if (s == 11) text = "November";
            else if (s == 12) text = "December";
            return text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("SELECT `ID`, `Weather`, `Title`, `Date`, `Content` FROM `content_diary` WHERE CONCAT (`Title`, `Date`) LIKE '%" + txtSearch.Text +"%'", con);
            showList(cm);
        }

        private void btnWriteDiary_Click(object sender, EventArgs e)
        {
            calender cl = new calender();
            cl.Show();
        }

        private void showListDiary_Load(object sender, EventArgs e)
        {
            showList(cmd);
        }
    }
}
