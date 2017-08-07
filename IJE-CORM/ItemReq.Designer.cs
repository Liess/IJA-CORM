namespace IJE
{
    partial class ItemReq
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
            this.Categ = new MaterialSkin.Controls.MaterialLabel();
            this.ItemNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.Itemcodelabel = new MaterialSkin.Controls.MaterialLabel();
            this.ItemName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ItemCode = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Category = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Categ
            // 
            this.Categ.AutoSize = true;
            this.Categ.Depth = 0;
            this.Categ.Font = new System.Drawing.Font("Roboto", 11F);
            this.Categ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Categ.Location = new System.Drawing.Point(6, 99);
            this.Categ.MouseState = MaterialSkin.MouseState.HOVER;
            this.Categ.Name = "Categ";
            this.Categ.Size = new System.Drawing.Size(73, 19);
            this.Categ.TabIndex = 23;
            this.Categ.Text = "Category:";
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Depth = 0;
            this.ItemNameLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.ItemNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ItemNameLabel.Location = new System.Drawing.Point(6, 69);
            this.ItemNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(87, 19);
            this.ItemNameLabel.TabIndex = 22;
            this.ItemNameLabel.Text = "Item Name:";
            // 
            // Itemcodelabel
            // 
            this.Itemcodelabel.AutoSize = true;
            this.Itemcodelabel.Depth = 0;
            this.Itemcodelabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.Itemcodelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Itemcodelabel.Location = new System.Drawing.Point(6, 39);
            this.Itemcodelabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.Itemcodelabel.Name = "Itemcodelabel";
            this.Itemcodelabel.Size = new System.Drawing.Size(82, 19);
            this.Itemcodelabel.TabIndex = 21;
            this.Itemcodelabel.Text = "Item Code:";
            // 
            // ItemName
            // 
            this.ItemName.Depth = 0;
            this.ItemName.Hint = "";
            this.ItemName.Location = new System.Drawing.Point(136, 69);
            this.ItemName.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemName.Name = "ItemName";
            this.ItemName.PasswordChar = '\0';
            this.ItemName.SelectedText = "";
            this.ItemName.SelectionLength = 0;
            this.ItemName.SelectionStart = 0;
            this.ItemName.Size = new System.Drawing.Size(163, 23);
            this.ItemName.TabIndex = 19;
            this.ItemName.UseSystemPasswordChar = false;
            // 
            // ItemCode
            // 
            this.ItemCode.Depth = 0;
            this.ItemCode.Enabled = false;
            this.ItemCode.Hint = "";
            this.ItemCode.Location = new System.Drawing.Point(136, 40);
            this.ItemCode.MouseState = MaterialSkin.MouseState.HOVER;
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.PasswordChar = '\0';
            this.ItemCode.SelectedText = "";
            this.ItemCode.SelectionLength = 0;
            this.ItemCode.SelectionStart = 0;
            this.ItemCode.Size = new System.Drawing.Size(163, 23);
            this.ItemCode.TabIndex = 18;
            this.ItemCode.UseSystemPasswordChar = false;
            // 
            // Category
            // 
            this.Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Category.FormattingEnabled = true;
            this.Category.Location = new System.Drawing.Point(136, 97);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(163, 21);
            this.Category.TabIndex = 20;
            // 
            // ItemReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Categ);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.Itemcodelabel);
            this.Controls.Add(this.ItemName);
            this.Controls.Add(this.ItemCode);
            this.Name = "ItemReq";
            this.Size = new System.Drawing.Size(307, 173);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel Categ;
        private MaterialSkin.Controls.MaterialLabel ItemNameLabel;
        private MaterialSkin.Controls.MaterialLabel Itemcodelabel;
        private MaterialSkin.Controls.MaterialSingleLineTextField ItemName;
        private MaterialSkin.Controls.MaterialSingleLineTextField ItemCode;
        private System.Windows.Forms.ComboBox Category;
    }
}
