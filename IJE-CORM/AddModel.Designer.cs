namespace IJE
{
    partial class AddModel
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
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.tbxModelName = new System.Windows.Forms.TextBox();
            this.tbxModelCode = new System.Windows.Forms.TextBox();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ModelList = new System.Windows.Forms.DataGridView();
            this.colModeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ModelList)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(24, 265);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(96, 19);
            this.materialLabel15.TabIndex = 14;
            this.materialLabel15.Text = "Model name:";
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(24, 210);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(92, 19);
            this.materialLabel14.TabIndex = 13;
            this.materialLabel14.Text = "Model code:";
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(24, 154);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(75, 19);
            this.materialLabel13.TabIndex = 12;
            this.materialLabel13.Text = "Item type:";
            // 
            // tbxModelName
            // 
            this.tbxModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxModelName.Location = new System.Drawing.Point(143, 265);
            this.tbxModelName.Name = "tbxModelName";
            this.tbxModelName.Size = new System.Drawing.Size(121, 24);
            this.tbxModelName.TabIndex = 11;
            // 
            // tbxModelCode
            // 
            this.tbxModelCode.Enabled = false;
            this.tbxModelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxModelCode.Location = new System.Drawing.Point(143, 208);
            this.tbxModelCode.Name = "tbxModelCode";
            this.tbxModelCode.Size = new System.Drawing.Size(121, 24);
            this.tbxModelCode.TabIndex = 10;
            // 
            // cmbItemType
            // 
            this.cmbItemType.DropDownHeight = 70;
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.IntegralHeight = false;
            this.cmbItemType.Location = new System.Drawing.Point(143, 152);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(121, 26);
            this.cmbItemType.TabIndex = 9;
            this.cmbItemType.SelectedIndexChanged += new System.EventHandler(this.cmbItemType_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IJE.Properties.Resources.submitbutt;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(66, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 35);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::IJE.Properties.Resources.cancelbuttons;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(138, 376);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(66, 35);
            this.button2.TabIndex = 30;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModelList
            // 
            this.ModelList.AllowUserToAddRows = false;
            this.ModelList.AllowUserToDeleteRows = false;
            this.ModelList.AllowUserToResizeColumns = false;
            this.ModelList.AllowUserToResizeRows = false;
            this.ModelList.ColumnHeadersHeight = 35;
            this.ModelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ModelList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModeCode,
            this.colModeName});
            this.ModelList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ModelList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.ModelList.Location = new System.Drawing.Point(-118, 52);
            this.ModelList.Name = "ModelList";
            this.ModelList.RowHeadersVisible = false;
            this.ModelList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ModelList.Size = new System.Drawing.Size(544, 382);
            this.ModelList.TabIndex = 31;
            this.ModelList.Visible = false;
            // 
            // colModeCode
            // 
            this.colModeCode.HeaderText = "colModeCode";
            this.colModeCode.Name = "colModeCode";
            this.colModeCode.Visible = false;
            // 
            // colModeName
            // 
            this.colModeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colModeName.HeaderText = "Model Name";
            this.colModeName.Name = "colModeName";
            // 
            // AddModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IJE.Properties.Resources.modelpanel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(288, 436);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.materialLabel15);
            this.Controls.Add(this.materialLabel14);
            this.Controls.Add(this.materialLabel13);
            this.Controls.Add(this.tbxModelName);
            this.Controls.Add(this.tbxModelCode);
            this.Controls.Add(this.cmbItemType);
            this.Controls.Add(this.ModelList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddModel";
            this.Load += new System.EventHandler(this.AddModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ModelList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private System.Windows.Forms.TextBox tbxModelName;
        private System.Windows.Forms.TextBox tbxModelCode;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView ModelList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModeName;
    }
}