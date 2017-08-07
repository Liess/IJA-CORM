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
    public partial class OverdueNotifFList : Form
    {
        DBConnect dbConnect;
        CodeGenerator codeGenerator;
        public OverdueNotifFList()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            codeGenerator = new CodeGenerator();
        }

        public static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string source7 = desktopPath + "\\QRcodes\\Pictures\\";
        private string getExpectedReturnDate(string dateBorrowed)
        {

            DateTime date = Convert.ToDateTime(dateBorrowed);
            date = date.AddDays(7);

            return date.ToString("MMM dd, yyyy");
        }
        private void OverdueNotifFList_Load(object sender, EventArgs e)
        {
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName", "strNameEmail" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where boolNameIsDel = false;", columns);
            string expectedReturnDate = "";
            string beforeReturnDate = "";
            string notificationDate = "";
            for (int i = 0; i < rs[0].Count; i++)
            {

                string bcode = rs[0].ElementAt(i).ToString();
                string borremail = rs[4].ElementAt(i).ToString();
                string bfname = rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString();
                string blname = rs[3].ElementAt(i).ToString();
                string[] columns2 = { "strItemName", "dtmBorHDateBorrowed", "strBorDBorHCode", "strBorDCode" };
                List<object>[] rs2;
                rs2 = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) where tblborrowheader.strBorHNameCode = '" + bcode + "' and tblborrowdetail.dtmBorDDateReturned is null;", columns2);


                for (int n = 0; n < rs2[0].Count; n++)
                {
                    string itemname = rs2[0].ElementAt(n).ToString();
                    string dateBorrowed = Convert.ToDateTime(rs2[1].ElementAt(n).ToString()).ToString("MMM dd, yyyy");
                    expectedReturnDate = getExpectedReturnDate(Convert.ToDateTime(rs2[1].ElementAt(n).ToString()).ToString("yyyy-MM-dd"));
                    DateTime expectedreturndate2 = Convert.ToDateTime(expectedReturnDate);
                    beforeReturnDate = expectedreturndate2.AddDays(-3).ToString("yyyy-MM-dd");
                    notificationDate = DateTime.Today.ToString("yyyy-MM-dd");

                    if (notificationDate == beforeReturnDate)
                    {
                        string pictoload = source7 + bcode + ".jpg";
                        try
                        {
                            this.imageList1.Images.Add(Image.FromFile(pictoload));
                       
                        }
                        catch
                        {
                            this.imageList1.Images.Add(Properties.Resources.borrower);
                        
                        }


              
                        this.imageList1.ImageSize = new Size(62, 62);

                     
                        listView1.LargeImageList = imageList1;
                        listView1.SmallImageList = imageList1;

                         ListViewItem lvi = new ListViewItem { ImageIndex = 0, Text = bcode };
                        lvi.SubItems.Add(bfname);
                        lvi.SubItems.Add(dateBorrowed);  
                        lvi.SubItems.Add(itemname);
                        listView1.Items.Add(lvi);

                      
                    }
                }


            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CloseInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
