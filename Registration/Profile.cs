using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Registration
{
    public partial class Profile : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        SqlConnection log = new SqlConnection(us.conn);

        SqlCommand add = new SqlCommand();

        public Profile()
        {
            InitializeComponent();
           
           

            lblFname.Text = char.ToUpper(us.fname[0]) + us.fname.Substring(1) + "\t\t" + " " + char.ToUpper(us.sname[0]) + us.sname.Substring(1);
            int pointHolder;
            pointHolder = (int)Math.Floor(d.point);
            lblpoin.Text = Convert.ToString(pointHolder);
            
            lblFname.TextAlign = ContentAlignment.MiddleCenter;

            label1.Text = us.emaill;
            label1.TextAlign = ContentAlignment.MiddleCenter;

            MaximizeBox = false;
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //go to menu form
            Form menu = new Menu();
            menu.Show();
            this.Hide();
            
        }

        private void btnhistory_Click(object sender, EventArgs e)
        {
            //go to History menu 
            Form history = new History();
            history.Show();
            this.Hide();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            //go to Addpoins menu
            Form add = new addpoints();
            add.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //go to Login form
            Form st = new Start1();
            st.Show();
            this.Hide();
        }
    }
}
