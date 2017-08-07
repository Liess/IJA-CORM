namespace IJE
{
    partial class addPosition
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
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tbxPosiName = new System.Windows.Forms.TextBox();
            this.tbxPosiCode = new System.Windows.Forms.TextBox();
            this.AddPosi = new System.Windows.Forms.Button();
            this.cmbDepName = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PositionList = new System.Windows.Forms.DataGridView();
            this.colPosiCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PositionList)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(16, 264);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(113, 19);
            this.materialLabel12.TabIndex = 28;
            this.materialLabel12.Text = "Position Name:";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(16, 204);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(108, 19);
            this.materialLabel9.TabIndex = 27;
            this.materialLabel9.Text = "Position Code:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(16, 144);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(91, 19);
            this.materialLabel2.TabIndex = 26;
            this.materialLabel2.Text = "Department:";
            // 
            // tbxPosiName
            // 
            this.tbxPosiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPosiName.Location = new System.Drawing.Point(146, 262);
            this.tbxPosiName.Name = "tbxPosiName";
            this.tbxPosiName.Size = new System.Drawing.Size(121, 22);
            this.tbxPosiName.TabIndex = 24;
            // 
            // tbxPosiCode
            // 
            this.tbxPosiCode.Enabled = false;
            this.tbxPosiCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPosiCode.Location = new System.Drawing.Point(146, 202);
            this.tbxPosiCode.Name = "tbxPosiCode";
            this.tbxPosiCode.Size = new System.Drawing.Size(121, 22);
            this.tbxPosiCode.TabIndex = 23;
            // 
            // AddPosi
            // 
            this.AddPosi.BackgroundImage = global::IJE.Properties.Resources.submitbutt;
            this.AddPosi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddPosi.Enabled = false;
            this.AddPosi.Location = new System.Drawing.Point(67, 387);
            this.AddPosi.Name = "AddPosi";
            this.AddPosi.Size = new System.Drawing.Size(66, 35);
            this.AddPosi.TabIndex = 25;
            this.AddPosi.Text = "v";
            this.AddPosi.UseVisualStyleBackColor = true;
            this.AddPosi.Click += new System.EventHandler(this.AddPosi_Click);
            // 
            // cmbDepName
            // 
            this.cmbDepName.DropDownHeight = 70;
            this.cmbDepName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepName.FormattingEnabled = true;
            this.cmbDepName.IntegralHeight = false;
            this.cmbDepName.Location = new System.Drawing.Point(146, 142);
            this.cmbDepName.Name = "cmbDepName";
            this.cmbDepName.Size = new System.Drawing.Size(121, 24);
            this.cmbDepName.TabIndex = 22;
            this.cmbDepName.SelectedIndexChanged += new System.EventHandler(this.cmbDepName_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::IJE.Properties.Resources.cancelbuttons;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(139, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 35);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PositionList
            // 
            this.PositionList.AllowUserToAddRows = false;
            this.PositionList.AllowUserToDeleteRows = false;
            this.PositionList.AllowUserToResizeColumns = false;
            this.PositionList.AllowUserToResizeRows = false;
            this.PositionList.ColumnHeadersHeight = 35;
            this.PositionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PositionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPosiCode,
            this.colPosiName});
            this.PositionList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PositionList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.PositionList.Location = new System.Drawing.Point(-6, 25);
            this.PositionList.Name = "PositionList";
            this.PositionList.RowHeadersVisible = false;
            this.PositionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PositionList.Size = new System.Drawing.Size(544, 382);
            this.PositionList.TabIndex = 30;
            this.PositionList.Visible = false;
            this.PositionList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionList_CellContentClick);
            // 
            // colPosiCode
            // 
            this.colPosiCode.HeaderText = "colPosiCode";
            this.colPosiCode.Name = "colPosiCode";
            this.colPosiCode.Visible = false;
            // 
            // colPosiName
            // 
            this.colPosiName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPosiName.HeaderText = "Position";
            this.colPosiName.Name = "colPosiName";
            // 
            // addPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IJE.Properties.Resources.positionpanel;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(286, 434);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.materialLabel12);
            this.Controls.Add(this.materialLabel9);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.tbxPosiName);
            this.Controls.Add(this.tbxPosiCode);
            this.Controls.Add(this.AddPosi);
            this.Controls.Add(this.cmbDepName);
            this.Controls.Add(this.PositionList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addPosition";
            this.Load += new System.EventHandler(this.addPosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PositionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.TextBox tbxPosiName;
        private System.Windows.Forms.TextBox tbxPosiCode;
        private System.Windows.Forms.Button AddPosi;
        private System.Windows.Forms.ComboBox cmbDepName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView PositionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosiCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosiName;
    }
}