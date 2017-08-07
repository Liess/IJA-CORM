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
    public partial class AddModel : Form
    {

        CodeGenerator codeGenerator = new CodeGenerator();
        DBConnect dbConnect = new DBConnect();
        public AddModel()
        {
            InitializeComponent();
            itemTypeAndCode[0] = new List<string>();
            itemTypeAndCode[1] = new List<string>();
        }
        List<string>[] itemTypeAndCode = new List<string>[2];


        public void refreshItemCmb()
        {
            this.cmbItemType.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strItemCode", "strItemName" };
            rs = dbConnect.Select("Select * from tblItemType where boolItemIsDel = false;", columns);



            for (int i = 0; i < rs[0].Count; i++)
            {
                //------for the combo box cmbItemType
                cmbItemType.Items.Add(rs[1].ElementAt(i).ToString());


                //------For the list itemTypeAndCode
                //Item Code
                itemTypeAndCode[0].Add(rs[0].ElementAt(i).ToString());
                //Item Name
                itemTypeAndCode[1].Add(rs[1].ElementAt(i).ToString());
            }

            //for trying if there are departments
            try
            {
                this.cmbItemType.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Item Types, Please add Item Types first");
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
        public string getItemCodeFromList(string searchItemName)
        {
            string returnCode = "";
            for (int i = 0; i < itemTypeAndCode[1].Count; i++)
            {
                if (itemTypeAndCode[1].ElementAt(i).Equals(searchItemName))
                {
                    returnCode = itemTypeAndCode[0].ElementAt(i);
                    break;
                }
            }
            return returnCode;
        }
        public void refreshModels(string modelOfWhat)
        {
            this.ModelList.Rows.Clear();
            List<object>[] rs;
            string[] columns = { "strModeCode", "strModeName" };
            rs = dbConnect.Select("Select * from tblModel where strModeItemCode = '" + modelOfWhat + "' and boolModeIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                //                             model code(hidden)           model name
                this.ModelList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString());
            }

            //clear selection
            ModelList.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtModelCode = tbxModelCode.Text;
            string txtModelName = tbxModelName.Text;
            string txtItemCode = getItemCodeFromList(cmbItemType.SelectedItem.ToString());
            //search if existing
            if (tbxModelName.Text != "")
            {
                if (!isExisting(txtModelName, ModelList))
                {
                    dbConnect.Insert("insert into tblModel values('" + txtModelCode + "','" + txtItemCode + "','" + txtModelName + "',false);");
                    tbxModelName.Clear();
                }
            }
            else
            {
                MessageBox.Show("Input a Model name");
            }
            //for if it didnt changed index generate code and refresh models
            //----generate
            this.tbxModelCode.Text = codeGenerator.generateCodeChild("tblModel", "strModeCode", getItemCodeFromList(cmbItemType.SelectedItem.ToString()), this.cmbItemType.SelectedItem.ToString());
            //----refresh position according to dep
            if (this.cmbItemType.SelectedIndex != -1)
            {
                refreshModels(getItemCodeFromList(cmbItemType.SelectedItem.ToString()));
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddModel_Load(object sender, EventArgs e)
        {
            refreshItemCmb();
        }

        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemType.SelectedIndex != -1)
            {
                try
                {
                    //generate
                    this.tbxModelCode.Text = codeGenerator.generateCodeChild("tblModel", "strModeCode", getItemCodeFromList(cmbItemType.SelectedItem.ToString()), this.cmbItemType.SelectedItem.ToString());
                    //refresh position according to dep
                    refreshModels(getItemCodeFromList(cmbItemType.SelectedItem.ToString()));
                    //enable add button
                    this.button1.Enabled = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("No Advisors");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
