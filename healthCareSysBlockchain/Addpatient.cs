using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class Addpatient : Form
    {
        public Addpatient()
        {
            InitializeComponent();
        }
        public static string cnic;
        ASCIIEncoding byteConverter = new ASCIIEncoding();
        RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
        byte[] plaintext;
        byte[] encryptedText;

        conn conn1 = new conn();
        String cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        static public byte[] Encryption(byte[] Data, RSAParameters RSAkey, bool DoOAEPPadding)
        {


            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAkey); encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;


            }




            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }


        static public byte[] Decryption(byte[] Data, RSAParameters RSAkey, bool DoOAEPPadding)
        {

            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAkey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);

                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }



        private void patient_Load(object sender, EventArgs e)
        {

            GetId();
            //bindDoctors();


        }

       


        public void InsertPaData(string text)
        {
            SqlConnection sql = new SqlConnection(cs);
            try {
                String qry = "insert into patientdata (name , age  , cnic , id , phone,PICTUES) values(@name , @age , @cnic , @id , @phone, @pictues)";


                sql.Open();
                SqlCommand cmd = new SqlCommand(qry, sql);
               // var image = new ImageConverter().ConvertTo(pictureBox2.Image, typeof(Byte[]));
                cmd.Parameters.AddWithValue("@name", nametxt.Text);
                cmd.Parameters.AddWithValue("@age", Agetxt.Text);
                cmd.Parameters.AddWithValue("@cnic", cnicTxt.Text);
                cmd.Parameters.AddWithValue("@Phone", phoneTxt.Text);
                cmd.Parameters.AddWithValue("@id", hash.Sha512(text));
                cmd.Parameters.AddWithValue("@pictues",SavePhoto());
                cnic = cnicTxt.Text;
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Patient Added");
                    GetId();
                    clearDAta();

                    //plaintext = byteConverter.GetBytes(textBox1.Text);
                    //encryptedText = Encryption(plaintext, rSA.ExportParameters(false), false);
                    //Encryptetxt.Text = byteConverter.GetString(encryptedText);

                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private object SavePhoto()
        {
            
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                return ms.GetBuffer();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertPaData(Encryptetxt.Text);
           
            
        }

        private void Encrypted_Click(object sender, EventArgs e)
        {
            //encryptedData ew = new encryptedData();
            //ew.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //byte[] decText = Decryption(encryptedText, rSA.ExportParameters(true), false);
            //decryptedtxt.Text = byteConverter.GetString(decText);
        }

        public void GetId()
        {
            try
            {


                SqlConnection sql = new SqlConnection(cs);
                String qry = "select count(id)+1 from patientdata";

                sql.Open();
                SqlDataAdapter da = new SqlDataAdapter(qry, sql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Encryptetxt.Text = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        public void clearDAta()
        {
            nametxt.Text = "";
            Agetxt.Text = "";
            cnicTxt.Text = "";
            phoneTxt.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void phoneTxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cnicTxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Agetxt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phoneTxt_KeyPress_1(object sender, KeyPressEventArgs e)
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
    }
}
