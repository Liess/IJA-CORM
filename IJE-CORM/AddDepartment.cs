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
    public partial class AddDepartment : Form
    {
        CodeGenerator codeGenerator = new CodeGenerator();
        DBConnect dbConnect = new DBConnect();
        public AddDepartment()
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
        public void refreshDepartments()
        {
            this.DepartmentList.Rows.Clear();
            List<object>[] rs;
            string[] columns = { "strDepCode", "strDepName" };
            rs = dbConnect.Select("Select * from tblDepartment where boolDepIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                this.DepartmentList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString());
            }
            //clear selection
            DepartmentList.ClearSelection();
        }

        private void AddDepart_Click(object sender, EventArgs e)
        {
            string txtDepCode = DeptCode.Text;
            string txtDepName = DeptName.Text;
            if (DeptName.Text != "")
            {
                //search if existing
                if (!isExisting(txtDepName, DepartmentList))
                {
                    dbConnect.Insert("insert into tblDepartment values('" + txtDepCode + "','" + txtDepName + "',false);");
                    DeptName.Clear();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Input a Department name");
            }
            //Generate new Department Code
            this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode", "Dep");

            //refresh DepartmentList
            refreshDepartments();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {
            this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode", "Dep");
            refreshDepartments();
        }
    }
}
