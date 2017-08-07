using MetroFramework.Forms;
using Microsoft.VisualBasic;
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
    public partial class maintenance : Form
    {

        CodeGenerator codeGenerator = new CodeGenerator();
        DBConnect dbConnect = new DBConnect();
        public maintenance()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
          
            FormBorderStyle = FormBorderStyle.None;
            //Generate Code at the Start for category
            this.CategoryCode.Text = codeGenerator.generateCodeParent("tblCategory", "strCategCode", "Categ");
            //refresh categories
            refreshCategories();

            //initialization of advisers and code
            advisersAndCode[0] = new List<string>();
            advisersAndCode[1] = new List<string>();
            //initialization of position and code
            departmentsAndCode[0] = new List<string>();
            departmentsAndCode[1] = new List<string>();
            //initialization of item type and code
            itemTypeAndCode[0] = new List<string>();
            itemTypeAndCode[1] = new List<string>();
            CategoryList.EnableHeadersVisualStyles = false;
            CategoryList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            CategoryList.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            VendorList.EnableHeadersVisualStyles = false;
            VendorList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            VendorList.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            DepartmentList.EnableHeadersVisualStyles = false;
            DepartmentList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            DepartmentList.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            SectionList.EnableHeadersVisualStyles = false;
            SectionList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            SectionList.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            ModelList.EnableHeadersVisualStyles = false;
            ModelList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            ModelList.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            PositionList.EnableHeadersVisualStyles = false;
            PositionList.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            PositionList.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
        }
        //------------------------------------FIELDS/ATTRIBUTES-----------------------------------------------
        //for storing advisers name and their code
        List<string>[] advisersAndCode = new List<string>[2];
        List<string>[] departmentsAndCode = new List<string>[2];
        List<string>[] itemTypeAndCode = new List<string>[2];


        //--------------------Datagrid event handlers--------------------------
        private void categoryList_CellClick(object sender, EventArgs e)
        {
            try
            {
                CategoryCode.Text = CategoryList.SelectedRows[0].Cells[0].Value.ToString();
                CategoryName.Text = CategoryList.SelectedRows[0].Cells[1].Value.ToString();
                AddCateg.Visible = false;
                
                button2.Visible = true;
                CancelCateg.Visible = true;
            }catch(ArgumentOutOfRangeException){

            }
            
        }
        private void vendorList_CellClick(object sender, EventArgs e)
        {
            try
            {
                VendorCode.Text = VendorList.SelectedRows[0].Cells[0].Value.ToString();
                VendorName.Text = VendorList.SelectedRows[0].Cells[1].Value.ToString();
                AddVend.Visible = false;
              
                button3.Visible = true;
                CancelVend.Visible = true;
            }catch(ArgumentOutOfRangeException){

            }
        }
        private void sectionList_CellClick(object sender, EventArgs e)
        {
            try
            {
                SectionCode.Text = SectionList.SelectedRows[0].Cells[0].Value.ToString();
                SectionName.Text = SectionList.SelectedRows[0].Cells[1].Value.ToString();
                cmbAdvisorName.SelectedText = SectionList.SelectedRows[0].Cells[2].Value.ToString();
                AddSection.Visible = false;
           
                button4.Visible = true;
                CancelSection.Visible = true;
            }
            catch (ArgumentOutOfRangeException)
            {
              
            }
        }
        private void departmentList_CellClick(object sender, EventArgs e)
        {
            try
            {
                DeptCode.Text = DepartmentList.SelectedRows[0].Cells[0].Value.ToString();
                DeptName.Text = DepartmentList.SelectedRows[0].Cells[1].Value.ToString();
                AddDepart.Visible = false;
          
                button5.Visible = true;
                CancelDep.Visible = true;
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        private void positionList_CellClick(object sender, EventArgs e)
        {
            try
            {
                tbxPosiCode.Text = PositionList.SelectedRows[0].Cells[0].Value.ToString();
                tbxPosiName.Text = PositionList.SelectedRows[0].Cells[1].Value.ToString();
                AddPosi.Visible = false;
               
                button6.Visible = true;
                CancelPos.Visible = true;

            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        private void modelList_CellClick(object sender, EventArgs e)
        {
            try
            {
                tbxModelCode.Text = ModelList.SelectedRows[0].Cells[0].Value.ToString();
                tbxModelName.Text = ModelList.SelectedRows[0].Cells[1].Value.ToString();
                AddModel.Visible = false;
  
                button7.Visible = true;
                CancelModel.Visible = true;
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }
        
        //------------------------------------------Generated Methods
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    this.CategoryCode.Text = codeGenerator.generateCodeParent("tblCategory", "strCategCode", "Categ");
                    refreshCategories();
                    panel1.Visible = true;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = false;
                    break;
                case 1:
                    this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");
                    refreshVendors();
                    panel1.Visible = false;
                    panel2.Visible = true;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = false;
                    break;
                case 2:
                    refreshAdvisorsCmb();
                    refreshSections();
                     panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = true;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = false;
                    break;
                case 3:
                    this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode", "Dep");
                    refreshDepartments();
                     panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = true;
                    panel5.Visible = false;
                    panel6.Visible = false;
                    break;
                case 4:
                    refreshDepartmentsCmb();
                     panel1.Visible =false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = true;
                    panel6.Visible = false;
                    break;
                case 5:
                    refreshItemCmb();
                     panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel6.Visible = true;
                    break;
            }
        }
        //-----------------------------------------METHODS------------------------------------------------------------------
        //----------------------------------DATA GRID---------------------------------------------------------------------
        public void refreshCategories()
        {
            this.CategoryList.Rows.Clear();
            List<object>[] rs;
            string[] columns = { "strCategCode", "strCategName" };
            rs = dbConnect.Select("Select * from tblCategory where boolCategIsDel = false;", columns);

            for (int i = 0; i < rs[0].Count; i++)
            {
                this.CategoryList.Rows.Add(rs[0].ElementAt(i).ToString(), rs[1].ElementAt(i).ToString());
            }

            //clear selection
            CategoryList.ClearSelection();
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

        //-------------------------------------CONVERTERS-----------//Not Really Important?------------------------------------------------------------------
        public string categToCode(string categName)
        {
            string[] columns = { "strCategCode" };
            List<object>[] rs;
            rs = dbConnect.Select("SELECT strCategCode from tblCategory WHERE strCategName = '" + categName + "';", columns);

            //return code
            return rs[0].ElementAt(0).ToString();
        }
        public string vendToCode(string vendName)
        {
            string[] columns = { "strVendCode" };
            List<object>[] rs;
            rs = dbConnect.Select("SELECT strVendCode from tblVendor WHERE strVendName = '" + vendName + "';", columns);

            //return code
            return rs[0].ElementAt(0).ToString();
        }
        public string depToCode(string depName)
        {
            string[] columns = { "strDepCode" };
            List<object>[] rs;
            rs = dbConnect.Select("SELECT strDepCode from tblDepartment WHERE strDepName = '" + depName + "';", columns);

            //return code
            return rs[0].ElementAt(0).ToString();
        }
        //------------------------------------------------------SEARCHING IF EXISTING------------------------------------
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
        //----------------------------------------------------OTHER METHODS------------------------------------------------------------
        //---------------------FOR ADVISER COMBO BOX------------------------------------------------------------------------------------
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
            }
        }
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
        //----------------------------------FOR Department COMBO BOX-------------------------------------------------
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
            }
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
        //----------------------------------FOR Item type COMBO BOX-------------------------------------------------
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
        public string getItemNameFromList(string searchItemCode)
        {
            string returnName = "";
            for (int i = 0; i < itemTypeAndCode[0].Count; i++)
            {
                if (itemTypeAndCode[0].ElementAt(i).Equals(searchItemCode))
                {
                    returnName = itemTypeAndCode[1].ElementAt(i);
                    break;
                }
            }
            return returnName;
        }

        //---------------------------------------------GEBNERATED CODES----------------------------------------------------------------
        private void maintenance_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void AddCateg_Click(object sender, EventArgs e)
        {
            string txtCategCode = CategoryCode.Text;
            string txtCategName = CategoryName.Text;

            if (CategoryName.Text != "") {
                if (!isExisting(txtCategName, CategoryList))
                {
                    dbConnect.Insert("insert into tblCategory values('" + txtCategCode + "','" + txtCategName + "',false);");
                }

                //Generate nnew Category Code
                this.CategoryCode.Text = codeGenerator.generateCodeParent("tblCategory", "strCategCode", "Categ");

                //refresh CategoryList
                refreshCategories();
                this.CategoryName.Clear();
            }
        
            else {
                MessageBox.Show("Input a Category name");
                      }            
        }

        private void DeleteCateg_Click(object sender, EventArgs e)
        {
            try
            {
                string a = this.CategoryList.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Are you you want to delete " + CategoryName.Text + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                 {
                     foreach (DataGridViewRow row in this.CategoryList.SelectedRows)
                {

                    //Logical delete in database
                    dbConnect.Update("Update tblCategory set boolCategIsDel = true where strCategCode = '" + row.Cells[0].Value.ToString() + "';");
                }
                refreshCategories();
                this.CategoryName.Clear();
                AddCateg.Visible = true;

                button2.Visible = false;
                CancelCateg.Visible = false;
                this.CategoryCode.Text = codeGenerator.generateCodeParent("tblCategory", "strCategCode", "Categ");
                refreshCategories();
                }
                else if (dialogResult == DialogResult.No)
                {


                }
             
            }
            catch (ArgumentOutOfRangeException)
            {

                MessageBox.Show("No selected item");
            }

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
            }
            else {
                MessageBox.Show("Input a Vendor name");
            }
        }

        private void DeleteVend_Click(object sender, EventArgs e)
        {
            try
            {
                string b = this.VendorList.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you you want to delete " + VendorName.Text + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                foreach (DataGridViewRow row in this.VendorList.SelectedRows)
                {
                    //Logical delete in database
                    dbConnect.Update("Update tblVendor set boolVendIsDel = true where strVendCode = '" + row.Cells[0].Value.ToString() + "';");
                }
                AddVend.Visible = true;

                button3.Visible = false;
                CancelVend.Visible = false;
                VendorName.Clear();

                //to generate new code and refresh vendors after
                this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");
                //refresh VendorList
                refreshVendors();
                }
                else if (dialogResult == DialogResult.No)
                {


                }
               
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("No selected item");
            }
        }

        private void AddSection_Click(object sender, EventArgs e)
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
                    }
                    SectionName.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("No selected adviser");
                }
            }
            else {
                MessageBox.Show("Input a Section name");
            }


            //refresh Sections
            refreshSections();
            AddSection.Visible = true;
            DeleteSection.Visible = true;
            button4.Visible =false;
            CancelSection.Visible = false;

            //-----Reseting data
            //clear cmb and code
            //for trying if there are advisers
            try
            {
                this.cmbAdvisorName.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Registered Adviser, Please register faculties first");
            }
        }
        private void DeleteSection_Click(object sender, EventArgs e)
        {
            try
            {
                string c = this.SectionList.SelectedRows[0].Cells[0].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Are you you want to delete " + SectionName.Text + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                foreach (DataGridViewRow row in this.SectionList.SelectedRows)
                {
                    //Logical delete in database
                    dbConnect.Update("Update tblSection set boolSectIsDel = true where strSectCode = '" + row.Cells[0].Value.ToString() + "';");
                }
                AddSection.Visible = true;
                button4.Visible = false;
                CancelSection.Visible = false;
                SectionName.Clear();
                //to generate code and refresh sections
                refreshAdvisorsCmb();
                refreshSections();
                }
                else if (dialogResult == DialogResult.No)
                {


                }
                

            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No selected Section");
            }

            //refresh Sections
            refreshSections();

            //for trying if there are advisers
            try
            {
                this.cmbAdvisorName.SelectedIndex = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Registered Adviser, Please register faculties first");
            }
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

                }
            }
            else {
                MessageBox.Show("Input a Department name");
            }
            //Generate new Department Code
            this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode","Dep");

            //refresh DepartmentList
            refreshDepartments();
        }

        private void DeleteDepart_Click(object sender, EventArgs e)
        {
            try
            {   string c = this.DepartmentList.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you you want to delete " + DeptName.Text + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
               
                foreach (DataGridViewRow row in this.DepartmentList.SelectedRows)
                {
                    //Logical delete in database
                    dbConnect.Update("Update tblDepartment set boolDepIsDel = true where strDepCode = '" + row.Cells[0].Value.ToString() + "';");
                }
                DeptName.Clear();
                AddDepart.Visible = true;
                DeleteDepart.Visible = true;
                button5.Visible = false;
                CancelDep.Visible = false;

                //to generate code and refresh departments
                this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode", "Dep");
                refreshDepartments();
                }
                else if (dialogResult == DialogResult.No)
                {


                }
             

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No selected Department");
            }
            //refresh Departments
            refreshDepartments();
        }

        private void CategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbAdvisorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAdvisorName.SelectedIndex != -1)
            {
                try
                {
                    this.SectionCode.Text = codeGenerator.generateCodeChild("tblSection", "strSectCode", getAdvisorCodeFromList(cmbAdvisorName.SelectedItem.ToString()), "Sec");
                    this.AddSection.Enabled = true;
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

        private void cmbDepName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepName.SelectedIndex != -1)
            {

                try
                {
                    //generate
                    this.tbxPosiCode.Text = codeGenerator.generateCodeChild("tblPosition", "strPosiCode", getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString()), this.cmbDepName.SelectedItem.ToString()+"Pos");
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
                }
            }
            else {
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

        private void DeletePosi_Click(object sender, EventArgs e)
        {
            try

            {   string f = this.PositionList.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you you want to delete " + tbxPosiName.Text + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in this.PositionList.SelectedRows)
                    {
                        //Logical delete in database
                        dbConnect.Update("Update tblPosition set boolPosiIsDel = true where strPosiCode = '" + row.Cells[0].Value.ToString() + "';");
                    }
                    AddPosi.Visible = true;

                    button6.Visible = false;
                    CancelPos.Visible = false;
                    tbxPosiName.Clear();

                    //to generate code
                    refreshDepartmentsCmb();
                }
                else if (dialogResult == DialogResult.No)
                {
                  

                }
                
              
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No selected Position");
            }


            //for trying if there are departments
            try
            {
                refreshPositions(getDepartmentCodeFromList(this.cmbDepName.SelectedItem.ToString()));
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Departments, Please Add Departments first");
            }
        }

        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItemType.SelectedIndex != -1)
            {
                try
                {
                    //generate
                    this.tbxModelCode.Text = codeGenerator.generateCodeChild("tblModel", "strModeCode", getItemCodeFromList(cmbItemType.SelectedItem.ToString()),this.cmbItemType.SelectedItem.ToString() );
                    //refresh position according to dep
                    refreshModels(getItemCodeFromList(cmbItemType.SelectedItem.ToString()));
                    //enable add button
                    this.AddModel.Enabled = true;
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

        private void AddModel_Click(object sender, EventArgs e)
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

        private void DeleteModel_Click(object sender, EventArgs e)
        {
            try
            {
                string g = this.ModelList.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you you want to delete " + tbxModelName.Text + "?", "Delete?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                foreach (DataGridViewRow row in this.ModelList.SelectedRows)
                {
                    //Logical delete in database
                    dbConnect.Update("Update tblModel set boolModeIsDel = true where strModeCode = '" + row.Cells[0].Value.ToString() + "';");
                }
                AddModel.Visible = true;
                button7.Visible = false;
                CancelModel.Visible = false;
                tbxModelName.Clear();

                //to generate code
                refreshItemCmb();
                }
                else if (dialogResult == DialogResult.No)
                {


                }
               
            }
            catch (ArgumentOutOfRangeException) {
                MessageBox.Show("No selected model");
            }
            //for trying if there are departments
            try
            {
                refreshModels(getItemCodeFromList(this.cmbItemType.SelectedItem.ToString()));
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("No Item Types, Please Item Types first");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void SectionName_Click(object sender, EventArgs e)
        {

        }

        private void SectionCode_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel8_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel7_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isExisting(CategoryName.Text, CategoryList))
            {
                dbConnect.Update("update tblCategory set strCategName = '"+CategoryName.Text+"' where strCategCode = '"+CategoryCode.Text+"';");
                MessageBox.Show("Update Successful!");
                   this.CategoryName.Clear();
                AddCateg.Visible = true;
             
                button2.Visible = false;
                CancelCateg.Visible = false;

                //To generate code and refresh
                this.CategoryCode.Text = codeGenerator.generateCodeParent("tblCategory", "strCategCode", "Categ");
                refreshCategories();
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!isExisting(VendorName.Text, VendorList))
            {
                dbConnect.Update("update tblVendor set strVendName = '"+VendorName.Text+"' where strVendCode = '"+VendorCode.Text+"';");
                MessageBox.Show("Update Successful!");
                this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");
                AddVend.Visible = true;
            
                button3.Visible = false;
                CancelVend.Visible = false;
                VendorName.Clear();

                //to generate new code and refresh vendors after
                this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");
                refreshVendors();
        
            }


            //Generate new Vendor Code
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!isExisting(SectionName.Text, SectionList))
            {
                dbConnect.Update("update tblSection set strSectName = '" + SectionName.Text + "', strSectFacuCode = '" + getAdvisorCodeFromList(cmbAdvisorName.SelectedItem.ToString()) + "' where strSectCode = '"+SectionCode.Text+"';");

                MessageBox.Show("Update Successful!");
                AddSection.Visible = true;
                DeleteSection.Visible = true;
                button4.Visible = false;
                CancelSection.Visible = false;
                SectionName.Clear();

                //to generate code and refresh data grid
                refreshAdvisorsCmb();
                refreshSections();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isExisting(DeptName.Text, DepartmentList))
            {
                dbConnect.Update("update tblDepartment set strDepName = '"+DeptName.Text+"' where strDepCode = '"+DeptCode.Text+"';");
                MessageBox.Show("Update Successful!");

                DeptName.Clear();
                AddDepart.Visible = true;
                DeleteDepart.Visible = true;
                button5.Visible = false;
                CancelDep.Visible = false;

                //to generate code and refresh departments
                this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode", "Dep");
                refreshDepartments();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!isExisting(tbxPosiName.Text, PositionList))
            {
                dbConnect.Update("update tblPosition set strPosiName = '"+tbxPosiName.Text+"' where strPosiCode = '"+tbxPosiCode.Text+"';");
                MessageBox.Show("Update Successful!");
                AddPosi.Visible = true;

                button6.Visible = false;
                CancelPos.Visible = false;
                tbxPosiName.Clear();

                //to generate code
                refreshDepartmentsCmb();
            }

            //----refresh position according to dep
            if (this.cmbDepName.SelectedIndex != -1)
            {
                refreshPositions(getDepartmentCodeFromList(cmbDepName.SelectedItem.ToString()));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!isExisting(tbxModelName.Text, ModelList))
            {
                dbConnect.Update("update tblModel set strModeName = '" + tbxModelName.Text + "' where strModeCode = '" + tbxModelCode.Text + "';");
                MessageBox.Show("Update Successful!");
                AddModel.Visible = true;
                DeleteModel.Visible = true;
                button7.Visible = false;
                CancelModel.Visible = false;
                tbxModelName.Clear();

                //to generate code
                refreshItemCmb();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CancelCateg_Click(object sender, EventArgs e)
        {
            this.CategoryName.Clear();
            AddCateg.Visible = true;
            DeleteCateg.Visible = true;
            button2.Visible = false;
            CancelCateg.Visible = false;
            //to generate new code and refresh datagrid
            this.CategoryCode.Text = codeGenerator.generateCodeParent("tblCategory", "strCategCode", "Categ");
            refreshCategories();
        }

        private void CancelVend_Click(object sender, EventArgs e)
        {
            AddVend.Visible = true;
            DeleteVend.Visible = true;
            button3.Visible = false;
            CancelVend.Visible = false;
            VendorName.Clear();

            //to generate new code and refresh vendors after
            this.VendorCode.Text = codeGenerator.generateCodeParent("tblVendor", "strVendCode", "Vendor");
            refreshVendors();
        }

        private void SectionList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CategoryList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void VendorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ModelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialLabel13_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel14_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel15_Click(object sender, EventArgs e)
        {

        }

        private void tbxModelName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxModelCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void CancelModel_Click(object sender, EventArgs e)
        {
            AddModel.Visible = true;
            DeleteModel.Visible = true;
            button7.Visible = false;
            CancelModel.Visible = false;
            tbxModelName.Clear();

            //to generate code
            refreshItemCmb();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddSection.Visible = true;
            DeleteSection.Visible = true;
            button4.Visible = false;
            CancelSection.Visible = false;
            SectionName.Clear();

            //to generate code and refresh sections
            refreshAdvisorsCmb();
            refreshSections();
        }

        private void CancelDep_Click(object sender, EventArgs e)
        {
            DeptName.Clear();
            AddDepart.Visible = true;
            DeleteDepart.Visible = true;
            button5.Visible = false;
            CancelDep.Visible = false;

            //to generate code and refresh departments
            this.DeptCode.Text = codeGenerator.generateCodeParent("tblDepartment", "strDepCode", "Dep");
            refreshDepartments();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void CancelPos_Click(object sender, EventArgs e)
        {
            AddPosi.Visible = true;
            DeletePosi.Visible = true;
            button6.Visible = false;
            CancelPos.Visible = false;
            tbxPosiName.Clear();

            //to generate code
            refreshDepartmentsCmb();
        }
    }
}
