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
using System.Net;
using System.Net.Mail;

namespace Diary
{
    public partial class Login : Form
    {
        MySqlConnection cn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");

        public Random rd = new Random();

        public Login()
        {
            //SendEmail2();
            InitializeComponent();
        }

        //this is only for test to emailing
        private void SendEmail2()
        {
            try
            {
                MailAddress addressFrom = new MailAddress("panasonic10132001@gmail.com", "Diary");
                MailAddress addressTo = new MailAddress("trunglequang12@gmail.com");
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Email verify code for your Diary Account";
                //String.Format("<html><body><p>Dear '{0}' </p><p>We have received yor email confirmation request. your verification is <h2><b>'{1}'<b/></h2> </p></body> </html>", labelName, codeNum);
                string htmlString = String.Format(@"<html>
                                                        <body>
                                                            <p>Hi trung</p>
                                                            <p>Welcome to Dairy and thanks for registering account with us.</p>
                                                            <p>To activate the account, please copy and type down Verification code we sent you below.<br>Your account will be created as soon as your enter verification code in the box </p>
                                                            <p>Your verification is <h2><b>'{0}'</b></h2></p> 
                                                            <p>We hope you enjoy the fucking prank I made fun for your friends. <b>In case this is not Trung, then I am deeply sorry</b></p>
                                                        </body> 
                                                    </html>", "your mom");
                message.IsBodyHtml = true;
                message.Body = htmlString;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("panasonic10132001@gmail.com", "cinosanap2017");

                client.Send(message);
                client.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear()
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
            showCB.Checked = false;
        }

        private void SignUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            clear();
            Register sgu = new Register();
            sgu.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT  `Email`, `Password` FROM `customer_info` WHERE `Email`=@email AND `Password`=@pw", cn);
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtUsername.Text;
            cmd.Parameters.Add("@pw", MySqlDbType.VarChar).Value = txtPassword.Text;

            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                Home home = new Home();
                this.Hide();
                txtUsername.Text = "";
                txtPassword.Text = "";
                home.Show();
            }
        }

        private void PasswordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}
