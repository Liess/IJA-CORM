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
    public partial class ItemInfo : Form
    {
        DBConnect dbConnect;
        string assetCodeSelected;
        string itemTypeCodeSelected;

        List<string>[] categAndCode;
        List<string>[] modelsAndCode;
        List<string>[] vendorsAndCode;


        public ItemInfo(string assetCode, string itemTypeCode)

        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            assetCodeSelected = assetCode;
            itemTypeCodeSelected = itemTypeCode;
            dbConnect = new DBConnect();
            this.BackColor = Color.CornflowerBlue;
            this.TransparencyKey = Color.CornflowerBlue;
            DatePurchased.MaxDate = DateTime.Today;
            refreshCategories();
            refreshModels(itemTypeCodeSelected);
            refreshVendors();
            refreshStatus();

            Display();
        }
        //------------------------------------------------METHODS--------------------------------------------------------------------
        public void refreshCategories()
        {
            //refresh categAndCode
            categAndCode = new List<string>[2];
            categAndCode[0] = new List<string>();
            categAndCode[1] = new List<string>();


            this.CategoryBox.Items.Clear();
            string[] columns = { "strCategCode", "strCategName" };
            List<object>[] result;
            result = dbConnect.Select("select strCategCode,strCategName from tblCategory where boolCategIsDel = false;", columns);
            for (int i = 0; i < result[0].Count; i++)
            {
                this.CategoryBox.Items.Add(result[1].ElementAt(i).ToString());
                //add to categ and code

                //code
                this.categAndCode[0].Add(result[0].ElementAt(i).ToString());
                //name
                this.categAndCode[1].Add(result[1].ElementAt(i).ToString());
            }
        }
        public void refreshModels(string modelsOfWhat)
        {
            //refresh modelsandCode
            modelsAndCode = new List<string>[2];
            modelsAndCode[0] = new List<string>();
            modelsAndCode[1] = new List<string>();


            List<object>[] rs;
            string[] columns = { "strModeCode", "strModeName" };
            rs = dbConnect.Select("Select * from tblModel where strModeItemCode = '" + modelsOfWhat + "' and boolModeIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                //cmb
                this.ModelBox.Items.Add(rs[1].ElementAt(i).ToString());

                //list
                modelsAndCode[0].Add(rs[0].ElementAt(i).ToString());
                modelsAndCode[1].Add(rs[1].ElementAt(i).ToString());
            }
        }
        public void refreshVendors()
        {
            //refresh categAndCode
            vendorsAndCode = new List<string>[2];
            vendorsAndCode[0] = new List<string>();
            vendorsAndCode[1] = new List<string>();

            this.VendorBox.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strVendCode", "strVendName" };
            rs = dbConnect.Select("select strVendCode,strVendName from tblVendor Where boolVendIsDel = false;", columns);
            for (int i = 0; i < rs[0].Count; i++)
            {
                this.VendorBox.Items.Add(rs[1].ElementAt(i).ToString());

                //list
                this.vendorsAndCode[0].Add(rs[0].ElementAt(i).ToString());
                this.vendorsAndCode[1].Add(rs[1].ElementAt(i).ToString());
            }
        }
        private void refreshStatus()
        {
            this.ItemStatus.Items.Clear();
            this.ItemStatus.Items.Add("Good Condition");
            this.ItemStatus.Items.Add("Damaged");
            this.ItemStatus.Items.Add("Others (see Notes)");
        }
        //---------------------------------------------GETTERS---------------------------------------------------------------------
        private string getCategCodeFromList(string codeOfWhat)
        {
            string toReturn = "";
            for (int i = 0; i < categAndCode[1].Count; i++)
            {
                if (codeOfWhat.Equals(categAndCode[1].ElementAt(i).ToString()))
                {
                    toReturn = categAndCode[0].ElementAt(i).ToString();
                    break;
                }
            }

            return toReturn;
        }
        public string getModelCodeFromList(string codeOfWhat)
        {
            string toReturn = "";
            for (int i = 0; i < modelsAndCode[1].Count; i++)
            {
                if (modelsAndCode[1].ElementAt(i).Equals(codeOfWhat))
                {
                    toReturn = modelsAndCode[0].ElementAt(i);
                    break;
                }
            }
            return toReturn;
        }
        public string getVendorCodeFromList(string codeOfWhat)
        {
            string toReturn = "";
            for (int i = 0; i < vendorsAndCode[1].Count; i++)
            {
                if (vendorsAndCode[1].ElementAt(i).Equals(codeOfWhat))
                {
                    toReturn = vendorsAndCode[0].ElementAt(i);
                    break;
                }
            }
            return toReturn;
        }
        //------------------------------------------------------OTHERS-----------------------------------------------------
        public void Display()
        {
            //Select for Asset
            string[] columns = { "strAsseCode", "dtmAssePurchased", "strVendName", "strModeName", "txtAsseNotes" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblasset inner join tblitemtype on (tblasset.strAsseItemCode = tblitemtype.strItemCode) inner join tblcategory on(tblitemtype.strItemCategCode = tblcategory.strCategCode) inner join tblmodel on(tblmodel.strModeCode = tblasset.strAsseModeCode) inner join tblvendor on(tblvendor.strVendCode = tblasset.strAsseVendCode) where strAsseCode = '" + this.assetCodeSelected + "';", columns);

            //select for Item Type
            string[] columns2 = { "strItemName", "strCategName" };
            List<object>[] rs2;
            rs2 = dbConnect.Select("select * from tblItemType inner join tblCategory on(tblItemType.strItemCategCode = tblCategory.strCategCode) where tblItemType.strItemCode = '" + this.itemTypeCodeSelected + "';", columns2);


            //Displaying
            AssetCode.Text = this.assetCodeSelected;
            ItemName.Text = rs2[0].ElementAt(0).ToString();
            CategoryBox.Text = rs2[1].ElementAt(0).ToString();
            VendorBox.Text = rs[2].ElementAt(0).ToString();
            ModelBox.Text = rs[3].ElementAt(0).ToString();
            DatePurchased.Value = Convert.ToDateTime(rs[1].ElementAt(0).ToString());
            ItemStatus.Text = determineStatus();
            Notes.Text = rs[4].ElementAt(0).ToString();
        }
        //dagdag
        private string determineStatus()
        {
            string[] columns = { "intAsseStatus" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblAsset where strAsseCode = '" + assetCodeSelected + "';", columns);

            switch (int.Parse(rs[0].ElementAt(0).ToString()))
            {
                case 1:
                    return "Good Condition";
                case 2:
                    return "Damaged";
                case 3:
                    return "Others (see Notes)";
                default:
                    return "Invalid Status";
            }
        }
        private string statusToInt(string status)
        {
            string returnString = "";
            if (status.Equals("Good Condition"))
            {
                returnString = "1";
            }
            else if (status.Equals("Damaged"))
            {
                returnString = "2";
            }
            else if (status.Equals("Others (see Notes)"))
            {
                returnString = "3";
            }

            return returnString;
        }
        public bool doesItemTypeExist(string itemToSearch)
        {
            bool returnBool = false;

            int count = dbConnect.Count("select count(*) from tblItemType where strItemName = '" + itemToSearch + "' and boolItemIsDel = false;");
            if (count > 0)
            {
                returnBool = true;
            }

            return returnBool;
        }
        //------------------------------------------------GENERATED CODE--------------------------------------------------------------------
        private void UpdateIT_Click(object sender, EventArgs e)
        {

            bool isInputValid = false;


            if (ItemName.Text != "") {
                    string assetcode = AssetCode.Text;
                    string itemname = ItemName.Text;
                    string itemcateg = CategoryBox.SelectedItem.ToString();
                    string itemvendor = VendorBox.SelectedItem.ToString();
                    string itemmodel = ModelBox.SelectedItem.ToString();
                    string datepurchased = this.DatePurchased.Value.Date.ToString("yyyy-MM-dd");
                    string status = statusToInt(ItemStatus.SelectedItem.ToString());
                    string notes = Notes.Text;
                    if (status == "1")
                {
                    Notes.Clear();
                    isInputValid = true;

                }
                if (status != "1")
                {
                    if (notes != "") {
                        isInputValid = true;
                    }
                    else {
                        MessageBox.Show("Please input notes.");
                    }

                }

                if (isInputValid)
                {
                    try
                    {

                        DialogResult dialogResult = MessageBox.Show("Are you you want to save your current changes?", "Update?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                        dbConnect.Update("update tblItemType set strItemName = '" + itemname + "',strItemCategCode = '" + getCategCodeFromList(itemcateg) + "' where strItemCode = '" + itemTypeCodeSelected + "'");
                        dbConnect.Update("update tblAsset set strAsseVendCode = '" + getVendorCodeFromList(itemvendor) + "',strAsseModeCode = '" + getModelCodeFromList(itemmodel) + "',dtmAssePurchased = '" + datepurchased + "',txtAsseNotes = '" + notes + "',intAsseStatus = " + status + " where strAsseCode = '" + assetCodeSelected + "';");
                        MessageBox.Show("Successfully Updated!");
                        EditIT.Visible = true;
                        UpdateIT.Visible = false;
                        ItemInfor.Enabled = false;
                        CloseInfo.Enabled = true;
                        CancelEdit.Visible = false;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Display();

                        }
                        //for itemtype
                     
                   
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Catched! \n" + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please input the fields correctly");
                }


            }
                else
                {
                    MessageBox.Show("Item name is required");
                }

            }
        
        private void EditIT_Click(object sender, EventArgs e)
        {
            EditIT.Visible = false;
            UpdateIT.Visible = true;
            ItemInfor.Enabled = true;
            
            CloseInfo.Enabled = false;
            CancelEdit.Visible = true;

            //mj code
            CategoryBox.Enabled = true;
            ItemName.Enabled = true;
       

        }

        private void CancelEdit_Click(object sender, EventArgs e)
        {
            EditIT.Visible = true;
            UpdateIT.Visible = false;
            ItemInfor.Enabled = false;
            CancelEdit.Visible = false;
         
            CloseInfo.Enabled = true;
            
            Display();
        }

        private void CloseInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AssetCode_Click(object sender, EventArgs e)
        {

        }

        private void ItemInfo_Load(object sender, EventArgs e)
        {

        }

        private void ClearText_Click(object sender, EventArgs e)
        {

        }

        private void ItemInfo_Load_1(object sender, EventArgs e)
        {
            DatePurchased.Value = DateTime.Today;
        }

        private void CategoryBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void AssetCode_Click_1(object sender, EventArgs e)
        {

        }
    }
}
