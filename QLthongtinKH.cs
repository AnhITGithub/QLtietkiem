using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLtietkiem
{
    public partial class QLthongtinKH : Form
    {
        SqlConnection sqlcon = null;
        string link = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True;MultipleActiveResultSets=true";
        SqlCommand cmd = new SqlCommand();

        public QLthongtinKH()
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void QLthongtinKH_Load(object sender, EventArgs e)
        {
            checkketnoi();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblKhachHang";
            cmd.Connection = sqlcon;
            SqlDataReader reader = cmd.ExecuteReader();
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

        private void them_Click(object sender, EventArgs e)
        {
            
           
            checkketnoi();
            

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into tblKhachHang " +
                "values('" + txtMaKH.Text.Trim() + "'," +
                " N'" + txtTenKH.Text.Trim() + "'," +
                " '" + txtGioitinh.Text.Trim() + "', " +
                "'" + DateTime.Parse(txtNgaysinh.Text.Trim()) + "'," +
                " '" + txtCMT.Text.Trim() + "'," +
                " N'" + txtDiachi.Text.Trim() + "'," +
                " '" + txtSDT.Text.Trim()+ "')";
            //cmd.CommandText = "insert into tblKhachHang values(@sMaKH,@sTenKH,@sGioitinh,@tNgaysinh,@sCMT,@sDiachi,@sSDT)";

            //cmd.Parameters.AddWithValue("@sMaKH", txtMaKH.Text);
            //cmd.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
            //cmd.Parameters.AddWithValue("@sGioitinh", txtGioitinh.Text);
            //cmd.Parameters.AddWithValue("@tNgaysinh", DateTime.Parse(txtNgaysinh.Text));
            //cmd.Parameters.AddWithValue("@sCMT", txtCMT.Text);
            //cmd.Parameters.AddWithValue("@sDiachi", txtDiachi.Text);
            //cmd.Parameters.AddWithValue("@sSDT", txtSDT.Text);


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
            QLthongtinKH_Load(sender, e);
            huyTTKH_Click(sender, e);
        }

        private void huyTTKH_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtGioitinh.Text = "";
            txtNgaysinh.Text = "";
            txtCMT.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            txtMaKH.Focus();
        }

        private void timMaKH_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "sMaKh", "*" + timMaKH.Text + "*");
            (table.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void timTenKH_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "sTenKH", "*" + timTenKH.Text + "*");
            (table.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

  

        private void sua_Click(object sender, EventArgs e)
        {
            checkketnoi();
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update tblKhachHang " +
                "set sMaKH='"+txtMaKH.Text.Trim()+"'," +
                "sTenKH=N'"+txtTenKH.Text.Trim()+"'," +
                "sGioitinh='"+txtGioitinh.Text.Trim()+"'," +
                "tNgaysinh='"+DateTime.Parse(txtNgaysinh.Text.Trim())+"'," +
                "sCMT='"+txtCMT.Text.Trim()+"'," +
                "sDiachi=N'"+txtDiachi.Text.Trim()+"'," +
                "sSDT='"+txtSDT.Text.Trim()+"' " +
                "where sMaKH='"+txtMaKH.Text.Trim()+"'";

        

            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            QLthongtinKH_Load(sender, e);
            huyTTKH_Click(sender, e);
        }

        private void lammoi_Click(object sender, EventArgs e)
        {
            timMaKH.Clear();
            timTenKH.Clear();
            timMaKH.Focus();
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            checkketnoi();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from tblKhachHang where sMaKH='"+ txtMaKH.Text.Trim() + "'";
            
            cmd.Connection = sqlcon;
            cmd.ExecuteNonQuery();
            QLthongtinKH_Load(sender, e);
            huyTTKH_Click(sender, e);
        }

        private void print_Click(object sender, EventArgs e)
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblKhachHang";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable("Bảng in thông tin khách hàng");
            da.Fill(dt);
            // Gán nguồn dữ liệu cho Crystal Report
            rptQLKhachHang baocao = new rptQLKhachHang();
            baocao.SetDataSource(dt);
            // Hiển thị báo cáo
            BaoCaoKH b = new BaoCaoKH();
            b.crystalReportViewerKH.ReportSource = baocao;
            b.ShowDialog();
        }

        private void back_Click(object sender, EventArgs e)
        {
            index view = new index();
            view.Show();
            this.Hide();
        }

        private void table_Click(object sender, EventArgs e)
        {
            int cursor = table.CurrentRow.Index;
            txtMaKH.Text = table.Rows[cursor].Cells[0].Value.ToString();
            txtTenKH.Text = table.Rows[cursor].Cells[1].Value.ToString();
            txtGioitinh.Text = table.Rows[cursor].Cells[2].Value.ToString();
            txtNgaysinh.Text = table.Rows[cursor].Cells[3].Value.ToString();
            txtCMT.Text = table.Rows[cursor].Cells[4].Value.ToString();
            txtDiachi.Text = table.Rows[cursor].Cells[5].Value.ToString();
            txtSDT.Text = table.Rows[cursor].Cells[6].Value.ToString();
        }
    }
}
