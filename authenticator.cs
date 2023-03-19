using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLtietkiem
{
    public partial class authenticator : Form
    {
        public authenticator()
        {
            InitializeComponent();
        }

        private void authenticator_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (xacthuc.Text == "123")
            {
                QLnhanvien view=new QLnhanvien();
                view.Show();
                this.Hide();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            index view=new index();
            view.Show();
            this.Hide();
        }
    }
}
