using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IJE
{
    public partial class AdminLogIn : Form
    {
        public AdminLogIn()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.CornflowerBlue;
            this.TransparencyKey = Color.CornflowerBlue;
            this.ActiveControl = textBox3;
 
            textBox1.ForeColor = SystemColors.GrayText;
            textBox2.ForeColor = SystemColors.GrayText;
            textBox1.Text = "Username";
            textBox2.Text = "Password";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.AcceptButton = this.LogIn;

        }
        private void AdminLogIn_Load_1(object sender, EventArgs e)
        {
           
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            string Username = "admin";
            string Code = "123";

            if ((textBox1.Text.ToLower() == Username) && (textBox2.Text == Code))
            {

                AdminPanel admin = new AdminPanel();
                admin.Show();
                this.Close();
        
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }

            if (AdminPanel.open == 1)
            {

                if ((textBox1.Text.ToLower() == Username) && (textBox2.Text == Code))
                {

                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

            }


            AdminPanel.open = 0;
        }

        private void AdminLogIn_Load(object sender, EventArgs e)
        {

        }

        private void Adlogin_Click(object sender, EventArgs e)
        {

        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adlogin_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
