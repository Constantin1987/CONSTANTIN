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
    public partial class addpoints : Form
    {    
         SqlConnection log = new SqlConnection(us.conn);

        SqlCommand add = new SqlCommand();
        double balance;
        double deposit = 0.5;

        bool drag = false;
        Point start_point = new Point(0, 0);

        public addpoints()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnregregister_Click(object sender, EventArgs e)
        {
            //add points to the customer account 
            if (txtpound.Text == "" || lblbalance.Text == "0")
            {
                MessageBox.Show("Please enter a valid  Amount");
                txtpound.Clear();
            }
            else
            {


                try
                {
                    d.point = (double)Math.Floor(balance) + (double)Math.Floor(d.point);
                    int pointHolder;
                    pointHolder = (int)Math.Floor(d.point);

                    add.Connection = log;
                    add.CommandType = CommandType.Text;
                    add.CommandText = "UPDATE  Customer SET Points = @NewPoint WHERE Email = @Mail";
                    add.Parameters.AddWithValue("@NewPoint", pointHolder);
                    add.Parameters.AddWithValue("@Mail", us.emaill);

                    log.Open();
                    add.ExecuteNonQuery();


                    MessageBox.Show("Thank You");

                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);
                    Form menu = new Profile();
                    menu.Show();
                    this.Hide();

                }
                catch
                {
                    MessageBox.Show("error");
                }
                finally
                {
                    log.Close();

                }
            }
        }
        private void btncalculate_Click(object sender, EventArgs e)
        {
            //points math

            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);

            int balanceHolder;
            if (txtpound.Text == "" ||txtpound.Text.StartsWith("0"))
            {
                MessageBox.Show("Please enter a valid  Amount");
                txtpound.Text = "";

            }
            else
            {
                try
                {
                    balance = double.Parse(txtpound.Text);

                    balance = balance * deposit;
                    
                    balanceHolder = (int)Math.Floor(balance);
                    
                    lblbalance.Text = balanceHolder.ToString();
                    //not less then 0 

                    if (balanceHolder<=0)
                    {
                        MessageBox.Show("Not negative values allowed  ");
                        lblbalance.Text ="0";
                        txtpound.Text = "";

                    }
                }
                catch
                {
                    MessageBox.Show("Please enter a valid  Amount");
                    txtpound.Clear();
                }
            }
        }

        private void addpoints_Load(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //go to the user account 
            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);
            Form history = new Profile();
            history.Show();
            this.Hide();
        }

        private void txtpound_TextChanged(object sender, EventArgs e)
        {
            // can't enter a "0" before number like 011
            try
            {
                txtpound.Text = txtpound.Text.TrimStart('0');

                if (txtpound.Text.StartsWith("0"))
                txtpound.Text = '0' + txtpound.Text;
            }
            catch
            {
                MessageBox.Show("Please enter a valid  Amount");
                txtpound.Clear();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //movable panel
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //movable panel
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //movable panel
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

        private void addpoints_Shown(object sender, EventArgs e)
        {
            txtpound.Focus();
        }

        private void txtpound_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                txtpound.Text = "";
                e.Handled = false;
                MessageBox.Show("Please enter a valid value");
               

            }

        }
    }
}
