using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class Viewpatient : Form
    {
        public Viewpatient()
        {
            InitializeComponent();
        }

        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        private void Viewpatient_Load(object sender, EventArgs e)
        {
            bindGrid();

        }
        public void bindGrid()
        {
            SqlConnection sql = new SqlConnection(cs);

            string qry = "select * from patientdata";

          //  string qry = "select patientDiagnose.id , patientData.Name , patientData.Cnic ,  patientDiagnose.Disease , patientDiagnose.Prescription , patientDiagnose.Date  , patientData.pictues  from patientData inner join patientDiagnose on patientData.Name = patientDiagnose.Patients";
            //string qry = "exec sp_bindata";

            sql.Open();

            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(cs);
            String qry = "select * from patientdata where Name like '%" + textBox1.Text + "%' ";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                label3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                pictureBox3.Image = Getphoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Double Click before ID TextField");
            }
        }

        private Image Getphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
