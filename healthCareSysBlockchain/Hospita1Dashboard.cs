using System


































































































    ;
using System.Windows.Forms;

namespace healthCareSysBlockchain
{
    public partial class Hospita1Dashboard : Form
    {
        public Hospita1Dashboard()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void aDDPATIENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Addpatient p = new Addpatient();
            p.ShowDialog();
        }



        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Addpatient p = new Addpatient();
            p.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Viewpatient vw = new Viewpatient();
            vw.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ViewDoctors v = new ViewDoctors();
            v.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            a.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ViewOfTreatedpatients tp = new ViewOfTreatedpatients();
            tp.ShowDialog();
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
    }
}
