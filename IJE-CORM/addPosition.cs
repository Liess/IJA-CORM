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
    public partial class addPosition : Form
    {

        CodeGenerator codeGenerator = new CodeGenerator();
        DBConnect dbConnect = new DBConnect();
        public addPosition()
        {
            InitializeComponent();
            departmentsAndCode[0] = new List<string>();
            departmentsAndCode[1] = new List<string>();
        }
        List<string>[] departmentsAndCode = new List<string>[2];
     
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

        public string getDepartmentNameFromList(string searchDepCode)
        {
            string returnName = "";
            for (int i = 0; i < departmentsAndCode[0].Count; i++)
            {
                if (departmentsAndCode[0].ElementAt(i).Equals(searchDepCode))
                {
                    returnName = departmentsAndCode[1].ElementAt(i);
                    break;
                }
            }
            return returnName;
        }
        public string getDepartmentCodeFromList(string searchDepName)
        {
            string returnCode = "";
            for (int i = 0; i < departmentsAndCode[1].Count; i++)
            {
                if (departmentsAndCode[1].ElementAt(i).Equals(searchDepName))
                {
                    returnCode = departmentsAndCode[0].ElementAt(i);
                    break;
                }
            }
            return returnCode;
        }
        public void refreshPositions(string posiOfWhat)
        {
            this.PositionList.Rows.Clear();
            List<object>[] rs;
            string[] columns = { "strPosiCode", "strPosiName" };
            rs = dbConnect.Select("Select * from tblPosition where strPosiDepCode = '" + posiOfWhat + "' and boolPosiIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                //                             posi code(hidden)           posi name
                this.PositionList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString());
            }

            //clear selection
            PositionList.ClearSelection();
        }
        private void AddPosi_Click(object sender, EventArgs e)
        {
            string txtPosiCode = tbxPosiCode.Text;
            string txtPosiName = tbxPosiName.Text;
            string txtDepCode = getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString());
            if (tbxPosiName.Text != "")
            {
                //search if existing
                if (!isExisting(txtPosiName, PositionList))
                {
                    dbConnect.Insert("insert into tblPosition values('" + txtPosiCode + "','" + txtDepCode + "','" + txtPosiName + "',false);");

                    tbxPosiName.Clear();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Input a Position name");
            }
            //for if it didnt changed index generate code and refreshpositions
            //----generate
            this.tbxPosiCode.Text = codeGenerator.generateCodeChild("tblPosition", "strPosiCode", getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString()), this.cmbDepName.SelectedItem.ToString() + "Pos");
            //----refresh position according to dep
            if (this.cmbDepName.SelectedIndex != -1)
            {
                refreshPositions(getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString()));
            }
        }

        public void refreshDepartmentsCmb()
        {
            this.cmbDepName.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strDepCode", "strDepName" };
            rs = dbConnect.Select("Select * from tblDepartment where boolDepIsDel = false;", columns);



            for (int i = 0; i < rs[0].Count; i++)
            {
                //------for the combo box cmbDepName
                cmbDepName.Items.Add(rs[1].ElementAt(i).ToString());


                //------For the list departmentsAndCode
                //Adviser Code
                departmentsAndCode[0].Add(rs[0].ElementAt(i).ToString());
                //Name (LName, FName MName)
                departmentsAndCode[1].Add(rs[1].ElementAt(i).ToString());
            }

            //for trying if there are departments
            try
            {
                this.cmbDepName.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Departments, Please add departments first");
                this.Close();
            }
        }

        private void addPosition_Load(object sender, EventArgs e)
        {
            refreshDepartmentsCmb();
        }

        private void PositionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepName.SelectedIndex != -1)
            {

                try
                {
                    //generate
                    this.tbxPosiCode.Text = codeGenerator.generateCodeChild("tblPosition", "strPosiCode", getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString()), this.cmbDepName.SelectedItem.ToString() + "Pos");
                    //refresh position according to dep
                    refreshPositions(getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString()));
                    //enable add button
                    this.AddPosi.Enabled = true;
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
