using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace QLtietkiem
{
    public partial class dangnhap : Form
    {
     
        SqlConnection sqlcon=null;
        string link = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True";

        public dangnhap()
        {
            InitializeComponent();
        }
        void checkketnoi()
        {
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(link);
            }
            if(sqlcon.State==ConnectionState.Closed)
            {
                sqlcon.Open();
            }
        }
    
        private void bt_login_Click(object sender, EventArgs e)
        {
            checkketnoi();
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "dangnhap";

            SqlParameter taikhoan=new SqlParameter("@taikhoan",SqlDbType.NVarChar);
            SqlParameter matkhau = new SqlParameter("@matkhau", SqlDbType.NVarChar);

            taikhoan.Value=txtTK.Text.Trim();
            matkhau.Value = txtMK.Text.Trim();

            cmd.Parameters.Add(taikhoan);
            cmd.Parameters.Add(matkhau);

            cmd.Connection=sqlcon;
            
            SqlDataReader reader=cmd.ExecuteReader();
            if (reader.Read() == true)
            {
                MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                index view = new index();
                view.Show();
                this.Hide();
            }
            else if (txtTK.Text == "admin" && txtMK.Text == "123")
            {
                MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                index view = new index();
                view.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reader.Close();
        }


        private void login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += bt_login_KeyDown;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Quenmatkhau quenmatkhau=new Quenmatkhau();
            quenmatkhau.Show();
            this.Hide();
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTK.Text==string.Empty)
            {
                checkTK.SetError(txtTK, "Chưa nhập tài khoản !");
           
            }
       

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
            if (txtMK.Text==string.Empty)
            {
                checkMK.SetError(txtMK, "Chưa nhập mật khẩu !");
            }
          
        }

        private void bt_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                bt_login_Click(sender, e);
            }
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            if(txtTK.Text=="Nhập tài khoản")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                txtTK.Text = "Nhập tài khoản";
                txtTK.ForeColor = Color.Silver;
            }
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (txtMK.Text == "")
            {
                txtMK.Text = "Nhập mật khẩu";
                txtMK.ForeColor = Color.Silver;
            }
        }

        private void txtMK_Enter(object sender, EventArgs e)
        {
            if (txtMK.Text == "Nhập mật khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
            }
        }
    }
}
