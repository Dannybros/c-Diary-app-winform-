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

namespace Diary
{
    public partial class calender : Form
    {
        Home hm = (Home)Application.OpenForms["Home"];
        MySqlConnection con = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        List<string> listStoredDate = new List<string>();

        string currentyear, currentmonth, currentdate, clickedDate;
        int clickedMonth, clickedYear;
        string[] DayNames = new string[7]{"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" }; 

        string diaryTitle;

        Button[] btnMonth;
        DateTime currentTime =DateTime.Today;
        List<FlowLayoutPanel> listFLDay = new List<FlowLayoutPanel>();

        public calender()
        {
            InitializeComponent();

            btnMonth = new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12 };
            Count_AddMysqlColumns(); 
            FirstUIonLoad();
           
            clickbtnMonthEvent();
        }


        private void calender_Load(object sender, EventArgs e)
        {
            TopMost = true;
            //WindowState = FormWindowState.Maximized;
            addlabel();
            generateDate();
        }


        private void addlabel()
        {
            int widht = this.Width / 7;
            for (int i=0; i<7; i++)
            {
                Label lb = new Label();
                lb.Text = DayNames[i];
                lb.Margin = new Padding(0, 0, 0, 0);
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Font = new Font("Playball", 14, FontStyle.Bold);
                lb.ForeColor = Color.White;
                lb.AutoSize = false;
                lb.Width = widht;
                lb.Height = PanelMain.Height;
                PanelMain.Controls.Add(lb);
            }
            
        }
        // What to show when first loaded
        //
        private void FirstUIonLoad()
        {
            currentyear = currentTime.ToString("yyyy");
            currentmonth = currentTime.ToString("MM");
            currentdate = currentTime.ToString("dd");

            clickedYear = int.Parse(currentyear);
            clickedMonth = int.Parse(currentmonth);

            lblMonth.Text = DateTime.Today.ToString("MMMM");
            lblYear.Text = currentyear;

            for (int i = 0; i <= btnMonth.Length-1; i++)
            {
                if (int.Parse(btnMonth[i].Text) == int.Parse(currentmonth))
                {
                    btnMonth[i].BackColor = Color.FromArgb(236, 150, 109);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
            hm.Show();
        }
        
        //background color change on a clicked month label
        //
        private void clickbtnMonthEvent()
        {
            foreach (var b in btnMonth)
            {
                b.Click += (s, e) =>
                {
                    clickedMonth = int.Parse(b.Text);
                    for (int i = 0; i <= btnMonth.Length - 1; i++)
                    {
                         btnMonth[i].BackColor = Color.FromArgb(31, 47, 122);
                    }
                    b.BackColor = Color.FromArgb(236, 150, 109);
                    lblMonth.Text = b.Tag.ToString();
                    generateDate();
                    
                }; 
            }
        }
        

        // Increasing & Decreasing Year
        //
        private void btnInc_Click(object sender, EventArgs e)
        {
            clickedYear += 1;
            lblYear.Text = clickedYear.ToString();
            AddLabelDay(FirstDayofMonth(clickedYear, clickedMonth), TotalDaysOfMonth(clickedYear, clickedMonth));
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            clickedYear -= 1;
            lblYear.Text = clickedYear.ToString();
            AddLabelDay(FirstDayofMonth(clickedYear, clickedMonth), TotalDaysOfMonth(clickedYear, clickedMonth));
        }


        /// Generating Calendars
        /////// creating panel for each date
        private void generateDate()
        {
            int width = this.Width / 7;
            int height = panelDates.Height / 6;
            panelDates.Controls.Clear();
            listFLDay.Clear();
            for(int i =1; i <=42; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDate{i}";
                fl.Size = new Size(width, height);
                fl.Margin = new Padding(0, 0, 0, 0);
                fl.BackColor = Color.Transparent;
                fl.BorderStyle = BorderStyle.FixedSingle;
                panelDates.Controls.Add(fl);
                listFLDay.Add(fl);
            }

            AddLabelDay(FirstDayofMonth(clickedYear, clickedMonth), TotalDaysOfMonth(clickedYear, clickedMonth));
        }


        /////// creating date name
        private void AddLabelDay(int startday, int totalDays)
        {
            int width = this.Width / 7;
            int height = panelDates.Height/6;
            foreach (FlowLayoutPanel fl in listFLDay)
            {
                fl.Controls.Clear();
            }
            
            for (int i=1; i<=totalDays; i++)
            {   
                Label dateNo = new Label();
                dateNo.Name = $"lblDay{i}";
                dateNo.Text = i.ToString();
                dateNo.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                dateNo.Margin = new Padding(0, 0, 0, 0);
                dateNo.ForeColor = Color.White;
                dateNo.TextAlign = ContentAlignment.TopLeft;
                dateNo.Size = new Size(width, height);
                dateNo.AutoSize = false;

                clickedDate = clickedYear.ToString() + "-" + clickedMonth.ToString("D2") + "-" + dateNo.Text; 

                if (i == int.Parse(currentdate) && clickedMonth == int.Parse(currentmonth))
                {
                    dateNo.BackColor = Color.FromArgb(130, 184, 55);
                }

                if (listStoredDate.Contains(clickedDate))
                {
                    Label diaryExist = new Label();

                    diaryExist.BackColor = Color.FromArgb(247, 158, 1);
                    diaryExist.AutoSize = false;
                    diaryExist.Tag = clickedDate;
                    diaryExist.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                    diaryExist.Size = new Size(width-20,height-40);
                    diaryExist.ForeColor = Color.White;
                    diaryTitle = GetTitleFromDB(clickedDate);
                    diaryExist.Text = diaryTitle;
                    diaryExist.TextAlign = ContentAlignment.MiddleCenter;
                    var topleft = dateNo.PointToScreen(new Point(0, 0));
                    diaryExist.Location = new Point(topleft.X, topleft.Y);
                    dateNo.Controls.Add(diaryExist);

                    foreach(Control o in dateNo.Controls)
                    {
                        o.Click += (s, e) =>
                        {
                            saveDialog sd = new saveDialog(diaryExist.Tag.ToString(), diaryExist.Text);
                            sd.Show();
                            this.Hide();
                        };
                    }
                }
                else
                {
                    dateNo.Click += (s, e) =>
                    {
                        string YMD = clickedYear.ToString() + "-" + clickedMonth.ToString("D2") + "-" + dateNo.Text;
                        Wording_Properties.Clicked_Date = YMD;
                        wiritingDiary2 wd = new wiritingDiary2(YMD);
                        wd.Show();
                        this.Hide();
                        //hm.Hide();
                    };
                }

                listFLDay[(i-2)+startday].Controls.Add(dateNo);
            }
        }

        //functions for first day and total days of month
        //
        private int FirstDayofMonth(int year, int month)
        {
            DateTime firstdayofMonth = new DateTime(year, month, 1);
            int i = Convert.ToInt32(firstdayofMonth.DayOfWeek);

            return i+ 1;
        }

        private int TotalDaysOfMonth(int year, int month)
        {
            DateTime firstdayofMonth = new DateTime(year, month, 1);
            int i = Convert.ToInt32(firstdayofMonth.AddMonths(1).AddDays(-1).Day);
            return i;
        }

        private string GetTitleFromDB(string date)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT `Title` FROM `content_diary` Where `Date` =@date", con);
            cmd.Parameters.AddWithValue("@date", date);

            con.Open();
            MySqlDataReader rd = null;
            rd = cmd.ExecuteReader();

            string titled="";
            while (rd.Read())
            {
                titled = rd["Title"].ToString();
            }

            con.Close();
            return titled;
        }
        
        private void Count_AddMysqlColumns()
        {
            listStoredDate.Clear();

            MySqlCommand cmd = new MySqlCommand("SELECT `Date` FROM `content_diary`", con);
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(ds);
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listStoredDate.Add(ds.Tables[0].Rows[i]["Date"].ToString());
            }
        }
    }
}
