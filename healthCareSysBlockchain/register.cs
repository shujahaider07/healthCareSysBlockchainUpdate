using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

using System.Security.Cryptography;


namespace healthCareSysBlockchain
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private void button1_Click(object sender, EventArgs e)
        {
            Register(textBox2.Text);
        }
   
        public void Register(String text)
        {
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            string qry = "insert into usertbl values (@username , @password , @usertype)";
            SqlCommand cmd = new SqlCommand(qry,sql);
            cmd.Parameters.AddWithValue("@username",textBox1.Text);
            cmd.Parameters.AddWithValue("@password",hash.Sha512(text));
            cmd.Parameters.AddWithValue("@usertype",comboBox1.Text);
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {

                MessageBox.Show("User Registered");
                login d = new login();
                d.Show();
                this.Hide();

            }
            else
            {

            }

            sql.Close();    

        }

        private void button2_Click(object sender, EventArgs e)
        {
            login d = new login();
            d.Show();
            this.Hide();
        }

        private void register_Load(object sender, EventArgs e)
        {
            String[] arr = { "Patient", "Doctor" };
            foreach (var item in arr)
            {

                comboBox1.Items.Add(item);
            }
        }
    }
}
