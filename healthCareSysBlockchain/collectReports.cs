using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class collectReports : Form
    {
        public collectReports()
        {
            InitializeComponent();
            bindGrid();
        }
        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void button1_Click(object sender, EventArgs e)
        {


            BindDAta();

        }

        public void BindDAta()
        {
            SqlConnection sql = new SqlConnection(cs);
            try
            {
                string qry = "select * from patientdiagnose where id = '" + textBox1.Text + "' ";

                //   string qry1 = "select patientDiagnose.id , patientData.Name , patientData.Cnic ,  patientDiagnose.Disease , patientDiagnose.Prescription , patientDiagnose.Date  , patientData.pictues  from patientData inner join patientDiagnose on patientData.Name = patientDiagnose.Patients where patientDiagnose.id = '" + textBox1.Text + "'";

                SqlDataAdapter da = new SqlDataAdapter(qry, sql);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                doctortxt.Text = dt.Rows[0]["doctorName"].ToString();
                patienttxt.Text = dt.Rows[0]["patients"].ToString();
                Diseasetxt.Text = dt.Rows[0]["Disease"].ToString();
                prescriptioTxt.Text = dt.Rows[0]["prescription"].ToString();


                label1.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label4.Visible = true;
                doctortxt.Visible = true;
                patienttxt.Visible = true;
                Diseasetxt.Visible = true;
                prescriptioTxt.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        public void bindGrid()
        {
            SqlConnection sql = new SqlConnection(cs);
            sql.Open();
            //   String qry = "select patientDiagnose.id , patientData.Name , patientData.Cnic ,  patientDiagnose.Disease , patientDiagnose.Prescription , patientDiagnose.Date  , patientData.pictues  from patientData inner join patientDiagnose on patientData.Name = patientDiagnose.Patients ";


            string qry = "select patientDiagnose.id , patientData.Name , patientData.Cnic ,  patientDiagnose.Disease , patientDiagnose.Prescription , patientDiagnose.Date  , patientData.pictues as Picture from patientData inner join patientDiagnose on patientData.Name = patientDiagnose.Patients where patientDiagnose.id = '" + textBox2.Text + "'";


            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Image Getphoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void collectReports_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                pictureBox2.Image = Getphoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
                label9.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Double Click on Before ID Column");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.newpic;
                Image img = bmp;

                e.Graphics.DrawImage(img, 100, 20, 600, 300);

                e.Graphics.DrawString("ID :" + textBox1.Text, new Font("Microsoft YaHei", 12, FontStyle.Bold), Brushes.Black, new Point(30, 350));
                e.Graphics.DrawString("Patient Name :" + patienttxt.Text, new Font("Microsoft YaHei", 15, FontStyle.Bold), Brushes.Black, new Point(30, 400));
                e.Graphics.DrawString("DOCTOR NAME :" + doctortxt.Text, new Font("Microsoft YaHei", 15, FontStyle.Bold), Brushes.Black, new Point(30, 450));
                e.Graphics.DrawString("TIME :" + DateTime.Now, new Font("Microsoft YaHei", 15, FontStyle.Bold), Brushes.Black, new Point(30, 500));
                e.Graphics.DrawString("DATE :" + DateTime.Now, new Font("Microsoft YaHei", 15, FontStyle.Bold), Brushes.Black, new Point(30, 550));
               
                

                e.Graphics.DrawString("----------------------------------------------------------------------------------------------------", new Font
                ("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 600));


                e.Graphics.DrawString("Disease :" + Diseasetxt.Text, new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(30, 650));
                e.Graphics.DrawString("Prescription :" + prescriptioTxt.Text, new Font("Arial", 25, FontStyle.Bold), Brushes.Black, new Point(30, 720));
                //e.Graphics.DrawString("DATE :" + DateTime.Now, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 400));
                //e.Graphics.DrawString("Prescription :" + DateTime.Now, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 430));
                //e.Graphics.DrawString("----------------------------------------------------------------------------------------------------", new Font
                //("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 480));




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




            //e.Graphics.DrawString("Doctor Name", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 520));

            //e.Graphics.DrawString("Patient", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(250, 520));

            //e.Graphics.DrawString("Disease", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(450, 520));

            //e.Graphics.DrawString("Prescription", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(650, 520));


            //if (dataGridView1.Rows.Count > 0)
            //{

            //    try
            //    {

            //        int gap = 610;
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {

            //            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap));
            //            gap = gap + 30;
            //        }
            //    }
            //    catch
            //    {

            //    }

            //}

            //if (dataGridView1.Rows.Count > 0)
            //{

            //    try
            //    {

            //        int gap1 = 610;
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {

            //            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(250, gap1));
            //            gap1 = gap1 + 30;
            //        }
            //    }
            //    catch
            //    {

            //    }

            //}




            //if (dataGridView1.Rows.Count > 0)
            //{

            //    try
            //    {

            //        int gap2 = 610;
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {

            //            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(450, gap2));
            //            gap2 = gap2 + 30;
            //        }
            //    }
            //    catch
            //    {

            //    }

            //}


            //if (dataGridView1.Rows.Count > 0)
            //{

            //    try
            //    {

            //        int gap3 = 610;
            //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //        {

            //            e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(650, gap3));
            //            gap3 = gap3 + 30;
            //        }
            //    }
            //    catch
            //    {

            //    }

            //}

            //int subtotalPrint = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    subtotalPrint = subtotalPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);


            //}

            //e.Graphics.DrawString("Subtotal: " + subtotalPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 800));



            //int taxPrint = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    taxPrint = taxPrint + Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);


            //}

            //e.Graphics.DrawString("Tax: " + taxPrint.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 830));






            //int finalamountAdd = 0;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    finalamountAdd = finalamountAdd + Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);


            //}

            //e.Graphics.DrawString("Final Amount: " + finalamountAdd.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 860));


        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
