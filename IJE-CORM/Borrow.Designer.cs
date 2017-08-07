namespace IJE
{
    partial class Borrow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemList = new System.Windows.Forms.DataGridView();
            this.colAssetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.RoomNumber = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BorrowIT = new System.Windows.Forms.Button();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.Searchbox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.ItemList)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemList
            // 
            this.ItemList.AllowUserToAddRows = false;
            this.ItemList.AllowUserToDeleteRows = false;
            this.ItemList.AllowUserToResizeColumns = false;
            this.ItemList.AllowUserToResizeRows = false;
            this.ItemList.ColumnHeadersHeight = 40;
            this.ItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssetCode,
            this.ItemName,
            this.itemCategory,
            this.Model});
            this.ItemList.Location = new System.Drawing.Point(0, 71);
            this.ItemList.MultiSelect = false;
            this.ItemList.Name = "ItemList";
            this.ItemList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemList.Size = new System.Drawing.Size(974, 234);
            this.ItemList.TabIndex = 8;
            this.ItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemList_CellContentClick);
            // 
            // colAssetCode
            // 
            this.colAssetCode.HeaderText = "Asset Code";
            this.colAssetCode.Name = "colAssetCode";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // itemCategory
            // 
            this.itemCategory.HeaderText = "Category";
            this.itemCategory.Name = "itemCategory";
            this.itemCategory.ReadOnly = true;
            this.itemCategory.Width = 200;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(476, 333);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(63, 19);
            this.materialLabel5.TabIndex = 15;
            this.materialLabel5.Text = "Reason:";
            this.materialLabel5.Click += new System.EventHandler(this.materialLabel5_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(196, 333);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(110, 19);
            this.materialLabel4.TabIndex = 14;
            this.materialLabel4.Text = "Room Number:";
            this.materialLabel4.Click += new System.EventHandler(this.materialLabel4_Click);
            // 
            // RoomNumber
            // 
            this.RoomNumber.Depth = 0;
            this.RoomNumber.Hint = "";
            this.RoomNumber.Location = new System.Drawing.Point(312, 333);
            this.RoomNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.PasswordChar = '\0';
            this.RoomNumber.SelectedText = "";
            this.RoomNumber.SelectionLength = 0;
            this.RoomNumber.SelectionStart = 0;
            this.RoomNumber.Size = new System.Drawing.Size(78, 23);
            this.RoomNumber.TabIndex = 10;
            this.RoomNumber.UseSystemPasswordChar = false;
            this.RoomNumber.Click += new System.EventHandler(this.RoomNumber_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(558, 333);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 91);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BorrowIT
            // 
            this.BorrowIT.BackgroundImage = global::IJE.Properties.Resources.borrowbutton;
            this.BorrowIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorrowIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowIT.Location = new System.Drawing.Point(426, 449);
            this.BorrowIT.Name = "BorrowIT";
            this.BorrowIT.Size = new System.Drawing.Size(108, 45);
            this.BorrowIT.TabIndex = 13;
            this.BorrowIT.UseVisualStyleBackColor = true;
            this.BorrowIT.Click += new System.EventHandler(this.BorrowIT_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.White;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(44, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(116, 19);
            this.materialLabel6.TabIndex = 47;
            this.materialLabel6.Text = "Advance Search";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.materialFlatButton1);
            this.panel2.Controls.Add(this.Searchbox);
            this.panel2.Location = new System.Drawing.Point(8, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 55);
            this.panel2.TabIndex = 46;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.BackColor = System.Drawing.Color.White;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Location = new System.Drawing.Point(264, 9);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(54, 36);
            this.materialFlatButton1.TabIndex = 46;
            this.materialFlatButton1.Text = "Clear";
            this.materialFlatButton1.UseVisualStyleBackColor = false;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // Searchbox
            // 
            this.Searchbox.Depth = 0;
            this.Searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbox.Hint = "                Item name";
            this.Searchbox.Location = new System.Drawing.Point(36, 16);
            this.Searchbox.MouseState = MaterialSkin.MouseState.HOVER;
            this.Searchbox.Name = "Searchbox";
            this.Searchbox.PasswordChar = '\0';
            this.Searchbox.SelectedText = "";
            this.Searchbox.SelectionLength = 0;
            this.Searchbox.SelectionStart = 0;
            this.Searchbox.Size = new System.Drawing.Size(197, 23);
            this.Searchbox.TabIndex = 8;
            this.Searchbox.UseSystemPasswordChar = false;
            this.Searchbox.TextChanged += new System.EventHandler(this.Searchbox_TextChanged);
            // 
            // Borrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.RoomNumber);
            this.Controls.Add(this.BorrowIT);
            this.Controls.Add(this.ItemList);
            this.Name = "Borrow";
            this.Size = new System.Drawing.Size(974, 501);
            this.Load += new System.EventHandler(this.Borrow_Load);
            this.VisibleChanged += new System.EventHandler(this.Borrow_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ItemList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemList;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField RoomNumber;
        private System.Windows.Forms.Button BorrowIT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialSingleLineTextField Searchbox;
    }
}
