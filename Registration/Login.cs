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
    public partial class Login : Form

    {   
        SqlConnection log = new SqlConnection(us.conn);

        SqlCommand user = new SqlCommand();
        SqlCommand match = new SqlCommand();

        bool drag = false;
        Point start_point = new Point(0, 0);

        public Login()
        {
            InitializeComponent();
            MaximizeBox = false;
            //Hide error labels
            lblErrorEmail.Text="";
            lblErrorPassword.Text="";
            
        }

        private void txtlogemail_MouseClick(object sender, MouseEventArgs e)
        {
            label12.Text="";
            lblErrorEmail.Text = "";
            lblErrorPassword.Text = "";
        }

        private void txtlogpassw_MouseClick(object sender, MouseEventArgs e)
        {
            lblErrorPassword.Text="";
            label12.Text = "";
            lblErrorEmail.Text = "";
        }

        private void btnregregister_Click(object sender, EventArgs e)
        {
            //go to register page 
            Form register = new Reg();
            register.Show();
            this.Hide();
        }

        private void btnreglogin_Click(object sender, EventArgs e)

        {
        }
            private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form customer = new CustomerDb();
            customer.Show();
            this.Hide();
                
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }

        private void lblErrorPassword_Click(object sender, EventArgs e)
        {
            
        }

        private void txtlogpassw_Click(object sender, EventArgs e)
        {
            
        }

        private void processingControl1_Click(object sender, EventArgs e)
        {

        }

        private void altoTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //check the Emails and Passwords 

            string adm, pass;
            pass = txtlogpassw.Text;
            adm = txtlogemail.Text;
            if (txtlogemail.Text == "" || txtlogpassw.Text == "")
            {
                
                lblErrorEmail.Text = "";
                lblErrorPassword.Text = "Please insert your details";
                lblErrorPassword.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                lblErrorPassword.Text = "";

                if (adm == "kostika" && pass == "1122")
                {
                    Form admin = new welcme2();
                    admin.Show();
                    this.Hide();
                }
                try
                {
                    SqlCommand checkEmail = new SqlCommand("SELECT Email FROM Customer WHERE Email = @Mail", log);
                    checkEmail.Parameters.AddWithValue("@Mail", txtlogemail.Text);
                    SqlDataReader read;

                    log.Open();
                    read = checkEmail.ExecuteReader();

                    if (read.HasRows)
                    {//Email exists
                     //lblerror.Hide();
                        lblErrorEmail.Text="";

                        read.Close();
                        log.Close();

                        //Get password

                        SqlCommand getPass = new SqlCommand("SELECT Password FROM Customer WHERE Email = @Mail", log);
                        getPass.Parameters.AddWithValue("@Mail", txtlogemail.Text);
                        string password;

                        log.Open();
                        password = (string)getPass.ExecuteScalar();
                        log.Close();

                        if (password.Equals(txtlogpassw.Text))
                        {

                            lblErrorPassword.Text="";



                            int pointss;
                            //customer points
                            SqlCommand getpoints = new SqlCommand("SELECT Points FROM Customer WHERE Email = @Poin", log);
                            getpoints.Parameters.AddWithValue("@Poin", txtlogemail.Text);
                            log.Open();
                            pointss = (int)getpoints.ExecuteScalar();
                            (d.point) = (double)pointss;
                            log.Close();

                            //First minimum require points
                            int minpoint1, minpoint2, minpoint3, minpoint4;
                            SqlCommand getminim1 = new SqlCommand("SELECT Amount FROM Minimum WHERE MinimumID = @Poin", log);
                            getminim1.Parameters.AddWithValue("@Poin", "1");
                            log.Open();
                            minpoint1 = (int)getminim1.ExecuteScalar();
                            a.minim1 = minpoint1;
                            log.Close();

                            //Second minimum require points
                            SqlCommand getminim2 = new SqlCommand("SELECT Amount FROM Minimum WHERE MinimumID = @Poin", log);
                            getminim2.Parameters.AddWithValue("@Poin", "2");
                            log.Open();
                            minpoint2 = (int)getminim2.ExecuteScalar();
                            a.minim2 = minpoint2;
                            log.Close();

                            //Third minimum require points
                            SqlCommand getminim3 = new SqlCommand("SELECT Amount FROM Minimum WHERE MinimumID = @Poin", log);
                            getminim3.Parameters.AddWithValue("@Poin", "3");
                            log.Open();
                            minpoint3 = (int)getminim3.ExecuteScalar();
                            a.minim3 = minpoint3;
                            log.Close();

                            //Four minimum require points
                            SqlCommand getminim4 = new SqlCommand("SELECT Amount FROM Minimum WHERE MinimumID = @Poin", log);
                            getminim4.Parameters.AddWithValue("@Poin", "4");
                            log.Open();
                            minpoint4 = (int)getminim4.ExecuteScalar();
                            a.minim4 = minpoint4;
                            log.Close();


                            us.emaill = txtlogemail.Text;
                            //select Firstname
                            SqlCommand getFirst = new SqlCommand("SELECT Firstname FROM Customer WHERE Email = @Mail", log);
                            getFirst.Parameters.AddWithValue("@Mail", txtlogemail.Text);
                            string firstName;
                            log.Open();
                            firstName = (string)getFirst.ExecuteScalar();
                            us.fname = firstName;
                            log.Close();

                            //select Surname
                            SqlCommand getsur = new SqlCommand("SELECT Surname FROM Customer WHERE Email = @Mail", log);
                            getsur.Parameters.AddWithValue("@Mail", txtlogemail.Text);
                            string surname;
                            log.Open();
                            surname = (string)getsur.ExecuteScalar();
                            us.sname = surname;
                            log.Close();



                            int ofp1, ofp2, ofp3, ofp4, ofp5;
                            string ofd1, ofd2, ofd3, ofd4, ofd5;
                            //First Offer description 
                            SqlCommand getofd1 = new SqlCommand("SELECT Description FROM Offers WHERE OfferID =@offer", log);
                            getofd1.Parameters.AddWithValue("@offer", 1);
                            log.Open();
                            ofd1 = (string)getofd1.ExecuteScalar();
                            us.of1 = ofd1;
                            log.Close();

                            //First Offer Costs
                            SqlCommand getofc1 = new SqlCommand("SELECT Costs FROM Offers WHERE OfferID =@offer", log);
                            getofc1.Parameters.AddWithValue("@offer", 1);
                            log.Open();
                            ofp1 = (int)getofc1.ExecuteScalar();
                            a.of11 = ofp1;
                            log.Close();

                            //Second Offer description 
                            SqlCommand getofd2 = new SqlCommand("SELECT Description FROM Offers WHERE OfferID =@offer", log);
                            getofd2.Parameters.AddWithValue("@offer", 2);
                            log.Open();
                            ofd2 = (string)getofd2.ExecuteScalar();
                            us.of2 = ofd2;
                            log.Close();
                            //Second Offer Costs
                            SqlCommand getofc2 = new SqlCommand("SELECT Costs FROM Offers WHERE OfferID =@offer", log);
                            getofc2.Parameters.AddWithValue("@offer", 2);
                            log.Open();
                            ofp2 = (int)getofc2.ExecuteScalar();
                            a.of22 = ofp2;
                            log.Close();
                            //Third Offer description 
                            SqlCommand getofd3 = new SqlCommand("SELECT Description FROM Offers WHERE OfferID =@offer", log);
                            getofd3.Parameters.AddWithValue("@offer", 3);
                            log.Open();
                            ofd3 = (string)getofd3.ExecuteScalar();
                            us.of3 = ofd3;
                            log.Close();

                            //Third Offer Costs
                            SqlCommand getofc3 = new SqlCommand("SELECT Costs FROM Offers WHERE OfferID =@offer", log);
                            getofc3.Parameters.AddWithValue("@offer", 3);
                            log.Open();
                            ofp3 = (int)getofc3.ExecuteScalar();
                            a.of33 = ofp3;
                            log.Close();
                            //Four Offer description 
                            SqlCommand getofd4 = new SqlCommand("SELECT Description FROM Offers WHERE OfferID =@offer", log);
                            getofd4.Parameters.AddWithValue("@offer", 4);
                            log.Open();
                            ofd4 = (string)getofd4.ExecuteScalar();
                            us.of4 = ofd4;
                            log.Close();

                            //Four Offer Costs
                            SqlCommand getofc4 = new SqlCommand("SELECT Costs FROM Offers WHERE OfferID =@offer", log);
                            getofc4.Parameters.AddWithValue("@offer", 4);
                            log.Open();
                            ofp4 = (int)getofc4.ExecuteScalar();
                            a.of44 = ofp4;
                            log.Close();

                            //Five offer description
                            SqlCommand getofd5 = new SqlCommand("SELECT Description FROM Offers WHERE OfferID =@offer", log);
                            getofd5.Parameters.AddWithValue("@offer", 5);
                            log.Open();
                            ofd5 = (string)getofd4.ExecuteScalar();
                            us.of5 = ofd5;
                            log.Close();

                            //Five offer Costs
                            SqlCommand getofc5 = new SqlCommand("SELECT Costs FROM Offers WHERE OfferID =@offer", log);
                            getofc5.Parameters.AddWithValue("@offer", 5);
                            log.Open();
                            ofp5 = (int)getofc4.ExecuteScalar();
                            a.of55 = ofp5;
                            log.Close();

                            Form well = new Wellcome();
                            well.Show();
                            this.Hide();
                        }
                        else
                        {
                            lblErrorPassword.Text= "Incorrect password";
                            lblErrorPassword.TextAlign = ContentAlignment.MiddleCenter;

                        }

                    }
                    else
                    {//Doesn't exist
                        log.Close();
                        
                        lblErrorEmail.Text= "Email doesn't exist";
                        lblErrorPassword.Text = "";

                    }

                    log.Open();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                log.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            txtlogemail.Focus();
        }
    }
}
