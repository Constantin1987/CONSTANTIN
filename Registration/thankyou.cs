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
    public partial class thankyou : Form
    {

        bool drag = false;
        Point start_point = new Point(0, 0);

        public thankyou()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void thankyou_Load(object sender, EventArgs e)
        {
            lblname.TextAlign = ContentAlignment.MiddleCenter;
          
            lblname.Text = char.ToUpper(us.fname[0]) + us.fname.Substring(1);
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // go to Account form 
            Form history = new Profile();
            history.Show();
            this.Hide();
        }

        private void btnregregister_Click(object sender, EventArgs e)
        {

            //go to Login form
            Form st = new Start1();
            st.Show();
            this.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
