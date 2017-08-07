namespace IJE
{
    partial class Inventory
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
            this.components = new System.ComponentModel.Container();
            this.ItemNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.Itemcodelabel = new MaterialSkin.Controls.MaterialLabel();
            this.ItemName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ItemCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.datepurchased = new System.Windows.Forms.DateTimePicker();
            this.Vendorbox = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new MaterialSkin.Controls.MaterialLabel();
            this.Datepur = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Quantity = new System.Windows.Forms.NumericUpDown();
            this.ModelBox = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Categ = new MaterialSkin.Controls.MaterialLabel();
            this.Category = new MetroFramework.Controls.MetroComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CancelAdd = new System.Windows.Forms.Button();
            this.ItemBox = new MetroFramework.Controls.MetroComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_itemname = new System.Windows.Forms.Label();
            this.Btn_AddModel = new MaterialSkin.Controls.MaterialFlatButton();
            this.Btn_AddVendor = new MaterialSkin.Controls.MaterialFlatButton();
            this.AddIT = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Quantity)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Depth = 0;
            this.ItemNameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.ItemNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ItemNameLabel.Location = new System.Drawing.Point(15, 104);
            this.ItemNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(87, 19);
            this.ItemNameLabel.TabIndex = 28;
            this.ItemNameLabel.Text = "Item Name:";
            // 
            // Itemcodelabel
            // 
            this.Itemcodelabel.AutoSize = true;
            this.Itemcodelabel.Depth = 0;
            this.Itemcodelabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.Itemcodelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Itemcodelabel.Location = new System.Drawing.Point(15, 49);
            this.Itemcodelabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.Itemcodelabel.Name = "Itemcodelabel";
            this.Itemcodelabel.Size = new System.Drawing.Size(82, 19);
            this.Itemcodelabel.TabIndex = 27;
            this.Itemcodelabel.Text = "Item Code:";
            // 
            // ItemName
            // 
            this.ItemName.Depth = 0;
            this.ItemName.Hint = "";
            this.ItemName.Location = new System.Drawing.Point(132, 105);
            this.ItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemName.Name = "ItemName";
            this.ItemName.PasswordChar = '\0';
            this.ItemName.SelectedText = "";
            this.ItemName.SelectionLength = 0;
            this.ItemName.SelectionStart = 0;
            this.ItemName.Size = new System.Drawing.Size(173, 23);
            this.ItemName.TabIndex = 25;
            this.ItemName.UseSystemPasswordChar = false;
            this.ItemName.Click += new System.EventHandler(this.ItemName_Click);
            // 
            // ItemCode
            // 
            this.ItemCode.Depth = 0;
            this.ItemCode.Enabled = false;
            this.ItemCode.Hint = "";
            this.ItemCode.Location = new System.Drawing.Point(132, 50);
            this.ItemCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.PasswordChar = '\0';
            this.ItemCode.SelectedText = "";
            this.ItemCode.SelectionLength = 0;
            this.ItemCode.SelectionStart = 0;
            this.ItemCode.Size = new System.Drawing.Size(173, 23);
            this.ItemCode.TabIndex = 24;
            this.ItemCode.UseSystemPasswordChar = false;
            // 
            // datepurchased
            // 
            this.datepurchased.CustomFormat = "MMMM dd,  yyyy";
            this.datepurchased.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepurchased.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepurchased.Location = new System.Drawing.Point(146, 231);
            this.datepurchased.MaxDate = new System.DateTime(2110, 1, 31, 0, 0, 0, 0);
            this.datepurchased.Name = "datepurchased";
            this.datepurchased.Size = new System.Drawing.Size(173, 24);
            this.datepurchased.TabIndex = 36;
            this.datepurchased.Value = new System.DateTime(2016, 9, 12, 0, 0, 0, 0);
            // 
            // Vendorbox
            // 
            this.Vendorbox.DropDownHeight = 90;
            this.Vendorbox.FormattingEnabled = true;
            this.Vendorbox.IntegralHeight = false;
            this.Vendorbox.ItemHeight = 23;
            this.Vendorbox.Location = new System.Drawing.Point(99, 72);
            this.Vendorbox.Name = "Vendorbox";
            this.Vendorbox.Size = new System.Drawing.Size(173, 29);
            this.Vendorbox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Depth = 0;
            this.label5.Font = new System.Drawing.Font("Roboto", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(13, 78);
            this.label5.MouseState = MaterialSkin.MouseState.HOVER;
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "Vendor:";
            // 
            // Datepur
            // 
            this.Datepur.AutoSize = true;
            this.Datepur.Depth = 0;
            this.Datepur.Font = new System.Drawing.Font("Roboto", 11F);
            this.Datepur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Datepur.Location = new System.Drawing.Point(13, 234);
            this.Datepur.MouseState = MaterialSkin.MouseState.HOVER;
            this.Datepur.Name = "Datepur";
            this.Datepur.Size = new System.Drawing.Size(117, 19);
            this.Datepur.TabIndex = 38;
            this.Datepur.Text = "Date purchased:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(13, 182);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 19);
            this.materialLabel1.TabIndex = 31;
            this.materialLabel1.Text = "Quantity:";
            // 
            // Quantity
            // 
            this.Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Location = new System.Drawing.Point(101, 182);
            this.Quantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(63, 22);
            this.Quantity.TabIndex = 32;
            // 
            // ModelBox
            // 
            this.ModelBox.DropDownHeight = 90;
            this.ModelBox.FormattingEnabled = true;
            this.ModelBox.IntegralHeight = false;
            this.ModelBox.ItemHeight = 23;
            this.ModelBox.Location = new System.Drawing.Point(99, 125);
            this.ModelBox.Name = "ModelBox";
            this.ModelBox.Size = new System.Drawing.Size(173, 29);
            this.ModelBox.TabIndex = 40;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(13, 128);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(55, 19);
            this.materialLabel2.TabIndex = 41;
            this.materialLabel2.Text = "Model:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Categ);
            this.panel1.Controls.Add(this.Category);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.Itemcodelabel);
            this.panel1.Controls.Add(this.ItemCode);
            this.panel1.Controls.Add(this.CancelAdd);
            this.panel1.Controls.Add(this.ItemNameLabel);
            this.panel1.Controls.Add(this.ItemName);
            this.panel1.Controls.Add(this.ItemBox);
            this.panel1.Location = new System.Drawing.Point(24, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 328);
            this.panel1.TabIndex = 42;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // Categ
            // 
            this.Categ.AutoSize = true;
            this.Categ.Depth = 0;
            this.Categ.Font = new System.Drawing.Font("Roboto", 11F);
            this.Categ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Categ.Location = new System.Drawing.Point(15, 166);
            this.Categ.MouseState = MaterialSkin.MouseState.HOVER;
            this.Categ.Name = "Categ";
            this.Categ.Size = new System.Drawing.Size(73, 19);
            this.Categ.TabIndex = 46;
            this.Categ.Text = "Category:";
            this.Categ.Click += new System.EventHandler(this.Categ_Click);
            // 
            // Category
            // 
            this.Category.DropDownHeight = 70;
            this.Category.FormattingEnabled = true;
            this.Category.IntegralHeight = false;
            this.Category.ItemHeight = 23;
            this.Category.Location = new System.Drawing.Point(133, 163);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(173, 29);
            this.Category.Style = MetroFramework.MetroColorStyle.Blue;
            this.Category.TabIndex = 45;
            this.Category.SelectedIndexChanged += new System.EventHandler(this.Category_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IJE.Properties.Resources.nextbutt;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(91, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 35);
            this.button1.TabIndex = 44;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelAdd
            // 
            this.CancelAdd.BackgroundImage = global::IJE.Properties.Resources.CancelButton2;
            this.CancelAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelAdd.Location = new System.Drawing.Point(162, 278);
            this.CancelAdd.Name = "CancelAdd";
            this.CancelAdd.Size = new System.Drawing.Size(69, 35);
            this.CancelAdd.TabIndex = 33;
            this.CancelAdd.UseVisualStyleBackColor = true;
            this.CancelAdd.Click += new System.EventHandler(this.CancelAdd_Click);
            // 
            // ItemBox
            // 
            this.ItemBox.DropDownHeight = 70;
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.IntegralHeight = false;
            this.ItemBox.ItemHeight = 23;
            this.ItemBox.Location = new System.Drawing.Point(132, 101);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(173, 29);
            this.ItemBox.TabIndex = 47;
            this.ItemBox.SelectedIndexChanged += new System.EventHandler(this.ItemBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_itemname);
            this.panel2.Controls.Add(this.Btn_AddModel);
            this.panel2.Controls.Add(this.Btn_AddVendor);
            this.panel2.Controls.Add(this.ModelBox);
            this.panel2.Controls.Add(this.AddIT);
            this.panel2.Controls.Add(this.materialLabel1);
            this.panel2.Controls.Add(this.materialLabel2);
            this.panel2.Controls.Add(this.Quantity);
            this.panel2.Controls.Add(this.datepurchased);
            this.panel2.Controls.Add(this.Datepur);
            this.panel2.Controls.Add(this.Vendorbox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(23, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 328);
            this.panel2.TabIndex = 43;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lbl_itemname
            // 
            this.lbl_itemname.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_itemname.ForeColor = System.Drawing.Color.Black;
            this.lbl_itemname.Location = new System.Drawing.Point(63, 21);
            this.lbl_itemname.Name = "lbl_itemname";
            this.lbl_itemname.Size = new System.Drawing.Size(196, 21);
            this.lbl_itemname.TabIndex = 89;
            this.lbl_itemname.Text = "Item Name";
            this.lbl_itemname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_AddModel
            // 
            this.Btn_AddModel.AutoSize = true;
            this.Btn_AddModel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_AddModel.Depth = 0;
            this.Btn_AddModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AddModel.Location = new System.Drawing.Point(279, 124);
            this.Btn_AddModel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Btn_AddModel.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_AddModel.Name = "Btn_AddModel";
            this.Btn_AddModel.Primary = false;
            this.Btn_AddModel.Size = new System.Drawing.Size(39, 36);
            this.Btn_AddModel.TabIndex = 44;
            this.Btn_AddModel.Text = "ADD";
            this.Btn_AddModel.UseVisualStyleBackColor = true;
            this.Btn_AddModel.Click += new System.EventHandler(this.Btn_AddModel_Click);
            // 
            // Btn_AddVendor
            // 
            this.Btn_AddVendor.AutoSize = true;
            this.Btn_AddVendor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_AddVendor.Depth = 0;
            this.Btn_AddVendor.Location = new System.Drawing.Point(279, 70);
            this.Btn_AddVendor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Btn_AddVendor.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_AddVendor.Name = "Btn_AddVendor";
            this.Btn_AddVendor.Primary = false;
            this.Btn_AddVendor.Size = new System.Drawing.Size(39, 36);
            this.Btn_AddVendor.TabIndex = 43;
            this.Btn_AddVendor.Text = "ADD";
            this.Btn_AddVendor.UseVisualStyleBackColor = true;
            this.Btn_AddVendor.Click += new System.EventHandler(this.Btn_AddVendor_Click);
            // 
            // AddIT
            // 
            this.AddIT.BackgroundImage = global::IJE.Properties.Resources.addbutton;
            this.AddIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddIT.Location = new System.Drawing.Point(115, 290);
            this.AddIT.Name = "AddIT";
            this.AddIT.Size = new System.Drawing.Size(90, 35);
            this.AddIT.TabIndex = 1;
            this.AddIT.UseVisualStyleBackColor = true;
            this.AddIT.Click += new System.EventHandler(this.AddIT_Click);
            // 
            // stop
            // 
            this.stop.Tick += new System.EventHandler(this.stop_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::IJE.Properties.Resources.AddItemPanel;
            this.pictureBox1.Location = new System.Drawing.Point(10, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 371);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(374, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Quantity)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddIT;
        private MaterialSkin.Controls.MaterialLabel ItemNameLabel;
        private MaterialSkin.Controls.MaterialLabel Itemcodelabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField ItemName;
        private MaterialSkin.Controls.MaterialSingleLineTextField ItemCode;
        private System.Windows.Forms.Button CancelAdd;
        private System.Windows.Forms.DateTimePicker datepurchased;
        private MetroFramework.Controls.MetroComboBox Vendorbox;
        private MaterialSkin.Controls.MaterialLabel label5;
        private MaterialSkin.Controls.MaterialLabel Datepur;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.NumericUpDown Quantity;
        private MetroFramework.Controls.MetroComboBox ModelBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private MaterialSkin.Controls.MaterialLabel Categ;
        private MetroFramework.Controls.MetroComboBox Category;
        private MetroFramework.Controls.MetroComboBox ItemBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer stop;
        private MaterialSkin.Controls.MaterialFlatButton Btn_AddModel;
        private MaterialSkin.Controls.MaterialFlatButton Btn_AddVendor;
        private System.Windows.Forms.Label lbl_itemname;
    }
}