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
    public partial class BorrowedItemDetail : Form
    {
        string borHCode;
        string borDCode;
        DBConnect dbConnect;
        public BorrowedItemDetail(string consBorHCode,string consBorDCode)
        {

            InitializeComponent();

            dbConnect = new DBConnect();
            borHCode = consBorHCode;
            borDCode = consBorDCode;
            display();
        }

        private void display()
        {
            string[] columns = { "strBorDRoom","strBorDPurpose" };
            List<object>[] rs;
            rs = dbConnect.Select("select * from tblBorrowDetail where strBorDBorHCode = '"+borHCode+"' and strBorDCode = '"+borDCode+"';",columns);
            RoomNumber.Text = rs[0].ElementAt(0).ToString();
            textBox1.Text = rs[1].ElementAt(0).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BorrowedItemDetail_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
