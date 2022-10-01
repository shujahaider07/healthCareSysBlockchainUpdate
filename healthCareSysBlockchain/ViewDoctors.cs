using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class ViewDoctors : Form
    {
        public ViewDoctors()
        {
            InitializeComponent();
            bindGrid();
        }

        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        private void ViewDoctors_Load(object sender, EventArgs e)
        {
            bindGrid();



        }

        public void bindGrid()
        {
            try
            {
                SqlConnection sql = new SqlConnection(cs);

                string qry = "select * from doctoradd";

                sql.Open();

                SqlDataAdapter da = new SqlDataAdapter(qry, sql);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
                DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
                dgv.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 30;

                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(cs);
                String qry = "select * from  doctoradd where Name like '%" + textBox1.Text + "%' ";
                SqlDataAdapter da = new SqlDataAdapter(qry, sql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                pictureBox3.Image = Getphoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
                label3.Text = " " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Double Click on Before ID Column");
            }
        }

        private Image Getphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
