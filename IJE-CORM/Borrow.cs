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
    public partial class Borrow : UserControl 
    {
        DBConnect dbConnect;
        CodeGenerator codeGenerator;

        string borrCode = "";


        public Borrow()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
            codeGenerator = new CodeGenerator();
        }
        //---Methods---
        //Dagdag



        private void refreshItemList()
        {
            this.ItemList.Rows.Clear();

            string[] columns = { "strAsseCode", "strItemName", "strCategName", "strModeName" };
            List<object>[] rs;
            rs = dbConnect.Select("select tblAsset.strAsseCode,tblitemtype.strItemName,tblcategory.strCategName,tblmodel.strModeName from tblasset inner join tblitemtype on (tblasset.strAsseItemCode = tblitemtype.strItemCode) inner join tblcategory on(tblitemtype.strItemCategCode = tblcategory.strCategCode) inner join tblmodel on(tblmodel.strModeCode = tblasset.strAsseModeCode) inner join tblvendor on(tblvendor.strVendCode = tblasset.strAsseVendCode)  where tblasset.boolAsseIsDel = false and tblmodel.boolModeIsDel = false and tblItemType.boolItemIsDel = false and tblvendor.boolVendIsDel = false  and tblAsset.intAsseStatus = 1;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                if (isAvailable(rs[0].ElementAt(i).ToString()).Equals("Available"))
                {
                    ItemList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), rs[2].ElementAt(i).ToString(), rs[3].ElementAt(i).ToString());
                }
            }
        }
        private string isAvailable(string asseCodeToCheck)
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
        private bool transactionNowExist()
        {
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");

            int count = dbConnect.Count("select count(*) from tblBorrowHeader where dtmBorHDateBorrowed = '" + dateNow + "' and strBorHNameCode = '" + this.borrCode + "';");

            switch (count)
            {
                case 0:
                    return false;
                default:
                    return true;
            }
        }
        private string getTransactionCodeNow()
        {
            string returnCode = "";

            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");

            string[] columns = { "strBorHCode" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblborrowheader where dtmBorHDateBorrowed = '"+dateNow+"' and strBorHNameCode = '"+this.borrCode+"';",columns);

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
                MessageBox.Show("You Already borrowed 3 Items. Please Return something to continue borrowing.");
            }

            return toReturn;
        }
        //---Event Handlers---
        private void Borrow_VisibleChanged(object sender, EventArgs e)
        {

            //When visible is changed to true or false, will transfer borrCode
            this.borrCode = AdminPanel.borrCode;

            //refreshItemList
            refreshItemList();

        }


        //---Generated Methods---
        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ItemListCellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Borrow_Load(object sender, EventArgs e)
        {

        }

        private void BorrowIT_Click(object sender, EventArgs e)
        {
            string borHCode;
            string borDCode;
            try
            {
                string assetCode = this.ItemList.SelectedRows[0].Cells[0].Value.ToString();
                string roomNum = RoomNumber.Text;
                string reason = textBox1.Text;

                



                if (roomNum != "" && reason != "")
                {
                    if (canBorrow())
                    {
                        if (transactionNowExist())
                        {

                            borHCode = getTransactionCodeNow();
                            borDCode = codeGenerator.generateCodeChild("tblBorrowDetail", "strBorDCode", borHCode, "BorD");
                            DialogResult dialogResult = MessageBox.Show("Continue?", "Borrow?", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //inserting borrower detail
                                dbConnect.Insert("insert into tblBorrowDetail values ('" + borHCode + "','" + borDCode + "','" + reason + "','" + roomNum + "',null,null,'" + assetCode + "');");
                                RoomNumber.Text = "";
                                textBox1.Text = "";
                                MessageBox.Show("Borrowed Successfully!");
                                //Back button


                            }
                            else if (dialogResult == DialogResult.No)
                            {


                            }

                        }
                        else
                        {
                            borHCode = codeGenerator.generateCodeParent("tblBorrowHeader", "strBorHCode", "BorH");
                            borDCode = codeGenerator.generateCodeChild("tblBorrowDetail", "strBorDCode", borHCode, "BorD");
                            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");

                            DialogResult dialogResult = MessageBox.Show("Continue?", "Borrow?", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //inserting borrower header
                                dbConnect.Insert("insert into tblBorrowHeader values ('" + borHCode + "','" + borrCode + "','" + dateNow + "',0);");

                                //inserting borrower detail
                                dbConnect.Insert("insert into tblBorrowDetail values ('" + borHCode + "','" + borDCode + "','" + reason + "','" + roomNum + "',null,null,'" + assetCode + "');");
                                RoomNumber.Text = "";
                                textBox1.Text = "";
                                MessageBox.Show("Borrowed Successfully!");

                            }
                            else if (dialogResult == DialogResult.No)
                            {


                            }
                        }
                    }
                    


                    //refresh ItemList
                    refreshItemList();
                }
                else
                {
                    MessageBox.Show("Room number and reason are required.");

                }
            }
            catch {
                MessageBox.Show("No items available");
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void RoomNumber_Click(object sender, EventArgs e)
        {

        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ItemList.Rows)
            {
                if ((row.Cells[1].Value.ToString().IndexOf(this.Searchbox.Text, StringComparison.CurrentCultureIgnoreCase) != -1))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Searchbox.Text = "";
        }
    }
}
