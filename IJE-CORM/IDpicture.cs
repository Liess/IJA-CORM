using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using System.Media;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace IJE
{
    public partial class IDpicture : Form
    {
        SoundPlayer player;
        private AdminPanel _idpic = null;

        public IDpicture(AdminPanel idpic)
        {
            InitializeComponent();
            _idpic = idpic;
          
       
        }

       
        public static VideoCaptureDevice FinalFrame;
        private FilterInfoCollection CaptureDevice;
       


        public static int i = 0;
         public void IDpicture_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            try
            {
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
                FinalFrame.Start();
            }
            catch {
                i = 1;
                MessageBox.Show("No camera detected");
                button2.Enabled = false;
            }
        }

        private void BorrowerLogIn_Paint(object sender, PaintEventArgs e)
        {

        }

   
        public void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox3.Image = bit; 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FinalFrame.IsRunning)
                {
                    FinalFrame.Stop();
                    this.Close();
                }
            }
            catch {
                this.Close();
            }
            this.Close();
        }

        public string source1 = @"C:\Users\maskarino\Desktop\QRcodes\Pictures\temp";
        private void button2_Click(object sender, EventArgs e)
        {

            if (FinalFrame.IsRunning)
            {
                FinalFrame.Stop();
            }
            Save.Visible = true;
            Cancel.Visible = true;
            button2.Visible = false;
            button3.Enabled = false;
            //pictureBox3.Image.Save(source1 +" haha"  + ".jpg", ImageFormat.Jpeg);
        }
        public static int a = 0;
        private void Save_Click(object sender, EventArgs e)
        {
            a = 1;
            //.Image.Save(source1 + " haha2" + ".jpg", ImageFormat.Jpeg);
            _idpic.IDpicturee.Image = pictureBox3.Image;
            this.Close();
        
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
            Save.Visible = false;
            Cancel.Visible = false;
            button2.Visible = true;
            button3.Enabled = true;
        }
    }
}
