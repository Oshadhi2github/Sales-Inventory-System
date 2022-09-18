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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=supermarket; User Id=sa; Password=opk");
        SqlCommand cmd;
        SqlDataReader read;
        string sql;

        private void button1_Click(object sender, EventArgs e)
        {
            string pname = txtPname.Text;
            string price = txtPrice.Text;
            string discount = txtDis.Text;

            sql = "insert into products(pname,price,discount) values(@pname,@price,@discount)";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Added");
            con.Close();

            txtPname.Clear();
            txtPrice.Clear();
            txtDis.Clear();
            txtPname.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
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
                txtPname.Text = dr["pname"].ToString();
                txtPrice.Text = dr["price"].ToString();
                txtDis.Text = dr["discount"].ToString();

            }
            else
            {
                MessageBox.Show("Product ID Not Found");
            }

            con.Close();


        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            string pname = txtPname.Text;
            string price = txtPrice.Text;
            string discount = txtDis.Text;
            string pID = txtID.Text;

            sql = "update products set pname= @pname ,price = @price,  discount =  @discount where id = @pid";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@discount", discount);
            cmd.Parameters.AddWithValue("@pID", pID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated");
            con.Close();
            txtPname.Clear();
            txtPrice.Clear();
            txtDis.Clear();
            txtPname.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }
    }
}
