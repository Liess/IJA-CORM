using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace IJE
{
    public partial class Inventory : Form
    {
        DBConnect dbConnect;
        CodeGenerator codeGenerator;
        string currentItemCode;

        List<string>[] categAndCode;
        List<string>[] modelsAndCode;
        List<string>[] vendorsAndCode;
        List<string>[] itemTypesAndCode;
        public Inventory()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
            this.TransparencyKey = Color.CornflowerBlue;
            dbConnect = new DBConnect();
            codeGenerator = new CodeGenerator();
            datepurchased.MaxDate = DateTime.Today;

            //Generate Code
            this.ItemCode.Text = codeGenerator.generateCodeParent("tblItemType", "strItemCode", "Item");



            refreshCategories();
            refreshItemTypes();
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

        public void loadingscreen2()
        {
            try
            {
                Application.Run(new SuccessSplashScreen());
            }
            catch (ThreadAbortException e)
            {
                Thread.ResetAbort();
            }

        }
        //------------------------------------------------METHODS--------------------------------------------------------------------
        public void refreshCategories()
        {
            //refresh categAndCode
            categAndCode = new List<string>[2];
            categAndCode[0] = new List<string>();
            categAndCode[1] = new List<string>();


            this.Category.Items.Clear();
            string[] columns = { "strCategCode", "strCategName" };
            List<object>[] result;
            result = dbConnect.Select("select strCategCode,strCategName from tblCategory where boolCategIsDel = false;", columns);
            for (int i = 0; i < result[0].Count; i++)
            {
                this.Category.Items.Add(result[1].ElementAt(i).ToString());
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

            this.ModelBox.Items.Clear();
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

            this.Vendorbox.Items.Clear();

            List<object>[] rs;
            string[] columns = { "strVendCode", "strVendName" };
            rs = dbConnect.Select("select strVendCode,strVendName from tblVendor Where boolVendIsDel = false;", columns);
            for (int i = 0; i < rs[0].Count; i++)
            {
                this.Vendorbox.Items.Add(rs[1].ElementAt(i).ToString());

                //list
                this.vendorsAndCode[0].Add(rs[0].ElementAt(i).ToString());
                this.vendorsAndCode[1].Add(rs[1].ElementAt(i).ToString());
            }

            Vendorbox.SelectedIndex = -1;
        }
        private void refreshItemTypes()
        {
            itemTypesAndCode = new List<string>[2];
            itemTypesAndCode[0] = new List<string>();
            itemTypesAndCode[1] = new List<string>();


            ItemBox.Items.Clear();
            string[] columns = { "strItemCode", "strItemName" };
            List<object>[] rs;
            rs = dbConnect.Select("Select strItemCode,strItemName from tblItemType where boolItemIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                ItemBox.Items.Add(rs[1].ElementAt(i).ToString());

                //list
                itemTypesAndCode[0].Add(rs[0].ElementAt(i).ToString());
                itemTypesAndCode[1].Add(rs[1].ElementAt(i).ToString());
            }
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
        public string getItemTypeCodeFromList(string codeOfWhat)
        {
            string toReturn = "";
            for (int i = 0; i < itemTypesAndCode[1].Count; i++)
            {
                if (itemTypesAndCode[1].ElementAt(i).Equals(codeOfWhat))
                {
                    toReturn = itemTypesAndCode[0].ElementAt(i);
                    break;
                }
            }
            return toReturn;
        }
        //--------------------------------------------------OTHERS----------------------------------------------------------------
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
        //---------------------------------------------GENERATED CODES-------------------------------------------------------------
        Thread t2;
        private void AddIT_Click(object sender, EventArgs e)
        {
          

         
            try
            {
                if (Quantity.Value > 0) {
                    string txtVendor = getVendorCodeFromList(Vendorbox.SelectedItem.ToString());
                    string txtModel = getModelCodeFromList(ModelBox.SelectedItem.ToString());
                    string txtQuantity = Quantity.Value.ToString();
                    string txtDate = this.datepurchased.Value.Date.ToString("yyyy-MM-dd");

                    DialogResult dialogResult = MessageBox.Show((Vendorbox.SelectedItem.ToString() +"\n" +ModelBox.SelectedItem.ToString()  + "\n" + txtQuantity + "\n" + txtDate), "Done?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        bool done = false;
                        ThreadPool.QueueUserWorkItem((x) =>
                        {
                            using (var splashForm = new AddingDataSplashScreen())
                            {
                                splashForm.Show();
                                while (!done)
                    for (int i = 0; i < int.Parse(txtQuantity); i++)
                    {
                       
                        dbConnect.Insert("Insert into tblAsset values ('" + codeGenerator.generateCodeChild("tblAsset", "strAsseCode", this.currentItemCode, "Asset") + "','" + txtDate + "','" + txtVendor + "','" + txtModel + "','" + currentItemCode + "','',1,false);");

                    }
                                    splashForm.Close();
                            }
                        });
                   
                     Thread.Sleep(4000); // Emulate hardwork
                    done = true;
                    this.Close();
                 
                
                    }
                    else if (dialogResult == DialogResult.No)
                    {


                    }
                  
                }
                else {
                    MessageBox.Show("Minimum item input: 1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fill the following requirements");
            }
           

        }

        private void CancelAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminPanel.r == 1)
            {
                if (doesItemTypeExist(this.ItemName.Text))
                {
                    MessageBox.Show(this.ItemName.Text + " already exist! please use add existing Item");
                }
                else
                {
                    //Insert Item to database
                    try
                    {

                        if (ItemName.Text != "")
                        {
                            string txtItemCode = this.ItemCode.Text;
                            string txtItemName = this.ItemName.Text;
                            string txtCategCode = getCategCodeFromList(this.Category.SelectedItem.ToString());

                            DialogResult dialogResult = MessageBox.Show("Are you you want to add " + txtItemName + "?", "Add item?", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                            dbConnect.Insert("Insert into tblItemType values ('" + txtItemCode + "','" + txtItemName + "','" + txtCategCode + "',false);");
                            MessageBox.Show("Please input the following details");
                            //Pass to itemcode to the next
                            currentItemCode = txtItemCode;
                            refreshModels(currentItemCode);
                            refreshVendors();

                            lbl_itemname.Text = txtItemName;
                            panel1.Visible = false;
                            panel2.Visible = true;
                            }
                            else if (dialogResult == DialogResult.No)
                            {


                            }
                           
                        }
                        else {
                            MessageBox.Show("Item name is required");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString() + "Category is required");
                    }
                 
                }
            }
            else if (AdminPanel.r == 2)
            {
                try
                {
                    currentItemCode = getItemTypeCodeFromList(ItemBox.SelectedItem.ToString());
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to add " + ItemBox.SelectedItem.ToString() + "?", "Add item?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lbl_itemname.Text = ItemBox.SelectedItem.ToString();
                    refreshModels(currentItemCode);
                    refreshVendors();
                    MessageBox.Show("Please input the following details");

                    panel1.Visible = false;
                    panel2.Visible = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {


                    }
                   
                }
                catch
                {
                    MessageBox.Show("Please select an item");

                }
            }
            else
            {
                MessageBox.Show("R is not equal to 1 | 2");
            }

            

        }
        private void refresh_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshModels(currentItemCode);
            refreshVendors();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            maintenance mainte = new maintenance();
            mainte.FormClosed += new FormClosedEventHandler(refresh_FormClosed);
            mainte.ShowDialog();
        }
        private void Inventory_Load(object sender, EventArgs e)
        {
            if (AdminPanel.r == 1)
            {
                pictureBox1.Image = Properties.Resources.AddItemPanel;
                ItemBox.Visible = false;
                ItemName.Visible = true;
                Category.Enabled = true;
                datepurchased.Value = DateTime.Today;
            }
            if (AdminPanel.r == 2)
            {
                pictureBox1.Image = Properties.Resources.AddExistingItem2;
                ItemBox.Visible = true;
                ItemName.Visible = false;
                Category.Enabled = false;
                ItemCode.Visible = false;
                Itemcodelabel.Visible = false;
                Category.Visible = false;
                Categ.Visible = false;
                datepurchased.Value = DateTime.Today;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ItemName_Click(object sender, EventArgs e)
        {

        }

        private void Categ_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int x = 0;


        private void stop_Tick(object sender, EventArgs e)
        {
            x++;

            if (x == 15)
            {
                t2.Abort();
                x = 0; 
                stop.Stop();
            }
        }

        private void refresh_vendor(object sender, FormClosedEventArgs e)
        {
            refreshVendors();
        }
        private void Btn_AddVendor_Click(object sender, EventArgs e)
        {
            AddVendor vendor = new AddVendor();
            vendor.FormClosed += new FormClosedEventHandler(refresh_vendor);
            vendor.ShowDialog();
        }
        private void refresh_model(object sender, FormClosedEventArgs e)
        {
            refreshModels(currentItemCode);
        }
        private void Btn_AddModel_Click(object sender, EventArgs e)
        {
           AddModel model = new AddModel();
            model.FormClosed += new FormClosedEventHandler(refresh_model);
            model.ShowDialog();
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
