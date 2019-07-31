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
using System.Net.Mail;


namespace Registration
    
{


    public partial class Reg : Form

    {

        Random numberGenerator = new Random();

        int po;



        SqlConnection con = new SqlConnection(us.conn);

        SqlCommand insert = new SqlCommand();

        bool drag = false;
        Point start_point = new Point(0, 0);

        public Reg()
        {

            InitializeComponent();
            MaximizeBox = false;

            po = numberGenerator.Next(220, 500);

        }
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Reg_Load(object sender, EventArgs e)
        {
            lblinsert.Text = "";
        }

        private void txtfirtsname_Click(object sender, EventArgs e)
        {

        }

        private void txtfirtsname_MouseClick(object sender, MouseEventArgs e)
        {
            lblinsert.Text = "";
            label6.ForeColor = Color.Gray;
        }

        private void txtsurname_MouseClick(object sender, MouseEventArgs e)
        {
            lblinsert.Text = "";
            label6.ForeColor = Color.Gray;

        }

        private void txtemail_MouseClick(object sender, MouseEventArgs e)
        {

            lblinsert.Text = "";
            label6.ForeColor = Color.Gray;
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            lblinsert.Text = "";
            label6.ForeColor = Color.Gray;

        }

        private void txtfirtsname_TextChanged(object sender, EventArgs e)
        {
            if (txtfirtsname.Text.Contains(" "))
            {
                MessageBox.Show("No Spaces!");
                txtfirtsname.Text = "";
            }
        }

        private void btnreglogin_Click(object sender, EventArgs e)
        {
            //go to Login form 
            Form login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnregregister_Click(object sender, EventArgs e)
        {
        }
        private void txtsurname_TextChanged(object sender, EventArgs e)
        {
            if (txtsurname.Text.Contains(" "))
            {
                MessageBox.Show("No Spaces!");
                txtsurname.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Register a new User to the system 
            try
            {

                if (txtfirtsname.Text == "" || txtsurname.Text == "" || txtregpassword.Text == "" || txtregemail.Text == "")
                {
                    lblinsert.Text = "Please inser your details ";

                }
                else
                {



                    lblinsert.Text = "";
                    string pass;
                    pass = txtregpassword.Text;

                    if (IsEmailValid(txtregemail.Text))
                    {


                        if (pass.Length >= 6)
                        {

                            DateTime dtime = DateTime.Now;
                            DateTime ttime = DateTime.Now;




                            insert.CommandType = CommandType.Text;
                            insert.CommandText = "INSERT Customer (Firstname,Surname,Email,Password,Points,Registration_Date,Registration_Time)VALUES('" + txtfirtsname.Text + "','" + txtsurname.Text + "','" + txtregemail.Text + "','" + txtregpassword.Text + "','" + po + "','" + dtime.ToString("dd/MM/yyyy") + "','" + ttime.ToString("H:mm:ss") + "')";
                            insert.Connection = con;
                            con.Open();
                            insert.ExecuteNonQuery();

                            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", con);
                            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                            DataTable dt = new DataTable();

                            adapt.Fill(dt);

                            Form login = new Login();
                            login.Show();
                            this.Hide();


                        }

                        else
                        {
                            label6.ForeColor = Color.Turquoise;

                        }

                    }
                    else
                    {
                        lblinsert.Text = "Please insert valid Email";
                       
                    }
                }
             } 
            catch (Exception it)
            {
                MessageBox.Show(it.Message);
            }
        
            finally
            {
                con.Close();
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Reg_Shown(object sender, EventArgs e)
        {
            txtfirtsname.Focus();
        }

        private void lblinsert_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtregemail_TextChanged(object sender, EventArgs e)
        {
            if (txtregemail.Text.Contains(" "))
            {
                MessageBox.Show("No Spaces!");
                txtregemail.Text = "";
            }
        }


        private void txtregemail_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtregpassword_TextChanged(object sender, EventArgs e)
        {
            if (txtregpassword.Text.Contains(" "))
            {
                MessageBox.Show("No Spaces!");
                txtregpassword.Text = "";
            }
        }
    }
}
