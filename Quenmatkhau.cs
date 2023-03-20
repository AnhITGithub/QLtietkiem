using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QLtietkiem
{
    public partial class Quenmatkhau : Form
    {
        string link = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True";
        SqlConnection sqlcon=null;
        DataClasses1DataContext db=new DataClasses1DataContext();

        void checkketnoi()
        {
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(link);
            }
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
        }

        public Quenmatkhau()
        {
            InitializeComponent();
        }



        private void Quenmatkhau_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += change_KeyDown;
        }

        private void back_Click(object sender, EventArgs e)
        {
            dangnhap view=new dangnhap();
            view.Show();
            this.Hide();

        }

        private void change_Click(object sender, EventArgs e)
        {
            checkketnoi();
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "quenmatkhau";
            
            SqlParameter tk=new SqlParameter("@tk", SqlDbType.NVarChar);
            SqlParameter mk = new SqlParameter("@matkhaumoi", SqlDbType.NVarChar);

            tk.Value = txtTK.Text.Trim();
            mk.Value = newMK.Text.Trim();

            cmd.Parameters.Add( tk );
            cmd.Parameters.Add( mk );

            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            if (newMK.Text == confirmMK.Text)
            {
                MessageBox.Show("Thay đổi mật khẩu thành công !", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dangnhap view=new dangnhap();
                view.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thay đổi mật khẩu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void change_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                change_Click(sender, e);
            }
        }

        private void txtTK_KeyUp(object sender, KeyEventArgs e)
        {
            //var st=(from s in db.tblNhanViens where s.sTaiKhoan==txtTK.Text select s).First();
            //var st = new tblNhanVien();
            //var st = from s in db.tblNhanViens where s.sTaiKhoan=txtTK.Text select s.sTaiKhoan;
            //    if ( st.sTaiKhoan == txtTK.Text)
            //    {
            //        signalTK.Text = "OK";
            //        signalTK.ForeColor = System.Drawing.Color.Green;
            //    }
            //    else
            //    {
            //        signalTK.Text = "Không tồn tại !";
            //        signalTK.ForeColor = System.Drawing.Color.Red;
            //    } 
        }

        private void confirmMK_KeyUp(object sender, KeyEventArgs e)
        {
            if(confirmMK.Text==newMK.Text)
            {
                singalMK.Text = "Chuẩn";
                singalMK.ForeColor = System.Drawing.Color.Green;
            }
            if(confirmMK.Text != newMK.Text)
            {
                singalMK.Text = "Chưa trùng !";
                singalMK.ForeColor = System.Drawing.Color.Brown;
            }
            if(confirmMK.Text =="")
            {
                singalMK.Text = "Chưa nhập !";
                singalMK.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (txtTK.Text == "")
            {
                txtTK.Text = "Nhập tài khoản đã được cấp";
                txtTK.ForeColor = Color.Silver;

            }
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            if(txtTK.Text== "Nhập tài khoản đã được cấp")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }
    }
}
