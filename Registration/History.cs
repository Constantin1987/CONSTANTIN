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
    public partial class History : Form
    {   
        SqlConnection log = new SqlConnection(us.conn);


        SqlCommand add = new SqlCommand();
        int total;


        bool drag = false;
        Point start_point = new Point(0, 0);

        public History()
        {

            InitializeComponent();

            

            MaximizeBox = false;


            add.Connection = log;
            add.CommandType = CommandType.Text;
            add.CommandText = "SELECT OfferID,Description,Costs,Purchase_Date From Transactions WHERE Email= '" + us.emaill + "'";
            try
            {

                SqlCommand getofc1 = new SqlCommand("SELECT Costs FROM Transactions WHERE Email= @Email", log);
                getofc1.Parameters.AddWithValue("@Email", us.emaill);
                log.Open();

                total = (int)getofc1.ExecuteScalar();

                log.Close();
                log.Open();
                SqlDataReader searchcust = add.ExecuteReader();
                if (searchcust.HasRows)
                {
                    while (searchcust.Read())
                    {
                        ListViewItem item = new ListViewItem(searchcust["Description"].ToString());
                        item.SubItems.Add(searchcust["Costs"] + "Points".ToString());
                        item.SubItems.Add(searchcust["Purchase_Date"].ToString());
                        listView1.Items.Add(item);
                        
                        label1.Hide();

                    }

                }
                else
                {
                    label1.Show();
                }
            }

            catch 

            {
                


                log.Close();

            }

        }

        private void History_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.enigmaDBDataSet.Transactions);




        }

        private void txthistory_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //go to Menu form 
            Form login = new Menu();
            login.Show();
            this.Hide();

        }

        private void lblFname_Click(object sender, EventArgs e)
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

        private void btnhistory_Click(object sender, EventArgs e)
        {

            //go to user Account 
            Form history = new Profile();
            history.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
