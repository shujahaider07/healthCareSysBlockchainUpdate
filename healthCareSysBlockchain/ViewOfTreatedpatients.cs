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



namespace healthCareSysBlockchain
{
    public partial class ViewOfTreatedpatients : Form
    {
        public ViewOfTreatedpatients()
        {
            InitializeComponent();
        }
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void TreatmentOfpatients_Load(object sender, EventArgs e)
        {
            bindGrid();
        }
   
    
    public void bindGrid()
        {
            SqlConnection sql = new SqlConnection(cs);
            String qry = "select * from patientdiagnose";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            String qry = "select * from patientdiagnose where patients like '%" + textBox1.Text + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
