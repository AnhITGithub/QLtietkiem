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
using System.Data.Linq.Mapping;

namespace QLtietkiem
{
    public partial class QLnhanvien : Form
    {
        SqlConnection sqlcon = null;
        string link = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True;MultipleActiveResultSets=true";
        SqlCommand cmd = new SqlCommand();
        public QLnhanvien()
        {
            InitializeComponent();
        }
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


        private void back_Click(object sender, EventArgs e)
        {
            index view = new index();
            view.Show();
            this.Hide();
        }

        private void QLnhanvien_Load_1(object sender, EventArgs e)
        {
            checkketnoi();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblNhanVien";
            cmd.Connection = sqlcon;
            SqlDataReader reader= cmd.ExecuteReader();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            reader.Close();
            dt.Clear();
            adapter.Fill(dt);
            table.DataSource = dt;
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read() == true)
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    reader.Close();
            //    dt.Clear();
            //    adapter.Fill(dt);
            //    table.DataSource = dt;
            //}
            sqlcon.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "sMaNV", "*" + txtSearch.Text + "*");
            (table.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

        }

     

        private void lammoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            textboxTK.Text = "";
            txtMK.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            txtMaNV.Focus();
        }

        private void them_Click(object sender, EventArgs e)
        {
            checkketnoi();
            string manv = txtMaNV.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string tk = textboxTK.Text.Trim();
            string mk = txtMK.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diachi = txtDiachi.Text.Trim();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tblNhanVien " +
                "values('" + manv + "', N'" + tennv + "', '" + tk + "', " +
                "'" + mk + "', '" + sdt + "', N'" + diachi + "')";

            //cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
            //cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
            //cmd.Parameters.AddWithValue("@taikhoan", textboxTK.Text);
            //cmd.Parameters.AddWithValue("@matkhau", txtMK.Text);
            //cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
            //cmd.Parameters.AddWithValue("@diachi", txtDiachi.Text);


            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from tblNhanVien";
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read() == true)
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    reader.Close();
            //    dt.Clear();
            //    adapter.Fill(dt);
            //    table.DataSource = dt;
            //}
            //sqlcon.Close();
            QLnhanvien_Load_1(sender, e);
            lammoi_Click(sender, e);
        }

        private void sua_Click(object sender, EventArgs e)
        {
            checkketnoi();
            string manv = txtMaNV.Text.Trim();
            string tennv = txtTenNV.Text.Trim();
            string tk = textboxTK.Text.Trim();
            string mk = txtMK.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diachi = txtDiachi.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tblNhanVien " +
                "set sMaNV='" + manv + "',sTenNV=N'" + tennv + "'," +
                "sTaiKhoan='" + tk + "',sMatKhau='" + mk + "',sSDT='" + sdt + "'," +
                "sDiaChi=N'" + diachi + "' where sMaNV='" + manv + "'";

            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            QLnhanvien_Load_1(sender, e);
            lammoi_Click(sender, e);

        }

        private void xoa_Click(object sender, EventArgs e)
        {
            checkketnoi();
            string manv = txtMaNV.Text.Trim();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tblNhanVien where sMaNV='" + manv + "'";
            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            QLnhanvien_Load_1(sender, e);
            lammoi_Click(sender, e);

        }

        private void print_Click(object sender, EventArgs e)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblNhanVien";
            SqlDataAdapter da=new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable("Bảng in thông tin nhân viên");
            da.Fill(dt);
            // Gán nguồn dữ liệu cho Crystal Report
            rptQLnhanvien baocao=new rptQLnhanvien();
            baocao.SetDataSource(dt);
            // Hiển thị báo cáo
            BaocaoNV b=new BaocaoNV();
            b.crystalReportViewerNV.ReportSource = baocao;
            b.ShowDialog();
        }

        private void table_Click(object sender, EventArgs e)
        {
            int curow = table.CurrentRow.Index;
            txtMaNV.Text = table.Rows[curow].Cells[0].Value.ToString();
            txtTenNV.Text = table.Rows[curow].Cells[1].Value.ToString();
            textboxTK.Text = table.Rows[curow].Cells[2].Value.ToString();
            txtMK.Text = table.Rows[curow].Cells[3].Value.ToString();
            txtSDT.Text = table.Rows[curow].Cells[4].Value.ToString();
            txtDiachi.Text = table.Rows[curow].Cells[5].Value.ToString();

            //table.CurrentRow.Selected = true;
            //txtMaNV.Text = table.Rows[e.RowIndex].Cells["sMaNV"].Value.ToString();
            //txtTenNV.Text = table.Rows[e.RowIndex].Cells["sTenNV"].Value.ToString();
            //textboxTK.Text = table.Rows[e.RowIndex].Cells["sTaiKhoan"].Value.ToString();
            //txtMK.Text = table.Rows[e.RowIndex].Cells["sMatKhau"].Value.ToString();
            //txtSDT.Text = table.Rows[e.RowIndex].Cells["sSDT"].Value.ToString();
            //txtDiachi.Text = table.Rows[e.RowIndex].Cells["sDiaChi"].Value.ToString();
        }
    }
}
