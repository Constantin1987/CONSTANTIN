using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class welcme2 : Form
    {
        int i = 4;

        bool drag = false;
        Point start_point = new Point(0, 0);

        public welcme2()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void welcme2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            i--;



            if (i == 0)
            {


                Form cust = new CustomerDb();
                cust.Show();
                this.Hide();
                timer1.Stop();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
