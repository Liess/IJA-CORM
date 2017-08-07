namespace IJE
{
    partial class AddVendor
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
            this.AddVend = new System.Windows.Forms.Button();
            this.VendorName = new System.Windows.Forms.TextBox();
            this.VendorCode = new System.Windows.Forms.TextBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.VendorList = new System.Windows.Forms.DataGridView();
            this.colVendCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.VendorList)).BeginInit();
            this.SuspendLayout();
            // 
            // AddVend
            // 
            this.AddVend.BackgroundImage = global::IJE.Properties.Resources.submitbutt;
            this.AddVend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddVend.Location = new System.Drawing.Point(67, 374);
            this.AddVend.Name = "AddVend";
            this.AddVend.Size = new System.Drawing.Size(66, 35);
            this.AddVend.TabIndex = 12;
            this.AddVend.UseVisualStyleBackColor = true;
            this.AddVend.Click += new System.EventHandler(this.AddVend_Click);
            // 
            // VendorName
            // 
            this.VendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorName.Location = new System.Drawing.Point(141, 235);
            this.VendorName.Name = "VendorName";
            this.VendorName.Size = new System.Drawing.Size(120, 24);
            this.VendorName.TabIndex = 11;
            // 
            // VendorCode
            // 
            this.VendorCode.Enabled = false;
            this.VendorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorCode.Location = new System.Drawing.Point(141, 172);
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.Size = new System.Drawing.Size(120, 24);
            this.VendorCode.TabIndex = 9;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(28, 237);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(105, 19);
            this.materialLabel10.TabIndex = 10;
            this.materialLabel10.Text = "Vendor Name:";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(29, 174);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(98, 19);
            this.materialLabel11.TabIndex = 8;
            this.materialLabel11.Text = "Vendor code:";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::IJE.Properties.Resources.cancelbuttons;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(140, 374);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(66, 35);
            this.button2.TabIndex = 29;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // VendorList
            // 
            this.VendorList.AllowUserToAddRows = false;
            this.VendorList.AllowUserToDeleteRows = false;
            this.VendorList.AllowUserToResizeColumns = false;
            this.VendorList.AllowUserToResizeRows = false;
            this.VendorList.ColumnHeadersHeight = 35;
            this.VendorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.VendorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVendCode,
            this.Vendors});
            this.VendorList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.VendorList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.VendorList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.VendorList.Location = new System.Drawing.Point(-75, 43);
            this.VendorList.Name = "VendorList";
            this.VendorList.RowHeadersVisible = false;
            this.VendorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VendorList.Size = new System.Drawing.Size(544, 382);
            this.VendorList.TabIndex = 30;
            this.VendorList.TabStop = false;
            this.VendorList.Visible = false;
            // 
            // colVendCode
            // 
            this.colVendCode.HeaderText = "colVendCode";
            this.colVendCode.Name = "colVendCode";
            this.colVendCode.Visible = false;
            // 
            // Vendors
            // 
            this.Vendors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Vendors.HeaderText = "Vendors";
            this.Vendors.Name = "Vendors";
            // 
            // AddVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IJE.Properties.Resources.vendorpanel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(286, 437);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.materialLabel11);
            this.Controls.Add(this.VendorCode);
            this.Controls.Add(this.materialLabel10);
            this.Controls.Add(this.VendorName);
            this.Controls.Add(this.AddVend);
            this.Controls.Add(this.VendorList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddVendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddVendor";
            this.Load += new System.EventHandler(this.AddVendor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VendorList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddVend;
        private System.Windows.Forms.TextBox VendorName;
        private System.Windows.Forms.TextBox VendorCode;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView VendorList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendors;
    }
}