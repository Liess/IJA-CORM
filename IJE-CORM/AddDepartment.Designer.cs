namespace IJE
{
    partial class AddDepartment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddDepart = new System.Windows.Forms.Button();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.DeptName = new System.Windows.Forms.TextBox();
            this.DeptCode = new System.Windows.Forms.TextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.DepartmentList = new System.Windows.Forms.DataGridView();
            this.colDepCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // AddDepart
            // 
            this.AddDepart.BackgroundImage = global::IJE.Properties.Resources.submitbutt;
            this.AddDepart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddDepart.Location = new System.Drawing.Point(68, 389);
            this.AddDepart.Name = "AddDepart";
            this.AddDepart.Size = new System.Drawing.Size(66, 35);
            this.AddDepart.TabIndex = 26;
            this.AddDepart.UseVisualStyleBackColor = true;
            this.AddDepart.Click += new System.EventHandler(this.AddDepart_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(17, 191);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(128, 19);
            this.materialLabel6.TabIndex = 22;
            this.materialLabel6.Text = "Department code:";
            // 
            // DeptName
            // 
            this.DeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptName.Location = new System.Drawing.Point(159, 241);
            this.DeptName.Name = "DeptName";
            this.DeptName.Size = new System.Drawing.Size(106, 22);
            this.DeptName.TabIndex = 25;
            // 
            // DeptCode
            // 
            this.DeptCode.Enabled = false;
            this.DeptCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeptCode.Location = new System.Drawing.Point(159, 191);
            this.DeptCode.Name = "DeptCode";
            this.DeptCode.Size = new System.Drawing.Size(106, 22);
            this.DeptCode.TabIndex = 24;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(16, 241);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(132, 19);
            this.materialLabel5.TabIndex = 23;
            this.materialLabel5.Text = "Department name:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::IJE.Properties.Resources.cancelbuttons;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(140, 389);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(66, 35);
            this.button2.TabIndex = 29;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DepartmentList
            // 
            this.DepartmentList.AllowUserToAddRows = false;
            this.DepartmentList.AllowUserToDeleteRows = false;
            this.DepartmentList.AllowUserToResizeColumns = false;
            this.DepartmentList.AllowUserToResizeRows = false;
            this.DepartmentList.ColumnHeadersHeight = 35;
            this.DepartmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DepartmentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDepCode,
            this.Department});
            this.DepartmentList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DepartmentList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.DepartmentList.Location = new System.Drawing.Point(-151, 21);
            this.DepartmentList.Name = "DepartmentList";
            this.DepartmentList.RowHeadersVisible = false;
            this.DepartmentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DepartmentList.Size = new System.Drawing.Size(544, 382);
            this.DepartmentList.TabIndex = 30;
            this.DepartmentList.Visible = false;
            // 
            // colDepCode
            // 
            this.colDepCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDepCode.HeaderText = "colDepCode";
            this.colDepCode.Name = "colDepCode";
            this.colDepCode.Visible = false;
            // 
            // Department
            // 
            this.Department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Department.HeaderText = "Departments";
            this.Department.Name = "Department";
            // 
            // AddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IJE.Properties.Resources.departmentpanel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(287, 436);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddDepart);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.DeptName);
            this.Controls.Add(this.DeptCode);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.DepartmentList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDepartment";
            this.Load += new System.EventHandler(this.AddDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddDepart;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.TextBox DeptName;
        private System.Windows.Forms.TextBox DeptCode;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView DepartmentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
    }
}