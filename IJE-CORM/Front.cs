using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using System.Media;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;



namespace IJE
{
    public partial class Front : Form
    {
        SoundPlayer player;
        DBConnect dbConnect;
        string user = "";
        string pass = "";

        public Front()
        {


            FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();

            this.ActiveControl = pictureBox1;

            textBox1.ForeColor = SystemColors.GrayText;
            textBox2.ForeColor = SystemColors.GrayText;
            textBox1.Text = "Username";
            textBox2.Text = "Password";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.AcceptButton = this.LogIn;




            //my code
            dbConnect = new DBConnect();


            //to get user and pass - mj
            getUserandPass();

            //Ernest code

        }


        public static VideoCaptureDevice FinalFrame;

        public int i;

        //-----Mj method
        private void getUserandPass()
        {
            int count = dbConnect.Count("select count(*) from tblAdmin;");

            if (count == 0)
            {

                dbConnect.Insert("insert into tbladmin values ('admin','user','pass','name','email@email.com','emailpass','message',false);");
                MessageBox.Show("First application usage. Temporary values:\nName: name\nUser: user\nPassword: pass\nEmail: email@email.com\nEmail Password: emailpass\nMessage: message\nPlease change this values in the settings later.");
            }

            //to get username and pass
            string[] columns = { "strAdmUser", "strAdmPass" };
            List<object>[] rs = dbConnect.Select("select * from tblAdmin where strAdmCode = 'admin';", columns);
            user = rs[0].ElementAt(0).ToString();
            pass = rs[1].ElementAt(0).ToString();
        }

        private bool isAbleToLogIn()
        {
            string[] columns = { "boolAdmIsLoggedIn" };
            List<object>[] rs = dbConnect.Select("select * from tblAdmin where strAdmCode = 'admin';", columns);

            if (rs[0].ElementAt(0).ToString().Equals("False")) //if admin is not logged in
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Password";
                textBox2.PasswordChar = '\0';
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';
                textBox2.ForeColor = SystemColors.WindowText;
            }
        }


        /*
         * GHOOOOST COOODEEE
         * 
         * 
        AdminPanel use = new AdminPanel();

         */
        bool signal2;
        private void LogIn_Click_1(object sender, EventArgs e)
        {
            if ((textBox1.Text.Equals(user)) && (textBox2.Text.Equals(pass)) && (isAbleToLogIn()))
            {
                dbConnect.Update("update tblAdmin set boolAdmIsLoggedIn = true;");


                AdminPanel admin = new AdminPanel();
           
                admin.Show();
     this.Hide();
                

            }
            else if (!isAbleToLogIn())
            {
                MessageBox.Show("Admin account already logged in");
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Front_Load(object sender, EventArgs e)
        {
            Hide();
            bool done = false;
            ThreadPool.QueueUserWorkItem((x) =>
            {
                using (var splashForm = new loadingscreenn())
                {
                    splashForm.Show();
                    while (!done)
                        Application.DoEvents();
                    splashForm.Close();
                }
            });

            Thread.Sleep(4000); // Emulate hardwork
            done = true;
            Show();
        }

        private void Front_FormClosing(object sender, FormClosingEventArgs e)
        {
            new DBConnect().Update("update tblAdmin set boolAdmIsLoggedIn = false;");

        }


        private void timer1_Tick(object sender, EventArgs e)
        {


        }


    }
}
