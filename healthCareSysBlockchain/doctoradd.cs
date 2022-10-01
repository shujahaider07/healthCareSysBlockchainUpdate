using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace healthCareSysBlockchain
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void admin_Load(object sender, EventArgs e)
        {
           
            GetID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            SqlConnection sql = new SqlConnection(cs);
            
            sql.Open();
            String qry = "insert into doctoradd values (@id,@name , @age , @specilization,@password,@picture)";
          
            SqlCommand cmd = new SqlCommand(qry, sql);
            cmd.Parameters.AddWithValue("@name", nametxt.Text);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@age", agetxt.Text);
            cmd.Parameters.AddWithValue("@specilization", spectxt.Text);
            cmd.Parameters.AddWithValue("@password", passwordtxt.Text);
            cmd.Parameters.AddWithValue("@picture",SavePhoto());
            int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    var confirm = MessageBox.Show("Are you want to Add Data", "Confirm", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        MessageBox.Show("Data Inserted");
                        GetID();
                        ClearData();

                    }
                    else
                    {
                        MessageBox.Show("Failed");
                    }

                }
                sql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void GetID()
        {
            SqlConnection sql = new SqlConnection(cs);
            String qry = "select count(id)+1 from doctoradd";
            SqlDataAdapter da = new SqlDataAdapter(qry, sql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            textBox1.Text = dt.Rows[0][0].ToString();
        }
        public void ClearData()
        {
            nametxt.Text = "";
            passwordtxt.Text = "";
            agetxt.Text = "";
            spectxt.Text = "";
        }

        //public void Insert(String Filename, byte[] image)
        //{
        //    SqlConnection sql = new SqlConnection(cs);
        //    sql.Open();
        //    String qry = "insert into doctoradd (picture,filename ) values (@picture,@Filename) ";
        //    SqlCommand cmd = new SqlCommand(qry, sql);
        //    cmd.Parameters.AddWithValue("@Filename", textBox2.Text);
        //    cmd.Parameters.AddWithValue("@picture", image);
        //    cmd.ExecuteNonQuery();
        //    sql.Close();
        //}


        //public void loadData()
        //{
        //    SqlConnection sql = new SqlConnection(cs);

        //    String qry = "select * from doctoradd";
        //    SqlDataAdapter da = new SqlDataAdapter(qry, sql);
        //    DataTable dt = new DataTable("picture");
        //    da.Fill(dt);
        //    dataGridView1.DataSource = dt;


        //}
        //byte[] ConvertImageToBytes(Image img)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    return ms.ToArray();

        //}
        //public Image ConvertByteArrayToImage(byte[] data)
        //{

        //    MemoryStream ms = new MemoryStream(data);
        //    return Image.FromStream(ms);



        //}

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "images |*.jpeg; *.jpg;  *.png;";
                ofd.FileName = "";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = new Bitmap(ofd.FileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void agetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void spectxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
