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
    public partial class Menu : Form
    {  
        SqlConnection log = new SqlConnection(us.conn);

        SqlCommand add = new SqlCommand();
        SqlCommand insert = new SqlCommand();

        bool drag = false;
        Point start_point = new Point(0, 0);

        DateTime dtime = DateTime.Now;
        DateTime ttime = DateTime.Now;
        

        public Menu()
        {

            InitializeComponent();
            MaximizeBox = false;

            
            int pointHolder;
            pointHolder = (int)Math.Floor(d.point);
            
            label5.Text = us.of1;
            lbl20.Text = a.of11.ToString();
            label2.Text = us.of2;
            lbl500.Text = a.of22.ToString();
            label3.Text = us.of3;
            lbl1000.Text = a.of33.ToString();
            label4.Text = us.of4;
            lbl2000.Text = a.of44.ToString();

            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);


        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //go to history 
            Form history = new History();
            history.Show();
            this.Hide();
        }

        private void btnPoints_Click(object sender, EventArgs e)
        {
            Form add = new addpoints();
            add.Show();
            this.Hide();

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void lblpoints_Click(object sender, EventArgs e)
        {

        }

        private void ch20_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void btnregregister_Click(object sender, EventArgs e)

        {
            //go to Account 
            Form history = new Profile();
            history.Show();
            this.Hide();
            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);
        }
        private void ch500_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ch1000_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ch2000_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // make a purchase  of 20 points  
            

            if (d.point <=a.of11||d.point<=a.minim1)
            {

                MessageBox.Show("Sorry you need to have the minimum  " + a.minim1 + " points in your account !!");

            }
            else
            {
                try
                {

                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);

                    d.point -= a.of11;
                  
                    
                    add.Connection = log;
                    add.CommandType = CommandType.Text;
                    add.CommandText = "UPDATE  Customer SET Points ='" + d.point + "' WHERE Email = '" + us.emaill + "'";
                    log.Open();
                    add.ExecuteNonQuery();
                    string dime = dtime.ToString("dd/MM/yyyy");
                    string ime = ttime.ToString("H:mm:ss");
                    insert.CommandType = CommandType.Text;
                    insert.CommandText = "INSERT Transactions (Email,OfferID,Costs,Description,Purchase_Date,Purchase_Time)VALUES('" + us.emaill + "','" + 1 + "','" + a.of11 + "','" + us.of1 + "','" + dime + "','" + ime + "')";
                    insert.Connection = log;

                    insert.ExecuteNonQuery();

                    

                    Form thank = new thankyou();
                    thank.Show();
                    this.Hide();

                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            finally
            {
                log.Close();

            }
        }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            // make a purchase  of 500 points  
            if (d.point <= a.minim2 || d.point<=a.of22)
            {

                MessageBox.Show("Sorry you need to have the minimum  " + a.minim2 + " points in your account !!");

            }
            else
            {

                try
                {


                    d.point -= a.of22;
                    add.Connection = log;
                    add.CommandType = CommandType.Text;
                    add.CommandText = "UPDATE  Customer SET Points ='" + d.point + "' WHERE Email = '" + us.emaill + "'";
                    log.Open();
                    add.ExecuteNonQuery();
                    string dime = dtime.ToString("dd/MM/yyyy");
                    string ime = ttime.ToString("H:mm:ss");
                    insert.CommandType = CommandType.Text;
                    insert.CommandText = "INSERT Transactions (Email,OfferID,Costs,Description,Purchase_Date,Purchase_Time)VALUES('" + us.emaill+ "','" + 2 + "','" + a.of22 + "','" + us.of2 + "','" + dime + "','" + ime + "')";
                    insert.Connection = log;

                    insert.ExecuteNonQuery();


                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);

                    
                    Form thank = new thankyou();
                    thank.Show();
                    this.Hide();
              

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    log.Close();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // make a purchase  of 1000 points  
            if (d.point <= a.minim3 || d.point<=a.of33)
            {

                MessageBox.Show("Sorry you need to have the minimum  " + a.minim3 + " points in your account !!");

            }
            else
            {


                try
                {
                    d.point -= a.of33;
                    add.Connection = log;
                    add.CommandType = CommandType.Text;
                    add.CommandText = "UPDATE  Customer SET Points ='" + d.point + "' WHERE Email = '" + us.emaill + "'";
                    log.Open();
                    add.ExecuteNonQuery();
                    string dime = dtime.ToString("dd/MM/yyyy");
                    string ime = ttime.ToString("H:mm:ss");
                    insert.CommandType = CommandType.Text;
                    insert.CommandText = "INSERT Transactions (Email,OfferID,Costs,Description,Purchase_Date,Purchase_Time)VALUES('" + us.emaill + "','" + 3 + "','" + a.of33 + "','" + us.of3 + "','" + dime + "','" + ime + "')";
                    insert.Connection = log;

                    insert.ExecuteNonQuery();

                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);
                    Form thank = new thankyou();
                    thank.Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            // make a purchase  of 2000 points  
            if (d.point <= a.minim4 || d.point<=a.of44)
            {
                MessageBox.Show("Sorry you need to have the minimum  " + a.minim4 + " points in your account !!");
            }
            else
            {


                try
                {
                    d.point -= a.of44;
                    add.Connection = log;
                    add.CommandType = CommandType.Text;
                    add.CommandText = "UPDATE  Customer SET Points ='" + d.point + "' WHERE Email = '" + us.emaill + "'";
                    log.Open();
                    add.ExecuteNonQuery();
                    string dime = dtime.ToString("dd/MM/yyyy");
                    string ime = ttime.ToString("H:mm:ss");
                    insert.CommandType = CommandType.Text;
                    insert.CommandText = "INSERT Transactions (Email,OfferID,Costs,Description,Purchase_Date,Purchase_Time)VALUES('" + us.emaill + "','" + 4 + "','" + a.of44 + "','" + us.of4 + "','" + dime + "','" + ime + "')";
                    insert.Connection = log;

                    insert.ExecuteNonQuery();

                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", log);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);
                    Form thank = new thankyou();
                    thank.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
