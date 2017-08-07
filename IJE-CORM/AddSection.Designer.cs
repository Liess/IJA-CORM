namespace IJE
{
    partial class AddSection
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
            this.button1 = new System.Windows.Forms.Button();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SectionCode = new System.Windows.Forms.TextBox();
            this.cmbAdvisorName = new System.Windows.Forms.ComboBox();
            this.SectionName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SectionList = new System.Windows.Forms.DataGridView();
            this.colAdvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SectionList)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IJE.Properties.Resources.submitbutt;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(71, 377);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(66, 35);
            this.button1.TabIndex = 26;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(19, 217);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(101, 19);
            this.materialLabel7.TabIndex = 22;
            this.materialLabel7.Text = "Section code:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(19, 276);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(105, 19);
            this.materialLabel8.TabIndex = 23;
            this.materialLabel8.Text = "Section name:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(18, 155);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 19);
            this.materialLabel1.TabIndex = 21;
            this.materialLabel1.Text = "Advisor Name:";
            // 
            // SectionCode
            // 
            this.SectionCode.Enabled = false;
            this.SectionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionCode.Location = new System.Drawing.Point(150, 216);
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.Size = new System.Drawing.Size(118, 22);
            this.SectionCode.TabIndex = 24;
            // 
            // cmbAdvisorName
            // 
            this.cmbAdvisorName.DropDownHeight = 90;
            this.cmbAdvisorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdvisorName.DropDownWidth = 90;
            this.cmbAdvisorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdvisorName.FormattingEnabled = true;
            this.cmbAdvisorName.IntegralHeight = false;
            this.cmbAdvisorName.Location = new System.Drawing.Point(149, 153);
            this.cmbAdvisorName.Name = "cmbAdvisorName";
            this.cmbAdvisorName.Size = new System.Drawing.Size(121, 24);
            this.cmbAdvisorName.TabIndex = 27;
            this.cmbAdvisorName.SelectedIndexChanged += new System.EventHandler(this.cmbAdvisorName_SelectedIndexChanged);
            // 
            // SectionName
            // 
            this.SectionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SectionName.Location = new System.Drawing.Point(150, 276);
            this.SectionName.Name = "SectionName";
            this.SectionName.Size = new System.Drawing.Size(118, 22);
            this.SectionName.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::IJE.Properties.Resources.cancelbuttons;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(141, 377);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(66, 35);
            this.button2.TabIndex = 28;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SectionList
            // 
            this.SectionList.AllowUserToAddRows = false;
            this.SectionList.AllowUserToDeleteRows = false;
            this.SectionList.AllowUserToResizeColumns = false;
            this.SectionList.AllowUserToResizeRows = false;
            this.SectionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SectionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAdvCode,
            this.colSectionName,
            this.dataGridViewTextBoxColumn2});
            this.SectionList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SectionList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.SectionList.Location = new System.Drawing.Point(-82, 30);
            this.SectionList.Name = "SectionList";
            this.SectionList.RowHeadersVisible = false;
            this.SectionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SectionList.Size = new System.Drawing.Size(544, 382);
            this.SectionList.TabIndex = 29;
            this.SectionList.Visible = false;
            this.SectionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SectionList_CellContentClick);
            // 
            // colAdvCode
            // 
            this.colAdvCode.HeaderText = "colAdvCode";
            this.colAdvCode.Name = "colAdvCode";
            this.colAdvCode.Visible = false;
            // 
            // colSectionName
            // 
            this.colSectionName.HeaderText = "Section Name";
            this.colSectionName.Name = "colSectionName";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Advisors";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // AddSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IJE.Properties.Resources.sectionpanel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(289, 436);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbAdvisorName);
            this.Controls.Add(this.SectionName);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.SectionCode);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SectionList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSection";
            this.Load += new System.EventHandler(this.AddSection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SectionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox SectionCode;
        private System.Windows.Forms.ComboBox cmbAdvisorName;
        private System.Windows.Forms.TextBox SectionName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView SectionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSectionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    }
}