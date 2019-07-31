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
    public partial class Statistics : Form
    {
        SqlConnection custom = new SqlConnection(us.conn);

        SqlCommand update = new SqlCommand();
        SqlCommand insert = new SqlCommand();

        public Statistics()
        {
            InitializeComponent();

       
        }
        private void tableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.enigmaDBDataSet);

        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            if (us.dtime == DateTime.Now)
            {

                update.Connection = custom;
                update.CommandType = CommandType.Text;
                update.CommandText = "UPDATE  Total SET Total_Customers ='" + a.totcust.ToString() + "' WHERE Date_Cust = '" + us.dtime.ToString("dd/MM/yyyy") + "'";
                custom.Open();
                update.ExecuteNonQuery();

                custom.Close();

                SqlCommand commFill = new SqlCommand("SELECT * FROM Total", custom);
                SqlDataAdapter adapt = new SqlDataAdapter(commFill);
                custom.Open();
                DataTable dt = new DataTable();

                adapt.Fill(dt);
                totalDataGridView.DataSource = dt;
                custom.Close();
            }
            else
            {
                    try
                    {

                    if (us.dtime < DateTime.Today)
                    {

                        insert.CommandType = CommandType.Text;
                        insert.CommandText = "INSERT Total (Date_Cust,Total_Customers)VALUES('" + us.dtime.ToString("dd/MM/yyyy") + "','" + a.totcust + "')";
                        insert.Connection = custom;
                        custom.Open();
                        insert.ExecuteNonQuery();
                        custom.Close();
                        custom.Close();

                        SqlCommand commFill = new SqlCommand("SELECT * FROM Total", custom);
                        SqlDataAdapter adapt = new SqlDataAdapter(commFill);
                        custom.Open();
                        DataTable dt = new DataTable();

                        adapt.Fill(dt);
                        totalDataGridView.DataSource = dt;
                        custom.Close();
                    }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        custom.Close();
                    
                }
            }


            //TODO: This line of code loads data into the 'enigmaDBDataSet.Total' table. You can move, or remove it, as needed.
            this.totalTableAdapter.Fill(this.enigmaDBDataSet.Total);
            // TODO: This line of code loads data into the 'enigmaDBDataSet.Table' table. You can move, or remove it, as needed.
             this.tableTableAdapter.Fill(this.enigmaDBDataSet.Table);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            chart1.Series["Customers"].XValueMember = "Date_Cust";
            chart1.Series["Customers"].YValueMembers = "Total_Customers";
            chart1.DataSource = enigmaDBDataSet.Total;
            chart1.DataBind();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand commFill = new SqlCommand("SELECT * FROM Total", custom);
            SqlDataAdapter adapt = new SqlDataAdapter(commFill);

            DataTable dt = new DataTable();

            adapt.Fill(dt);

            totalDataGridView.DataSource = dt;

        }
    }
}
