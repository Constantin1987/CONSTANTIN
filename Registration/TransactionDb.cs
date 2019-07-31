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
    public partial class TransactionDb : Form
    {   
        SqlConnection custom = new SqlConnection(us.conn);

        SqlCommand searchh = new SqlCommand();

        bool drag = false;
        Point start_point = new Point(0, 0);

        public TransactionDb()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void TransactionDb_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.enigmaDBDataSet.Transactions);

            
        }

        private void transactionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.enigmaDBDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search for Customer usin Email
            if (textBox1.Text == ""||textBox1.Text== "Enter customer Email")
            {
                MessageBox.Show("Please enter your details", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox1.Text = "";
            }
            else
            {
                searchh.Connection = custom;
                searchh.CommandType = CommandType.Text;
                searchh.CommandText = "SELECT * From Transactions WHERE Email= '" + textBox1.Text + "'";
                custom.Open();

                SqlDataAdapter custdisplay = new SqlDataAdapter(searchh);
                DataTable offerrs = new DataTable();
                custdisplay.Fill(offerrs);
                transactionsDataGridView.DataSource = offerrs;
                custom.Close();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form st = new Start1();
            st.Show();
            this.Hide();
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnshow_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form offers = new OffersDb();
            offers.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            //Update data table 
            SqlCommand commFill = new SqlCommand("SELECT * FROM Transactions", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);

            transactionsDataGridView.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //search for customers transactions by Date 
            searchh.Connection = custom;
            searchh.CommandType = CommandType.Text;
            searchh.CommandText = "SELECT * From Transactions WHERE Purchase_Date ='" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' ";
            custom.Open();

            SqlDataAdapter custdisplay = new SqlDataAdapter(searchh);
            DataTable offerrs = new DataTable();
            custdisplay.Fill(offerrs);
            transactionsDataGridView.DataSource = offerrs;
            custom.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
