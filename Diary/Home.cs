using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
    public partial class Home : Form
    {
        showListDiary sl = new showListDiary();

        Control[] all;

        public Home()
        {
            InitializeComponent();
            all = new Control[] { btnDiaryHome, btnCaledar, btnSetting, btnLogOut };

            for(int i=0; i<all.Length; i++)
            {
                mousehover(all[i]);
            }
        }

        private void btnCaledar_Click(object sender, EventArgs e)
        {
            calender cs = new calender();
            switchPanel(cs);
        }
    
        private void switchPanel(Form panel)
        {
            //panel.Width = PanelView.Width;
            //panel.Height = PanelView.Height;

            PanelView.Controls.Clear();
            panel.TopLevel = false;
            panel.Dock = DockStyle.Fill;
            PanelView.Controls.Add(panel);
            panel.Show();
        }
        
        private void mousehover(Control cont)
        {
            cont.MouseEnter += (s, e) =>
            {
                cont.BackColor = Color.FromArgb(0, 9, 18);
            };
            cont.MouseLeave += (s, e) =>
            {
                cont.BackColor = Color.FromArgb(6, 30, 52);
            };
        }

        private void btnWriteDiary_Click(object sender, EventArgs e)
        {

        }

        private void btnDiaryHome_Click(object sender, EventArgs e)
        {
            switchPanel(sl);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Setting st = new Setting();
            st.Show();
        }
    }
}
