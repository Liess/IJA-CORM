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
    public partial class AddSection : Form
    {

        CodeGenerator codeGenerator = new CodeGenerator();
        DBConnect dbConnect = new DBConnect();
        public AddSection()
        {
            InitializeComponent();
            advisersAndCode[0] = new List<string>();
            advisersAndCode[1] = new List<string>();
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

        List<string>[] advisersAndCode = new List<string>[2];
        public string getAdvisorCodeFromList(string searchAdvName)
        {
            string returnCode = "";
            for (int i = 0; i < advisersAndCode[1].Count; i++)
            {
                if (advisersAndCode[1].ElementAt(i).Equals(searchAdvName))
                {
                    returnCode = advisersAndCode[0].ElementAt(i);
                    break;
                }
            }
            return returnCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtSectionCode = SectionCode.Text;
            string txtSectionName = SectionName.Text;
            if (SectionName.Text != "")
            {
                try
                {
                    string txtSectionAdviser = getAdvisorCodeFromList(cmbAdvisorName.SelectedItem.ToString());
                    //search if existing
                    if (!isExisting(txtSectionName, SectionList))
                    {
                        dbConnect.Insert("insert into tblSection values('" + txtSectionCode + "','" + txtSectionName + "','" + txtSectionAdviser + "',false);");
                        this.SectionCode.Text = codeGenerator.generateCodeChild("tblSection", "strSectCode", getAdvisorCodeFromList(cmbAdvisorName.SelectedItem.ToString()), "Sec");
                        this.Close();
                    }
                    SectionName.Clear();
             
                }
                catch (Exception)
                {
                    MessageBox.Show("No selected adviser");
                }
            }
            else
            {
                MessageBox.Show("Input a Section name");
            }

            try
            {
                this.cmbAdvisorName.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Registered Adviser, Please register faculties first");
        
            }
        }

        public void refreshAdvisorsCmb()
        {
            this.cmbAdvisorName.Items.Clear();
            List<object>[] rs;
            string[] columns = { "strNameCode", "strNameFName", "strNameMName", "strNameLName" };
            rs = dbConnect.Select("Select * from tblName inner join tblfaculty on (tblName.strNameCode = tblfaculty.strFacuNameCode) where intNameType = 2 AND boolNameIsDel = false;", columns);


            for (int i = 0; i < rs[0].Count; i++)
            {
                //------for the combo box cmbAdvisersName
                cmbAdvisorName.Items.Add(rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString());


                //------For the list advisersAndCode
                //Adviser Code
                advisersAndCode[0].Add(rs[0].ElementAt(i).ToString());
                //Name (LName, FName MName)
                advisersAndCode[1].Add(rs[3].ElementAt(i).ToString() + ", " + rs[1].ElementAt(i).ToString() + " " + rs[2].ElementAt(i).ToString());
            }

            //for trying if there are advisers
            try
            {
                this.cmbAdvisorName.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Registered Adviser, Please register faculties first");
                this.Close();
            }
        }

        public string getAdvisorNameFromList(string searchAdvCode)
        {
            string returnName = "";
            for (int i = 0; i < advisersAndCode[0].Count; i++)
            {
                if (advisersAndCode[0].ElementAt(i).Equals(searchAdvCode))
                {
                    returnName = advisersAndCode[1].ElementAt(i);
                    break;
                }
            }
            return returnName;
        }

        public void refreshSections()
        {
            this.SectionList.Rows.Clear();
            List<object>[] rs;
            string[] columns = { "strSectCode", "strSectName", "strSectFacuCode" };
            rs = dbConnect.Select("Select * from tblSection where boolSectIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                //                             sect code(hidden)           sect name                           adviser name
                this.SectionList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString(), getAdvisorNameFromList(rs[2].ElementAt(i).ToString()));
            }

            //clear selection
            SectionList.ClearSelection();
        }

        private void AddSection_Load(object sender, EventArgs e)
        {
            refreshAdvisorsCmb();
            refreshSections();
        }

        private void cmbAdvisorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdvisorName.SelectedIndex != -1)
            {
                try
                {
                    this.SectionCode.Text = codeGenerator.generateCodeChild("tblSection", "strSectCode", getAdvisorCodeFromList(cmbAdvisorName.SelectedItem.ToString()), "Sec");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SectionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
