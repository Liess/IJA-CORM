using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IJE
{
    public partial class Rent : UserControl
    {
        DBConnect dbConnect;


        string borrCode = "";

        public Rent()
        {
            InitializeComponent();

            dbConnect = new DBConnect();
        }
        //----Methods----

        private void refreshItemList()
        {
            this.ItemList.Rows.Clear();
            string[] columns = { "strAsseCode","strBorHCode","strBorDCode", "strItemName", "dtmBorHDateBorrowed" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblborrowheader inner join tblborrowdetail on(tblborrowheader.strBorHCode = tblborrowdetail.strBorDBorHCode) inner join tblasset on(tblborrowdetail.strBorDAsseCode = tblasset.strAsseCode) inner join tblitemtype on(tblasset.strAsseItemCode = tblitemtype.strItemCode) where tblborrowheader.strBorHNameCode = '" + borrCode + "' and tblborrowdetail.dtmBorDDateReturned is null;", columns);

            for (int i = 0; i < rs[0].Count;i++ )
            {
                string dateBorrowed = Convert.ToDateTime(rs[4].ElementAt(i).ToString()).ToString("MMM dd, yyyy");
                string expectedReturnDate = getExpectedReturnDate(Convert.ToDateTime(rs[4].ElementAt(i).ToString()).ToString("yyyy-MM-dd"));


                this.ItemList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), rs[2].ElementAt(i).ToString(), rs[3].ElementAt(i).ToString(), dateBorrowed, expectedReturnDate,computeFine(Convert.ToDateTime(expectedReturnDate)));
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
        private string getNameAndCode()
        {
            string returnString = "";
            string[] columns = { "strNameFName","strNameMName","strNameLName"};
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblName where strNameCode = '"+this.borrCode+"';",columns);

            //concat the name
            returnString = rs[2].ElementAt(0).ToString() + ", " + rs[0].ElementAt(0).ToString() + " " + rs[1].ElementAt(0).ToString(); 

            //add the Name Code at the start
            returnString = borrCode + " * "+ returnString;

            return returnString;
        }
        //----Event Handlers-----
        private void Rent_VisibleChanged(object sender, EventArgs e)
        {
            //get borrCode from admin panel
            this.borrCode = AdminPanel.borrCode;
            //refresh itemlist
            refreshItemList();
            
        }


        //----Generated Codes-----
        private void ReturnIT_Click(object sender, EventArgs e)
        {
            bool isInputValid = false;
            try
            {
                string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
                string assetCode = this.ItemList.SelectedRows[0].Cells[0].Value.ToString();
                string borHCode = this.ItemList.SelectedRows[0].Cells[1].Value.ToString();
                string borDCode = this.ItemList.SelectedRows[0].Cells[2].Value.ToString();
                string fine = this.ItemList.SelectedRows[0].Cells[6].Value.ToString();
                string notes = this.Notes.Text;
                string status = "";
                if (Good.Checked == true)
                {
                    status = "1";
                    isInputValid = true;
                }
                else if (Damage.Checked == true)
                {
                    status = "2";
                    isInputValid = true;
                }
                else if (Others.Checked == true)
                {
                    status = "3";
                    if (notes == "")
                    {
                        MessageBox.Show("Notes is required.");

                    }
                    else
                    {
                        isInputValid = true;
                    }
                }

                //check if input valid
                if (isInputValid)
                {
                      DialogResult dialogResult = MessageBox.Show("Continue?" , "Return?", MessageBoxButtons.YesNo);
                      if (dialogResult == DialogResult.Yes)
                      {
                          //Update Borrower Header
                          dbConnect.Update("update tblBorrowHeader set dblBorHFine = dblBorHFine + " + fine + " where strBorHCode = '" + borHCode + "';");

                          //Update Borrower Detail
                          dbConnect.Update("update tblBorrowDetail set dtmBorDDateReturned = '" + dateNow + "',strBorDRemarks = '" + notes + "' where strBorDBorHCode = '" + borHCode + "' and strBorDCode = '" + borDCode + "';");

                          //Update Asset
                          dbConnect.Update("update tblAsset set txtAsseNotes = '" + notes + "',intAsseStatus = " + status + " where strAsseCode = '" + assetCode + "';");

                          //if damaged or others
                          if (status.Equals("2") || status.Equals("3"))
                          {
                              dbConnect.Update("update tblAsset set txtAsseNotes = '" + notes + " By: " + getNameAndCode() + "' where strAsseCode = '" + assetCode + "';");
                          }

                          Notes.Clear();
                          MessageBox.Show("Successfully Returned");
                      }
                      else if (dialogResult == DialogResult.No)
                      {


                      }

                }
                else
                {
                    MessageBox.Show("Please choose returning condition");
                }
            }
            catch {
                MessageBox.Show("No selected item");
            }



            //refresh ItemList
            refreshItemList();
        }

        private void Rent_Load(object sender, EventArgs e)
        {

        }

        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Notes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
