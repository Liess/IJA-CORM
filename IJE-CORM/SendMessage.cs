using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Threading;
namespace IJE
{
    public partial class SendMessage : Form
    {
        string emailadd = "";
        string ijacormemail = "";
        string ijacormemailpass = "";
        public SendMessage(string email,string thisemail, string thisemailpass)
        {
            InitializeComponent();
            EmailAdd.Text = email;
            emailadd = email;
            ijacormemail = thisemail;
            ijacormemailpass = thisemailpass;
            
        }
        public void loadingscreen()
        {
            try
            {
                Application.Run(new SendingMessageSplashScreen());
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }


        }
        public void loadingscreen2()
        {
            try
            {
                Application.Run(new SuccessSplashScreen());
            }
            catch (Exception)
            {
                Thread.ResetAbort();
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
           // Thread t = new Thread(new ThreadStart(loadingscreen));
            try{
            if (Message.Text != "")
            {
                var fromAddress = new MailAddress(ijacormemail, "From Name");
                var toAddress = new MailAddress(emailadd, "To Name");
                string fromPassword = ijacormemailpass;
                string subject = Subj.Text;

                string body = Message.Text;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                   
                    smtp.Send(message);
                 MessageBox.Show("Message sent");
                }
             
                this.Close();
           
            }
            else
            {
                MessageBox.Show("Please input a message ");
            }
            }
            catch {
             
                MessageBox.Show("No internet Connection");
            
        }

        }
      
        private void SendMessage_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int x = 0;
        private void stop_Tick(object sender, EventArgs e)
        {
            x++;

            if (x == 5)
            {

                stop.Stop();


            }

        }
    }
}
