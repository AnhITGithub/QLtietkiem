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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void LoạiTiếtKiệmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loaitietkiem loaitietkiem = new loaitietkiem();
            loaitietkiem.Show();
            this.Hide();
        }

        private void quảnLíNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //QLnhanvien QLnhanvien = new QLnhanvien();
            //QLnhanvien.Show();
            //this.Hide();
            authenticator view=new authenticator();
            view.Show();
            this.Hide();
        }

        private void quảnLíHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLsotietkiem sotietkiem = new QLsotietkiem();
            sotietkiem.Show();
            this.Hide();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon HoaDon = new HoaDon();
            HoaDon.Show();
            this.Hide();
        }

        //private void thoat_Click(object sender, EventArgs e)
        //{
        //    DialogResult dialog = MessageBox.Show("Thoát chương trình !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if(dialog==DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }
        //    else
        //    {
        //        //do nothing
        //    }
        //}

 

        private void index_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        //private void back_Click(object sender, EventArgs e)
        //{
        //    DialogResult dialogResult = MessageBox.Show("Trở về màn hình đăng nhập !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //    if (dialogResult == DialogResult.Yes)
        //    {
        //        dangnhap login = new dangnhap();
        //        login.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        ///do nothing
        //    }
        //}

    

        private void quảnLíKháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            QLthongtinKH view=new QLthongtinKH();
            view.Show();
            this.Hide();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Trở về màn hình đăng nhập !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                dangnhap login = new dangnhap();
                login.Show();
                this.Hide();
            }
            else
            {
                ///do nothing
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Thoát chương trình !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                //do nothing
            }
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            anh.Image = dsAnh.Images[i];
            if (i == dsAnh.Images.Count-1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
            
        }
    }
}
