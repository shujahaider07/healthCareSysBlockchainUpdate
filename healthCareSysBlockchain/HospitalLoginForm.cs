using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;



namespace healthCareSysBlockchain
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        String usertype;
        private void default_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Select Option";



        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection sql = new SqlConnection(cs);

            sql.Open();
            String qry = "select * from usertbl where username = '" + textBox2.Text + "' and password = '" + textBox1.Text + "'";

            SqlCommand cmd = new SqlCommand(qry, sql);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);


            if (conn1.IsExist(qry) == true)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    usertype = dt.Rows[0][3].ToString().Trim();

                    if (usertype == "h1")
                    {
                        Hospita1Dashboard d = new Hospita1Dashboard();
                        d.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Not Matched");
                    }


                }



                if (comboBox1.SelectedIndex == 1)
                {
                    usertype = dt.Rows[0][3].ToString().Trim();

                    if (usertype == "h2")
                    {
                        Hospital2 h2 = new Hospital2();
                        h2.Show();
                        this.Hide();
                    }




                    if (comboBox1.SelectedIndex == 2)
                    {
                        usertype = dt.Rows[0][3].ToString().Trim();

                        if (usertype == "h3")
                        {
                            DoctorPanel f = new DoctorPanel();
                            f.Show();
                            this.Hide();
                        }


                    }

                }
                sql.Close();



            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


