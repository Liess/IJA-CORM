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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.Threading;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Globalization;

namespace IJE
{
    public partial class AdminPanel : Form
    {
        Front a;
        SoundPlayer player;
        public static int open = 0;
        //ernest Code
        public static string borrCode = "";
        public static string fullname = "";


        //My code
        DBConnect dbConnect;
        List<string>[] adviserAndCode;
        List<string>[] departmentAndCode;
        List<string>[] modelsAndCode;
        CodeGenerator codeGenerator;
        string itemNameToShow = "";
        string categToShow = "";
        string modelToShow = "";
        string availToShow = "";
        string borrowername = "";
        string itemNameToShow2 = "";
        string categToShow2 = "";


        ////ODBC
        //static string reportsServerName = "kahit anopangalan";
        //static string reportsDatabase = "nullsystem";
        //static string reportsUID = "root";
        //static string reportsPass = "root";

        //For others
        static string reportsServerName = "MySql2";
        static string reportsDatabase = "nullsystem";
        static string reportsUID = "null";
        static string reportsPass = "null";


        string borToShowStud = "";
        string nameToShowStud = "";
        string advToShowStud = "";
        string secToShowStud = "";

        string borToShowFacu = "";
        string nameToShowFacu = "";
        string depToShowFacu = "";
        string posToShowFacu = "";
        string user = "";
        string pass = "";
        string curremail = "";
        string currname = "";
        string emailpass = "";
        string message = "";
        string blname = "";
        string borremail = "";
        public AdminPanel()
        {
            FormBorderStyle = FormBorderStyle.None;

          
            InitializeComponent();
            
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
          
             if (!(System.IO.Directory.Exists(desktopPath + @"\" + "QRcodes")))
               
                 {
                System.IO.Directory.CreateDirectory(desktopPath + @"\" + "QRcodes");
                System.IO.Directory.CreateDirectory(desktopPath + @"\" + "QRcodes"+@"\"+"Student");
                System.IO.Directory.CreateDirectory(desktopPath + @"\" + "QRcodes" + @"\" + "Student" + @"\" + "ID");
                Properties.Resources.StudentID.Save(desktopPath + "\\QRcodes\\Student\\ID\\StudentID.png");

                System.IO.Directory.CreateDirectory(desktopPath + @"\" + "QRcodes" + @"\" + "Faculty");
                System.IO.Directory.CreateDirectory(desktopPath + @"\" + "QRcodes" + @"\" + "Faculty" + @"\" + "ID");
                Properties.Resources.FacultyID.Save(desktopPath + "\\QRcodes\\Faculty\\ID\\FacultyID.png");

                System.IO.Directory.CreateDirectory(desktopPath + @"\" + "QRcodes" + @"\" + "Pictures");
                Properties.Resources.custodian.Save(desktopPath + "\\QRcodes\\Pictures\\custodian.png");
                Properties.Resources.IJAIDBack_1_.Save(desktopPath + "\\QRcodes\\Pictures\\IDback.png");
            }
            

            //INALIS KO PARA MA SET
             //Todate.MaxDate = DateTime.Today;
             FromDate.MaxDate = DateTime.Today;
            int style = NativeWinAPI.GetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(this.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            timer1.Start();
            timer2.Start();
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            Student.Select();

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;

            FacultyList.EnableHeadersVisualStyles = false;
            FacultyList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;

            StudList.EnableHeadersVisualStyles = false;
            StudList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;

            ItemBorrowed.EnableHeadersVisualStyles = false;
            ItemBorrowed.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;

            StuBorrower.EnableHeadersVisualStyles = false;
            StuBorrower.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;


            FacuBorrower.EnableHeadersVisualStyles = false;
            FacuBorrower.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;


            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            adminpicture.Region = rg;
            System.Drawing.Drawing2D.GraphicsPath gp2 = new System.Drawing.Drawing2D.GraphicsPath();
            gp2.AddEllipse(0, 0, pictureBox19.Width - 3, pictureBox19.Height - 3);
            Region rg2 = new Region(gp2);
            pictureBox19.Region = rg2;

            //Mj Code's Start here
         
            dbConnect = new DBConnect();
            codeGenerator = new CodeGenerator();
       
            //get departments
            getDepartments();
      


            

            
            this.Searchbox.Leave += new System.EventHandler(this.SearchBox_Leave);
            this.Searchbox.Enter += new System.EventHandler(this.SearchBox_Enter);
            Section.Items.Insert(0, "Please select any value");
                

            
            string[] columns = { "strAdmUser", "strAdmPass", "strAdmName", "strAdmEmail","strAdmEmailPass","txtAdmMessage" };
            List<object>[] rs = dbConnect.Select("select * from tblAdmin where strAdmCode = 'admin';", columns);
            user = rs[0].ElementAt(0).ToString();
            pass = rs[1].ElementAt(0).ToString();
            currname = rs[2].ElementAt(0).ToString();
            curremail = rs[3].ElementAt(0).ToString();
            emailpass = rs[4].ElementAt(0).ToString();
            message = rs[5].ElementAt(0).ToString();
            

            CurrEmailAdd.Text = curremail;
            tbx_Name.Text = currname;
            tbx_username.Text = user;
           
            EmailPass.Text = emailpass;
            Message.Text = message;
            initialmess.Text = "Dear [name],";
        }

     
        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }



        public string bcode;
        private VideoCaptureDevice FinalFrame;
        private FilterInfoCollection CaptureDevice;
        public int i;
        public int show = 0;
        public int sure = 0;
        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string source1 = desktopPath + "\\QRcodes\\Student\\ID\\StudentID.png";
        public string source2 = desktopPath + "\\QRcodes\\Faculty\\ID\\FacultyID.png";
        public string source3 = desktopPath + "\\QRcodes\\Student\\ID\\";
        public string source4 = desktopPath + "\\QRcodes\\Student\\";
        public string source5 = desktopPath + "\\QRcodes\\Faculty\\ID\\";
        public string source6 = desktopPath + "\\QRcodes\\Faculty\\";
        public string source7 = desktopPath + "\\QRcodes\\Pictures\\";

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (Searchbox.Text.Length == 0)
            {
               
                Searchbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
        }
        public void loadingscreen()
        {
            try
            {
                Application.Run(new AddingDataSplashScreen());
            }
            catch (ThreadAbortException e)
            {
                Thread.ResetAbort();
            }
        }
        //-----------------------------------------FOR CODE GENERATION----------------------------------------------------------------------
        //---------------Counts
        public int countSect()
        {
            string[] columns = { "count(*)" };
            List<object>[] rs = new List<object>[1];
            rs = dbConnect.Select("select count(*) from tblSection;", columns);
            return int.Parse(rs[0].ElementAt(0).ToString());
        }
        public int countCateg()
        {
            string[] columns = { "count(*)" };
            List<object>[] rs = new List<object>[1];
            rs = dbConnect.Select("select count(*) from tblCategory;", columns);
            return int.Parse(rs[0].ElementAt(0).ToString());
        }
        //-----------------Generators
        /*
        public string generateCategCode()
        {
            int count = countCateg();
            if(count==0){

            }
        }*/


        //-----------------------------------------REGISTRATION-------------------------------------------------

        //  Registration panel
        private void Register_Click(object sender, EventArgs e)
        {

            //Mj Code
            //---//get adv
            getAdvisers();
            //---//get dep
            getDepartments();



            panel1.Visible = false;
            RegistrationPanel.Visible = true;
            InventoryPanel.Visible = false;
            SettingsPanel.Visible = false;
            OptionPanel.Visible = false;
            RegiPanel.Visible = true;
            BorrowerButton.Enabled = false;
        
       
            if (Student.Checked)
            {
                StudFactNo.Text = "Student Number: ";
                StuFacNo.MaxLength = 7;
                addep.Text = "Adviser: ";
                secpos.Text = "Section: ";
                Addsectionn.Visible = true;
                addDepartment.Visible = false;
                Addposition.Visible = false;
                ID.Image = Image.FromFile(source1);
            }
            if (Faculty.Checked)
            {
                StudFactNo.Text = "Faculty Number: ";
                StuFacNo.MaxLength = 10;
                Addsectionn.Visible = false;
                addDepartment.Visible = true;
                Addposition.Visible = true;
                addep.Text = "Department: ";
                secpos.Text = "Position: ";
                ID.Image = Image.FromFile(source2);
            }
            MessageBox.Show(" Take a picture or upload an image first ", "Note:", MessageBoxButtons.OK);

        }

        // Methods
        public void getDepartments()
        {
            //get position and code
            departmentAndCode = new List<string>[2];
            departmentAndCode[0] = new List<string>();
            departmentAndCode[1] = new List<string>();
            //clear adviser box
            DepBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strDepCode", "strDepName" };
            rs = dbConnect.Select("select * from tblDepartment where boolDepIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {

                //for posiandCode
                departmentAndCode[0].Add(rs[0].ElementAt(row).ToString());
                departmentAndCode[1].Add(rs[1].ElementAt(row).ToString());


                DepBox.Items.Add(rs[1].ElementAt(row).ToString());
            }
        }
        public void getPositions(string dep)
        {

            PosBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strPosiCode", "strPosiName" };
            rs = dbConnect.Select("select * from tblPosition where strPosiDepCode = '" + dep + "' and boolPosiIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {


                //for cmb
                PosBox.Items.Add(rs[1].ElementAt(row).ToString());
            }
        }
        public void getSections(string adv)
        {
            SecBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strSectName" };
            rs = dbConnect.Select("select strSectName from tblSection where strSectFacuCode = '" + adv + "' and boolSectIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {
                SecBox.Items.Add(rs[0].ElementAt(row).ToString());
            }
        }
        public void getAdvisers()
        {
            //to refresh nameAndCode
            adviserAndCode = new List<string>[2];
            adviserAndCode[0] = new List<string>();
            adviserAndCode[1] = new List<string>();
            //clear adviser box
            AdviserBox.Items.Clear();


            List<object>[] rs;
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName" };
            rs = dbConnect.Select("select * from tblName where intNameType = 2 and boolNameIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {
                AdviserBox.Items.Add(rs[3].ElementAt(row).ToString() + ", " + rs[1].ElementAt(row).ToString() + " " + rs[2].ElementAt(row).ToString());
                //putting values to name and code for searching later

                adviserAndCode[0].Add(rs[0].ElementAt(row).ToString());
                adviserAndCode[1].Add(rs[3].ElementAt(row).ToString() + ", " + rs[1].ElementAt(row).ToString() + " " + rs[2].ElementAt(row).ToString());
            }


        }

        public string depToCode(string dep)
        {
            List<object>[] rs;
            string[] columns = { "strDepCode" };
            rs = dbConnect.Select("select * from tblDepartment where strDepName = '" + dep + "' and boolDepIsDel = false;", columns);
            return rs[0].ElementAt(0).ToString();
        }
        public string posToCode(string pos, string dep)
        {
            List<object>[] rs;
            string[] columns = { "strPosiCode" };
            rs = dbConnect.Select("select * from tblPosition where strPosiName = '" + pos + "' and strPosiDepCode = '" + dep + "' and boolPosiIsDel = false;", columns);
            return rs[0].ElementAt(0).ToString();
        }
        public string secToCode(string sec)
        {
            List<object>[] rs;
            string[] columns = { "strSectCode" };
            rs = dbConnect.Select("select * from tblSection where strSectName = '" + sec + "' and boolSectIsDel = false;", columns);
            return rs[0].ElementAt(0).ToString();
        }
        public string advToCode(string adv)
        {
            string retCode = null;
            for (int i = 0; i < adviserAndCode[1].Count; i++)
            {
                if (adviserAndCode[1].ElementAt(i).ToString().Equals(adv))
                {
                    retCode = adviserAndCode[0].ElementAt(i).ToString();
                    break;
                }
            }

            if (retCode == null)
            {
                MessageBox.Show("Can't Find Advisers");
            }

            return retCode;
        }

        public static bool IsnospecialChar(string input)
        {
            
               var regexItem = new Regex("^[a-zA-Z ñ]*$");

                if(regexItem.IsMatch(input)){
                      return true;         
                }
                    return false;
        }

        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Register Faculty and student


        public void RegisterBorrower()
        {
            string fullname = Lname.Text + ", " + Fname.Text + " " + Mname.Text;
            string stuFacNo = StuFacNo.Text;
            string fname = Fname.Text;
            string mname = Mname.Text;
            string lname = Lname.Text;
            string email = Emailbox.Text;


     
            if (emailIsValid(email) == false)
            {

                MessageBox.Show("Invalid Email");

            }
            else
            {
                if (Student.Checked)
                {

                    try
                    {
                        if (StuFacNo.Text != "" && Fname.Text != "" && Mname.Text != "" && Lname.Text != "" && Emailbox.Text != "" && AdviserBox.SelectedItem != null && SecBox.SelectedItem != null && emailIsValid(email) == true)
                        {
                            if (stuFacNo.Length == 7) 
                            {
                                if (IsnospecialChar(fname) && IsnospecialChar(mname) && IsnospecialChar(lname))
                                {
                                    string adviser = AdviserBox.SelectedItem.ToString();
                                    string sect = SecBox.SelectedItem.ToString();

                                    DialogResult dialogResult = MessageBox.Show(fullname + "\n" + stuFacNo + "\n" + email + "\n" + adviser + "\n" + sect + "\nRegister?", "Register?", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {

                                        dbConnect.Insert("insert into tblName values ('" + stuFacNo + "','" + fname + "','" + mname + "','" + lname + "','" + email + "',1,false);");
                                        dbConnect.Insert("insert into tblStudent values ('" + stuFacNo + "','" + secToCode(sect) + "');");

                                        Zen.Barcode.CodeQrBarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                                        QrCodeGen.Image = barcode.Draw(StuFacNo.Text, 50);
                                        QrCodeGen.Image = resizeImage(QrCodeGen.Image, new Size(178, 166));
                                        IDpicturee.Image = resizeImage(IDpicturee.Image, new Size(103, 107));
                                        QrCodeGen.Image.Save(source4 + StuFacNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                        IDpicturee.Image.Save(source7 + StuFacNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                        using (Image image = Image.FromFile(source1))
                                        using (Image watermarkImage = Image.FromFile(source7 + StuFacNo.Text + ".jpg"))
                                        using (Image watermarkImage2 = Image.FromFile(source4 + StuFacNo.Text + ".jpg"))
                                        using (Graphics imageGraphics = Graphics.FromImage(image))
                                        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
                                        using (TextureBrush watermarkBrush2 = new TextureBrush(watermarkImage2))
                                        {
                                            int x = (16);
                                            int y = (12);
                                            int o = (323);
                                            int p = (102);
                                            int f = 14;
                                            if (fullname.Length > 15)
                                            {
                                                f = 12;
                                            }

                                            watermarkBrush.TranslateTransform(x, y);
                                            imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new System.Drawing.Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                                            watermarkBrush2.TranslateTransform(o, p);
                                            imageGraphics.FillRectangle(watermarkBrush2, new Rectangle(new System.Drawing.Point(o, p), new Size(watermarkImage2.Width + 1, watermarkImage2.Height)));
                                            imageGraphics.DrawString(StuFacNo.Text, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(60, 137));
                                            imageGraphics.DrawString(lname + ",", new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(82, 181));
                                            imageGraphics.DrawString(fname + " " + mname, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(37, 204));
                                            imageGraphics.DrawString(sect, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(147, 247));
                                            image.Save(source3 + StuFacNo.Text + ".jpg");
                                        }
                                        ID.Image = Image.FromFile(source3 + StuFacNo.Text + ".jpg");

                                        StuFacNo.Enabled = false;
                                        Fname.Enabled = false;
                                        Mname.Enabled = false;
                                        Lname.Enabled = false;
                                        Emailbox.Enabled = false;
                                        DepBox.Enabled = false;
                                        PosBox.Enabled = false;
                                        AdviserBox.Enabled = false;
                                        SecBox.Enabled = false;
                                        GenerateID.Visible = true;
                                        RegStudent.Visible = false;
                                        Faculty.Enabled = false;
                                    }
                                    else if (dialogResult == DialogResult.No)
                                    {


                                    }
                                }
                                 else
                            {
                                MessageBox.Show("Name format is invalid");
                            }
                            }
                           
                               else {
                                    MessageBox.Show("Student number must be 7 characters");
                                }




                        }


                        else if (StuFacNo.Text == "" || Fname.Text == "" || Mname.Text == "" || Lname.Text == "" || Emailbox.Text == "" || AdviserBox.Text == "" || SecBox.Text == "")
                        {
                            MessageBox.Show("You must fill all the requirements correctly");
                        }

                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(fullname + " already registered!", "Warning", MessageBoxButtons.OK);
                        clrAll();
                    }

                }
                else if (Faculty.Checked)
                {

                    try
                    {
                        if (StuFacNo.Text != "" && Fname.Text != "" && Mname.Text != "" && Lname.Text != "" && Emailbox.Text != "" && DepBox.SelectedItem != null && PosBox.SelectedItem != null && emailIsValid(email) == true)
                        {
                            if (stuFacNo.Length == 10)
                            {
                                if (IsnospecialChar(fname) && IsnospecialChar(mname) && IsnospecialChar(lname))
                                {
                                    string dep = DepBox.SelectedItem.ToString();
                                    string posi = PosBox.SelectedItem.ToString();

                                    DialogResult dialogResult = MessageBox.Show(fullname + "\n" + stuFacNo + "\n" + email + "\n" + dep + "\n" + posi + "\nRegister?", "Register?", MessageBoxButtons.YesNo);
                                      if (dialogResult == DialogResult.Yes)
                                            {
                                                dbConnect.Insert("insert into tblName values ('" + stuFacNo + "','" + fname + "','" + mname + "','" + lname + "','" + email + "',2,false);");
                                                dbConnect.Insert("insert into tblFaculty values ('" + stuFacNo + "','" + depToCode(dep) + "','" + posToCode(posi, depToCode(dep)) + "');");
                                                Zen.Barcode.CodeQrBarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                                                QrCodeGen.Image = barcode.Draw(StuFacNo.Text, 50);
                                                QrCodeGen.Image = resizeImage(QrCodeGen.Image, new Size(178, 166));
                                                IDpicturee.Image = resizeImage(IDpicturee.Image, new Size(103, 107));
                                                QrCodeGen.Image.Save(source6 + StuFacNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                IDpicturee.Image.Save(source7 + StuFacNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                                using (Image image = Image.FromFile(source2))
                                                using (Image watermarkImage = Image.FromFile(source7 + StuFacNo.Text + ".jpg"))
                                                using (Image watermarkImage2 = Image.FromFile(source6 + StuFacNo.Text + ".jpg"))
                                                using (Graphics imageGraphics = Graphics.FromImage(image))
                                                using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
                                                using (TextureBrush watermarkBrush2 = new TextureBrush(watermarkImage2))
                                                {
                                                    int x = (16);
                                                    int y = (12);
                                                    int o = (323);
                                                    int p = (102);
                                                    int f = 14;
                                                    if (fullname.Length > 15)
                                                    {
                                                        f = 12;
                                                    }

                                                    watermarkBrush.TranslateTransform(x, y);
                                                    imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new System.Drawing.Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                                                    watermarkBrush2.TranslateTransform(o, p);
                                                    imageGraphics.FillRectangle(watermarkBrush2, new Rectangle(new System.Drawing.Point(o, p), new Size(watermarkImage2.Width + 1, watermarkImage2.Height)));
                                                    imageGraphics.DrawString(StuFacNo.Text, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(60, 137));
                                                    imageGraphics.DrawString(lname + ",", new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(82, 181));
                                                    imageGraphics.DrawString(fname + " " + mname, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(37, 204));
                                                    imageGraphics.DrawString(dep + ", " + posi, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(147, 247));
                                                    image.Save(source5 + StuFacNo.Text + ".jpg");
                                                     }

                                                    ID.Image = Image.FromFile(source5 + StuFacNo.Text + ".jpg");


                                                        StuFacNo.Enabled = false;
                                                        Fname.Enabled = false;
                                                        Mname.Enabled = false;
                                                        Lname.Enabled = false;
                                                        Emailbox.Enabled = false;
                                                        DepBox.Enabled = false;
                                                        PosBox.Enabled = false;
                                                        AdviserBox.Enabled = false;
                                                        SecBox.Enabled = false;
                                                        GenerateID.Visible = true;
                                                        RegStudent.Visible = false;
                                                        Student.Enabled = false;
                                                        getAdvisers();
                                                        getDepartments();
                                                    }
                                        else if (dialogResult == DialogResult.No)
                                                   
                                                    {


                                                    }
                               }
                            else
                            {
                                MessageBox.Show("Name format is invalid");
                            }
                        }
                 else {
                    MessageBox.Show("Faculty number must be 10 characters");
                      }
                            
                        }
        else if (StuFacNo.Text == "" || Fname.Text == "" || Mname.Text == "" || Lname.Text == "" || Emailbox.Text == "" || AdviserBox.Text == "" || SecBox.Text == "")
              {
                 MessageBox.Show("You must fill all the requirements correctly");
              }
          }

                    catch (Exception ex)
                    {
                        MessageBox.Show(fullname + " already registered!", "Warning", MessageBoxButtons.OK);
                        clrAll();
                    }
                }
                else
                {
                    MessageBox.Show("Please choose if you are a Faculty or a Student");
                }

           

            }
        }


        private void RegStudent_Click(object sender, EventArgs e)
        {
            int count;



            string[] columns2 = { "count(*)" };
            List<object>[] rs2 = new List<object>[1];
            rs2 = dbConnect.Select("select count(*) from tblName where boolNameIsDel = false;", columns2);

            count = int.Parse(rs2[0].ElementAt(0).ToString());





            if (count == 0)
            {
                RegisterBorrower();


            }
            else
            {

                bool isExist = false;
                List<object>[] rs;
                string[] columns = { "strNameCode" };
                rs = dbConnect.Select("select * from tblName  where boolNameIsDel = false;", columns);
                string stuFacNo = StuFacNo.Text;
                for (int i = 0; i < rs[0].Count; i++)
                {
                    if (stuFacNo.Equals(rs[0].ElementAt(i).ToString()))
                    {
                        MessageBox.Show("Student/Faculty number already exists");
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    RegisterBorrower();
                }
            }

            //Save to database

        }


        public int check = 0;
        public int no = 0;
        // Student section
        private void Student_CheckedChanged(object sender, EventArgs e)
        {
            if (no != 1)
            {
                sure = 0;


                if (StuFacNo.Text != "" || Fname.Text != "" || Mname.Text != "" || Lname.Text != "" || Emailbox.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "Your current data will not be save", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sure = 1;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        if (no != 1)
                        {
                            no = 1;
                           Student.PerformClick();

                        }

                    }
                }
                else
                {
                    sure = 1;
                }
                if (sure == 1)
                {
                    clrAll();
                    StudFactNo.Text = "Student Number: ";
                    StuFacNo.MaxLength = 7;

                    addep.Text = "Adviser: ";
                    secpos.Text = "Section: ";

                    SecBox.Visible = true;
                    AdviserBox.Visible = true;
                    DepBox.Visible = false;
                    PosBox.Visible = false;
                    AdviserBox.Visible = true;
                    SecBox.Visible = true;
                    ID.Image = Image.FromFile(source1);
                    IDpicturee.Image = null;
                    RegStudent.Enabled = false;
                    Addposition.Visible = false;
                    addDepartment.Visible = false;
                    Addsectionn.Visible = true;

                }
            }
        }

        // Faculty Section
        private void Faculty_CheckedChanged(object sender, EventArgs e)
        {

            if (no != 1)
            {
                sure = 0;

                if (StuFacNo.Text != "" || Fname.Text != "" || Mname.Text != "" || Lname.Text != "" || Emailbox.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "Your current data will not be save", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sure = 1;
                    }
                    else if (dialogResult == DialogResult.No)
                    {




                        no = 1;

                        Faculty.PerformClick();

                    }
                }
                else
                {
                    sure = 1;
                }
                if (sure == 1)
                {
                    clrAll();
                    StuFacNo.MaxLength = 10;
                    StudFactNo.Text = "Faculty Number: ";
                    addep.Text = "Department: ";
                    secpos.Text = "Position: ";
                    DepBox.Visible = true;
                    PosBox.Visible = true;
                    SecBox.Visible = false;
                    AdviserBox.Visible = false;
                    DepBox.Visible = true;
                    PosBox.Visible = true;
                    ID.Image = Image.FromFile(source2);
                    IDpicturee.Image = null;
                    RegStudent.Enabled = false;
                    Addposition.Visible = true;
                    addDepartment.Visible = true;
                    Addsectionn.Visible = false;

                }
            }
       

        }









        // Back to admin panel from registration
        private void Back_Click(object sender, EventArgs e)
        {
            sure = 0;
            if (RegStudent.Visible == false)
            {
                DialogResult dialogResult = MessageBox.Show("Done?", "The data has been saved successfully", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    sure = 1;
                    GenerateID.PerformClick();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            if (RegStudent.Visible == true)
            {
                if (StuFacNo.Text != "" || Fname.Text != "" || Mname.Text != "" || Lname.Text != "" || Emailbox.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "Your current data will not be save", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sure = 1;
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                else
                {
                    sure = 1;
                }
            }

            if (sure == 1)
            {
                clrAll();

                RegistrationPanel.Visible = false;
                panel1.Visible = true;
                QrCodeGen.Image = null;
                ID.Image = null;
                IDpicturee.Image = null;
                OptionPanel.Visible = true;
                RegiPanel.Visible = false;
                BorrowerButton.Enabled = true;

            }

        }


        //Done
        private void GenerateID_Click(object sender, EventArgs e)
        {
            clrAll();
            StuFacNo.Enabled = true;
            Fname.Enabled = true;
            Mname.Enabled = true;
            Lname.Enabled = true;
            Emailbox.Enabled = true;
            DepBox.Enabled = true;
            PosBox.Enabled = true;
            AdviserBox.Enabled = true;
            SecBox.Enabled = true;
            GenerateID.Visible = false;
            RegStudent.Visible = true;
            Student.Enabled = true;
            Faculty.Enabled = true;
            QrCodeGen.Image = null;
            RegStudent.Enabled = false;
            IDpicturee.Image = null;
            if (Student.Checked)
            {
                ID.Image = Image.FromFile(source1);
            }
            if (Faculty.Checked)
            {
                ID.Image = Image.FromFile(source2);
            }
        }

        public void clrAll()
        {
            StuFacNo.Text = "";
            Fname.Text = "";
            Mname.Text = "";
            Lname.Text = "";
            Emailbox.Text = "";
            DepBox.SelectedIndex = -1;
            SecBox.SelectedIndex = -1;
            PosBox.SelectedIndex = -1;
            AdviserBox.SelectedIndex = -1;
            IDpicturee.Image = null;
            RegStudent.Enabled = false;
        }




        //----------------------------INVENTORY--------------------------------------------------------------------------




        public string vendToCode(string vend)
        {
            List<object>[] rs;
            string[] columns = { "strVendCode" };
            rs = dbConnect.Select("select * from tblVendor where strVendName = '" + vend + "';", columns);
            return rs[0].ElementAt(0).ToString();
        }

        // Inventory panel
        private void Inventory_Click(object sender, EventArgs e)
        {
     

            InventoryPanel.Visible = true;
            panel1.Visible = false;
            RegistrationPanel.Visible = false;
            SettingsPanel.Visible = false;
            BorrowerButton.Enabled = false;
            InventoryOption.Visible = true;
            OptionPanel.Visible = false;

            //refresh datagrid
            z = 1;

            z = 0;
  
         

            refreshInventory();
  
            //refresh categories
            //refreshCategories();
            //refresh vendors


        }

        public void refreshAssets()
        {


            string itemSelect = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string[] columns = { "strAsseCode", "dtmAssePurchased", "strVendName", "Availability", "strModeName", "txtAsseNotes" };
            List<object>[] rs;
            rs = dbConnect.Select("select tblasset.strAsseCode,tblasset.dtmAssePurchased,tblvendor.strVendName,(select count(*) from tblAsset INNER JOIN tblborrowdetail on tblAsset.strAsseCode = tblborrowdetail.strBorDAsseCode where tblborrowdetail.dtmBorDDateReturned is null) as Availability, tblmodel.strModeName,tblasset.txtAsseNotes from tblAsset INNER JOIN tblVendor on tblAsset.strAsseVendCode = tblVendor.strVendCode INNER JOIN tblModel on(tblAsset.strAsseModeCode = tblmodel.strModeCode) where tblAsset.strAsseItemCode = '" + itemSelect + "' and tblAsset.boolAsseIsDel = false;", columns);
            //add to datagridview

            for (int i = 0; i < rs[0].Count; i++)
            {

            }

        }

        public bool itemIsExisting(string itemSearch)// FOR WHAT PURPOSE
        {
            List<object>[] rs;
            string[] columns = { "count(*)" };
            rs = dbConnect.Select("select count(*) from tblItemType where strItemCode = '" + itemSearch + "' and boolItemIsDel = true;", columns);
            if (int.Parse(rs[0].ElementAt(0).ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string categToCode(string categName)
        {
            string[] columns = { "strCategCode" };
            List<object>[] result;
            result = dbConnect.Select("SELECT strCategCode from tblCategory WHERE strCategName = '" + categName + "';", columns);

            //return code
            return result[0].ElementAt(0).ToString();
        }



        public void clrAllInve()
        {


        }
        //-----------------------------------------------NEWLY ADDED AFTER 75 GRADE--------------------------------------------





        public int countAvailableAssets(string itemToCount)
        {
            string[] columns = { "strAsseCode" };
            List<object>[] rs;
            rs = dbConnect.Select("select strAsseCode from tblAsset where tblasset.strAsseItemCode = '" + itemToCount + "' and tblAsset.boolAsseIsDel = false;", columns);
            //add to datagridview

            int availAssets = 0;
            for (int i = 0; i < rs[0].Count; i++)
            {
                if (isAvailable(rs[0].ElementAt(i).ToString()).Equals("Available"))
                {
                    availAssets++;
                }
            }

            return availAssets;
        }

        //-----------------------------------------------AFTER TRANGKASO-------------------------------------------------------------
          private void refreshInventory()
        {
            
            dataGridView2.Rows.Clear();
            string[] columns = { "strAsseCode", "strItemName", "strCategName", "strModeName" };
            List<object>[] rs;

            rs = dbConnect.Select("select tblAsset.strAsseCode,tblitemtype.strItemName,tblcategory.strCategName,tblmodel.strModeName from tblasset inner join tblitemtype on (tblasset.strAsseItemCode = tblitemtype.strItemCode) inner join tblcategory on(tblitemtype.strItemCategCode = tblcategory.strCategCode) inner join tblmodel on(tblmodel.strModeCode = tblasset.strAsseModeCode) inner join tblvendor on(tblvendor.strVendCode = tblasset.strAsseVendCode)  where tblasset.boolAsseIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {

                //dagdagReturn
                string displayAvailability = "";

                if (isUnavailable(rs[0].ElementAt(i).ToString()))
                {
                    displayAvailability = "Unavailable";
                }
                else
                {
                    displayAvailability = isAvailable(rs[0].ElementAt(i).ToString());
                }

                dataGridView2.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), rs[2].ElementAt(i).ToString(), rs[3].ElementAt(i).ToString(), displayAvailability);
            }
            //To update filters every time the datagrid is refreshed
            searchAndUpdateFilters();
     
        }

        public string isAvailable(string asseCodeToCheck)
        {
            int count = dbConnect.Count("select count(*) from (select * from tblborrowdetail a left join tblasset b on a.strBorDAsseCode = b.strAsseCode where a.dtmBorDDateReturned is null and a.strBorDAsseCode = '" + asseCodeToCheck + "') as t;");

            switch (count)
            {
                case 0:
                    return "Available";
                default:
                    return "Borrowed";
            }

        }
        public bool isExisting(string searchName, DataGridView tableToSearch)
        {
            bool doesExist = false;
            foreach (DataGridViewRow row in tableToSearch.Rows)
            {
                if (row.Cells[1].Value.ToString().ToUpper().Equals(searchName.ToUpper()))
                {
                    MessageBox.Show(searchName + " already exists!");
                    doesExist = true;
                    break;
                }
            }
            return doesExist;
        }
        public string getItemTypeCode(string codeOfWhat)
        {
            string returnCode = "";

            string[] columns = { "strItemCode" };
            List<object>[] rs;
            rs = dbConnect.Select("select strItemCode from tblItemType where strItemName = '" + codeOfWhat + "' and boolItemIsDel = false;", columns);

            returnCode = rs[0].ElementAt(0).ToString();

            return returnCode;
        }
        private bool canBorrow()
        {
            bool toReturn = true;

            int count = dbConnect.Count("select count(*) from tblborrowheader inner join tblborrowdetail on (tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) where tblborrowheader.strBorHNameCode = '" + borrCode + "' and tblborrowdetail.dtmBorDDateReturned is null;");

            if (count >= 3)
            {
                toReturn = false;
            }

            return toReturn;
        }
        //dagdagReturn
        private bool isUnavailable(string assetCode)
        {
            bool returnBool = false;
            string[] columns = { "intAsseStatus" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblAsset where strAsseCode = '" + assetCode + "';", columns);

            if (int.Parse(rs[0].ElementAt(0).ToString()) > 1)
            {
                returnBool = true;
            }

            return returnBool;
        }

        //----------------------------------------------------ADVANCE SEARCH---------------------------------------------------------
        private void searchAndUpdateFilters()
        {
            CategBox.Items.Clear();
            ModBox.Items.Clear();
            AvailBox.Items.Clear();
            //Add first BLANK SPACES for Clear
            CategBox.Items.Add("");
            ModBox.Items.Add("");
            AvailBox.Items.Add("");



            //Add options for availability
            AvailBox.Items.Add("Available");
            AvailBox.Items.Add("Borrowed");
            AvailBox.Items.Add("Unavailable"); //dagdagReturn


            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                //checking and updating category box
                bool doesExist = false;
                for (int categInd = 0; categInd < CategBox.Items.Count; categInd++)
                {
                    if (CategBox.Items[categInd].ToString().Equals(dataGridView2.Rows[i].Cells[2].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    CategBox.Items.Add(dataGridView2.Rows[i].Cells[2].Value.ToString());
                }
                //categ end
                //checking and updating model box
                doesExist = false; //reset checker
                for (int ModInd = 0; ModInd < ModBox.Items.Count; ModInd++)
                {
                    if (ModBox.Items[ModInd].ToString().Equals(dataGridView2.Rows[i].Cells[3].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    ModBox.Items.Add(dataGridView2.Rows[i].Cells[3].Value.ToString());
                }
                //mod end
            }
        }
        public void searchAndUpdateModels()
        {
            ModBox.Items.Clear();
            ModBox.Items.Add("");

            for (int i = 0; i < dataGridView2.RowCount; i++ )
            {
                bool doesExist = false; //reset checker
                for (int ModInd = 0; ModInd < ModBox.Items.Count; ModInd++)
                {
                    if (ModBox.Items[ModInd].ToString().Equals(dataGridView2.Rows[i].Cells[3].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist && dataGridView2.Rows[i].Visible)
                {
                    ModBox.Items.Add(dataGridView2.Rows[i].Cells[3].Value.ToString());
                }
            }
        }
        private void searchDataGrid()
        {
            if(//check if not all
                !this.categToShow.Equals("") &&
                !this.modelToShow.Equals("") &&
                !this.availToShow.Equals(""))
            {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (
                            (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                            (row.Cells[2].Value.ToString().Equals(this.categToShow)) &&
                            (row.Cells[3].Value.ToString().Equals(this.modelToShow)) &&
                            (row.Cells[4].Value.ToString().Equals(this.availToShow))
                            )
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
            }else if(
                this.categToShow.Equals("") &&
                this.modelToShow.Equals("") &&
                this.availToShow.Equals(""))
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().IndexOf(this.categToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[3].Value.ToString().IndexOf(this.modelToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[4].Value.ToString().IndexOf(this.availToShow, StringComparison.CurrentCultureIgnoreCase) != -1)
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }

            }
            else if (this.categToShow.Equals("") && this.availToShow.Equals(""))
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().IndexOf(this.categToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[3].Value.ToString().Equals(this.modelToShow)) &&
                        (row.Cells[4].Value.ToString().IndexOf(this.availToShow, StringComparison.CurrentCultureIgnoreCase) != -1)
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (this.categToShow.Equals("") && this.modelToShow.Equals(""))
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().IndexOf(this.categToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[3].Value.ToString().IndexOf(this.modelToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[4].Value.ToString().Equals(this.availToShow))
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (this.modelToShow.Equals("") && this.availToShow.Equals(""))
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().Equals(this.categToShow)) &&
                        (row.Cells[3].Value.ToString().IndexOf(this.modelToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[4].Value.ToString().IndexOf(this.availToShow, StringComparison.CurrentCultureIgnoreCase) != -1)
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }else if(this.categToShow.Equals("")){
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().IndexOf(this.categToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[3].Value.ToString().Equals(this.modelToShow)) &&
                        (row.Cells[4].Value.ToString().Equals(this.availToShow))
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }else if(this.modelToShow.Equals("")){
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().Equals(this.categToShow)) &&
                        (row.Cells[3].Value.ToString().IndexOf(this.modelToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[4].Value.ToString().Equals(this.availToShow))
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }else if (this.availToShow.Equals("")){
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().Equals(this.categToShow)) &&
                        (row.Cells[3].Value.ToString().Equals(this.modelToShow)) &&
                        (row.Cells[4].Value.ToString().IndexOf(this.availToShow, StringComparison.CurrentCultureIgnoreCase) != -1)
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            
        }
        private void searchAndUpdateCategoryFilter()
        {
            CategBox.Items.Clear();
            CategBox.Items.Add("");

            for (int i = 0; i < Dtgrid_ItemView.RowCount; i++)
            {
                //checking and updating category box
                bool doesExist = false;
                for (int categInd = 0; categInd < CategBox.Items.Count; categInd++)
                {
                    if (CategBox.Items[categInd].ToString().Equals(Dtgrid_ItemView.Rows[i].Cells[2].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    CategBox.Items.Add(Dtgrid_ItemView.Rows[i].Cells[2].Value.ToString());
                }
                //categ end
            }
        }
        private void searchDataGrid2()
        {
            if(
                itemNameToShow2.Equals("") &&
                categToShow2.Equals("")
                ){
                    foreach (DataGridViewRow row in Dtgrid_ItemView.Rows)
                    {
                        if (
                            (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow2, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                            (row.Cells[2].Value.ToString().IndexOf(this.categToShow2, StringComparison.CurrentCultureIgnoreCase) != -1)
                            )
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }

            }
            else if (
                !itemNameToShow2.Equals("") &&
                !categToShow2.Equals("")
                )
            {
                foreach (DataGridViewRow row in Dtgrid_ItemView.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow2, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().Equals(this.categToShow2))
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (itemNameToShow2.Equals(""))
            {
                foreach (DataGridViewRow row in Dtgrid_ItemView.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow2, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().Equals(this.categToShow2))
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else if (categToShow2.Equals(""))
            {
                foreach (DataGridViewRow row in Dtgrid_ItemView.Rows)
                {
                    if (
                        (row.Cells[1].Value.ToString().IndexOf(this.itemNameToShow2, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                        (row.Cells[2].Value.ToString().IndexOf(this.categToShow2, StringComparison.CurrentCultureIgnoreCase) != -1)
                        )
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
        }
        //------------------------------------------FOR BORROW LIST---------------------------------------------------------
 
        private void refreshStuBorrowerList()
        {
            this.StuBorrower.Rows.Clear();

            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where intNameType = 1 and boolNameIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                string name = rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString();
            
                this.StuBorrower.Rows.Add(rs[0].ElementAt(i).ToString(), name, rs[4].ElementAt(i).ToString());
            }

            try
            {
                refreshItemBorrowedList(this.StuBorrower.Rows[0].Cells[0].Value.ToString());
            }catch(Exception){
                MessageBox.Show("No Student Borrowers");
            }
        }
        private void refreshFacuBorrowerList()
        {
            this.FacuBorrower.Rows.Clear();

            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where intNameType = 2 and boolNameIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                string name = rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString();

                this.FacuBorrower.Rows.Add(rs[0].ElementAt(i).ToString(), name, rs[4].ElementAt(i).ToString());
            }

            try
            {
                refreshItemBorrowedList(this.FacuBorrower.Rows[0].Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("No Faculty Borrowers");
            }
        }
        //---------------------------------------
        //--------------------------------------------------FOR Item Borrowed List
        private void refreshItemBorrowedList(string currentNameCodeToDisplay)
        {
            this.ItemBorrowed.Rows.Clear();
            string[] columns = { "strItemName", "dtmBorHDateBorrowed","strBorDBorHCode","strBorDCode" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) where tblborrowheader.strBorHNameCode = '" + currentNameCodeToDisplay + "' and tblborrowdetail.dtmBorDDateReturned is null;", columns);
   
            for (int i = 0; i < rs[0].Count; i++)
            {
                string dateBorrowed = Convert.ToDateTime(rs[1].ElementAt(i).ToString()).ToString("MMM dd, yyyy");
                string expectedReturnDate = getExpectedReturnDate(Convert.ToDateTime(rs[1].ElementAt(i).ToString()).ToString("yyyy-MM-dd"));

                this.ItemBorrowed.Rows.Add(rs[0].ElementAt(i).ToString(), dateBorrowed, expectedReturnDate, computeFine(Convert.ToDateTime(expectedReturnDate)), rs[2].ElementAt(i).ToString(), rs[3].ElementAt(i).ToString());
            }
        }
        private string getExpectedReturnDate(string dateBorrowed)
        {
            DateTime date = Convert.ToDateTime(dateBorrowed);
            date = date.AddDays(7);

            return date.ToString("MMM dd, yyyy");
        }
        private string computeFine(DateTime expectedReturnDate)
        {
            double fine = 0;
            DateTime dateNow = DateTime.Now;

            //computing overdue days
            int overdueDays = (dateNow - expectedReturnDate).Days;

            //computing fine and making it string
            fine = overdueDays * 10d;

            //if not yet overdue
            if (fine < 0)
            {
                fine = 0;
            }

            return fine.ToString();
        }
        //--------------------
        //------------------------------------Event Handlers
        private void stuBorrower_CellClicked(object sender, EventArgs e)
        {
            refreshItemBorrowedList(StuBorrower.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void facuBorrower_CellClicked(object sender, EventArgs e)
        {
            refreshItemBorrowedList(FacuBorrower.SelectedRows[0].Cells[0].Value.ToString());
        }
        private void searchName_TextChanged(object sender, EventArgs e)
        {
            string toSearch = this.SearchName.Text;
            if (StuList.Checked)
            {
                foreach (DataGridViewRow row in this.StuBorrower.Rows)
                {
                    if ((row.Cells[1].Value.ToString().IndexOf(toSearch, StringComparison.CurrentCultureIgnoreCase)) != -1)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.FacuBorrower.Rows)
                {
                    if ((row.Cells[1].Value.ToString().IndexOf(toSearch, StringComparison.CurrentCultureIgnoreCase)) != -1)
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }

        }
        private void searchItem_TextChanged(object sender, EventArgs e)
        {
            string toSearch = SearchItem.Text;
            foreach (DataGridViewRow row in this.ItemBorrowed.Rows)
            {
                if ((row.Cells[0].Value.ToString().IndexOf(toSearch, StringComparison.CurrentCultureIgnoreCase)) != -1)
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        //-------------------------------------------FOR BORROWER INFO---------------------------------------------------------------
        private void refreshInfoStudList()
        {
            this.StudList.Rows.Clear();

            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail", "Advisor", "strSectName" };
            List<object>[] rs;
            rs = dbConnect.Select("select strNameCode,strNameFName,strNameMName,strNameLName,strNameEmail,(select CONCAT(strNameLName,', ',strNameFName,' ',strNameMName) from tblName where strNameCode = tblsection.strSectFacuCode) as Advisor,tblsection.strSectName from tblName inner join tblStudent on (tblName.strNameCode = tblstudent.strStudNameCode) inner join tblsection on(tblstudent.strStudSectCode = tblsection.strSectCode) where intNameType = 1 and boolNameIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                this.StudList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), rs[2].ElementAt(i).ToString(), rs[3].ElementAt(i).ToString(), rs[4].ElementAt(i).ToString(), rs[5].ElementAt(i).ToString(), rs[6].ElementAt(i).ToString());
            }

            searchAndUpdateFiltersBorrowerInfoStudent();
        }
        private void refreshInfoFacultyList()
        {
            this.FacultyList.Rows.Clear();

            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail", "strDepName", "strPosiName" };
            List<object>[] rs;
            rs = dbConnect.Select("select strNameCode,strNameFName,strNameMName,strNameLName,strNameEmail,strDepName,strPosiName from tblName inner join tblfaculty on(tblName.strNameCode = tblfaculty.strFacuNameCode) inner join tblposition on(tblfaculty.strFacuPosiCode = tblposition.strPosiCode) inner join tbldepartment on(tblfaculty.strFacuPosiDepCode = tbldepartment.strDepCode) where intNameType = 2 and boolNameIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                this.FacultyList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), rs[2].ElementAt(i).ToString(), rs[3].ElementAt(i).ToString(), rs[4].ElementAt(i).ToString(), rs[5].ElementAt(i).ToString(), rs[6].ElementAt(i).ToString());
            }


            searchAndUpdateFiltersBorrowerInfoFaculty();
        }
        //-------------------------------BORROWER INFO---------------------ADVANCE SEARCH---------------------------------------------------------
        private void searchAndUpdateFiltersBorrowerInfoStudent()
        {
            BorAdvisorbox.Items.Clear();
            BorSecBox.Items.Clear();
            //Add first BLANK SPACES for Clear
            BorAdvisorbox.Items.Add("");
            BorSecBox.Items.Add("");


            for (int i = 0; i < StudList.RowCount; i++)
            {
                //checking and updating category box
                bool doesExist = false;
                for (int j = 0; j < BorAdvisorbox.Items.Count; j++)
                {
                    if (BorAdvisorbox.Items[j].ToString().Equals(StudList.Rows[i].Cells[5].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    BorAdvisorbox.Items.Add(StudList.Rows[i].Cells[5].Value.ToString());
             
                 
                }
                //categ end
                //checking and updating model box
                doesExist = false; //reset checker
                for (int j = 0; j < BorSecBox.Items.Count; j++)
                {
                    if (BorSecBox.Items[j].ToString().Equals(StudList.Rows[i].Cells[6].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    BorSecBox.Items.Add(StudList.Rows[i].Cells[6].Value.ToString());
                    Section.Items.Add(StudList.Rows[i].Cells[6].Value.ToString());

                }
                //mod end
            }
        }
        private void searchAndUpdateFiltersBorrowerInfoFaculty()
        {
            BorDepBox.Items.Clear();
            BorPosBox.Items.Clear();
            //Add first BLANK SPACES for Clear
            BorDepBox.Items.Add("");
            BorPosBox.Items.Add("");


            for (int i = 0; i < FacultyList.RowCount; i++)
            {
                //checking and updating category box
                bool doesExist = false;
                for (int j = 0; j < BorDepBox.Items.Count; j++)
                {
                    if (BorDepBox.Items[j].ToString().Equals(FacultyList.Rows[i].Cells[5].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    BorDepBox.Items.Add(FacultyList.Rows[i].Cells[5].Value.ToString());
                }
                //categ end
                //checking and updating model box
                doesExist = false; //reset checker
                for (int j = 0; j < BorPosBox.Items.Count; j++)
                {
                    if (BorPosBox.Items[j].ToString().Equals(FacultyList.Rows[i].Cells[6].Value.ToString()))
                    {
                        doesExist = true;
                        break;
                    }
                }
                if (!doesExist)
                {
                    BorPosBox.Items.Add(FacultyList.Rows[i].Cells[6].Value.ToString());
                }
                //mod end
            }
        }
        private void searchDataGridStud()
        {

            foreach (DataGridViewRow row in StudList.Rows)
            {
                if (
                    (row.Cells[0].Value.ToString().IndexOf(this.borToShowStud, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                    ((row.Cells[1].Value.ToString() + " "+ row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString()).IndexOf(this.nameToShowStud, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                    (row.Cells[5].Value.ToString().IndexOf(this.advToShowStud, StringComparison.Ordinal) != -1) &&
                    (row.Cells[6].Value.ToString().IndexOf(this.secToShowStud, StringComparison.Ordinal) != -1)
                    )
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        private void searchDataGridFacu()
        {
            foreach (DataGridViewRow row in FacultyList.Rows)
            {
                if (
                    (row.Cells[0].Value.ToString().IndexOf(this.borToShowFacu, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                    ((row.Cells[1].Value.ToString() + " " + row.Cells[2].Value.ToString() + " " + row.Cells[3].Value.ToString()).IndexOf(this.nameToShowFacu, StringComparison.CurrentCultureIgnoreCase) != -1) &&
                    (row.Cells[5].Value.ToString().IndexOf(this.depToShowFacu, StringComparison.Ordinal) != -1) &&
                    (row.Cells[6].Value.ToString().IndexOf(this.posToShowFacu, StringComparison.Ordinal) != -1)
                    )
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
        //--------------------------------------------------REPORTS-----------------------------------------------------------------------
        private void refreshReportSection()
        {
            Section.Items.Clear();
            
            string[] columns = { "strSectName"};
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblSection where boolSectIsDel = false;",columns);

            for (int i = 0; i < rs[0].Count; i++ )
            {
                Section.Items.Add(rs[0].ElementAt(i).ToString());
            }
        }
        private void refreshReportDepartment()
        {
            Departments.Items.Clear();
            string[] columns = { "strDepName" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblDepartment where boolDepIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                Departments.Items.Add(rs[0].ElementAt(i).ToString());
            }
        }
        private void refreshReportCategory()
        {
            Category.Items.Clear();
            Category.Items.Add("ALL");

            string[] columns = { "strCategName" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblCategory where boolCategIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                Category.Items.Add(rs[0].ElementAt(i).ToString());
            }
        }
        private void refreshReportItemName()
        {
            ItemName.Items.Clear();
            ItemName.Items.Add("ALL");

            string[] columns = { "strItemName" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblItemType where boolItemIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                ItemName.Items.Add(rs[0].ElementAt(i).ToString());
            }
        }
        private void refreshReportItemName2()
        {
            ItemName2.Items.Clear();
            string[] columns = { "strItemName" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblItemType where boolItemIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                ItemName2.Items.Add(rs[0].ElementAt(i).ToString());
            }
        }
        //-----------------------------------------------------ITEM VIEWW----------------------------------------------------------
        private void refreshDGridItemView()
        {
            Dtgrid_ItemView.Rows.Clear();
            string[] columns = { "strItemCode","strItemName","strCategName","Quantity","Available","Borrowed","Unavailable"};
            List<object>[] rs;
            rs = dbConnect.Select("select tblitemtype.strItemCode,tblitemtype.strItemName,tblCategory.strCategName,(select count(*) from tblasset where tblasset.strAsseItemCode = tblitemtype.strItemCode and tblasset.boolAsseIsDel = false) as Quantity,((select count(*) from tblasset where tblasset.strAsseItemCode = tblitemtype.strItemCode and tblasset.boolAsseIsDel = false) - (select count(*) from tblasset inner join tblborrowdetail on(tblasset.strAsseCode = tblborrowdetail.strBorDAsseCode) where tblborrowdetail.dtmBorDDateReturned is null and tblasset.strAsseItemCode = tblitemtype.strItemCode and tblasset.boolAsseIsDel = false) - (select count(*) from tblasset where tblasset.strAsseItemCode = tblitemtype.strItemCode and tblasset.intAsseStatus != 1 and tblasset.boolAsseIsDel = false)) as Available,(select count(*) from tblasset inner join tblborrowdetail on(tblasset.strAsseCode = tblborrowdetail.strBorDAsseCode) where tblborrowdetail.dtmBorDDateReturned is null and tblasset.strAsseItemCode = tblitemtype.strItemCode and tblasset.boolAsseIsDel = false) as Borrowed,(select count(*) from tblasset where tblasset.strAsseItemCode = tblitemtype.strItemCode and tblasset.intAsseStatus != 1 and tblasset.boolAsseIsDel = false) as Unavailable from tblitemtype inner join tblCategory on(tblCategory.strCategCode = tblItemtype.strItemCategCode) where tblitemtype.boolItemIsDel = false;", columns);
            for (int i = 0; i < rs[0].Count;i++ )
            {
                Dtgrid_ItemView.Rows.Add(rs[0].ElementAt(i).ToString(),rs[1].ElementAt(i).ToString(),rs[2].ElementAt(i).ToString(),rs[3].ElementAt(i).ToString(),rs[4].ElementAt(i).ToString(),rs[5].ElementAt(i).ToString(),rs[6].ElementAt(i).ToString());
            }
            searchAndUpdateCategoryFilter();
        }

        //-----------------------------------------------GENERATED CODES------------------------------------------------------------
        public static int r = 0;
        // Adding Item to the database


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            //for listing the assets
            // Category.SelectedItem = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                refreshAssets();
                //refreshModelscmbInventory(row.Cells[0].Value.ToString());
            }

            //for edit button

            AddIT.Visible = true;

            //clear fields
            //--Item
            // ItemName.Text = "";
            //  Category.SelectedIndex = -1;
            //--Asset

            //this.Vendorbox.SelectedIndex = -1;

            //generateItemCode
            // this.ItemCode.Text = codeGenerator.generateCodeParent("tblItemType", "strItemCode","Item");
            //generateAssetCode
            //if delete
            /*
            if (z != 1)
            {

                this.AssoCode.Text = codeGenerator.generateCodeChild("tblAsset", "strAsseCode", dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString());
                z = 0;

            }
             *///GHOOST CODEE


        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //for edit button

            //clear fields
            //--Item

            //--Asset

            this.Vendorbox.SelectedIndex = -1;

        }


        // Show specific item
        private void showspecs_Click(object sender, EventArgs e)
        {

        }

        // Searching items
        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            if(PerAssetView.Checked){
                itemNameToShow = Searchbox.Text;
                searchDataGrid();
                searchAndUpdateModels();
            }else if(PerItemView.Checked){
                itemNameToShow2 = Searchbox.Text;
                searchDataGrid2();
            }
        }

        public int z;
        // Delete items in database
        private void DeleteIT_Click(object sender, EventArgs e)
        {

            try
            {
                string c = this.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                foreach (DataGridViewRow row in this.dataGridView2.SelectedRows)
                {
                    //delete in database
                    dbConnect.Update("Update tblItemType SET boolItemIsDel = true WHERE strItemCode = '" + row.Cells[0].Value.ToString() + "';");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No selected item");
            }
            z = 1;
            refreshInventory();
            z = 0;
        }



        // Clear Text in item inventory section
        private void ClearText_Click(object sender, EventArgs e)
        {

        }

        // Editing Specific item


        // Clear Specific item section
        private void ClearText2_Click(object sender, EventArgs e)
        {
            Vendorbox.SelectedIndex = -1;


            //generateAssetCode
            this.AssoCode.Text = codeGenerator.generateCodeChild("tblAsset", "strAsseCode", dataGridView2.CurrentRow.Cells[0].Value.ToString(), dataGridView2.CurrentRow.Cells[1].Value.ToString());

        }


        // back to admin panel from inventory
        private void InventoryBack_Click(object sender, EventArgs e)
        {

            InventoryPanel.Visible = false;
            SettingsPanel.Visible = false;
            RegistrationPanel.Visible = false;
            panel1.Visible = true;
            BorrowerButton.Enabled = true;
            InventoryOption.Visible = false;
            OptionPanel.Visible = true;
        }






        //END OF METHODS
        private void Shutdown_Click(object sender, EventArgs e)
        {
            open = 1;
            AdminLogIn login = new AdminLogIn();
            login.ShowDialog();

        }


        private void Select_Click(object sender, EventArgs e)
        {

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }






        private void PosBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //----------------------------SETTINGS--------------------------------------------------------------------------
        // Settings panel

        private void Settings_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;
            RegistrationPanel.Visible = false;
            SettingsPanel.Visible = true;
            InventoryPanel.Visible = false;

        }
        int borcount = 0;
        private void ShowNotification()
        {
         
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where boolNameIsDel = false;", columns);
            string expectedReturnDate = "";
            string beforeReturnDate = "";
            string notificationDate = "";
            for (int i = 0; i < rs[0].Count; i++)
            {
               
                bcode = rs[0].ElementAt(i).ToString();
          
                string bfname = rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString();
     
                string[] columns2 = { "strItemName", "dtmBorHDateBorrowed", "strBorDBorHCode", "strBorDCode" };
                List<object>[] rs2;
                rs2 = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) where tblborrowheader.strBorHNameCode = '" + bcode + "' and tblborrowdetail.dtmBorDDateReturned is null;", columns2);


                for (int n = 0; n < rs2[0].Count; n++)
                {
                    expectedReturnDate = getExpectedReturnDate(Convert.ToDateTime(rs2[1].ElementAt(n).ToString()).ToString("yyyy-MM-dd"));
                    DateTime expectedreturndate2 = Convert.ToDateTime(expectedReturnDate);
                    beforeReturnDate = expectedreturndate2.AddDays(-3).ToString("yyyy-MM-dd");
                    notificationDate = DateTime.Today.ToString("yyyy-MM-dd");
                        
                    if (notificationDate == beforeReturnDate){
                        borcount++;
                       
                    
                }
                }
            }

            //  string pictoload = source7 + bcode + ".jpg";
            int duration;
            int.TryParse("sticky (click to dismiss)", out duration);
            if (duration <= 0)
            {
                duration = -1;
            }

            var animationMethod = FormAnimator.AnimationMethod.Slide;
            foreach (FormAnimator.AnimationMethod method in Enum.GetValues(typeof(FormAnimator.AnimationMethod)))
            {
                if (string.Equals(method.ToString(), "Slide"))
                {
                    animationMethod = method;
                    break;
                }
            }

            var animationDirection = FormAnimator.AnimationDirection.Up;
            foreach (FormAnimator.AnimationDirection direction in Enum.GetValues(typeof(FormAnimator.AnimationDirection)))
            {
                if (string.Equals(direction.ToString(), "Up"))
                {
                    animationDirection = direction;
                    break;
                }
            }

            if (borcount > 0){
            var toastNotification = new Notification(borcount,message, emailpass,curremail, duration, animationMethod, animationDirection);
            //  PlayNotificationSound(comboBoxSound.Text);

            toastNotification.Show();
            borcount = 0;
            }
        }


        // Camera Devices
        private void WebcamScanner_Load(object sender, EventArgs e)
        {
           

          
            ShowNotification();
            pictureBox1.Image = Image.FromFile(source7 + "custodian.png");
            adminpicture.Image = Image.FromFile(source7 + "custodian.png");
            AdminName.Text = currname;
            player = new SoundPlayer();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                Cameralist.Items.Add(Device.Name);
            }
            Cameralist.SelectedIndex = 0;
            FromDate.Value = DateTime.Today;
            Todate.Value = DateTime.Today;
          


        }

        public void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {

                pictureBox3.Image = (Bitmap)eventArgs.Frame.Clone();

            }
            catch
            {

            }
            //pictureBox1.Image = eventArgs.Frame.Clone() as Bitmap;
            //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();  
        }


        // Change camera
        private void Changecam_CheckedChanged(object sender, EventArgs e)
        {
            if (Changecam.Checked == true)
            {
                Cameralist.Enabled = true;
                set1.Visible = true;
            }
            if (Changecam.Checked == false)
            {
                Cameralist.Enabled = false;
                set1.Visible = false;
            }
        }

        // Back to admin panel from settings
        private void BackSettings_Click(object sender, EventArgs e)
        {

            SettingsPanel.Visible = false;
            panel1.Visible = true;
            BtnSettings.Image = Properties.Resources.SettingsImg2;
        }

        // Changing of camera
        public static int j = 0;

        private void set1_Click(object sender, EventArgs e)
        {



            FinalFrame = new VideoCaptureDevice(CaptureDevice[Cameralist.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            IDpicture idcam = new IDpicture(this);
       
            IJE.IDpicture.FinalFrame = new VideoCaptureDevice(CaptureDevice[Cameralist.SelectedIndex].MonikerString);
            IJE.IDpicture.FinalFrame.NewFrame += new NewFrameEventHandler(idcam.FinalFrame_NewFrame);

            



            Changecam.Checked = false;


        }

        //  Present time.
        private void timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
            lblDate.Text = DateTime.Now.ToString("MM/dd/yy");
            lblDay.Text = DateTime.Now.ToString("ddd");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }








        private void date_TextChanged(object sender, EventArgs e)
        {

        }



        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void refresh_FormClosed2(object sender, FormClosedEventArgs e)
        {
            refreshInventory();
        }

        private void DataGridView2CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ItemInfo itin = new ItemInfo(dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), this.getItemTypeCode(dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
            itin.FormClosed += new FormClosedEventHandler(refresh_FormClosed2);
            itin.ShowDialog();
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemInfo itin = new ItemInfo(dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), this.getItemTypeCode(dataGridView2.SelectedRows[0].Cells[1].Value.ToString()));
            itin.FormClosed += new FormClosedEventHandler(refresh_FormClosed2);
            itin.ShowDialog();
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void StudFactNo_Click(object sender, EventArgs e)
        {

        }

        private void FirstName_Click(object sender, EventArgs e)
        {

        }

        private void postext_TextChanged(object sender, EventArgs e)
        {

        }

        private void Emailbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ID_Click(object sender, EventArgs e)
        {

        }

        private void DepBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                getPositions(depToCode(DepBox.SelectedItem.ToString()));
            }
            catch (Exception)
            {
                //wont do anything if you back
            }
        }

        private void addep_Click(object sender, EventArgs e)
        {

        }



        private void secpos_Click(object sender, EventArgs e)
        {

        }

        private void Advtext_Click(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Searchbox_Click(object sender, EventArgs e)
        {
            Searchbox.Clear();
        }

        private void vendoradd_Click(object sender, EventArgs e)
        {

        }


        private void ItemName_Click(object sender, EventArgs e)
        {

        }


        private void postext_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteAc_Click(object sender, EventArgs e)
        {

            try
            {

            }
            catch
            {
                MessageBox.Show("No selected asset");

            }
            refreshAssets();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            QrCodeScanner.Enabled = true;
            QrCodeScanner.Start();
        }

        private void quit_Click(object sender, EventArgs e)
        {
            QrCodeScanner.Stop();
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
                FinalFrame.NewFrame -= new NewFrameEventHandler(FinalFrame_NewFrame);
            }
            this.Close();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Reports_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            ReportsPanel.Visible = true;
            BorrowerButton.Enabled = false;
            refreshReportSection();
            refreshReportDepartment();
            refreshReportItemName();
            refreshReportCategory();
            refreshReportItemName2();
        }
        private void refresh_FormClosed(object sender, FormClosedEventArgs e)
        {
            //refresh datagrid
            refreshInventory();
            //refresh categories
            //refreshCategories();
            ////refresh vendors

            //---//get adv
            getAdvisers();
            //---//get dep
            getDepartments();


        }


        private void Maintenance_Click(object sender, EventArgs e)
        {
            maintenance mainte = new maintenance();
            mainte.FormClosed += new FormClosedEventHandler(refresh_FormClosed);
            mainte.ShowDialog();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void InventoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Datepur_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void BorrowerInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public static bool isstudent;
        private void StudInfo_CheckedChanged(object sender, EventArgs e)
        {
            StudList.Visible = true;
            FacultyList.Visible = false;
            isstudent = true;
            BorNo.Text = "Student Number: ";
            BorNoInfo.MaxLength = 7;

            BorAdviDep.Text = "Adviser: ";
            BorDepPos.Text = "Section: ";

            BorSecBox.Visible = true;
            BorAdvisorbox.Visible = true;
            BorDepBox.Visible = false;
            BorPosBox.Visible = false;
          
            //refresh StudList
            refreshInfoStudList();
        }

        private void FacuInfo_CheckedChanged(object sender, EventArgs e)
        {
            StudList.Visible = false;
            FacultyList.Visible = true;
            isstudent = false;
            BorNo.Text = "Faculty Number: ";
            BorNoInfo.MaxLength = 10;

            BorAdviDep.Text = "Department: ";
            BorDepPos.Text = "Position: ";

            BorSecBox.Visible = false;
            BorAdvisorbox.Visible = false;
            BorDepBox.Visible = true;
            BorPosBox.Visible = true;

            //refresh FacultyList
            refreshInfoFacultyList();
        }

        private void BorrowerInfo_Click(object sender, EventArgs e)
        {
            BorrowerInfoPanel.Visible = true;
            panel1.Visible = false;
            BorrowerButton.Enabled = false;
            StudInfo.Checked = true;
            OptionPanel.Visible = false;
            BorrowerInfoOption.Visible = true;
            refreshInfoStudList();
        }

        private void BorInfoBack_Click(object sender, EventArgs e)
        {
            BorrowerInfoPanel.Visible = false;
            panel1.Visible = true;
  

        }





        private void BackBorrList_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            BorrowerButton.Enabled = true;
            BorrowListPanel.Visible = false;
        }

        private void BorrowList_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            BorrowerButton.Enabled = false;
            BorrowListPanel.Visible = true;
            StuList.Checked = true;

        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            StuBorrower.Visible = true;
            FacuBorrower.Visible = false;

            //refrsh the StuBorrowerList
            refreshStuBorrowerList();
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            StuBorrower.Visible = false;
            FacuBorrower.Visible = true;

            //refrsh the FacuBorrowerList
            refreshFacuBorrowerList();
        }

        private void AdviserBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //inside try catch for Back button
            try
            {
                getSections(advToCode(AdviserBox.SelectedItem.ToString()));
            }
            catch (Exception)
            {
                //wont do anything if you back
            }

        }

        private void SecBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BrandBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                QrCodeScanner.Start();
                timer2.Stop();
            }
        }

        private void ItemCode_Click(object sender, EventArgs e)
        {

        }

        private void Categ_Click(object sender, EventArgs e)
        {

        }

        private void Itemcodelabel_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        public int strt = 0;
        public int acct = 0;
        public int logout = 1;
        private void CustodianButton_Click(object sender, EventArgs e)
        {
            CustodianButton.BackgroundImage = Properties.Resources.custodianSelect;
            BorrowerButton.BackgroundImage = Properties.Resources.borrowerNormal;
            t = 2;
            if (strt != 1)
            {
                strt = 1;
                timer3.Start();
                decoded = "";

            }
            logout = 1;

            pictureBox1.Image = Image.FromFile(source7 + "custodian.png");
            CustodianButton.Enabled = false;
            BorrowerButton.Enabled = true;
            panel7.Visible = true;
            BorrowerLogIn.Visible = false;
            panel1.Visible = true;
            AdminName.Text = currname;
            BorrowerPanel.Visible = false;
            QrCodeScanner.Stop();
            OptionPanel.Visible = true;
            BorInfo.Visible = false;
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
                FinalFrame.NewFrame -= new NewFrameEventHandler(FinalFrame_NewFrame);
            }



        }
        public int t = 2;
        private void BorrowerButton_Click(object sender, EventArgs e)
        {

            BorrowerButton.BackgroundImage = Properties.Resources.borrowerSelect;
            CustodianButton.BackgroundImage = Properties.Resources.custodianNormal;
            t = 1;
            if (acct != 1)
            {

                FinalFrame = new VideoCaptureDevice(CaptureDevice[Cameralist.SelectedIndex].MonikerString);
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                FinalFrame.Start();
                pictureBox3.Focus();
                timer2.Start();
                strt = 2;
                panel7.Visible = false;
                timer3.Start();

                BorrowerLogIn.Visible = true;

               

            }
            if (acct == 1)
            {
                BorrowerLogIn.Visible = false;
                panel7.Visible = true;
                pictureBox1.Image = Image.FromFile(source7 + borrCode + ".jpg");
                logout = 2;
                OptionPanel.Visible = false;
                BorInfo.Visible = true;
                AdminName.Text = borrowername;
            }

            CustodianButton.Enabled = true;
            BorrowerButton.Enabled = false;
            panel1.Visible = false;
            BorrowerPanel.BringToFront();
            BorrowerPanel.Visible = true;
         

        }

        public int init = 250;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (strt == 1)
            {
                init = init - 141;
                panel5.Location = new System.Drawing.Point(0, init);
                if (init == 250)
                {
                    timer3.Stop();

                }
            }
            if (strt == 2)
            {
                init = init + 141;
                panel5.Location = new System.Drawing.Point(0, init);
                if (init == 673)
                {
                    timer3.Stop();

                }
            }
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            BorrowerPanel.Enabled = true;
        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void CancelEdit_Click(object sender, EventArgs e)
        {

        }

            private void BorrowerInfoBack_Click(object sender, EventArgs e)
            {
                this.BorrowerInfoPanel.Visible = false;
                BorrowerButton.Enabled = true;
                panel1.Visible = true;
                OptionPanel.Visible = true;
                BorrowerInfoOption.Visible = false;
           
            }

        private void BorrowButton_Click(object sender, EventArgs e)
        {
            if (canBorrow())
            {
                
                BorrowerButtons.Visible = false;
                BorrowerPanel.BackgroundImage = Properties.Resources.borrowepanel2;
                BorrowerBack.Visible = true;
                borrow3.Visible = true;
                CustodianButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("You have already Borrowed 3 Items, return item/se in order to borrow another.");
            }


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
             CustodianButton.Enabled = false;
            BorrowerButtons.Visible = false;
            BorrowerPanel.BackgroundImage = Properties.Resources.returnpanel2;
            BorrowerBack.Visible = true;
            rent3.Visible = true;
        }

        private void BorrowerLogIn_Paint(object sender, PaintEventArgs e)  
        {

        }

       

        private void BorrowerBack_Click(object sender, EventArgs e)
        {
               CustodianButton.Enabled = true;
            BorrowerButtons.Visible = true;
            borrow2.Visible = false;
            rent2.Visible = false;
            BorrowerBack.Visible = false;
            BorrowerPanel.BackgroundImage = Properties.Resources.BORROWERS_MENU;
            rent3.Visible = false;
            borrow3.Visible = false;
        }

        public string decoded;
        public int access = 0;
        private void QrCodeScanner_Tick(object sender, EventArgs e)
        {
            List<object>[] rs;

            string[] columns = { "strNameCode", "strNameFName" };
            rs = dbConnect.Select("select * from tblName where boolNameIsDel = false;", columns);
            BarcodeReader Reader = new BarcodeReader { AutoRotate = true };
            QRCodeReader qrReader = new QRCodeReader();
            Result result = Reader.Decode((Bitmap)pictureBox3.Image);
            if (result != null)
            {
                decoded = result.ToString().Trim();

                if (decoded != "")
                {
                    QrCodeScanner.Stop();
                    if (FinalFrame.IsRunning == true)
                    {
                        FinalFrame.Stop();
                        FinalFrame.NewFrame -= new NewFrameEventHandler(FinalFrame_NewFrame);
                    }

                    bool register = true;
                    for (int i = 0; i < rs[0].Count; i++)
                    {
                        if (decoded.Equals(rs[0].ElementAt(i)))
                        {
                            loadingg.Visible = true;
                            loadingg.Text = "Hi " + rs[1].ElementAt(i).ToString();
                            try
                            {
                                pictureBox3.Image = Image.FromFile(source7 + decoded + ".jpg");
                            }
                            catch
                            {
                                pictureBox3.Image = Properties.Resources.borrower;
                            }
                            LogIn.Enabled = true;
                            CancelLogin.Enabled = true;
                            Loading.Visible = false;
                            access = 1;
                            break;
                        }
                        if (i == rs[0].Count -1)
                        {

                            if (!decoded.Equals(rs[0].ElementAt(i)))
                            {   
                                decoded = "";
                                MessageBox.Show("Unregistered QR code.");
                                pictureBox3.Image = null;
                                    
                                register = false;
                                break;
                            }
                        }

                    }
                    if (!register){

                          FinalFrame = new VideoCaptureDevice(CaptureDevice[Cameralist.SelectedIndex].MonikerString);
                                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                                FinalFrame.Start();
                                pictureBox3.Focus();
                                timer2.Start();
                                register = true;
                    }


                }
            }
            checkk.PerformClick();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CategBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(PerAssetView.Checked){
                categToShow = CategBox.SelectedItem.ToString();
                searchDataGrid();
                searchAndUpdateModels();
            }else if(PerItemView.Checked){
                categToShow2 = CategBox.SelectedItem.ToString();
                searchDataGrid2();
            } 
        }

        private void ModBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelToShow = ModBox.SelectedItem.ToString();
            searchDataGrid();
        }

        private void AvailBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            availToShow = AvailBox.SelectedItem.ToString();
            searchDataGrid();
            searchAndUpdateModels();
        }

        private void FacultyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BorrowerInfo BI = new BorrowerInfo(FacultyList.SelectedRows[0].Cells[0].Value.ToString());
            BI.FormClosed += new FormClosedEventHandler(refreshBinfo2_FormClosed);
            BI.ShowDialog();
        }

        private void StudList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BorrowerInfo BI = new BorrowerInfo(StudList.SelectedRows[0].Cells[0].Value.ToString());
            BI.FormClosed += new FormClosedEventHandler(refreshBinfo_FormClosed);
            BI.ShowDialog();
        }
        private void refreshBinfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            refreshInfoStudList();

        }

        private void refreshBinfo2_FormClosed(object sender, FormClosedEventArgs e)
        {
          
            refreshInfoFacultyList();

        }

        private void borrow1_Load(object sender, EventArgs e)
        {

        }

        private void SearchName_Click(object sender, EventArgs e)
        {

        }

        private void SearchItem_Click(object sender, EventArgs e)
        {

        }

        private void SearchOverdue_CheckedChanged(object sender, EventArgs e)
        {
            if (SearchOverdue.Checked)
            {//if Checked
                foreach (DataGridViewRow row in ItemBorrowed.Rows)
                {
                    //if there is no fine = not overdue
                    if (row.Cells[3].Value.ToString().Equals("0"))
                    {
                        row.Visible = false;
                    }
                    else //if none
                    {
                        row.Visible = true;
                    }
                }
            }
            else // if not checked Reset it
            {
                foreach (DataGridViewRow row in ItemBorrowed.Rows)
                {
                    row.Visible = true;
                }
            }
        }

       
        private void checkk_Click(object sender, EventArgs e)
        {
            QrCodeScanner.Enabled = true;
            QrCodeScanner.Start();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrowerInfo BI = new BorrowerInfo(borrCode);
            BI.ShowDialog();
        }

        private void ItemBorrowed_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BorrowedItemDetail BID = new BorrowedItemDetail(ItemBorrowed.SelectedRows[0].Cells[4].Value.ToString(), ItemBorrowed.SelectedRows[0].Cells[5].Value.ToString());
            BID.ShowDialog();
        }

        private void Register_MouseHover(object sender, EventArgs e)
        {
            Register.Image = Properties.Resources.anni6;
        }

        private void Register_MouseLeave(object sender, EventArgs e)
        {
            Register.Image = Properties.Resources.register;
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsPanel.BringToFront();
            SettingsPanel.Visible = true;
          

            BtnSettings.Image = Properties.Resources.SettingsSelect;
        }

        private void BtnSettings_MouseHover(object sender, EventArgs e)
        {
            if (SettingsPanel.Visible == true)
            {
                BtnSettings.Image = Properties.Resources.SettingsSelect;
            }
            else
            {
                BtnSettings.Image = Properties.Resources.SettingsHover;
            }


        }

        private void BtnSettings_MouseLeave(object sender, EventArgs e)
        {
            if (SettingsPanel.Visible == true)
            {
                BtnSettings.Image = Properties.Resources.SettingsSelect;
            }
            else
            {
                BtnSettings.Image = Properties.Resources.SettingsImg2;
            }
        }

        private void BtnDesktop_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public int l = 0;
        private void BtnShutdown_Click(object sender, EventArgs e)
        {
            BtnShutdown.Image = Properties.Resources.shutdownselect;
           // open = 1;
            //l = 1;
            //AdminLogIn login = new AdminLogIn();
            //login.ShowDialog();
             DialogResult dialogResult = MessageBox.Show("Are you sure you want to shutdown? Be sure that all your work is done before shutting down.", "Shut down?", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 Application.Exit();
             }
             else if (dialogResult == DialogResult.No)
             {
         BtnShutdown.Image = Properties.Resources.shutdownimg;

             }
           

        }

        private void BtnDesktop_MouseHover(object sender, EventArgs e)
        {
            BtnDesktop.Image = Properties.Resources.desktophover;

        }

        private void BtnDesktop_MouseLeave(object sender, EventArgs e)
        {
            BtnDesktop.Image = Properties.Resources.desktopimg2;
        }

        private void BtnShutdown_MouseHover(object sender, EventArgs e)
        {
            BtnShutdown.Image = Properties.Resources.shutdownhover;
        }

        private void BtnShutdown_MouseLeave(object sender, EventArgs e)
        {

            if (l == 1)
            {
                BtnShutdown.Image = Properties.Resources.shutdownselect;
                l = 0;
            }
            else
            {
                BtnShutdown.Image = Properties.Resources.shutdownimg;
            }
        }

        private void CustodianButton_MouseHover(object sender, EventArgs e)
        {
            if (t == 2)
            {
                CustodianButton.BackgroundImage = Properties.Resources.custodianSelect;

            }
            else
            {
                CustodianButton.BackgroundImage = Properties.Resources.custodianHover;
            }

        }

        private void CustodianButton_MouseLeave(object sender, EventArgs e)
        {
            if (t == 2)
            {
                CustodianButton.BackgroundImage = Properties.Resources.custodianSelect;

            }
            else
            {
                CustodianButton.BackgroundImage = Properties.Resources.custodianNormal;
            }
        }

        private void BorrowerButton_MouseHover(object sender, EventArgs e)
        {
            if (t == 1)
            {
                BorrowerButton.BackgroundImage = Properties.Resources.borrowerSelect;

            }
            else
            {
                BorrowerButton.BackgroundImage = Properties.Resources.borrowerHover;
            }
        }

        private void BorrowerButton_MouseLeave(object sender, EventArgs e)
        {
            if (t == 1)
            {
                BorrowerButton.BackgroundImage = Properties.Resources.borrowerSelect;


            }
            else
            {
                BorrowerButton.BackgroundImage = Properties.Resources.borrowerNormal;
            }
        }

        private void BorrowerInfo_MouseHover(object sender, EventArgs e)
        {
            BorrowerInfo.Image = Properties.Resources.anni3;
        }

        private void BorrowerInfo_MouseLeave(object sender, EventArgs e)
        {
            BorrowerInfo.Image = Properties.Resources.borrowerInfo;
        }

        private void BorrowList_MouseHover(object sender, EventArgs e)
        {
            BorrowList.Image = Properties.Resources.anni1;
        }

        private void BorrowList_MouseLeave(object sender, EventArgs e)
        {
            BorrowList.Image = Properties.Resources.borrowList;
        }

        private void Maintenance_MouseHover(object sender, EventArgs e)
        {
            Maintenance.Image = Properties.Resources.anni5;
        }

        private void Maintenance_MouseLeave(object sender, EventArgs e)
        {
            Maintenance.Image = Properties.Resources.maintenance;
        }

        private void Inventory_MouseHover(object sender, EventArgs e)
        {
            Inventory.Image = Properties.Resources.anni4;
        }

        private void Inventory_MouseLeave(object sender, EventArgs e)
        {
            Inventory.Image = Properties.Resources.inventory1;
        }

        private void Reports_MouseHover(object sender, EventArgs e)
        {
            Reports.Image = Properties.Resources.anni7;

        }

        private void Reports_MouseLeave(object sender, EventArgs e)
        {
            Reports.Image = Properties.Resources.report;
        }


        public int c = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            BtnLogout.BackgroundImage = Properties.Resources.logoutselect;
            c = 1;
            if (logout == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Be sure that all your work is done before logging out.", "Log out?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //log out admin
                    dbConnect.Update("update tblAdmin set boolAdmIsLoggedIn = false;");
                    

                    Front front = new Front();
                    front.Show();
                    this.Hide();

                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            if (logout == 2)
            {
                FinalFrame = new VideoCaptureDevice(CaptureDevice[Cameralist.SelectedIndex].MonikerString);
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                FinalFrame.Start();
                pictureBox3.Focus();
                timer2.Start();
                strt = 2;
                acct = 0;
                CancelLogin.Enabled = false;
                loadingg.Visible = false;

                AdminName.Text = "";
                panel7.Visible = false;
                timer3.Start();
                borrow2.Visible = false;
                rent2.Visible = false;
                BorrowerLogIn.Visible = true;
                BorrowerPanel.BackgroundImage = Properties.Resources.BORROWERS_MENU;
                BorrowerButtons.Enabled = false;
                LogIn.Enabled = false;
                BorInfo.Visible = false;
                BorrowerBack.PerformClick();
            }
            BtnLogout.BackgroundImage = Properties.Resources.logoutnormal;
        }

        private void BtnLogout_MouseHover(object sender, EventArgs e)
        {
            BtnLogout.BackgroundImage = Properties.Resources.logouthover;
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            if (c == 1)
            {
                BtnLogout.BackgroundImage = Properties.Resources.logoutselect;
                c = 0;
            }
            else
            {
                BtnLogout.BackgroundImage = Properties.Resources.logoutnormal;
            }
        }

        private void Mname_Click(object sender, EventArgs e)
        {

        }

        private void Lname_Click(object sender, EventArgs e)
        {

        }

        private void Fname_Click(object sender, EventArgs e)
        {

        }

        private void LastName_Click(object sender, EventArgs e)
        {

        }

        private void MiddleName_Click(object sender, EventArgs e)
        {

        }

        private void OptionPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void Modelabel_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Searchbox_MouseLeave(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            Searchbox.Clear();

            CategBox.SelectedIndex = 0;
            ModBox.SelectedIndex = 0;
            AvailBox.SelectedIndex = 0;
        }
        public int d = 0;
        private void AddIT_Click(object sender, EventArgs e)
        {
            AddIT.Image = Properties.Resources.addselect;
            d = 1;
            r = 1;
            Inventory inve = new Inventory();
            inve.FormClosed += new FormClosedEventHandler(refreshinve_FormClosed);
            inve.ShowDialog();
            AddIT.Image = Properties.Resources.additemnormal;
        }
        private void refreshinve_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshInventory();

        }

        private void AddExist_Click(object sender, EventArgs e)
        {
            AddExist.Image = Properties.Resources.addexistingselect;
            d = 1;
            r = 2;
            Inventory inve = new Inventory();
            inve.FormClosed += new FormClosedEventHandler(refreshinve_FormClosed);
            inve.ShowDialog();
            AddExist.Image = Properties.Resources.addexistingnormal;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.deleteselect;
           if(PerAssetView.Checked){
               try
               {
                   string c = this.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                   DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + c + "?", "Delete?", MessageBoxButtons.YesNo);
                   if (dialogResult == DialogResult.Yes)
                   {
                       foreach (DataGridViewRow row in this.dataGridView2.SelectedRows)
                       {
                           //delete in database
                           dbConnect.Update("Update tblAsset SET boolAsseIsDel = true WHERE strAsseCode = '" + row.Cells[0].Value.ToString() + "';");
                       }
                   }
                   else if (dialogResult == DialogResult.No)
                   {


                   }
               }
               catch (ArgumentOutOfRangeException)
               {
                   MessageBox.Show("No selected item");
               }
               refreshInventory();
           }
           else if (PerItemView.Checked)
           {
               try
               {
                   string c = this.Dtgrid_ItemView.SelectedRows[0].Cells[1].Value.ToString();
                   DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + c + "?", "Delete?", MessageBoxButtons.YesNo);
                   if (dialogResult == DialogResult.Yes)
                   {
                       foreach (DataGridViewRow row in this.Dtgrid_ItemView.SelectedRows)
                       {
                           //delete in database
                           dbConnect.Update("Update tblItemtype SET boolItemIsDel = true WHERE strItemCode = '" + row.Cells[0].Value.ToString() + "';");
                       }
                   }
                   else if (dialogResult == DialogResult.No)
                   {


                   }
               }
               catch (ArgumentOutOfRangeException)
               {
                   MessageBox.Show("No selected item");
               }
               refreshDGridItemView();
           }
            
            pictureBox10.Image = Properties.Resources.deletenormal;
        }

        private void AddIT_MouseHover(object sender, EventArgs e)
        {
            AddIT.Image = Properties.Resources.addhover;
        }

        private void AddIT_MouseLeave(object sender, EventArgs e)
        {
            if (d == 1)
            {
                AddIT.Image = Properties.Resources.addselect;
                d = 0;
            }
            else
            {
                AddIT.Image = Properties.Resources.additemnormal;
            }

        }

        private void AddExist_MouseHover(object sender, EventArgs e)
        {
            AddExist.Image = Properties.Resources.addexistinghover;
        }

        private void AddExist_MouseLeave(object sender, EventArgs e)
        {
            if (d == 1)
            {
                AddExist.Image = Properties.Resources.addexistingselect;
                d = 0;
            }
            else
            {
                AddExist.Image = Properties.Resources.addexistingnormal;
            }

        }

        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.deletehover;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Image = Properties.Resources.deletenormal;
        }

        private void InventoryOption_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void StuFacNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Email_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            if(StudInfo.Checked){
                nameToShowStud = tbx_borname.Text;
                searchDataGridStud();
            }
            else
            {
                nameToShowFacu = tbx_borname.Text;
                searchDataGridFacu();
            }

            
        }

        private void BorNo_Click(object sender, EventArgs e)
        {

        }

        private void BorNoInfo_TextChanged(object sender, EventArgs e)
        {
            if(StudInfo.Checked){
                borToShowStud = BorNoInfo.Text;
                searchDataGridStud();
            }
            else
            {
                borToShowFacu = BorNoInfo.Text;
                searchDataGridFacu();
            }  
        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void BorAdvisorbox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            advToShowStud = BorAdvisorbox.SelectedItem.ToString();
            searchDataGridStud();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BorrowListPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rent1_Load(object sender, EventArgs e)
        {

        }

        private void BorrowerButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.Image = Properties.Resources.anni3;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Image = Properties.Resources.borrowerInfo;
        }

        private void BorrowButton_MouseHover(object sender, EventArgs e)
        {
            BorrowButton.Image = Properties.Resources.anni2;
        }

        private void BorrowButton_MouseLeave(object sender, EventArgs e)
        {
            BorrowButton.Image = Properties.Resources.borrow;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.anni8;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.returnnn;
        }

        private void BorrowerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BorrowerPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void rent2_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void idpictureclose(object sender, FormClosedEventArgs e)
        {

            if (IDpicture.i != 1 && IDpicture.a == 1)
            {
                RegStudent.Enabled = true;

            }
            else
            {

                IDpicture.i = 0;
                IDpicture.a = 0;
            }

        }

        public static int cap = 0;
        private void TakeIDpicture_Click(object sender, EventArgs e)
        {
            cap = 1;
            IDpicture id = new IDpicture(this);
            id.FormClosed += new FormClosedEventHandler(idpictureclose);
            id.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IDpicturee.ImageLocation = openFileDialog1.FileName;
                RegStudent.Enabled = true;
            }

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void RegiPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void BorInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Student_Click(object sender, EventArgs e)
        {
            if (no == 1)
            { 
                Student.Checked = false;
            Faculty.Checked = true;
         
                no = 0;
            }
        }

        private void Faculty_Click(object sender, EventArgs e)
        {
            if (no == 1)
            {
                Student.Checked = true;
                Faculty.Checked = false;
              
                no = 0;
            }
        }


        private void pictureBox13_Click(object sender, EventArgs e)
        {
            string nameCodeToDelete = "";
            bool isValidSelection = false;
        
        
        
            if (StudInfo.Checked)
            {
                try
                {
                    nameCodeToDelete = StudList.SelectedRows[0].Cells[0].Value.ToString();
                    isValidSelection = true;
                }
                catch
                {
                    MessageBox.Show("No selected student");
                }
            }
            else if (FacuInfo.Checked)
            {
                try
                {
                    nameCodeToDelete = FacultyList.SelectedRows[0].Cells[0].Value.ToString();
                    isValidSelection = true;
                }
                catch {
                    MessageBox.Show("No selected faculty");
                }
            }

            if (isValidSelection)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wanto to delete " + nameCodeToDelete + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
           dbConnect.Update("update tblName set boolNameIsDel = true where strNameCode = '" + nameCodeToDelete + "';");
                MessageBox.Show("Successfully Deleted!");
                }
                else if (dialogResult == DialogResult.No)
                {


                }

           
            }
            else
            {
                MessageBox.Show("Please select valid item to delete.");
            }

            //refresh StudList
            refreshInfoStudList();
            //refresh FacultyList
            refreshInfoFacultyList();
        }

        

        private void BorDepBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            depToShowFacu = BorDepBox.SelectedItem.ToString();
            searchDataGridFacu();
        }

        private void BorSecBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            secToShowStud = BorSecBox.SelectedItem.ToString();
            searchDataGridStud();

        }

        private void BorPosBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            posToShowFacu = BorPosBox.SelectedItem.ToString();
            searchDataGridFacu();
        }


        private void ReportsBack_Click(object sender, EventArgs e)
        {
            ReportsPanel.Visible = false;
            panel1.Visible = true;
            BorrowerButton.Enabled = true;
            refreshReportSection();
            refreshReportDepartment();
            refreshReportItemName();
            refreshReportCategory();
            refreshReportItemName2();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
         //   StudentListReporst1.SetParameterValue("StudCode", textBox1.Text);
          //  crystalReportViewer1.ReportSource = StudentListReporst1;
          //  crystalReportViewer1.Refresh();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void SendOverdueEmail_Tick(object sender, EventArgs e)
        {
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where intNameType = 2 and boolNameIsDel = false;", columns);
            string expectedReturnDate = "";
            for (int i = 0; i < rs[0].Count; i++)
            {
                bcode = rs[0].ElementAt(i).ToString();
                string email = rs[4].ElementAt(i).ToString();

                string[] columns2 = { "strItemName", "dtmBorHDateBorrowed", "strBorDBorHCode", "strBorDCode" };
                List<object>[] rs2;
                rs2 = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) where tblborrowheader.strBorHNameCode = '" + bcode + "' and tblborrowdetail.dtmBorDDateReturned is null;", columns2);


                for (int n = 0; n < rs2[0].Count; n++)
                {

                    string dateBorrowed = Convert.ToDateTime(rs2[1].ElementAt(n).ToString()).ToString("MMM dd, yyyy");
                    expectedReturnDate = getExpectedReturnDate(Convert.ToDateTime(rs2[1].ElementAt(n).ToString()).ToString("yyyy-MM-dd"));
                    DateTime expectedreturndate2 = Convert.ToDateTime(expectedReturnDate);
                    DateTime dateNow = DateTime.Now;
                    int overdueDays = (dateNow - expectedreturndate2).Days;



                    //computing overdue days

                    //computing fine and making it string
                    double fine = overdueDays * 10d;

                    //if not yet overdue
                    if (fine != 0)
                    {
       
                        var fromAddress = new MailAddress("ijacorentalmanagement@gmail.com", "From Name");
                        var toAddress = new MailAddress(email, "To Name");
                        const string fromPassword = "ijacorm123456789";
                        const string subject = "test";
                        const string body = "Pogi mo kuya";

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
                }




            }

            SendOverdueEmail.Stop();
        }


        private void refresh_sect(object sender, FormClosedEventArgs e)
        {

            getAdvisers();
            Addsectionn.Image = Properties.Resources.AddSection;
        }

           private void refresh_pos(object sender, FormClosedEventArgs e)
        {
            try
            {
                getPositions(depToCode(DepBox.SelectedItem.ToString()));
            }
            catch (Exception)
            {
                //wont do anything if you back
            }
            getDepartments();
            addDepartment.Image = Properties.Resources.AddDepartment;
            Addposition.Image = Properties.Resources.AddPositionHover;
           }
        

        private void Addsectionn_Click(object sender, EventArgs e)
        {
            d = 1;
            Addsectionn.Image = Properties.Resources.AddSectionSelect;
            AddSection sect = new AddSection();
            sect.FormClosed += new FormClosedEventHandler(refresh_sect);
            sect.ShowDialog();
        }

        private void Addposition_Click(object sender, EventArgs e)
        {
            d = 1;
            Addposition.Image = Properties.Resources.AddPositionSelect;
            addPosition pos = new addPosition();
            pos.FormClosed += new FormClosedEventHandler(refresh_pos);
            pos.ShowDialog();
        }

        private void addDepartment_Click(object sender, EventArgs e)
        {
            d = 1;

            addDepartment.Image = Properties.Resources.AddDepartmentSelect;
            AddDepartment dept = new AddDepartment();
            dept.FormClosed += new FormClosedEventHandler(refresh_pos);
            dept.ShowDialog();
        }

        private void addDepartment_MouseHover(object sender, EventArgs e)
        {
    
            addDepartment.Image = Properties.Resources.AddDepartmentHover;
        }

        private void Addposition_MouseHover(object sender, EventArgs e)
        {
            Addposition.Image = Properties.Resources.AddPositionHover;
        }

        private void Addsectionn_MouseHover(object sender, EventArgs e)
        {
            Addsectionn.Image = Properties.Resources.AddSectionHover;
        }

        private void Addsectionn_MouseLeave(object sender, EventArgs e)
        {
            if (d == 1)
            {
                Addsectionn.Image = Properties.Resources.AddSectionSelect;
           
                d = 0;
            }
            else
            {
           Addsectionn.Image = Properties.Resources.AddSection;
            }
          
        }

        private void addDepartment_MouseLeave(object sender, EventArgs e)
        {
            if (d == 1)
            {
                addDepartment.Image = Properties.Resources.AddDepartmentSelect;

                d = 0;
            }
            else
            {
                addDepartment.Image = Properties.Resources.AddDepartment;
            }
            
        }

        private void Addposition_MouseLeave(object sender, EventArgs e)
        {

            if (d == 1)
            {
                Addposition.Image = Properties.Resources.AddPositionSelect;

                d = 0;
            }
            else
            {
          Addposition.Image = Properties.Resources.AddPosition;
            }
          
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //so everytime you will click invenyory the daily is checked
            if(tabControl1.SelectedIndex == 2){
                Daily.Checked = true;
            }
        }

        private void Todate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"StudentListReports.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            try
            {
                crParameterDiscreteValue.Value = Section.SelectedItem.ToString();
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["sectName"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
           

            crConnectionInfo.ServerName = reportsServerName;
            crConnectionInfo.DatabaseName = reportsDatabase;
            crConnectionInfo.UserID = reportsUID;
            crConnectionInfo.Password = reportsPass;
            CrTables = cryRpt.Database.Tables;


            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer2.ReportSource = cryRpt;
            crystalReportViewer2.Refresh();
            }
            catch
            {
                MessageBox.Show("Please select a section");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"FacultyListReports2.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            try
            {
                crParameterDiscreteValue.Value = Departments.SelectedItem.ToString();
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["depName"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                crConnectionInfo.ServerName = reportsServerName;
                crConnectionInfo.DatabaseName = reportsDatabase;
                crConnectionInfo.UserID = reportsUID;
                crConnectionInfo.Password = reportsPass;
                CrTables = cryRpt.Database.Tables;

                
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                crystalReportViewer1.ReportSource = cryRpt;
                crystalReportViewer1.Refresh();
            }
            catch {
                MessageBox.Show("Please select a department");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"ListOfDamageItemsReports.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            try
            {
                crParameterDiscreteValue.Value = ItemName2.SelectedItem.ToString();
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["itemName"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;
                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                crConnectionInfo.ServerName = reportsServerName;
                crConnectionInfo.DatabaseName = reportsDatabase;
                crConnectionInfo.UserID = reportsUID;
                crConnectionInfo.Password = reportsPass;
                CrTables = cryRpt.Database.Tables;


                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                crystalReportViewer4.ReportSource = cryRpt;
                crystalReportViewer4.Refresh();
            }
            catch { MessageBox.Show("Select an item"); }
        }

        private void ViewInventoryList_Click(object sender, EventArgs e)
        {
            //Checking for date
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today;
            
            if (Yearly.Checked)
            {
                from = new DateTime(FromDate.Value.Year, 01, 01);
                to = new DateTime(FromDate.Value.Year, 12, 31);

            }
            else if (Monthly.Checked)
            {
                from = new DateTime(FromDate.Value.Year, FromDate.Value.Month, 01);
                to = new DateTime(FromDate.Value.Year, FromDate.Value.Month, DateTime.DaysInMonth(FromDate.Value.Year, FromDate.Value.Month));
            }
            else if (Weekly.Checked)
            {
                from = FromDate.Value;
                to = Todate.Value;
            }
            else if (Daily.Checked)
            {
                from = FromDate.Value;
                to = Todate.Value;
            }
            else if (SpecificDate.Checked)
            {
                from = FromDate.Value;
                to = FromDate.Value;
            }

          if(DateTime.Compare(from,to) > 0){
              MessageBox.Show("Please input valid From and To Dates");
          }
          else
          {
              //Checking for filteringy
              try
              {
                  string localCateg = Category.SelectedItem.ToString();
                  string localStatus = Status.SelectedItem.ToString();
                  string localItemName = ItemName.SelectedItem.ToString();

                  if (localCateg.Equals("ALL"))
                  {
                      localCateg = "";
                  }
                  if (localStatus.Equals("ALL"))
                  {
                      localStatus = "";
                  }
                  if (localItemName.Equals("ALL"))
                  {
                      localItemName = "";
                  }


                  ReportDocument cryRpt = new ReportDocument();
                  cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"InventoryReportList.rpt");

                  TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

                  TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                  ConnectionInfo crConnectionInfo = new ConnectionInfo();
                  Tables CrTables;
                  ParameterFieldDefinitions crParameterFieldDefinitions;
                  ParameterFieldDefinition crParameterFieldDefinition;
                  ParameterValues crParameterValues = new ParameterValues();
                  ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                  //--date

                  crParameterDiscreteValue.Value = from;
                  crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                  crParameterFieldDefinition = crParameterFieldDefinitions["dateFrom"];
                  crParameterValues = crParameterFieldDefinition.CurrentValues;
                  crParameterValues.Clear();
                  crParameterValues.Add(crParameterDiscreteValue);
                  crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                  crParameterDiscreteValue.Value = to;
                  crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                  crParameterFieldDefinition = crParameterFieldDefinitions["dateTo"];
                  crParameterValues = crParameterFieldDefinition.CurrentValues;
                  crParameterValues.Clear();
                  crParameterValues.Add(crParameterDiscreteValue);
                  crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                  //-----

                  crParameterDiscreteValue.Value = localItemName;
                  crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                  crParameterFieldDefinition = crParameterFieldDefinitions["itemName"];
                  crParameterValues = crParameterFieldDefinition.CurrentValues;
                  crParameterValues.Clear();
                  crParameterValues.Add(crParameterDiscreteValue);
                  crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                  crParameterDiscreteValue.Value = localStatus;
                  crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                  crParameterFieldDefinition = crParameterFieldDefinitions["status"];
                  crParameterValues = crParameterFieldDefinition.CurrentValues;
                  crParameterValues.Clear();
                  crParameterValues.Add(crParameterDiscreteValue);
                  crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                  crParameterDiscreteValue.Value = localCateg;
                  crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                  crParameterFieldDefinition = crParameterFieldDefinitions["categoryName"];
                  crParameterValues = crParameterFieldDefinition.CurrentValues;
                  crParameterValues.Clear();
                  crParameterValues.Add(crParameterDiscreteValue);
                  crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


                  crConnectionInfo.ServerName = reportsServerName;
                  crConnectionInfo.DatabaseName = reportsDatabase;
                  crConnectionInfo.UserID = reportsUID;
                  crConnectionInfo.Password = reportsPass;
                  CrTables = cryRpt.Database.Tables;


                  foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                  {
                      crtableLogoninfo = CrTable.LogOnInfo;
                      crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                      CrTable.ApplyLogOnInfo(crtableLogoninfo);
                  }

                  crystalReportViewer3.ReportSource = cryRpt;
                  crystalReportViewer3.Refresh();
              }
              catch
              {
                  MessageBox.Show("Select a department, category and status");
              }
          }

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"StudentListReports.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = "";
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["sectName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crConnectionInfo.ServerName = reportsServerName;
            crConnectionInfo.DatabaseName = reportsDatabase;
            crConnectionInfo.UserID = reportsUID;
            crConnectionInfo.Password = reportsPass;
            CrTables = cryRpt.Database.Tables;


            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer2.ReportSource = cryRpt;
            crystalReportViewer2.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"FacultyListReports2.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = "";
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["depName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crConnectionInfo.ServerName = reportsServerName;
            crConnectionInfo.DatabaseName = reportsDatabase;
            crConnectionInfo.UserID = reportsUID;
            crConnectionInfo.Password = reportsPass;
            CrTables = cryRpt.Database.Tables;


            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"InventoryReportList.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            //--date
            
            crParameterDiscreteValue.Value = DateTime.MinValue;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["dateFrom"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = DateTime.MaxValue;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["dateTo"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
            
            //-----

            crParameterDiscreteValue.Value = "";
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["itemName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = "";
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["status"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = "";
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["categoryName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crConnectionInfo.ServerName = reportsServerName;
            crConnectionInfo.DatabaseName = reportsDatabase;
            crConnectionInfo.UserID = reportsUID;
            crConnectionInfo.Password = reportsPass;
            CrTables = cryRpt.Database.Tables;


            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer3.ReportSource = cryRpt;
            crystalReportViewer3.Refresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(AppDomain.CurrentDomain.BaseDirectory + @"ListOfDamageItemsReports.rpt");

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = "";
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["itemName"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crConnectionInfo.ServerName = reportsServerName;
            crConnectionInfo.DatabaseName = reportsDatabase;
            crConnectionInfo.UserID = reportsUID;
            crConnectionInfo.Password = reportsPass;
            CrTables = cryRpt.Database.Tables;


            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            crystalReportViewer4.ReportSource = cryRpt;
            crystalReportViewer4.Refresh();
        }

        private void SaveEmail_Click(object sender, EventArgs e)
        {
            if (CurrEmailAdd.Text !=""){
                string initial = "Dear "+blname+",";
            
                dbConnect.Update("update tbladmin set strAdmEmail = '" + CurrEmailAdd.Text + "',strAdmEmailPass = '" + EmailPass.Text + "',txtAdmMessage = \"" + Message.Text + "\" where strAdmCode = 'admin';");
                MessageBox.Show("Successfully updated!");
                
                curremail = CurrEmailAdd.Text;
                message = Message.Text;
                emailpass = EmailPass.Text;
                ChangeEmail.Checked = false;
                ChangeMessage.Checked = false;
            }
            else
            {
                MessageBox.Show("Email Address is required");
            }
       
        }

        public void savepicture(){
                        Bitmap bmp3 = new Bitmap(adminpicture.Image);
                        pictureBox1.Image.Dispose();
                        adminpicture.Image.Dispose();
                        
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        File.Delete(source7 + "custodian.png");
                        bmp3.Save(source7 + "custodian.png");
                        pictureBox1.Image = Image.FromFile(source7 + "custodian.png");
                        adminpicture.Image = Image.FromFile(source7 + "custodian.png");
        }
        private void SaveAcct_Click(object sender, EventArgs e)
        {
            if (ChangePass.Checked == true)
            {
    
                if (oldpass.Text == pass)
              {
                    if (oldpass.Text != "" && tbx_password.Text != "")
                   {
                        dbConnect.Update("update tbladmin set strAdmName = '" + tbx_Name.Text + "',strAdmUser = '" + tbx_username.Text + "',strAdmPass = '" + tbx_password.Text + "' where strAdmCode = 'admin';");
                        MessageBox.Show("Successfully updated!");
                        AdminName.Text = tbx_Name.Text;   
                        ChangePass.Checked = false;
                        ChangeName.Checked = false;
                        pass = tbx_password.Text;
                      
                        oldpass.Clear();
                        savepicture();

                   }
                    else
                    {
                        MessageBox.Show("Please fill the following fields.");
                    }
               }
               else
               {
                   MessageBox.Show("Wrong Old Password");
               }


               
             
            }
            else if (ChangePass.Checked == false)
            {
               
             
                if (tbx_Name.Text != "" && tbx_username.Text != "")
                {
                  
                    if (Password.Text == pass)
                    {
                        dbConnect.Update("update tbladmin set strAdmName = '" + tbx_Name.Text + "',strAdmUser = '" + tbx_username.Text + "',strAdmPass = '" + pass + "' where strAdmCode = 'admin';");
                        MessageBox.Show("Successfully updated!");
                        AdminName.Text = tbx_Name.Text;  
                        ChangePass.Checked = false;
                        ChangeName.Checked = false;
                     
                        Password.Clear();
                        savepicture();
                    }
                    else{
                        MessageBox.Show("Incorrect Password!");
                       
                    }
                }
                else
                {
                    MessageBox.Show("Name and username is required.");
                }
               

            }
          
          

        }

        private void ChangeEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangeEmail.Checked == true)
            {
                CurrEmailAdd.Enabled = true;
                SaveEmail.Visible = true;
                label20.Visible = true;
                EmailPass.Visible = true;
            }
            if (ChangeEmail.Checked == false)
            {
                CurrEmailAdd.Enabled =false;
                
                label20.Visible = false;
                EmailPass.Visible = false;
                if (ChangeMessage.Checked == false)
                {

                    SaveEmail.Visible = false;
                }
            }
        }

        private void tbx_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangePass_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangePass.Checked == true)
            {
                tbx_password.Clear();
                SaveAcct.Visible = true;
                panel9.Visible = true;
                tbx_username.Enabled = false;
                tbx_Name.Enabled = false;
                Password.Enabled = false ;
               
            }
            if (ChangePass.Checked == false)
            {
     
                tbx_username.Enabled = true;
                tbx_Name.Enabled = true;
                Password.Enabled = true;
                panel9.Visible = false;
                if (ChangeName.Checked == false)
                {
                    SaveAcct.Visible = false;
                    tbx_username.Enabled = false;
                    tbx_Name.Enabled = false;
             
                }
            }
        }

        private void SettingsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChangeUsername_CheckedChanged(object sender, EventArgs e)
        {
          

        }

        private void ChangeName_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangeName.Checked == true)
            {
                tbx_Name.Enabled = true;
                tbx_username.Enabled = true;
                pictureBox19.Visible = true;
                SaveAcct.Visible = true;
                label21.Visible = true;
                Password.Visible = true;
                ChangePass.Visible = true;
                ChangePass.Checked = false;
            }
            if (ChangeName.Checked == false)
            {
                tbx_Name.Enabled = false;
                tbx_username.Enabled = false;
                pictureBox19.Visible = false;
                ChangePass.Checked = false;
                label21.Visible = false;
                Password.Visible = false;
                ChangePass.Visible = false;
                if(ChangePass.Checked == false){
                    SaveAcct.Visible = false;
                }
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
              adminpicture.ImageLocation = openFileDialog1.FileName;
          
            }
        }

        private void adminpicture_Click(object sender, EventArgs e)
        {

        }
  
        private void LogIn_Click_2(object sender, EventArgs e)
        {
            acct = 1;
            strt = 1;
            logout = 2;
            timer3.Start();



            List<object>[] rs;

            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName" };
            rs = dbConnect.Select("select * from tblName where boolNameIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                if (decoded.Equals(rs[0].ElementAt(i)))
                {
                    borrowername =  rs[1].ElementAt(i).ToString();
                    AdminName.Text = borrowername;
                    borrCode = rs[0].ElementAt(i).ToString();
                    fullname = rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString();
                    OptionPanel.Visible = false;
                    BorInfo.Visible = true;
                    Code.Text = borrCode;
                    Bfullname.Text = fullname;
                    BorrowerButtons.Enabled = true;
                    loadingg.Visible = true;
                    try
                    {
                        pictureBox1.Image = Image.FromFile(source7 + borrCode + ".jpg");
                    }
                    catch
                    {
                        pictureBox1.Image = Properties.Resources.borrower;

                    }
                    BorrowerLogIn.Visible = false;
                    panel7.Visible = true;

                }

            }

        }

        private void CancelLogin_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[Cameralist.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            pictureBox3.Focus();
            timer2.Start();
            CancelLogin.Enabled = false;
            LogIn.Enabled = false;
            loadingg.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            SearchName.Clear();
            SearchItem.Clear();
            SearchOverdue.Checked = false;
        }

        private void CheckNotification_Click(object sender, EventArgs e)
        {
            if (Notification.allow==0)
            {

                ShowNotification();
            }
       
        }

       

        private void SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (StuList.Checked == true)
                {
                    var sendmess = new SendMessage(StuBorrower.SelectedRows[0].Cells[2].Value.ToString(), curremail,emailpass);
                    sendmess.ShowDialog();
                }
                if (Faculist.Checked == true)
                {
                    var sendmess = new SendMessage(FacuBorrower.SelectedRows[0].Cells[2].Value.ToString(), curremail,emailpass);
                    sendmess.ShowDialog();
                }
            }
            catch {
                MessageBox.Show("No Selected student/faculty");
            }
        }

        private void Section_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Yearly_CheckedChanged(object sender, EventArgs e)
        {
            if(Yearly.Checked){
                FromDate.Format = DateTimePickerFormat.Custom;
                FromDate.CustomFormat = "yyyy";
                FromDate.ShowUpDown = true;
                label6.Visible = false;
                Todate.Visible = false;

                FromDate.Value = new DateTime(2016, 01, 01);
                Todate.Value = new DateTime(2016,12,31);
            }
            
        }

        private void Monthly_CheckedChanged(object sender, EventArgs e)
        {
            if(Monthly.Checked){
                FromDate.Format = DateTimePickerFormat.Custom;
                FromDate.CustomFormat = "MMMM yyyy";
                FromDate.ShowUpDown = true;
                label6.Visible = false;
                Todate.Visible = false;

                FromDate.Value = new DateTime(2016, 01, 01);
                Todate.Value = new DateTime(2016, 01, 31);

            }
        }

        private void Weekly_CheckedChanged(object sender, EventArgs e)
        {
            if(Weekly.Checked){
                //adding the listener for per week
                this.FromDate.ValueChanged += new System.EventHandler(this.FromDate_ValueChanged);
                //to fire the event that makes it at thes start of the week
                FromDate.Value = FromDate.Value.AddDays(-1);

                FromDate.Format = DateTimePickerFormat.Custom;
                FromDate.CustomFormat = "MMMM dd,  yyyy";
                FromDate.ShowUpDown = false;
                label6.Visible = true;
                Todate.Visible = true;
                Todate.Format = DateTimePickerFormat.Custom;
                Todate.CustomFormat = "MMMM dd,  yyyy";
                Todate.Enabled = false;
                
            }
            else
            {
                //removing the listener for per week
                this.FromDate.ValueChanged -= this.FromDate_ValueChanged;

                Todate.Enabled = true;
            }
       }

        private void Daily_CheckedChanged(object sender, EventArgs e)
        {
            if(Daily.Checked){
                FromDate.Format = DateTimePickerFormat.Custom;
                FromDate.CustomFormat = "MMMM dd,  yyyy";
                FromDate.ShowUpDown = false;
                label6.Visible = true;
                Todate.Visible = true;

                Todate.MaxDate = DateTime.Today;
            }
            else
            {
                Todate.MaxDate = DateTimePicker.MaximumDateTime;
            }         
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
        
        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime date = FromDate.Value;
            while(date.DayOfWeek != firstDay){
                date = date.AddDays(-1);
            }

            FromDate.Value = date;
            Todate.Value = FromDate.Value.AddDays(6);
        }

        private void ChangeMessage_CheckedChanged(object sender, EventArgs e)
        {
            if (ChangeMessage.Checked == true)
            {
                Message.ReadOnly = false;
                SaveEmail.Visible = true;

               
                
            }
            if (ChangeMessage.Checked == false)
            {
                Message.ReadOnly = true;
                if(ChangeEmail.Checked ==false){

                 SaveEmail.Visible = false;
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BorNoInfo.Clear();
            tbx_borname.Clear();
            BorAdvisorbox.SelectedIndex = 0;
            BorSecBox.SelectedIndex = 0;

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            refreshInventory();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClearAdvInvSearch_Click(object sender, EventArgs e)
        {
            Searchbox.Clear();

            CategBox.SelectedIndex = 0;
            ModBox.SelectedIndex = 0;
            AvailBox.SelectedIndex = 0;
        }

        private void PerAssetView_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            Dtgrid_ItemView.Visible = false;
            AvailBox.Enabled = true;
            ModBox.Enabled = true;

            refreshInventory();
        }

        private void PerItemView_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            Dtgrid_ItemView.Visible = true;
            AvailBox.Enabled = false;
            ModBox.Enabled = false;

            refreshDGridItemView();
        }

        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            pictureBox13.Image = Properties.Resources.deletehover;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
          
                pictureBox13.Image = Properties.Resources.deletenormal;
           
  
        }

        private void Clrsearch_Click(object sender, EventArgs e)
        {
            SearchName.Clear();
            SearchItem.Clear();
            SearchOverdue.Checked = false;
        }

       

        private void clrsearch2_Click(object sender, EventArgs e)
        {
            BorNoInfo.Clear();
            tbx_borname.Clear();
            if ( StudInfo.Checked == true){
               BorAdvisorbox.SelectedIndex = 0;
            BorSecBox.SelectedIndex = 0;
            }
            if (FacuInfo.Checked == true){
            
            BorDepBox.SelectedIndex = 0;
            BorPosBox.SelectedIndex = 0;
            }
        }

        private void SpecificDate_CheckedChanged(object sender, EventArgs e)
        {


            if(SpecificDate.Checked){
                label6.Visible = false;
                Todate.Visible = false;

                Todate.MaxDate = DateTime.Now;
            }
            else
            {
                Todate.MaxDate = DateTimePicker.MaximumDateTime;
            }
            
        }

        private void EmailPass_TextChanged(object sender, EventArgs e)
        {

        } 
    }


}

