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

    public partial class CustomerDb : Form
    {    
        SqlConnection custom = new SqlConnection(us.conn);
        
        SqlCommand search = new SqlCommand();
        SqlCommand update = new SqlCommand();
        SqlCommand delete = new SqlCommand();

        bool drag = false;
        Point start_point = new Point(0, 0);

        
        public CustomerDb()
        {
            InitializeComponent();
         
        }

        private void CustomerDb_Load(object sender, EventArgs e)
        {
            //Update datatatable 

            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);
            DataTable dt = new DataTable();
            custom.Open();
            adapt.Fill(dt);
            customerDataGridView.DataSource = dt;            
            custom.Close();

            // TODO: This line of code loads data into the 'enigmaDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.enigmaDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Offers' table. You can move, or remove it, as needed.
            this.offersTableAdapter.Fill(this.enigmaDBDataSet.Offers);
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.enigmaDBDataSet.Customer);

        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // click on datatable row and will show the customer details in text boxes 

            txtsearch.Text = customerDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            lblEmail.Text = customerDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtTBfirstname.Text = customerDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtTbsurname.Text = customerDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtTBpoints.Text = customerDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtTBpassword.Text = customerDataGridView.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void txtsearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtsearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search for customer EmaIL
            if (txtsearch.Text == ""||txtsearch.Text== "Enter customer Email")
            {
                MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtsearch.Text = "";
            }
            else
            {
                search.Connection = custom;
                search.CommandType = CommandType.Text;
                search.CommandText = "SELECT * From Customer WHERE Email ='" + txtsearch.Text + "' ";
                custom.Open();

                SqlDataReader searchcust = search.ExecuteReader();
                if (searchcust.HasRows)
                {
                    while (searchcust.Read())
                    {
                        lblEmail.Text = Convert.ToString(searchcust["Email"]);
                        txtTBfirstname.Text = Convert.ToString(searchcust["Firstname"]);
                        txtTbsurname.Text = Convert.ToString(searchcust["Surname"]);
                        txtTBpoints.Text = Convert.ToString(searchcust["Points"]);
                        txtTBpassword.Text = Convert.ToString(searchcust["Password"]);
                    }
                }
                else
                {
                    MessageBox.Show("Customern not Found");
                    txtsearch.Text = "";

                }
                custom.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clear all text boxes 
            txtTBfirstname.Clear();
            txtTbsurname.Clear();
            txtTBpoints.Clear();
            txtTBpassword.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Update customer details
            try
                    {
                int poinholder;
                poinholder = int.Parse(txtTBpoints.Text);
                if (txtTBfirstname.Text == "" || txtTbsurname.Text == "" || txtTBpoints.Text == "" || txtTBpassword.Text == ""|| poinholder <= 0)
                {
                    
                    MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtTBpoints.Text = "";
                }
                  else                 
                    {
                    
                    update.Connection = custom;
                    update.CommandType = CommandType.Text;
                    update.CommandText = "UPDATE Customer SET Firstname ='" + txtTBfirstname.Text + "',Surname ='" + txtTbsurname.Text + "', Points ='" + txtTBpoints.Text + "', Password ='" + txtTBpassword.Text + "' WHERE Email ='" + lblEmail.Text + "'";
                    custom.Open();
                    update.ExecuteNonQuery();

                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", custom);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);

                    customerDataGridView.DataSource = dt;

                    MessageBox.Show("Updated successfully ");
                    txtsearch.Clear();
                    lblEmail.Text = "";
                    txtTBfirstname.Clear();
                    txtTbsurname.Clear();
                    txtTBpoints.Clear();
                    txtTBpassword.Clear();
                     }
                  }
               catch 
                    {
                MessageBox.Show("Please enter a valid  Amount");
                txtTBpoints.Text = "";
            }
                  finally
                    {
                        custom.Close();
                    }
            }
        private void button3_Click_1(object sender, EventArgs e)
        {
            //go to  Transaction menu and Update the table 

            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);

            Form trans = new TransactionDb();
            trans.Show();
            this.Hide();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete  a customer and all details
            if (lblEmail.Text == "Email" || txtTBfirstname.Text == "" || txtTbsurname.Text == "" || txtTBpoints.Text == "" || txtTBpassword.Text == "")
            {
                MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {


                try
                {
                    delete.Connection = custom;
                    delete.CommandType = CommandType.Text;
                    delete.CommandText = "DELETE from Transactions WHERE Email ='" + txtsearch.Text + "'";

                    custom.Open();
                    delete.ExecuteNonQuery();
                    custom.Close();

                    delete.Connection = custom;
                    delete.CommandType = CommandType.Text;
                    delete.CommandText = "DELETE from Customer WHERE Email ='" + txtsearch.Text + "'";
                    custom.Open();
                    delete.ExecuteNonQuery();



                    SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", custom);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);

                    customerDataGridView.DataSource = dt;

                    MessageBox.Show("Deleted successfully ");
                    txtsearch.Clear();
                    lblEmail.Text = "";
                    txtTBfirstname.Clear();
                    txtTbsurname.Clear();
                    txtTBpoints.Clear();
                    txtTBpassword.Clear();


                }
                catch (Exception err)
                {
                    MessageBox.Show("Unable to Delete,\r\n" + err.Message);

                }
                finally
                {
                    custom.Close();
                }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //go to Offer menu

            Form offers = new OffersDb();
            offers.Show();
            this.Hide();
        }

        private void customerDataGridView_DoubleClick(object sender, EventArgs e)
        {



        }

        private void button3_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //go to Login menu
            Form st = new Start1();
            st.Show();
            this.Hide();

        }

        private void button3_Click_3(object sender, EventArgs e)
        {

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
        private void timer1_Tick(object sender, EventArgs e)
        {
            int count;
            count = customerDataGridView.RowCount -1;
            lblcount.Text = "Total customers :  " +count.ToString();

            lbltotal.Text = "0";
            for (int i = 0; i < customerDataGridView.Rows.Count - 1; i++)

            {
                lbltotal.Text = Convert.ToString(int.Parse(lbltotal.Text) + int.Parse(customerDataGridView.Rows[i].Cells[3].Value.ToString()));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Update datatable
            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);

            customerDataGridView.DataSource = dt;

        }
        private void button7_Click(object sender, EventArgs e)
        {
            //search customers using datetime calendar
            search.Connection = custom;
            search.CommandType = CommandType.Text;
            search.CommandText = "SELECT * From Customer WHERE Registration_Date ='" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' ";
            custom.Open();

            SqlDataAdapter custdisplay = new SqlDataAdapter(search);
            DataTable offerrs = new DataTable();
            custdisplay.Fill(offerrs);
            customerDataGridView.DataSource = offerrs;
            custom.Close();
        }

        private void txtTBpoints_TextChanged(object sender, EventArgs e)
        {
            // can't enter a "0" before number like 011
            try
            {
                txtTBpoints.Text = txtTBpoints.Text.TrimStart('0');

                if (txtTBpoints.Text.StartsWith("0"))
                    txtTBpoints.Text = '0' + txtTBpoints.Text;
            }
            catch
            {
                MessageBox.Show("Please enter a valid  Amount");
                txtTBpoints.Clear();
            }
        }

        private void txtTBpoints_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dont allow to enter characters or spaces 
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
               
                e.Handled = false;
                MessageBox.Show("Please enter a valid value");
                txtTBpoints.Text = "";

            }
        }

        private void lbltotal_Click(object sender, EventArgs e)
        {

        }
    }
}
