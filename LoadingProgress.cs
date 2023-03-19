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
    public partial class LoadingProgress : Form
    {
        public LoadingProgress()
        {
            InitializeComponent();
        }

        private void LoadingProgress_Load(object sender, EventArgs e)
        {
            loadingPercent.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void loading_Tick(object sender, EventArgs e)
        {
            if (loadingBar.Value < 100)
            {
                loadingBar.Value += 1;
                percent.Text=loadingBar.Value.ToString() +"%";
            }
            else
            {
                loadingPercent.Stop();
                dangnhap view=new dangnhap();
                view.Show();
                this.Hide();
            }
        }
    }
}
