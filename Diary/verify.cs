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
using System.Net.Mail;
using System.Net;
namespace Diary
{
    public partial class verify : Form
    {
        MySqlConnection cn = new MySqlConnection("datasource=localhost; port=3306; username=root; password=; database=diary");
        Register sg = new Register();
        string userID;
        string codeNum;

        private readonly char[] Alphanumeric = ("0123456789" + "ABCEDEF").ToCharArray();
        
        public verify(string id)
        {
            InitializeComponent();
            labelEmail.Text = Names;
            userID = id;
        }

        private void verify_Load(object sender, EventArgs e)
        {
            LoadVerifyCode();
            SendEmail2();
        }
        public string Email
        {
            get { return labelEmail.Text; }
            set { labelEmail.Text = value; }
        }

        public string Names
        {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }

        private void LoadVerifyCode()
        {
            StringBuilder result = new StringBuilder();
            Random rn = new Random();

            for (int i = 0; i < 7; i++)
            {
                result.Append(Alphanumeric[rn.Next(Alphanumeric.Length)]);
            }
            codeNum = result.ToString();

        }

        private void email()
        {
            string subject = "Email verify code for your Diary Account";
            string verify_code = "your verification is" + codeNum;

            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("panasonic10132001@gmail.com", "cinosanap2017"); //account name and password  
                client.EnableSsl = true; // Set SSL = true  

                MailMessage message = new MailMessage();
                message.To.Add(labelEmail.Text); // Add Receiver mail Address  
                message.From = new MailAddress("panasonic10132001@gmail.com"); // Sender address  
                message.Subject = subject;

                //message.IsBodyHtml = true; 
                message.Body = verify_code;

                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendEmail2()
        {
            try
            {
                MailAddress addressFrom = new MailAddress("panasonic10132001@gmail.com", "Diary");
                MailAddress addressTo = new MailAddress("kkheadphones@gmail.com");
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Email verify code for your Diary Account";
                //String.Format("<html><body><p>Dear '{0}' </p><p>We have received yor email confirmation request. your verification is <h2><b>'{1}'<b/></h2> </p></body> </html>", labelName, codeNum);
                string htmlString = String.Format(@"<html>
                                                        <body>
                                                            <p>Hi '{0}'</p>
                                                            <p>Welcome to Dairy and thanks for registering account with us.</p>
                                                            <p>To activate the account, please copy and type down Verification code we sent you below.<br>Your account will be created as soon as your enter verification code in the box </p>
                                                            <p>Your verification is <h2><b>{1}</b></h2></p> 
                                                            <p>We hope you enojy </p>
                                                        </body> 
                                                    </html>", labelName.Text, codeNum);
                message.IsBodyHtml = true;
                message.Body = htmlString;

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new NetworkCredential("panasonic10132001@gmail.com", "cinosanap2017");

                client.Send(message);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            labelEmail.Text = "";
            txtVer.Text = "";
            sg.Show();
            this.Hide();

            MySqlCommand cmd = new MySqlCommand("DELETE FROM `customer_info` WHERE `ID`=@gn", cn);
            cmd.Parameters.Add("@gn", MySqlDbType.Text).Value = userID;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            cn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
            }
            cn.Close();
        }

        private void clear()
        {
            txtVer.Text = "";
            labelEmail.Text = "";
        }

        private void insertVerify(string s)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `customer_info` SET `verify_code`=@vf WHERE `Family_Name`=@id", cn);
            cmd.Parameters.Add("@vf", MySqlDbType.VarChar).Value = s;
            cmd.Parameters.Add("@id", MySqlDbType.Text).Value = userID;

            cn.Open();

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Sign up Successfully!");
                Login lg = new Login();
                Register su = new Register();

                this.Hide();
                su.Hide();
                clear();
                lg.Show();
            }
            else
            {
                MessageBox.Show("Sign up failed!");
            }
            cn.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtVer.Text == codeNum)
            {
                insertVerify(txtVer.Text);
            }
            else
            {
                MessageBox.Show(@"your verification code is not matching! 
                                  Try again please");
                txtVer.Text = "";
            }
        }

        private void BtnTrySendAgain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadVerifyCode();
            SendEmail2();
        }

        private void txtVer_TextChanged(object sender, EventArgs e)
        {
            txtVer.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
