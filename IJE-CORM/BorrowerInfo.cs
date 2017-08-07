using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging ;
using System.IO;
using System.Drawing.Printing;

namespace IJE
{
    public partial class BorrowerInfo : Form
    {
        string biBorrowerCode;
        DBConnect dbConnect;
        List<string>[] departmentAndCode;
        List<string>[] adviserAndCode;
        public BorrowerInfo(string consCode)
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
            this.TransparencyKey = Color.CornflowerBlue;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            //mj Code
            biBorrowerCode = consCode;
            dbConnect = new DBConnect();
            BorNoInfo.Text = biBorrowerCode;
            //ends here
            if (isStudent())
            {
                BorNo.Text = "Student Number: ";
                BorNoInfo.MaxLength = 7;

                BorAdviDep.Text = "Adviser: ";
                BorDepPos.Text = "Section: ";

                BorSecBox.Visible = true;
                BorAdvisorbox.Visible = true;
                BorDepBox.Visible = false;
                BorPosBox.Visible = false;

                //starts here
                getAdvisers();
                refreshStudDetails();
               string fullname = BorLname.Text + ", " + BorFname.Text + " " + BorMidName.Text;
               try
               {
               ID.Image = Image.FromFile(source3 + BorNoInfo.Text + ".jpg");
               QrCodeGen.Image=Image.FromFile(source4 + BorNoInfo.Text + ".jpg");
               IDpicturee.Image = Image.FromFile(source7 + BorNoInfo.Text + ".jpg");
               }
               catch
               {
                   IDpicturee.Image = Properties.Resources.borrower;
                   ID.Image = Properties.Resources.StudentID;
                   Zen.Barcode.CodeQrBarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                   QrCodeGen.Image = barcode.Draw(BorNo.Text, 50);
                   QrCodeGen.Image = resizeImage(QrCodeGen.Image, new Size(178, 166));
                   QrCodeGen.Image.Save(source4 + BorNoInfo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

               }
            
                refreshBorrowedItems();

                //ends here
            }
            else if (!isStudent())
            {
                BorNo.Text = "Faculty Number: ";
                BorNoInfo.MaxLength = 10;

                BorAdviDep.Text = "Department: ";
                BorDepPos.Text = "Position: ";

                BorSecBox.Visible = false;
                BorAdvisorbox.Visible = false;
                BorDepBox.Visible = true;
                BorPosBox.Visible = true;

                //starts here
                getDepartments();
                refreshFacuDetails();
                string fullname = BorLname.Text + ", " + BorFname.Text + " " + BorMidName.Text;
                try
                {
                     ID.Image = Image.FromFile(source5 + BorNoInfo.Text + ".jpg");
                QrCodeGen.Image = Image.FromFile(source6 + BorNoInfo.Text + ".jpg");
                IDpicturee.Image = Image.FromFile(source7 + BorNoInfo.Text + ".jpg");
                }
                catch
                {
                    IDpicturee.Image = Properties.Resources.borrower;
                    ID.Image = Properties.Resources.FacultyID;
                    Zen.Barcode.CodeQrBarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    QrCodeGen.Image = barcode.Draw(BorNo.Text, 50);
                    QrCodeGen.Image = resizeImage(QrCodeGen.Image, new Size(178, 166));
                    QrCodeGen.Image.Save(source6 + BorNoInfo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                }
        
                refreshBorrowedItems();
                //ends here
            }
        }


        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string source1 = desktopPath + "\\QRcodes\\Student\\ID\\StudentID.png";
        public string source2 = desktopPath + "\\QRcodes\\Faculty\\ID\\FacultyID.png";
        public string source3 = desktopPath + "\\QRcodes\\Student\\ID\\";
        public string source4 = desktopPath + "\\QRcodes\\Student\\";
        public string source5 = desktopPath + "\\QRcodes\\Faculty\\ID\\";
        public string source6 = desktopPath + "\\QRcodes\\Faculty\\";
        public string source7 = desktopPath + "\\QRcodes\\Pictures\\";
        //----------------------METHODS---------------------------
        private void refreshStudDetails()
        {
            string[] columns = { "strNameFName","strNameMName","strNameLName","strNameEmail","strSectFacuCode","strSectName"};
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName inner join tblStudent on (tblName.strNameCode = tblstudent.strStudNameCode) inner join tblsection on(tblstudent.strStudSectCode = tblsection.strSectCode) where strNameCode = '"+biBorrowerCode+"';",columns);

            BorFname.Text = rs[0].ElementAt(0).ToString();
            BorMidName.Text = rs[1].ElementAt(0).ToString();
            BorLname.Text = rs[2].ElementAt(0).ToString();
            BorEmail.Text = rs[3].ElementAt(0).ToString();
            BorAdvisorbox.SelectedItem = advCodeToName(rs[4].ElementAt(0).ToString());
            BorSecBox.SelectedItem = rs[5].ElementAt(0).ToString();
       
        }
        private bool isStudent()
        {
            bool retBool = false;
            int count = dbConnect.Count("select count(*) from tblName where strNameCode = '"+biBorrowerCode+"' and intNameType = 1;");

            if(count == 1){
                retBool = true;
            }

            return retBool;
        }
        private void refreshFacuDetails()
        {
            string[] columns = { "strNameFName", "strNameMName", "strNameLName", "strNameEmail", "strDepName", "strPosiName" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName inner join tblfaculty on(tblName.strNameCode = tblfaculty.strFacuNameCode) inner join tblposition on(tblfaculty.strFacuPosiCode = tblposition.strPosiCode) inner join tbldepartment on(tblfaculty.strFacuPosiDepCode = tbldepartment.strDepCode) where strNameCode = '"+biBorrowerCode+"';", columns);

            BorFname.Text = rs[0].ElementAt(0).ToString();
            BorMidName.Text = rs[1].ElementAt(0).ToString();
            BorLname.Text = rs[2].ElementAt(0).ToString();
            BorEmail.Text = rs[3].ElementAt(0).ToString();
            BorDepBox.SelectedItem = rs[4].ElementAt(0).ToString();
            BorPosBox.SelectedItem = rs[5].ElementAt(0).ToString();
        }
        private void refreshBorrowedItems()
        {
            this.dataGridView2.Rows.Clear();
            string[] columns = { "strAsseCode","strItemName","strModeName","dtmBorHDateBorrowed","dtmBorDDateReturned","strBorDRemarks"};
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) inner join tblmodel on(tblasset.strAsseModeCode = tblModel.strModeCode) where tblborrowheader.strBorHNameCode = '" + biBorrowerCode + "';", columns);
            for (int i = 0; i < rs[0].Count; i++ )
            {
                string dateReturned = rs[4].ElementAt(i).ToString();
                if(!dateReturned.Equals("")){
                    dateReturned = Convert.ToDateTime(dateReturned).ToString("MMM dd,yyyy");
                }


                this.dataGridView2.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), rs[2].ElementAt(i).ToString(), Convert.ToDateTime(rs[3].ElementAt(i).ToString()).ToString("MMM dd,yyyy"),dateReturned , rs[5].ElementAt(i).ToString());
            }
        }
        //----------------------COPY PASTE METHODS
        public void getDepartments()
        {
            //get position and code
            departmentAndCode = new List<string>[2];
            departmentAndCode[0] = new List<string>();
            departmentAndCode[1] = new List<string>();
            //clear adviser box
            BorDepBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strDepCode", "strDepName" };
            rs = dbConnect.Select("select * from tblDepartment where boolDepIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {

                //for posiandCode
                departmentAndCode[0].Add(rs[0].ElementAt(row).ToString());
                departmentAndCode[1].Add(rs[1].ElementAt(row).ToString());


                BorDepBox.Items.Add(rs[1].ElementAt(row).ToString());
            }
        }
        public void getPositions(string dep)
        {

            BorPosBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strPosiCode", "strPosiName" };
            rs = dbConnect.Select("select * from tblPosition where strPosiDepCode = '" + dep + "' and boolPosiIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {


                //for cmb
                BorPosBox.Items.Add(rs[1].ElementAt(row).ToString());
            }
        }
        public void getSections(string adv)
        {
            BorSecBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strSectName" };
            rs = dbConnect.Select("select strSectName from tblSection where strSectFacuCode = '" + adv + "' and boolSectIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {
                BorSecBox.Items.Add(rs[0].ElementAt(row).ToString());
            }
        }
        public void getAdvisers()
        {
            //to refresh nameAndCode
            adviserAndCode = new List<string>[2];
            adviserAndCode[0] = new List<string>();
            adviserAndCode[1] = new List<string>();
            //clear adviser box
            BorAdvisorbox.Items.Clear();


            List<object>[] rs;
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName" };
            rs = dbConnect.Select("select * from tblName where intNameType = 2 and boolNameIsDel = false;", columns);
            for (int row = 0; row < rs[0].Count; row++)
            {
                BorAdvisorbox.Items.Add(rs[3].ElementAt(row).ToString() + ", " + rs[1].ElementAt(row).ToString() + " " + rs[2].ElementAt(row).ToString());
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
        public string advCodeToName(string advCode)
        {
            string retName = "";
            for (int i = 0; i < adviserAndCode[0].Count; i++)
            {
                if (adviserAndCode[0].ElementAt(i).ToString().Equals(advCode))
                {
                    retName = adviserAndCode[1].ElementAt(i).ToString();
                    break;
                }
            }

            return retName;
        }
        //--------------------GENERATED METHODS
        private void BorrowerInfo_Load(object sender, EventArgs e)
        {
  
           
           
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void EditInfo_Click(object sender, EventArgs e)
        {
            CloseInfo.Enabled = false;
            this.UpdateInfo.Visible = true;
            this.EditInfo.Visible = false;
            pictureBox3.Visible = true;
            CancelEdit.Visible = true;

            BorFname.Enabled = true;
            BorMidName.Enabled = true;
            BorLname.Enabled = true;
            BorEmail.Enabled = true;
           

            if (isStudent())
            {
                BorAdvisorbox.Enabled = true;
                BorSecBox.Enabled = true;
             

               
            }
            if (!isStudent())
            {
                BorDepBox.Enabled = true;
                BorPosBox.Enabled = true;
        
               
            }

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

        public static bool IsnospecialChar(string input)
        {
            var regexItem = new Regex("^[a-zA-Z ñ]*$");

            if (regexItem.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        private void UpdateInfo_Click(object sender, EventArgs e)
        {
             if (Notification.allow != 1)
            {
                string BFname = BorFname.Text;
                string BMname = BorMidName.Text;
                string BLname = BorLname.Text;
                string emailAd = BorEmail.Text;
                string fullname = BLname + ", " + BFname + " " + BMname;
                if (emailIsValid(emailAd) == false)
                {

                    MessageBox.Show("Invalid Email");

                }
                else 
                {
                    if (isStudent())
                    {
                        try
                        {
                            string BorAdvi = "";

                            string BorSec = "";
                            try
                            {
                                BorAdvi = BorAdvisorbox.SelectedItem.ToString();
                                BorSec = BorSecBox.SelectedItem.ToString();
                            }
                            catch
                            {
                                MessageBox.Show("Please Select a advisor and section");
                            }

                            //starts here
                            if (BorFname.Text != "" && BorMidName.Text != "" && BorLname.Text != "" && BorEmail.Text != "" && BorAdvi != "" && BorSec != "" && emailIsValid(emailAd) == true)
                            {

                                if (IsnospecialChar(BFname) && IsnospecialChar(BMname) && IsnospecialChar(BLname))
                                {

                                    dbConnect.Update("update tblName set strNameFName = '" + BFname + "',strNameMName = '" + BMname + "',strNameLName = '" + BLname + "',strNameEmail = '" + emailAd + "' where strNameCode = '" + biBorrowerCode + "';");
                                    dbConnect.Update("update tblStudent set strStudSectCode = '" + secToCode(BorSec) + "' where strStudNameCode = '" + biBorrowerCode + "';");
                                    BorAdvisorbox.Enabled = false;
                                    BorSecBox.Enabled = false;
                                    BorFname.Enabled = false;
                                    BorMidName.Enabled = false;
                                    BorLname.Enabled = false;
                                    BorEmail.Enabled = false;

                                    Bitmap bmp1 = new Bitmap(resizeImage(IDpicturee.Image, new Size(103, 107)));
                                    Bitmap bmp2 = new Bitmap(ID.Image);


                                    IDpicturee.Image.Dispose();
                                    System.GC.Collect();
                                    System.GC.WaitForPendingFinalizers();
                                    File.Delete(source7 + BorNoInfo.Text + ".jpg");

                                    ID.Image.Dispose();
                                    System.GC.Collect();
                                    System.GC.WaitForPendingFinalizers();
                                    File.Delete(source3 + BorNoInfo.Text + ".jpg");


                                    bmp1.Save(source7 + BorNoInfo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                                    IDpicturee.Image = Image.FromFile(source7 + BorNoInfo.Text + ".jpg");
                                    // // Dispose of the image files.

                                    using (Image image = Image.FromFile(source1))
                                    using (Image watermarkImage = Image.FromFile(source7 + BorNoInfo.Text + ".jpg"))
                                    using (Image watermarkImage2 = Image.FromFile(source4 + BorNoInfo.Text + ".jpg"))
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
                                        imageGraphics.DrawString(BorNoInfo.Text, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(60, 137));
                                        imageGraphics.DrawString(BLname + ",", new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(82, 181));
                                        imageGraphics.DrawString(BFname + " " + BMname, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(37, 204));
                                        imageGraphics.DrawString(BorSec, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(147, 247));
                                        image.Save(source3 + BorNoInfo.Text + ".jpg");


                                    }
                                    ID.Image = Image.FromFile(source3 + BorNoInfo.Text + ".jpg");


                                    MessageBox.Show("Update Successful!");
                                    CloseInfo.Enabled = true;
                                    this.UpdateInfo.Visible = false;
                                    this.EditInfo.Visible = true;

                                    CancelEdit.Visible = false;
                                    pictureBox3.Visible = false;
                                }
                                else
                                {

                                    MessageBox.Show("Name format is invalid");

                                }
                            }

                            else
                            {
                                MessageBox.Show("You must fill all the requirements");
                            }

                          
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(fullname + " already registered!", "Warning", MessageBoxButtons.OK);
                        }
                    }

                    if (!isStudent())
                    {
                        try
                        {
                            string BorDep = "";
                            string Borpos = "";
                            try
                            {
                                BorDep = BorDepBox.SelectedItem.ToString();
                                Borpos = BorPosBox.SelectedItem.ToString();
                            }
                            catch
                            {
                                MessageBox.Show("Please Select Department and position");
                            }

                            if (BorFname.Text != "" && BorMidName.Text != "" && BorLname.Text != "" && BorEmail.Text != "" && BorDepBox.SelectedItem != null && BorPosBox.SelectedItem != null && emailIsValid(emailAd) == true)
                            {
                                if (IsnospecialChar(BFname) && IsnospecialChar(BMname) && IsnospecialChar(BLname))
                                {
                                    //starts here
                                    dbConnect.Update("update tblName set strNameFName = '" + BFname + "',strNameMName = '" + BMname + "',strNameLName = '" + BLname + "',strNameEmail = '" + emailAd + "' where strNameCode = '" + biBorrowerCode + "';");
                                    dbConnect.Update("update tblFaculty set strFacuPosiCode = '" + posToCode(Borpos, depToCode(BorDep)) + "',strFacuPosiDepCode = '" + depToCode(BorDep) + "' where strFacuNameCode = '" + biBorrowerCode + "';");
                                    BorDepBox.Enabled = false;
                                    BorPosBox.Enabled = false;
                                    BorFname.Enabled = false;
                                    BorMidName.Enabled = false;
                                    BorLname.Enabled = false;
                                    BorEmail.Enabled = false;

                                    Bitmap bmp1 = new Bitmap(resizeImage(IDpicturee.Image, new Size(103, 107)));
                                    Bitmap bmp2 = new Bitmap(ID.Image);


                                    IDpicturee.Image.Dispose();
                                    System.GC.Collect();
                                    System.GC.WaitForPendingFinalizers();
                                    File.Delete(source7 + BorNoInfo.Text + ".jpg");

                                    ID.Image.Dispose();
                                    System.GC.Collect();
                                    System.GC.WaitForPendingFinalizers();
                                    File.Delete(source5 + BorNoInfo.Text + ".jpg");


                                    bmp1.Save(source7 + BorNoInfo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                                    IDpicturee.Image = Image.FromFile(source7 + BorNoInfo.Text + ".jpg");
                                    // // Dispose of the image files.

                                    using (Image image = Image.FromFile(source1))
                                    using (Image watermarkImage = Image.FromFile(source7 + BorNoInfo.Text + ".jpg"))
                                    using (Image watermarkImage2 = Image.FromFile(source6 + BorNoInfo.Text + ".jpg"))
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
                                        imageGraphics.DrawString(BorNoInfo.Text, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(60, 137));
                                        imageGraphics.DrawString(BLname + ",", new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(82, 181));
                                        imageGraphics.DrawString(BFname + " " + BMname, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(37, 204));
                                        imageGraphics.DrawString(BorDep + ", " + Borpos, new Font("Tahoma", f, FontStyle.Bold), Brushes.Black, new PointF(147, 247));
                                        image.Save(source5 + BorNoInfo.Text + ".jpg");

                                        MessageBox.Show("Done");
                                    }
                                    ID.Image = Image.FromFile(source5 + BorNoInfo.Text + ".jpg");
                                    MessageBox.Show("Update Successful!");
                                    CloseInfo.Enabled = true;
                                    this.UpdateInfo.Visible = false;
                                    this.EditInfo.Visible = true;
                                    pictureBox3.Visible = false;
                                    CancelEdit.Visible = false;


                                }
                                else {
                                    MessageBox.Show("Name format is invalid");
                                }
                            }
                            else
                            {
                                MessageBox.Show("You must fill all the requirements");
                            }


                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show(fullname + " already registered!", "Warning", MessageBoxButtons.OK);

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Manage first all the notifications before updating individual information");
            }
           
            }
        
        private void CancelEdit_Click(object sender, EventArgs e)
        {
            CloseInfo.Enabled = true;
            this.UpdateInfo.Visible = false;
            this.EditInfo.Visible = true;
            BorFname.Enabled = false;
            BorMidName.Enabled = false;
            BorLname.Enabled = false;
            BorEmail.Enabled = false;
            pictureBox3.Visible = false;
            CancelEdit.Visible = false;
            if (isStudent())
            {
                BorAdvisorbox.Enabled =false;
                BorSecBox.Enabled = false;

                try
                {
                    IDpicturee.Image = Image.FromFile(source7 + BorNoInfo.Text + ".jpg");
                }
                catch {

                    IDpicturee.Image = Properties.Resources.borrower;
                }
                refreshStudDetails();

            }
            else if (!isStudent())
            {
                BorDepBox.Enabled = false;
                BorPosBox.Enabled = false;

                try
                {
                    IDpicturee.Image = Image.FromFile(source7 + BorNoInfo.Text + ".jpg");
                }
                catch
                {

                    IDpicturee.Image = Properties.Resources.borrower;
                }
                refreshFacuDetails();

            }
        }

        private void CloseInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ClearText_Click(object sender, EventArgs e)
        {

        }

        private void BorNo_Click(object sender, EventArgs e)
        {

        }

        private void BorSecBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BorAdvisorbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSections(advToCode(BorAdvisorbox.SelectedItem.ToString()));
        }

        private void BorDepPos_Click(object sender, EventArgs e)
        {

        }

        private void BorAdviDep_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void BorEmail_Click(object sender, EventArgs e)
        {

        }

        private void BorPosBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BorDepBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPositions(depToCode(BorDepBox.SelectedItem.ToString()));
        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void BorLname_Click(object sender, EventArgs e)
        {

        }

        private void BorMidName_Click(object sender, EventArgs e)
        {

        }

        private void BorFname_Click(object sender, EventArgs e)
        {

        }

        private void BorNoInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                
        }

        private void Upload_Click(object sender, EventArgs e)
        {

        }

        private void Capture_Click(object sender, EventArgs e)
        {
            IDpicture2 id = new IDpicture2(this);
            id.ShowDialog();
        }

        private void Upload_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                pictureBox2.ImageLocation = openFileDialog1.FileName;
             
            }
        }
    
      
    
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            
        }

   

        private void IDpicturee_MouseHover(object sender, EventArgs e)
        {
           

        }

        private void IDpicturee_Click(object sender, EventArgs e)
        {
    
        }

        private void IDpicturee_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IDpicturee.ImageLocation = openFileDialog1.FileName;

            }
        }
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            if (isStudent())
            {

                try
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(source3 + BorNoInfo.Text + ".jpg"); 
                    Point loc = new Point(100, 100);
         
                    e.Graphics.DrawImage(img, loc);
                }
                catch
                {
                    MessageBox.Show("No image available");
                }
  
          
        
            }
            if (!isStudent())
            {
                try
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(source5 + BorNoInfo.Text + ".jpg");
              
                    Point loc = new Point(100, 100);
                   
                    e.Graphics.DrawImage(img, loc);
                }
                catch {
                    MessageBox.Show("No image available");
                }
             

            }
            System.Drawing.Image img2 = Properties.Resources.IJAIDBack_1_;
            Point loc2 = new Point(100, 500);
            e.Graphics.DrawImage(img2, loc2);
            
        }
        private void Print_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
           PrintDialog dialog = new PrintDialog();
            dialog.ShowDialog();
            pd.PrinterSettings = dialog.PrinterSettings;
            pd.Print();
        }
    }
}
