namespace IJE
{
    partial class Rent
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
            this.colBorHCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorDCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBorrowed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.TextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.Others = new System.Windows.Forms.RadioButton();
            this.Damage = new System.Windows.Forms.RadioButton();
            this.Good = new System.Windows.Forms.RadioButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.ReturnIT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemList)).BeginInit();
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
            this.colBorHCode,
            this.colBorDCode,
            this.ItemName,
            this.DateBorrowed,
            this.DateDue,
            this.colFine});
            this.ItemList.Location = new System.Drawing.Point(2, 20);
            this.ItemList.Name = "ItemList";
            this.ItemList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ItemList.Size = new System.Drawing.Size(971, 208);
            this.ItemList.TabIndex = 9;
            this.ItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemList_CellContentClick);
            // 
            // colAssetCode
            // 
            this.colAssetCode.HeaderText = "Asset Code";
            this.colAssetCode.Name = "colAssetCode";
            // 
            // colBorHCode
            // 
            this.colBorHCode.HeaderText = "Borrower Header Code";
            this.colBorHCode.Name = "colBorHCode";
            // 
            // colBorDCode
            // 
            this.colBorDCode.HeaderText = "Borrow Detail Code";
            this.colBorDCode.Name = "colBorDCode";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // DateBorrowed
            // 
            this.DateBorrowed.HeaderText = "Date borrowed";
            this.DateBorrowed.Name = "DateBorrowed";
            // 
            // DateDue
            // 
            this.DateDue.HeaderText = "Expected date of return";
            this.DateDue.Name = "DateDue";
            // 
            // colFine
            // 
            this.colFine.HeaderText = "Fine";
            this.colFine.Name = "colFine";
            // 
            // Notes
            // 
            this.Notes.Location = new System.Drawing.Point(124, 272);
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(379, 136);
            this.Notes.TabIndex = 12;
            this.Notes.TextChanged += new System.EventHandler(this.Notes_TextChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(51, 268);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(54, 19);
            this.materialLabel3.TabIndex = 11;
            this.materialLabel3.Text = "Notes:";
            // 
            // Others
            // 
            this.Others.AutoSize = true;
            this.Others.Location = new System.Drawing.Point(720, 366);
            this.Others.Name = "Others";
            this.Others.Size = new System.Drawing.Size(115, 17);
            this.Others.TabIndex = 18;
            this.Others.TabStop = true;
            this.Others.Text = "Others (See Notes)";
            this.Others.UseVisualStyleBackColor = true;
            // 
            // Damage
            // 
            this.Damage.AutoSize = true;
            this.Damage.Location = new System.Drawing.Point(720, 333);
            this.Damage.Name = "Damage";
            this.Damage.Size = new System.Drawing.Size(65, 17);
            this.Damage.TabIndex = 17;
            this.Damage.TabStop = true;
            this.Damage.Text = "Damage";
            this.Damage.UseVisualStyleBackColor = true;
            // 
            // Good
            // 
            this.Good.AutoSize = true;
            this.Good.Location = new System.Drawing.Point(720, 300);
            this.Good.Name = "Good";
            this.Good.Size = new System.Drawing.Size(97, 17);
            this.Good.TabIndex = 16;
            this.Good.TabStop = true;
            this.Good.Text = "Good condition";
            this.Good.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(636, 268);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(56, 19);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Status:";
            // 
            // ReturnIT
            // 
            this.ReturnIT.BackColor = System.Drawing.Color.White;
            this.ReturnIT.BackgroundImage = global::IJE.Properties.Resources.returnbutton;
            this.ReturnIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReturnIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnIT.Location = new System.Drawing.Point(455, 437);
            this.ReturnIT.Name = "ReturnIT";
            this.ReturnIT.Size = new System.Drawing.Size(103, 45);
            this.ReturnIT.TabIndex = 10;
            this.ReturnIT.UseVisualStyleBackColor = false;
            this.ReturnIT.Click += new System.EventHandler(this.ReturnIT_Click);
            // 
            // Rent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.Others);
            this.Controls.Add(this.Damage);
            this.Controls.Add(this.Good);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.ReturnIT);
            this.Controls.Add(this.ItemList);
            this.Name = "Rent";
            this.Size = new System.Drawing.Size(974, 501);
            this.Load += new System.EventHandler(this.Rent_Load);
            this.VisibleChanged += new System.EventHandler(this.Rent_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.ItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemList;
        private System.Windows.Forms.TextBox Notes;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Button ReturnIT;
        private System.Windows.Forms.RadioButton Others;
        private System.Windows.Forms.RadioButton Damage;
        private System.Windows.Forms.RadioButton Good;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorHCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorDCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBorrowed;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFine;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}
