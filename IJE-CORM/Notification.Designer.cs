namespace IJE
{
    partial class Notification
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
            this.lifeTimer = new System.Windows.Forms.Timer(this.components);
            this.SendEmail = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.BorrowersCount = new System.Windows.Forms.Label();
            this.BorrPic = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Bname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorrPic)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick_1);
            // 
            // SendEmail
            // 
            this.SendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendEmail.ForeColor = System.Drawing.Color.White;
            this.SendEmail.Location = new System.Drawing.Point(131, 53);
            this.SendEmail.Name = "SendEmail";
            this.SendEmail.Size = new System.Drawing.Size(135, 26);
            this.SendEmail.TabIndex = 96;
            this.SendEmail.Text = "Send Message to all";
            this.SendEmail.UseVisualStyleBackColor = true;
            this.SendEmail.Click += new System.EventHandler(this.SendEmail_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(160, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(177, 21);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Overdue Notification";
            // 
            // stop
            // 
            this.stop.Tick += new System.EventHandler(this.stop_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(178)))), ((int)(((byte)(139)))));
            this.panel1.Controls.Add(this.BorrowersCount);
            this.panel1.Controls.Add(this.BorrPic);
            this.panel1.Location = new System.Drawing.Point(1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 127);
            this.panel1.TabIndex = 0;
            // 
            // BorrowersCount
            // 
            this.BorrowersCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowersCount.ForeColor = System.Drawing.Color.White;
            this.BorrowersCount.Location = new System.Drawing.Point(12, 76);
            this.BorrowersCount.Name = "BorrowersCount";
            this.BorrowersCount.Size = new System.Drawing.Size(70, 34);
            this.BorrowersCount.TabIndex = 92;
            this.BorrowersCount.Text = "999";
            this.BorrowersCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BorrPic
            // 
            this.BorrPic.Image = global::IJE.Properties.Resources.borrower;
            this.BorrPic.Location = new System.Drawing.Point(11, 14);
            this.BorrPic.Name = "BorrPic";
            this.BorrPic.Size = new System.Drawing.Size(70, 64);
            this.BorrPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BorrPic.TabIndex = 0;
            this.BorrPic.TabStop = false;
            this.BorrPic.Click += new System.EventHandler(this.BorrPic_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.SendEmail);
            this.panel2.Controls.Add(this.Bname);
            this.panel2.Location = new System.Drawing.Point(94, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 91);
            this.panel2.TabIndex = 97;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(44, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 97;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Bname
            // 
            this.Bname.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bname.ForeColor = System.Drawing.Color.White;
            this.Bname.Location = new System.Drawing.Point(10, 7);
            this.Bname.Name = "Bname";
            this.Bname.Size = new System.Drawing.Size(287, 30);
            this.Bname.TabIndex = 89;
            this.Bname.Text = "They will be overdue after 3 days.";
            this.Bname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(160)))), ((int)(((byte)(124)))));
            this.ClientSize = new System.Drawing.Size(403, 123);
            this.ControlBox = false;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Notification";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Notification_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BorrPic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer lifeTimer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button SendEmail;
        private System.Windows.Forms.Timer stop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label BorrowersCount;
        private System.Windows.Forms.PictureBox BorrPic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Bname;
    }
}