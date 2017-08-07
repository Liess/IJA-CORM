namespace IJE
{
    partial class ItemInfo
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ItemInfor = new System.Windows.Forms.Panel();
            this.ItemStatus = new System.Windows.Forms.ComboBox();
            this.Notes = new System.Windows.Forms.TextBox();
            this.ModelBox = new System.Windows.Forms.ComboBox();
            this.AssetCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.DatePurchased = new System.Windows.Forms.DateTimePicker();
            this.ItemName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.VendorBox = new System.Windows.Forms.ComboBox();
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.CancelEdit = new System.Windows.Forms.Button();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.CloseInfo = new System.Windows.Forms.Button();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.EditIT = new System.Windows.Forms.Button();
            this.UpdateIT = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ItemInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BackgroundImage = global::IJE.Properties.Resources.itemdetailpanel;
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.ItemInfor);
            this.panel6.Controls.Add(this.materialLabel1);
            this.panel6.Controls.Add(this.CancelEdit);
            this.panel6.Controls.Add(this.materialLabel14);
            this.panel6.Controls.Add(this.CloseInfo);
            this.panel6.Controls.Add(this.materialLabel13);
            this.panel6.Controls.Add(this.materialLabel7);
            this.panel6.Controls.Add(this.materialLabel9);
            this.panel6.Controls.Add(this.materialLabel11);
            this.panel6.Controls.Add(this.materialLabel8);
            this.panel6.Controls.Add(this.materialLabel12);
            this.panel6.Controls.Add(this.UpdateIT);
            this.panel6.Controls.Add(this.EditIT);
            this.panel6.Location = new System.Drawing.Point(1, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(491, 651);
            this.panel6.TabIndex = 39;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::IJE.Properties.Resources.ItemDetails3;
            this.pictureBox1.Location = new System.Drawing.Point(74, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 50);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // ItemInfor
            // 
            this.ItemInfor.BackColor = System.Drawing.Color.White;
            this.ItemInfor.Controls.Add(this.ItemStatus);
            this.ItemInfor.Controls.Add(this.Notes);
            this.ItemInfor.Controls.Add(this.ModelBox);
            this.ItemInfor.Controls.Add(this.AssetCode);
            this.ItemInfor.Controls.Add(this.DatePurchased);
            this.ItemInfor.Controls.Add(this.ItemName);
            this.ItemInfor.Controls.Add(this.VendorBox);
            this.ItemInfor.Controls.Add(this.CategoryBox);
            this.ItemInfor.Enabled = false;
            this.ItemInfor.Location = new System.Drawing.Point(213, 92);
            this.ItemInfor.Name = "ItemInfor";
            this.ItemInfor.Size = new System.Drawing.Size(267, 449);
            this.ItemInfor.TabIndex = 56;
            // 
            // ItemStatus
            // 
            this.ItemStatus.BackColor = System.Drawing.Color.White;
            this.ItemStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemStatus.FormattingEnabled = true;
            this.ItemStatus.Location = new System.Drawing.Point(12, 279);
            this.ItemStatus.Name = "ItemStatus";
            this.ItemStatus.Size = new System.Drawing.Size(173, 24);
            this.ItemStatus.TabIndex = 61;
            // 
            // Notes
            // 
            this.Notes.Location = new System.Drawing.Point(10, 323);
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(251, 123);
            this.Notes.TabIndex = 56;
            // 
            // ModelBox
            // 
            this.ModelBox.BackColor = System.Drawing.Color.White;
            this.ModelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelBox.FormattingEnabled = true;
            this.ModelBox.Location = new System.Drawing.Point(12, 190);
            this.ModelBox.Name = "ModelBox";
            this.ModelBox.Size = new System.Drawing.Size(173, 24);
            this.ModelBox.TabIndex = 54;
            // 
            // AssetCode
            // 
            this.AssetCode.Depth = 0;
            this.AssetCode.Enabled = false;
            this.AssetCode.Hint = "";
            this.AssetCode.Location = new System.Drawing.Point(12, 27);
            this.AssetCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.AssetCode.Name = "AssetCode";
            this.AssetCode.PasswordChar = '\0';
            this.AssetCode.SelectedText = "";
            this.AssetCode.SelectionLength = 0;
            this.AssetCode.SelectionStart = 0;
            this.AssetCode.Size = new System.Drawing.Size(173, 23);
            this.AssetCode.TabIndex = 42;
            this.AssetCode.UseSystemPasswordChar = false;
            this.AssetCode.Click += new System.EventHandler(this.AssetCode_Click_1);
            // 
            // DatePurchased
            // 
            this.DatePurchased.CustomFormat = "MMMM dd,  yyyy";
            this.DatePurchased.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatePurchased.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePurchased.Location = new System.Drawing.Point(12, 230);
            this.DatePurchased.Name = "DatePurchased";
            this.DatePurchased.Size = new System.Drawing.Size(173, 24);
            this.DatePurchased.TabIndex = 50;
            // 
            // ItemName
            // 
            this.ItemName.Depth = 0;
            this.ItemName.Hint = "";
            this.ItemName.Location = new System.Drawing.Point(12, 64);
            this.ItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemName.Name = "ItemName";
            this.ItemName.PasswordChar = '\0';
            this.ItemName.SelectedText = "";
            this.ItemName.SelectionLength = 0;
            this.ItemName.SelectionStart = 0;
            this.ItemName.Size = new System.Drawing.Size(173, 23);
            this.ItemName.TabIndex = 43;
            this.ItemName.UseSystemPasswordChar = false;
            // 
            // VendorBox
            // 
            this.VendorBox.BackColor = System.Drawing.Color.White;
            this.VendorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VendorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VendorBox.FormattingEnabled = true;
            this.VendorBox.Location = new System.Drawing.Point(12, 147);
            this.VendorBox.Name = "VendorBox";
            this.VendorBox.Size = new System.Drawing.Size(173, 24);
            this.VendorBox.TabIndex = 51;
            // 
            // CategoryBox
            // 
            this.CategoryBox.BackColor = System.Drawing.Color.White;
            this.CategoryBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Location = new System.Drawing.Point(12, 105);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(173, 24);
            this.CategoryBox.TabIndex = 44;
            this.CategoryBox.SelectedIndexChanged += new System.EventHandler(this.CategoryBox_SelectedIndexChanged_1);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(44, 372);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(52, 19);
            this.materialLabel1.TabIndex = 60;
            this.materialLabel1.Text = "Status";
            // 
            // CancelEdit
            // 
            this.CancelEdit.BackgroundImage = global::IJE.Properties.Resources.cancelbutt;
            this.CancelEdit.Location = new System.Drawing.Point(104, 606);
            this.CancelEdit.Name = "CancelEdit";
            this.CancelEdit.Size = new System.Drawing.Size(73, 33);
            this.CancelEdit.TabIndex = 57;
            this.CancelEdit.TabStop = false;
            this.CancelEdit.UseVisualStyleBackColor = true;
            this.CancelEdit.Visible = false;
            this.CancelEdit.Click += new System.EventHandler(this.CancelEdit_Click);
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(44, 414);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(54, 19);
            this.materialLabel14.TabIndex = 57;
            this.materialLabel14.Text = "Notes:";
            // 
            // CloseInfo
            // 
            this.CloseInfo.Image = global::IJE.Properties.Resources.closebutt;
            this.CloseInfo.Location = new System.Drawing.Point(400, 606);
            this.CloseInfo.Name = "CloseInfo";
            this.CloseInfo.Size = new System.Drawing.Size(75, 33);
            this.CloseInfo.TabIndex = 0;
            this.CloseInfo.UseVisualStyleBackColor = true;
            this.CloseInfo.Click += new System.EventHandler(this.CloseInfo_Click);
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(44, 120);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(91, 19);
            this.materialLabel13.TabIndex = 45;
            this.materialLabel13.Text = "Asset Code:";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(44, 283);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(55, 19);
            this.materialLabel7.TabIndex = 55;
            this.materialLabel7.Text = "Model:";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(44, 327);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(117, 19);
            this.materialLabel9.TabIndex = 52;
            this.materialLabel9.Text = "Date purchased:";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(44, 198);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(73, 19);
            this.materialLabel11.TabIndex = 47;
            this.materialLabel11.Text = "Category:";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(44, 240);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(61, 19);
            this.materialLabel8.TabIndex = 53;
            this.materialLabel8.Text = "Vendor:";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(44, 160);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(87, 19);
            this.materialLabel12.TabIndex = 46;
            this.materialLabel12.Text = "Item Name:";
            // 
            // EditIT
            // 
            this.EditIT.BackgroundImage = global::IJE.Properties.Resources.editbutt;
            this.EditIT.Location = new System.Drawing.Point(25, 606);
            this.EditIT.Name = "EditIT";
            this.EditIT.Size = new System.Drawing.Size(73, 33);
            this.EditIT.TabIndex = 6;
            this.EditIT.UseVisualStyleBackColor = true;
            this.EditIT.Click += new System.EventHandler(this.EditIT_Click);
            // 
            // UpdateIT
            // 
            this.UpdateIT.BackgroundImage = global::IJE.Properties.Resources.updatebutt;
            this.UpdateIT.Location = new System.Drawing.Point(25, 606);
            this.UpdateIT.Name = "UpdateIT";
            this.UpdateIT.Size = new System.Drawing.Size(73, 33);
            this.UpdateIT.TabIndex = 6;
            this.UpdateIT.UseVisualStyleBackColor = true;
            this.UpdateIT.Visible = false;
            this.UpdateIT.Click += new System.EventHandler(this.UpdateIT_Click);
            // 
            // ItemInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 651);
            this.Controls.Add(this.panel6);
            this.Name = "ItemInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ItemInfo";
            this.Load += new System.EventHandler(this.ItemInfo_Load_1);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ItemInfor.ResumeLayout(false);
            this.ItemInfor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button CancelEdit;
        private System.Windows.Forms.Panel ItemInfor;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private System.Windows.Forms.TextBox Notes;
        private System.Windows.Forms.ComboBox ModelBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialSingleLineTextField AssetCode;
        private System.Windows.Forms.DateTimePicker DatePurchased;
        private MaterialSkin.Controls.MaterialSingleLineTextField ItemName;
        private System.Windows.Forms.ComboBox VendorBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.Button CloseInfo;
        private System.Windows.Forms.Button UpdateIT;
        private System.Windows.Forms.Button EditIT;
        private System.Windows.Forms.ComboBox ItemStatus;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}