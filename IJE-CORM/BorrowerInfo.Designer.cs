namespace IJE
{
    partial class BorrowerInfo
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Print = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBorrowed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateReturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.PictureBox();
            this.QrCodeGen = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.EditInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseInfo = new System.Windows.Forms.Button();
            this.CancelEdit = new System.Windows.Forms.Button();
            this.BorDepPos = new MaterialSkin.Controls.MaterialLabel();
            this.BorAdviDep = new MaterialSkin.Controls.MaterialLabel();
            this.UpdateInfo = new System.Windows.Forms.Button();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.BorNo = new MaterialSkin.Controls.MaterialLabel();
            this.BorEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.BorNoInfo = new System.Windows.Forms.TextBox();
            this.BorPosBox = new System.Windows.Forms.ComboBox();
            this.BorFname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.BorMidName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.BorLname = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.BorSecBox = new System.Windows.Forms.ComboBox();
            this.BorDepBox = new System.Windows.Forms.ComboBox();
            this.BorAdvisorbox = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.IDpicturee = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QrCodeGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDpicturee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::IJE.Properties.Resources.borrwerspanel;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Print);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.ID);
            this.panel1.Controls.Add(this.QrCodeGen);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.EditInfo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.CloseInfo);
            this.panel1.Controls.Add(this.CancelEdit);
            this.panel1.Controls.Add(this.BorDepPos);
            this.panel1.Controls.Add(this.BorAdviDep);
            this.panel1.Controls.Add(this.UpdateInfo);
            this.panel1.Controls.Add(this.materialLabel3);
            this.panel1.Controls.Add(this.BorNo);
            this.panel1.Controls.Add(this.BorEmail);
            this.panel1.Controls.Add(this.BorNoInfo);
            this.panel1.Controls.Add(this.BorPosBox);
            this.panel1.Controls.Add(this.BorFname);
            this.panel1.Controls.Add(this.BorMidName);
            this.panel1.Controls.Add(this.materialLabel4);
            this.panel1.Controls.Add(this.BorLname);
            this.panel1.Controls.Add(this.materialLabel5);
            this.panel1.Controls.Add(this.materialLabel6);
            this.panel1.Controls.Add(this.BorSecBox);
            this.panel1.Controls.Add(this.BorDepBox);
            this.panel1.Controls.Add(this.BorAdvisorbox);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.IDpicturee);
            this.panel1.Controls.Add(this.pictureBox16);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 740);
            this.panel1.TabIndex = 73;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Print
            // 
            this.Print.BackgroundImage = global::IJE.Properties.Resources.print;
            this.Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Print.Location = new System.Drawing.Point(653, 312);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(84, 28);
            this.Print.TabIndex = 81;
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::IJE.Properties.Resources.transaction;
            this.pictureBox5.Location = new System.Drawing.Point(421, 347);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(626, 19);
            this.pictureBox5.TabIndex = 80;
            this.pictureBox5.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView2.ColumnHeadersHeight = 40;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colItemCode,
            this.colItemName,
            this.ItemModel,
            this.DateBorrowed,
            this.DateReturned,
            this.Notes});
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(213)))), ((int)(((byte)(220)))));
            this.dataGridView2.Location = new System.Drawing.Point(397, 381);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(672, 344);
            this.dataGridView2.TabIndex = 71;
            this.dataGridView2.TabStop = false;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // colItemCode
            // 
            this.colItemCode.HeaderText = "Asset Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colItemName.HeaderText = "Item Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 300;
            // 
            // ItemModel
            // 
            this.ItemModel.HeaderText = "Model";
            this.ItemModel.Name = "ItemModel";
            // 
            // DateBorrowed
            // 
            this.DateBorrowed.HeaderText = "Date Borrowed";
            this.DateBorrowed.Name = "DateBorrowed";
            // 
            // DateReturned
            // 
            this.DateReturned.HeaderText = "Date Return";
            this.DateReturned.Name = "DateReturned";
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.Width = 500;
            // 
            // ID
            // 
            this.ID.BackColor = System.Drawing.Color.White;
            this.ID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ID.Location = new System.Drawing.Point(720, 94);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(327, 202);
            this.ID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ID.TabIndex = 78;
            this.ID.TabStop = false;
            // 
            // QrCodeGen
            // 
            this.QrCodeGen.BackColor = System.Drawing.Color.White;
            this.QrCodeGen.Location = new System.Drawing.Point(414, 92);
            this.QrCodeGen.Name = "QrCodeGen";
            this.QrCodeGen.Size = new System.Drawing.Size(253, 202);
            this.QrCodeGen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.QrCodeGen.TabIndex = 76;
            this.QrCodeGen.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::IJE.Properties.Resources.large_square_for_pattern_block_set_clipart_etc_IFFxWg_clipart;
            this.pictureBox2.Location = new System.Drawing.Point(701, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(362, 221);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::IJE.Properties.Resources.large_square_for_pattern_block_set_clipart_etc_IFFxWg_clipart;
            this.pictureBox4.Location = new System.Drawing.Point(397, 83);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(287, 222);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 73;
            this.pictureBox4.TabStop = false;
            // 
            // EditInfo
            // 
            this.EditInfo.BackgroundImage = global::IJE.Properties.Resources.editbutt;
            this.EditInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EditInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditInfo.Location = new System.Drawing.Point(153, 651);
            this.EditInfo.Name = "EditInfo";
            this.EditInfo.Size = new System.Drawing.Size(81, 32);
            this.EditInfo.TabIndex = 66;
            this.EditInfo.UseVisualStyleBackColor = true;
            this.EditInfo.Click += new System.EventHandler(this.EditInfo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IJE.Properties.Resources.borrowerinfo2;
            this.pictureBox1.Image = global::IJE.Properties.Resources.borrowerinfo2;
            this.pictureBox1.Location = new System.Drawing.Point(299, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 50);
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CloseInfo
            // 
            this.CloseInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseInfo.Image = global::IJE.Properties.Resources.closebutt;
            this.CloseInfo.Location = new System.Drawing.Point(156, 692);
            this.CloseInfo.Name = "CloseInfo";
            this.CloseInfo.Size = new System.Drawing.Size(75, 33);
            this.CloseInfo.TabIndex = 68;
            this.CloseInfo.UseVisualStyleBackColor = true;
            this.CloseInfo.Click += new System.EventHandler(this.CloseInfo_Click);
            // 
            // CancelEdit
            // 
            this.CancelEdit.BackgroundImage = global::IJE.Properties.Resources.cancelbutt;
            this.CancelEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CancelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelEdit.Location = new System.Drawing.Point(194, 651);
            this.CancelEdit.Name = "CancelEdit";
            this.CancelEdit.Size = new System.Drawing.Size(81, 32);
            this.CancelEdit.TabIndex = 70;
            this.CancelEdit.TabStop = false;
            this.CancelEdit.UseVisualStyleBackColor = true;
            this.CancelEdit.Visible = false;
            this.CancelEdit.Click += new System.EventHandler(this.CancelEdit_Click);
            // 
            // BorDepPos
            // 
            this.BorDepPos.AutoSize = true;
            this.BorDepPos.BackColor = System.Drawing.Color.White;
            this.BorDepPos.Depth = 0;
            this.BorDepPos.Font = new System.Drawing.Font("Roboto", 11F);
            this.BorDepPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BorDepPos.Location = new System.Drawing.Point(15, 606);
            this.BorDepPos.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorDepPos.Name = "BorDepPos";
            this.BorDepPos.Size = new System.Drawing.Size(49, 19);
            this.BorDepPos.TabIndex = 65;
            this.BorDepPos.Text = "label2";
            this.BorDepPos.Click += new System.EventHandler(this.BorDepPos_Click);
            // 
            // BorAdviDep
            // 
            this.BorAdviDep.AutoSize = true;
            this.BorAdviDep.BackColor = System.Drawing.Color.White;
            this.BorAdviDep.Depth = 0;
            this.BorAdviDep.Font = new System.Drawing.Font("Roboto", 11F);
            this.BorAdviDep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BorAdviDep.Location = new System.Drawing.Point(15, 558);
            this.BorAdviDep.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorAdviDep.Name = "BorAdviDep";
            this.BorAdviDep.Size = new System.Drawing.Size(49, 19);
            this.BorAdviDep.TabIndex = 64;
            this.BorAdviDep.Text = "label1";
            this.BorAdviDep.Click += new System.EventHandler(this.BorAdviDep_Click);
            // 
            // UpdateInfo
            // 
            this.UpdateInfo.BackgroundImage = global::IJE.Properties.Resources.updatebutt;
            this.UpdateInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UpdateInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateInfo.Location = new System.Drawing.Point(107, 651);
            this.UpdateInfo.Name = "UpdateInfo";
            this.UpdateInfo.Size = new System.Drawing.Size(81, 32);
            this.UpdateInfo.TabIndex = 67;
            this.UpdateInfo.UseVisualStyleBackColor = true;
            this.UpdateInfo.Visible = false;
            this.UpdateInfo.Click += new System.EventHandler(this.UpdateInfo_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.White;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(15, 511);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(51, 19);
            this.materialLabel3.TabIndex = 63;
            this.materialLabel3.Text = "Email:";
            this.materialLabel3.Click += new System.EventHandler(this.materialLabel3_Click);
            // 
            // BorNo
            // 
            this.BorNo.AutoSize = true;
            this.BorNo.BackColor = System.Drawing.Color.White;
            this.BorNo.Depth = 0;
            this.BorNo.Font = new System.Drawing.Font("Roboto", 11F);
            this.BorNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BorNo.Location = new System.Drawing.Point(95, 318);
            this.BorNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorNo.Name = "BorNo";
            this.BorNo.Size = new System.Drawing.Size(49, 19);
            this.BorNo.TabIndex = 52;
            this.BorNo.Text = "label1";
            this.BorNo.Click += new System.EventHandler(this.BorNo_Click);
            // 
            // BorEmail
            // 
            this.BorEmail.BackColor = System.Drawing.Color.White;
            this.BorEmail.Depth = 0;
            this.BorEmail.Enabled = false;
            this.BorEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorEmail.Hint = "";
            this.BorEmail.Location = new System.Drawing.Point(149, 511);
            this.BorEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorEmail.Name = "BorEmail";
            this.BorEmail.PasswordChar = '\0';
            this.BorEmail.SelectedText = "";
            this.BorEmail.SelectionLength = 0;
            this.BorEmail.SelectionStart = 0;
            this.BorEmail.Size = new System.Drawing.Size(230, 23);
            this.BorEmail.TabIndex = 55;
            this.BorEmail.UseSystemPasswordChar = false;
            this.BorEmail.Click += new System.EventHandler(this.BorEmail_Click);
            // 
            // BorNoInfo
            // 
            this.BorNoInfo.BackColor = System.Drawing.Color.White;
            this.BorNoInfo.Enabled = false;
            this.BorNoInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorNoInfo.Location = new System.Drawing.Point(229, 317);
            this.BorNoInfo.Name = "BorNoInfo";
            this.BorNoInfo.Size = new System.Drawing.Size(83, 22);
            this.BorNoInfo.TabIndex = 50;
            this.BorNoInfo.TextChanged += new System.EventHandler(this.BorNoInfo_TextChanged);
            // 
            // BorPosBox
            // 
            this.BorPosBox.BackColor = System.Drawing.Color.White;
            this.BorPosBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BorPosBox.DropDownHeight = 70;
            this.BorPosBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BorPosBox.Enabled = false;
            this.BorPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorPosBox.FormattingEnabled = true;
            this.BorPosBox.IntegralHeight = false;
            this.BorPosBox.Location = new System.Drawing.Point(149, 605);
            this.BorPosBox.Name = "BorPosBox";
            this.BorPosBox.Size = new System.Drawing.Size(230, 24);
            this.BorPosBox.TabIndex = 60;
            this.BorPosBox.SelectedIndexChanged += new System.EventHandler(this.BorPosBox_SelectedIndexChanged);
            // 
            // BorFname
            // 
            this.BorFname.BackColor = System.Drawing.Color.White;
            this.BorFname.Depth = 0;
            this.BorFname.Enabled = false;
            this.BorFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorFname.Hint = "";
            this.BorFname.Location = new System.Drawing.Point(149, 368);
            this.BorFname.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorFname.Name = "BorFname";
            this.BorFname.PasswordChar = '\0';
            this.BorFname.SelectedText = "";
            this.BorFname.SelectionLength = 0;
            this.BorFname.SelectionStart = 0;
            this.BorFname.Size = new System.Drawing.Size(224, 23);
            this.BorFname.TabIndex = 51;
            this.BorFname.UseSystemPasswordChar = false;
            this.BorFname.Click += new System.EventHandler(this.BorFname_Click);
            // 
            // BorMidName
            // 
            this.BorMidName.BackColor = System.Drawing.Color.White;
            this.BorMidName.Depth = 0;
            this.BorMidName.Enabled = false;
            this.BorMidName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorMidName.Hint = "";
            this.BorMidName.Location = new System.Drawing.Point(149, 414);
            this.BorMidName.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorMidName.Name = "BorMidName";
            this.BorMidName.PasswordChar = '\0';
            this.BorMidName.SelectedText = "";
            this.BorMidName.SelectionLength = 0;
            this.BorMidName.SelectionStart = 0;
            this.BorMidName.Size = new System.Drawing.Size(223, 23);
            this.BorMidName.TabIndex = 53;
            this.BorMidName.UseSystemPasswordChar = false;
            this.BorMidName.Click += new System.EventHandler(this.BorMidName_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.White;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(15, 466);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(86, 19);
            this.materialLabel4.TabIndex = 62;
            this.materialLabel4.Text = "Last Name:";
            this.materialLabel4.Click += new System.EventHandler(this.materialLabel4_Click);
            // 
            // BorLname
            // 
            this.BorLname.BackColor = System.Drawing.Color.White;
            this.BorLname.Depth = 0;
            this.BorLname.Enabled = false;
            this.BorLname.Hint = "";
            this.BorLname.Location = new System.Drawing.Point(149, 466);
            this.BorLname.MouseState = MaterialSkin.MouseState.HOVER;
            this.BorLname.Name = "BorLname";
            this.BorLname.PasswordChar = '\0';
            this.BorLname.SelectedText = "";
            this.BorLname.SelectionLength = 0;
            this.BorLname.SelectionStart = 0;
            this.BorLname.Size = new System.Drawing.Size(222, 23);
            this.BorLname.TabIndex = 54;
            this.BorLname.UseSystemPasswordChar = false;
            this.BorLname.Click += new System.EventHandler(this.BorLname_Click);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.White;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(15, 414);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(102, 19);
            this.materialLabel5.TabIndex = 61;
            this.materialLabel5.Text = "Middle Name:";
            this.materialLabel5.Click += new System.EventHandler(this.materialLabel5_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.White;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(15, 368);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(87, 19);
            this.materialLabel6.TabIndex = 58;
            this.materialLabel6.Text = "First Name:";
            this.materialLabel6.Click += new System.EventHandler(this.materialLabel6_Click);
            // 
            // BorSecBox
            // 
            this.BorSecBox.BackColor = System.Drawing.Color.White;
            this.BorSecBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BorSecBox.DropDownHeight = 70;
            this.BorSecBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BorSecBox.Enabled = false;
            this.BorSecBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorSecBox.FormattingEnabled = true;
            this.BorSecBox.IntegralHeight = false;
            this.BorSecBox.Location = new System.Drawing.Point(149, 605);
            this.BorSecBox.Name = "BorSecBox";
            this.BorSecBox.Size = new System.Drawing.Size(230, 24);
            this.BorSecBox.TabIndex = 59;
            this.BorSecBox.Visible = false;
            this.BorSecBox.SelectedIndexChanged += new System.EventHandler(this.BorSecBox_SelectedIndexChanged);
            // 
            // BorDepBox
            // 
            this.BorDepBox.BackColor = System.Drawing.Color.White;
            this.BorDepBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BorDepBox.DropDownHeight = 70;
            this.BorDepBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BorDepBox.Enabled = false;
            this.BorDepBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorDepBox.FormattingEnabled = true;
            this.BorDepBox.IntegralHeight = false;
            this.BorDepBox.Location = new System.Drawing.Point(149, 556);
            this.BorDepBox.Name = "BorDepBox";
            this.BorDepBox.Size = new System.Drawing.Size(230, 24);
            this.BorDepBox.TabIndex = 56;
            this.BorDepBox.SelectedIndexChanged += new System.EventHandler(this.BorDepBox_SelectedIndexChanged);
            // 
            // BorAdvisorbox
            // 
            this.BorAdvisorbox.BackColor = System.Drawing.Color.White;
            this.BorAdvisorbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BorAdvisorbox.DropDownHeight = 70;
            this.BorAdvisorbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BorAdvisorbox.Enabled = false;
            this.BorAdvisorbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorAdvisorbox.FormattingEnabled = true;
            this.BorAdvisorbox.IntegralHeight = false;
            this.BorAdvisorbox.Location = new System.Drawing.Point(149, 556);
            this.BorAdvisorbox.Name = "BorAdvisorbox";
            this.BorAdvisorbox.Size = new System.Drawing.Size(230, 24);
            this.BorAdvisorbox.TabIndex = 57;
            this.BorAdvisorbox.Visible = false;
            this.BorAdvisorbox.SelectedIndexChanged += new System.EventHandler(this.BorAdvisorbox_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::IJE.Properties.Resources.editttt;
            this.pictureBox3.Location = new System.Drawing.Point(179, 170);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(54, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 79;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // IDpicturee
            // 
            this.IDpicturee.Location = new System.Drawing.Point(99, 92);
            this.IDpicturee.Name = "IDpicturee";
            this.IDpicturee.Size = new System.Drawing.Size(211, 202);
            this.IDpicturee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IDpicturee.TabIndex = 77;
            this.IDpicturee.TabStop = false;
            this.IDpicturee.Click += new System.EventHandler(this.IDpicturee_Click);
            this.IDpicturee.MouseLeave += new System.EventHandler(this.IDpicturee_MouseLeave);
            this.IDpicturee.MouseHover += new System.EventHandler(this.IDpicturee_MouseHover);
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = global::IJE.Properties.Resources.large_square_for_pattern_block_set_clipart_etc_IFFxWg_clipart;
            this.pictureBox16.Location = new System.Drawing.Point(85, 82);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(237, 222);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 74;
            this.pictureBox16.TabStop = false;
            // 
            // BorrowerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1082, 741);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "BorrowerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BorrowerInfo";
            this.Load += new System.EventHandler(this.BorrowerInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QrCodeGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDpicturee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox BorSecBox;
        private System.Windows.Forms.ComboBox BorAdvisorbox;
        private MaterialSkin.Controls.MaterialLabel BorDepPos;
        private MaterialSkin.Controls.MaterialLabel BorAdviDep;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField BorEmail;
        private System.Windows.Forms.ComboBox BorPosBox;
        private System.Windows.Forms.ComboBox BorDepBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialSingleLineTextField BorLname;
        private MaterialSkin.Controls.MaterialSingleLineTextField BorMidName;
        private MaterialSkin.Controls.MaterialSingleLineTextField BorFname;
        private System.Windows.Forms.Button EditInfo;
        private System.Windows.Forms.Button UpdateInfo;
        private System.Windows.Forms.Button CancelEdit;
        private System.Windows.Forms.Button CloseInfo;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox QrCodeGen;
        public System.Windows.Forms.PictureBox IDpicturee;
        private System.Windows.Forms.PictureBox ID;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MaterialSkin.Controls.MaterialLabel BorNo;
        private System.Windows.Forms.TextBox BorNoInfo;
        public System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBorrowed;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateReturned;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
    }
}