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
    public partial class OffersDb : Form
    {
        SqlConnection custom = new SqlConnection(us.conn);

        SqlCommand update = new SqlCommand();
        SqlCommand search = new SqlCommand();

        bool drag = false;
        Point start_point = new Point(0, 0);


        public OffersDb()
        {
            InitializeComponent();
            MaximizeBox = false;
            SqlCommand commFill = new SqlCommand("SELECT * FROM Offers", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            custom.Open();
            adapt.Fill(dt);
            custom.Close();

            offersDataGridView.DataSource = dt;



        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clear all textboxes 
            txtofferprice.Clear();
            txtofferdescription.Clear();
            lblofferID.Text = "";
        }

        private void offersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.offersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.enigmaDBDataSet);

        }

        private void OffersDb_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Minimum' table. You can move, or remove it, as needed.
            this.minimumTableAdapter.Fill(this.enigmaDBDataSet.Minimum);
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Offers' table. You can move, or remove it, as needed.
            this.offersTableAdapter.Fill(this.enigmaDBDataSet.Offers);

        }

        private void offersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblofferID.Text = offersDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            txtofferprice.Text = offersDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtofferdescription.Text = offersDataGridView.SelectedRows[0].Cells[2].Value.ToString();


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Update a Offers
                try
                {
                int poinholder;
                poinholder = int.Parse(txtofferprice.Text);
                if (lblofferID.Text == "OfferID" || txtofferdescription.Text == "" || txtofferprice.Text == ""|| poinholder <= 0)
                {
                    MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtofferprice.Text = "";
                }
                else
                {
                    update.Connection = custom;
                    update.CommandType = CommandType.Text;
                    update.CommandText = "UPDATE Offers SET Costs ='" + txtofferprice.Text + "',Description ='" + txtofferdescription.Text + "' WHERE OfferID ='" + lblofferID.Text + "'";
                    custom.Open();
                    update.ExecuteNonQuery();

                    SqlCommand commFill = new SqlCommand("SELECT * FROM Offers", custom);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);

                    offersDataGridView.DataSource = dt;

                    MessageBox.Show("Updated successfully ");
                    lblofferID.Text = "";
                    txtofferdescription.Clear();
                    txtofferprice.Clear();
                    txtsearch1.Clear();
                }
                }
                catch 
                {
                MessageBox.Show("Please enter a valid  Amount");
                txtofferprice.Text = "";

            }
                finally
                {
                    custom.Close();
                }
            }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //go to login form 
            Form st = new Start1();
            st.Show();
            this.Hide();
        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            //search for Offers 
            if (txtsearch1.Text == ""||txtsearch1.Text=="Enter product ID")
            {
                MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtsearch1.Text = "";
            }
            else
            {

                search.Connection = custom;
                search.CommandType = CommandType.Text;
                search.CommandText = "SELECT * From Offers WHERE OfferID ='" + txtsearch1.Text + "' ";
                custom.Open();
                SqlDataReader searchcust = search.ExecuteReader();

                if (searchcust.HasRows)
                {
                    while (searchcust.Read())
                    {
                        lblofferID.Text = Convert.ToString(searchcust["OfferID"]);
                        txtofferprice.Text = Convert.ToString(searchcust["Costs"]);
                        txtofferdescription.Text = Convert.ToString(searchcust["Description"]);

                    }
                }
                else
                {
                    MessageBox.Show("Offer not Found");
                    txtsearch1.Text = "";
                }
                custom.Close();
            }
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            //update a minimum required points 
            try
            {
                int poinholder;
                poinholder = int.Parse(txtchange.Text);
                if (txtchange.Text == ""|| poinholder <= 0)
                {
                    MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtchange.Text = "";
                }
                else
                {
                    update.Connection = custom;
                    update.CommandType = CommandType.Text;
                    update.CommandText = "UPDATE Minimum SET Amount ='" + txtchange.Text + "'WHERE MinimumID = '" + label6.Text + "'";

                    custom.Open();
                    update.ExecuteNonQuery();


                    SqlCommand commFill = new SqlCommand("SELECT * FROM Minimum", custom);
                    SqlDataAdapter adapt = new SqlDataAdapter(commFill);

                    DataTable dt = new DataTable();

                    adapt.Fill(dt);

                    minimumDataGridView.DataSource = dt;

                    MessageBox.Show("Updated successfully ");
                    txtchange.Clear();


                }
            }
            catch
            {
                MessageBox.Show("Please valid amount", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtchange.Text = "";


            }
            finally
            {
                custom.Close();
            }
        }

    
        private void minimumDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtchange.Text = minimumDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            label6.Text= minimumDataGridView.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            //go to Transactions menu 
            SqlCommand commFill = new SqlCommand("SELECT * FROM Customer", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);

            Form trans = new TransactionDb();
            trans.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //go to Customer menu
            Form cust = new CustomerDb();
            cust.Show();
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void txtofferprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {

                e.Handled = false;
                MessageBox.Show("Please enter a valid value");
               txtofferprice.Text = "";

            }
        }

        private void txtchange_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {

                e.Handled = false;
                MessageBox.Show("Please enter a valid value");
                txtchange.Text = "";

            }
        }

        private void txtofferprice_TextChanged(object sender, EventArgs e)
        {
            // can't enter a "0" before number like 011
            try
            {
                txtofferprice.Text = txtofferprice.Text.TrimStart('0');

                if (txtofferprice.Text.StartsWith("0"))
                    txtofferprice.Text = '0' + txtofferprice.Text;
            }
            catch
            {
                MessageBox.Show("Please enter a valid  Amount");
                txtofferprice.Clear();
            }
        }

        private void txtchange_TextChanged(object sender, EventArgs e)
        {
            // can't enter a "0" before number like 011
            try
            {
                txtchange.Text = txtchange.Text.TrimStart('0');

                if (txtchange.Text.StartsWith("0"))
                    txtchange.Text = '0' + txtchange.Text;
            }
            catch
            {
                MessageBox.Show("Please enter a valid  Amount");
                txtchange.Clear();
            }
        }

        private void txtsearch1_MouseClick(object sender, MouseEventArgs e)
        {
            txtsearch1.Text = "";
        }
    }
}
