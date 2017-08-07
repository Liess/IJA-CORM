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
    public partial class AddVendor : Form
    {

        CodeGenerator codeGenerator = new CodeGenerator();
        DBConnect dbConnect = new DBConnect();
        public AddVendor()
        {
            InitializeComponent();
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

        public void refreshVendors()
        {
            this.VendorList.Rows.Clear();
            List<object>[] rs;
            string[] columns = { "strVendCode", "strVendName" };
            rs = dbConnect.Select("Select * from tblVendor where boolVendIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                this.VendorList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString());
            }

            //clear selection
            VendorList.ClearSelection();
        }

        private void AddVend_Click(object sender, EventArgs e)
        {
            string txtVendCode = VendorCode.Text;
            string txtVendName = VendorName.Text;
            if (VendorName.Text != "")
            {
                //search if existing
                if (!isExisting(txtVendName, VendorList))
                {
                    dbConnect.Insert("insert into tblVendor values('" + txtVendCode + "','" + txtVendName + "',false);");
        
                }


                //Generate new Vendor Code
                this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");

                //refresh VendorList
                refreshVendors();
                VendorName.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Input a Vendor name");
            }
        }

        private void AddVendor_Load(object sender, EventArgs e)
        {
            this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");
            refreshVendors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }
    }
}
