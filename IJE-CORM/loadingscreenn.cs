using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IJE
{
    public partial class loadingscreenn : Form
    {
        public loadingscreenn()
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.BackColor = Color.Transparent;
        }

        private void loadingscreenn_Load(object sender, EventArgs e)
        {
      

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
