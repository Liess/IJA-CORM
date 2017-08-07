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
       
    public partial class Notification : Form   
    { 
        
        public static int allow;
        DBConnect dbConnect;
        CodeGenerator codeGenerator;
        string emailadd = "";
      string thisemailadd = "";
     string myConstant = "";
     string itemname = "";
     string dateborrowed = "";
        string message1 = "";
        string emailpass = "";
        private static readonly List<Notification> OpenNotifications = new List<Notification>();
        private bool _allowFocus;
        private readonly FormAnimator _animator;
        private IntPtr _currentForegroundWindow;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="duration"></param>
        /// <param name="animation"></param>
        /// <param name="direction"></param>
        public Notification(int borrowercount, string mess, string emailpassword, string thisemail, int duration, FormAnimator.AnimationMethod animation, FormAnimator.AnimationDirection direction)
        {
          
            InitializeComponent();
            allow = 1;
            if (duration < 0)
                duration = int.MaxValue;
            else

                duration = duration * 1000;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, BorrPic.Width - 3, BorrPic.Height - 3);
            Region rg = new Region(gp);
           BorrPic.Region = rg;
            lifeTimer.Interval = duration;

     
          //  Itemname.Text = item;
          //  itemname = item;
          //  Bdate.Text = date;
         //   dateborrowed = date;
         //   Bname.Text = name;

            dbConnect = new DBConnect();
            codeGenerator = new CodeGenerator();
           
            thisemailadd = thisemail;
          //  myConstant = lastname;
            message1 = mess;
            emailpass = emailpassword;
            BorrowersCount.Text =""+borrowercount;
            _animator = new FormAnimator(this, animation, direction, 500);

            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 5, Height - 5, 20, 20));
         
        }

        #region Methods

        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        #endregion // Methods

        #region Event Handlers

        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                                      Screen.PrimaryScreen.WorkingArea.Height - Height);

            // Move each open form upwards to make room for this one
            foreach (Notification openForm in OpenNotifications)
            {
                openForm.Top -= Height;
            }

            OpenNotifications.Add(this);
            lifeTimer.Start();
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += Height;
            }

            OpenNotifications.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void Notification_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelRO_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion // Event Handlers

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void loadingscreen()
        {
            Application.Run(new SendingMessageSplashScreen());


        }
        public void loadingscreen2()
        {
            Application.Run(new SuccessSplashScreen());


        }
        private void BorrPic_Click(object sender, EventArgs e)
        {

           
            this.Close();
        
            allow = 0;
        }

        private string getExpectedReturnDate(string dateBorrowed)
        {   
        
            DateTime date = Convert.ToDateTime(dateBorrowed);
            date = date.AddDays(7);

            return date.ToString("MMM dd, yyyy");
        }


        private void SendEmail_Click(object sender, EventArgs e)
        {  
         
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where boolNameIsDel = false;", columns);
            string expectedReturnDate = "";
            string beforeReturnDate = "";
            string notificationDate = "";

            bool haveNet = true;
            for (int i = 0; i < rs[0].Count; i++)
            {

               string bcode = rs[0].ElementAt(i).ToString();
              string borremail = rs[4].ElementAt(i).ToString();
                //-----///string bfname = rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString();
         string  blname = rs[3].ElementAt(i).ToString();
                string[] columns2 = { "strItemName", "dtmBorHDateBorrowed", "strBorDBorHCode", "strBorDCode" };
                List<object>[] rs2;
             rs2 = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) where tblborrowheader.strBorHNameCode = '" + bcode + "' and tblborrowdetail.dtmBorDDateReturned is null;", columns2);


         for (int n = 0; n < rs2[0].Count; n++)
                {
                    expectedReturnDate = getExpectedReturnDate(Convert.ToDateTime(rs2[1].ElementAt(n).ToString()).ToString("yyyy-MM-dd"));
                   DateTime expectedreturndate2 = Convert.ToDateTime(expectedReturnDate);
                    beforeReturnDate = expectedreturndate2.AddDays(-3).ToString("yyyy-MM-dd");
                    notificationDate = DateTime.Today.ToString("yyyy-MM-dd");

                    if (notificationDate == beforeReturnDate)
                    {
                       
                        try
                          {
                             var fromAddress = new MailAddress(thisemailadd, "From Name");
                             var toAddress = new MailAddress(borremail, "To Name");
                             string fromPassword = emailpass;
                             const string subject = "3days Before Overdue Notification";
                             string body = "Dear " + blname+ ",\n\n" +message1;

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
                        
                            }
                        
                         
                        
             
                        
                           

                       }
                        catch{
                           
                        
                            haveNet = false;
                            break;
                        }

                    }
         }
         if (!haveNet)
         {
             MessageBox.Show("No internet connection");
             break;
         }
                      
        }
            if (haveNet)
            {
                MessageBox.Show("Send Successful");
                allow = 0;
                this.Close();
            }
        }
   
        int x = 0;

        private void stop_Tick(object sender, EventArgs e)
        {
         
            x++;


            if (x == 5)
            {

           

                x = 0;
                stop.Stop();
            }

                
       
          
        }

        private void lifeTimer_Tick_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OverdueNotifFList op = new OverdueNotifFList();
            op.ShowDialog();
        }
    }
}
