using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace healthCareSysBlockchain
{
    public partial class DoctorPanel : Form

    {
        public static string text;

        public DoctorPanel()
        {
            InitializeComponent();


        }

        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        private void Form1_Load_1(object sender, EventArgs e)
        {
            GetId();
            BindComboBox();
            doctortxt.Text = loginOfDoctors.text;
            textBox1.Text = loginOfDoctors.text;
           // cnicTxt.Text = patient.cnic;

            
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            try
            {
                sql.Open();
                String qry = "insert into patientdiagnose values (@id ,@DoctorName, @Patients,@disease,@prescription , @date )";
                SqlCommand cmd = new SqlCommand(qry, sql);
                cmd.Parameters.AddWithValue("@id", hash.Sha512( Encryptetxt.Text));
                cmd.Parameters.AddWithValue("@DoctorName", doctortxt.Text);
                cmd.Parameters.AddWithValue("@Patients", comboBox1.Text);
                cmd.Parameters.AddWithValue("@disease", Diseasetxt.Text);
                cmd.Parameters.AddWithValue("@prescription", prescriptioTxt.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    var confirm = MessageBox.Show("Are you want to Add Data", "Confirm", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        MessageBox.Show("Sucessfull");
                        BindGrid();
                        GetId();
                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }


                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }



        public void GetId()
        {
            SqlConnection sql = new SqlConnection(cs);
            String qry = "select count(id)+1 from patientdiagnose";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Encryptetxt.Text = dt.Rows[0][0].ToString();

        }

        public void BindComboBox()
        {
            SqlConnection sql = new SqlConnection(cs);
            String qry = "select * from patientdata";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = dt;


        }

        private void label8_Click(object sender, EventArgs e)
        {
            MasterDashboard m = new MasterDashboard();
            m.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MasterDashboard m = new MasterDashboard();
            m.Show();
            this.Hide();
        }


        public void BindGrid()
        {
            SqlConnection sql = new SqlConnection(cs);
            string qry = "select * from patientdiagnose where doctorName  =  '"+textBox1.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(qry,sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
