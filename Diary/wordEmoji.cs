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
    public partial class wordEmoji : Form
    {
        wiritingDiary2 wd = (wiritingDiary2)Application.OpenForms["wiritingDiary2"];
        Label[] array;
        public wordEmoji()
        {
            InitializeComponent();
            this.ForeColor = Color.White;
            array = new Label[] {label1,label2,label3,label4,label5,label6,label7,label8,label9,label10,label11,label12,label13,label14,
            label15,label16,label17,label18,label19,label20,label21,label22,label23,label24,label25};

            foreach(Label l in array)
            {
                l.ForeColor = Color.White;
                l.Click += (s, e) =>
                {
                    wd.InsertStringToRTB(l.Text);
                    this.Close();
                    wd.Focus();
                };
                l.MouseEnter += (s, e) =>
                {
                    l.BackColor = Color.FromArgb(21, 61, 118);
                };
                l.MouseLeave += (s, e) =>
                {
                    l.BackColor = Color.FromArgb(6, 33, 52);
                };
            }
        }
        
    }
}
