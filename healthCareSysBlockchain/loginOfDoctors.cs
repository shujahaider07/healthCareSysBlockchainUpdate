using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class loginOfDoctors : Form
    {

        public static string text;
        public loginOfDoctors()
        {
            InitializeComponent();
        }
        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        private void loginOfDoctors_Load(object sender, EventArgs e)
        {
            bindDoctors();
           // comboBox1.SelectedText = "Select Doctor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            String qry = "select * from doctoradd where name = @name and password = @password";
            SqlCommand cmd = new SqlCommand(qry,sql);
            cmd.Parameters.AddWithValue("@name",usertxt.Text);
            cmd.Parameters.AddWithValue("@password",passtxt.Text);
            text = usertxt.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {

                MessageBox.Show("Login");
                DoctorPanel dp = new DoctorPanel();
                dp.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Login Failed Wrong Password");
            }

            sql.Close();
            

        }
  
        public void bindDoctors()
        {

            SqlConnection sql = new SqlConnection(cs);
            String qry = "select * from doctoradd";
            SqlDataAdapter da = new SqlDataAdapter(qry,sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = dt;  


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
