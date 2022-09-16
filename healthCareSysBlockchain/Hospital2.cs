using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class Hospital2 : Form
    {
        public Hospital2()
        {
            InitializeComponent();
        }

        private void Request_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = true;
            //label2.Visible = true;  
            //pictureBox2.Visible = true; 
            //label3.Visible = true;
            //pictureBox3.Visible=true;  
            //label5.Visible= true;   
            //pictureBox4.Visible=true;   
            //label6.Visible=true;    
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Addpatient p = new Addpatient();
            p.ShowDialog();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Viewpatient v = new Viewpatient();
            v.ShowDialog(); 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ViewDoctors vd = new ViewDoctors();
            vd.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ViewOfTreatedpatients tp = new ViewOfTreatedpatients();
            tp.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MasterDashboard m = new MasterDashboard();
            m.Show();
            this.Hide();
        }
    }
}
