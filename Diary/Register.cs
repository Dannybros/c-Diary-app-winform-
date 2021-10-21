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
    public partial class Register : Form
    {
        MySqlConnection cn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        Login lgo = new Login();
        string tem = "Temporary";
        public string Userid;

        public Register()
        {
            InitializeComponent();
        }

        public string generateGUID()
        {
            string newGUID = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            return newGUID;
        }

        private void LoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clear();
            this.Hide();
            lgo.Show();
        }

        bool IsValidatedEmail(string src)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(src);
                return addr.Address == src;
            }
            catch { return false; }
        }

        private void clear()
        {
            txtFirstName.Text = "";
            txtPassword.Text = "";
            txtRePw.Text = "";
            bdDate.Value = DateTime.Now;
            showCB.Checked = false;
        }

        private void showCB_CheckedChanged(object sender, EventArgs e)
        {
            if (showCB.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clear();
            this.Hide();
            lgo.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int datebd = int.Parse(bdDate.Value.ToString("yyyy"));
            int dateNow = int.Parse(DateTime.Now.ToString("yyyy"));
            if (txtPassword.Text != txtRePw.Text)
            {
                MessageBox.Show("Passwords are not matching");
            }

            if (txtPassword.Text.Trim() == "" || txtRePw.Text.Trim() == "" || txtFirstName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill every fields");
            }

            else if (datebd - dateNow > 3)
            {
                MessageBox.Show("You can't be less than 3? You think I am dumb?!! Try again");
            }

            else if (IsValidatedEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Email address does not exit!");
            }
            else
            {
                Userid = generateGUID();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `customer_info`(`ID`, `Family_Name`,`Birthday`, `Given_Name`, `Email`, `Password`) VALUES (@id, @fn,@bd, @gn, @email, @pw)", cn);
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Userid;
                cmd.Parameters.Add("@fn", MySqlDbType.Text).Value = txtFirstName.Text;
                cmd.Parameters.Add("@gn", MySqlDbType.Text).Value = txtGivenName.Text;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@bd", MySqlDbType.Date).Value = bdDate.Value;
                cmd.Parameters.Add("@pw", MySqlDbType.VarChar).Value = txtPassword.Text;

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    verify vf = new verify(Userid);

                    vf.Email = txtEmail.Text;
                    vf.Names = txtGivenName.Text;
                    vf.Show();
                }
                else
                {
                    MessageBox.Show("Sorry, Register failed, try again.");
                    clear();
                }
                cn.Close();
            }
        }
    }
}
