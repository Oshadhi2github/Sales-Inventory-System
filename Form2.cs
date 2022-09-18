using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalesInventory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=supermarket; User Id=sa; Password=opk");
        SqlCommand cmd;
        SqlDataReader read;
        string sql;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pID = txtID.Text;


            sql = "select * from products where id =@pID";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pID", pID);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtpname.Text = dr["pname"].ToString();
                double price = double.Parse(dr["price"].ToString());
                double dis = double.Parse(dr["discount"].ToString());

                double cal = price * dis / 100;
                double discountprice = price - cal;






                txtprice.Text = price.ToString();
                txtdis.Text = discountprice.ToString();

            }
            else
            {
                MessageBox.Show("Product ID Not Found");
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pid = txtID.Text;

            string price = txtprice.Text;
            string discount = txtdis.Text;


            sql = "insert into sales(pid,price,discount) values(@pid,@price,@discount)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added");
            con.Close();
            txtpname.Clear();
            txtprice.Clear();
            txtdis.Clear();
            txtpname.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
