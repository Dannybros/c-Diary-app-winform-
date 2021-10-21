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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            fillfont();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                label4.BackColor = cd.Color;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Wording_Properties.Official_Font = comboBox1.Text;
            Wording_Properties.Official_FontSize =Convert.ToInt32(comboBox2.Text);
            Wording_Properties.fontcolor = label4.BackColor;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fillfont()
        {
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }

        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            Wording_Properties.Official_Font = "Times New Roman";
            Wording_Properties.Official_FontSize = 14;
            Wording_Properties.fontcolor = Color.White;

            comboBox1.Text = "Times New Roman";
            comboBox2.Text = "14";
            label4.BackColor = Color.White;
        }
    }
}