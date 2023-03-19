using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLtietkiem
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();

            hienthi(dataGridViewHD);
            load_cbMaSoTK();
            load_cbMaNV();
            
        }
        public static string sqlcon = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True";
        public static SqlConnection mycon;
        public static SqlCommand com;
        public static SqlDataAdapter ad;
        public static DataTable dt;

        private void load_cbMaSoTK()
        {
            SqlConnection mycon = new SqlConnection(sqlcon);
            string sql1 = "Select * FROM tblSotietkiem";
            SqlDataAdapter ad = new SqlDataAdapter(sql1, mycon);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            cbMaSoTK.DataSource = dt;
            cbMaSoTK.DisplayMember = "sMaSoTK";
        }
        private void load_cbMaNV()
        {
            SqlConnection mycon = new SqlConnection(sqlcon);
            string sql1 = "Select * FROM tblNhanVien";
            SqlDataAdapter ad = new SqlDataAdapter(sql1, mycon);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "sMaNV";
        }

        private void hienthi(DataGridView dataGridViewHD)
        {


            string chuoi = @"select sMaHD,sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui,sKyhan,sPhantram,sTongtien,sTienlai,sMaNV,sTenNV,sNgaylap
                            from tblHoaDon ";
            ad = new SqlDataAdapter(chuoi, sqlcon);
            dt = new DataTable();
            ad.Fill(dt);
            dataGridViewHD.DataSource = dt;
            dataGridViewHD.Columns[0].HeaderText = "MÃ HOÁ ĐƠN";
            dataGridViewHD.Columns[1].HeaderText = "MÃ SỔ TIẾT KIỆM";
            dataGridViewHD.Columns[2].HeaderText = "MÃ KHÁCH HÀNG";
            dataGridViewHD.Columns[3].HeaderText = "TÊN KHÁCH HÀNG";
            dataGridViewHD.Columns[4].HeaderText = "MÃ LOẠI TIẾT KIỆM";
            dataGridViewHD.Columns[5].HeaderText = "LOẠI TIẾT KIỆM";
            dataGridViewHD.Columns[6].HeaderText = "SỐ TIỀN GỬI";
            dataGridViewHD.Columns[7].HeaderText = "NGÀY GỬI";
            dataGridViewHD.Columns[8].HeaderText = "KỲ HẠN";
            dataGridViewHD.Columns[9].HeaderText = "PHẦN TRĂM";
            dataGridViewHD.Columns[10].HeaderText = "TỔNG TIỀN";
            dataGridViewHD.Columns[11].HeaderText = "TIỀN LÃI";
            dataGridViewHD.Columns[12].HeaderText = "MÃ NHÂN VIÊN LẬP";
            dataGridViewHD.Columns[13].HeaderText = "NGƯỜI LẬP";
            dataGridViewHD.Columns[14].HeaderText = "NGÀY LẬP";

        }


        private void bt_them_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection mycon = new SqlConnection(sqlcon))
                {
                    using (SqlCommand com = new SqlCommand("", mycon))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "tblHoaDon_INSERT";
                        if (txtMaHD.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn phải nhập mã hoá đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtMaHD.Focus();
                            return;
                        }
                        if (cbMaSoTK.Text==string.Empty)
                        {
                            MessageBox.Show("Bạn phải chọn mã sổ tiết kiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbMaSoTK.Focus();
                            return;
                        }
                        if (cbMaNV.Text == string.Empty)
                        {
                            MessageBox.Show("Bạn phải chọn mã nhân viên lập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbMaNV.Focus();
                            return;
                        }

                        com.Parameters.AddWithValue("@sMaHD", txtMaHD.Text);
                        com.Parameters.AddWithValue("@sMaSoTK", cbMaSoTK.Text);
                        com.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
                        com.Parameters.AddWithValue("@sSotiengui", txtSotiengui.Text);
                        com.Parameters.AddWithValue("@sTienlai", txtTienlai.Text);
                        com.Parameters.AddWithValue("@sTongtien", txtTongTien.Text);
                        com.Parameters.AddWithValue("@sMaNV", cbMaNV.Text);
                        com.Parameters.AddWithValue("@sMaKH", txtMaKH.Text);
                        com.Parameters.AddWithValue("@sMaLoaiTK", txtMaLoaiTK.Text);
                        com.Parameters.AddWithValue("@sTenLoaiTk", txtTenLoaiTK.Text);
                        com.Parameters.AddWithValue("@sKyhan", txtKyhan.Text);
                        com.Parameters.AddWithValue("@sPhantram", txtPhantram.Text);
                        com.Parameters.AddWithValue("@sNgaygui", DateTime.Parse(txtNgaygui.Text));
                        com.Parameters.AddWithValue("@sNgaylap", DateTime.Parse(dtNgaylap.Text));
                        com.Parameters.AddWithValue("@sTenNV", txtTenNV.Text);
   
                        mycon.Open();
                        int kq=com.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại !", "Thông báo", MessageBoxButtons.OK);
                        }
                        
                        hienthi(dataGridViewHD);
                        bt_F5_Click(sender, e);
                        mycon.Close();

                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
            }

        }


        private void bt_tinhtien_Click(object sender, EventArgs e)
        {
            string tiengui = txtSotiengui.Text.Trim();
            string phantram= txtPhantram.Text.Trim();
            string kyhan= txtKyhan.Text.Trim();

            float a = float.Parse(tiengui);
            float b = float.Parse(phantram);
            float c = float.Parse(kyhan);

            double tienlai = Math.Round(a * b * (c / 365),2);
            double result = Math.Round(tienlai + a,2);
            txtTongTien.Text = result.ToString();
            txtTienlai.Text = tienlai.ToString();
        }

        private void dataGridViewHD_Click(object sender, EventArgs e)
        {
            int curow = dataGridViewHD.CurrentRow.Index;//khaibaobien curow
            txtMaHD.Text = dataGridViewHD.Rows[curow].Cells[0].Value.ToString();
            cbMaSoTK.Text = dataGridViewHD.Rows[curow].Cells[1].Value.ToString();
            txtMaKH.Text = dataGridViewHD.Rows[curow].Cells[2].Value.ToString();
            txtTenKH.Text = dataGridViewHD.Rows[curow].Cells[3].Value.ToString();
            txtMaLoaiTK.Text = dataGridViewHD.Rows[curow].Cells[4].Value.ToString();
            txtTenLoaiTK.Text = dataGridViewHD.Rows[curow].Cells[5].Value.ToString();
            txtSotiengui.Text = dataGridViewHD.Rows[curow].Cells[6].Value.ToString();
            txtNgaygui.Text = dataGridViewHD.Rows[curow].Cells[7].Value.ToString();
            txtKyhan.Text = dataGridViewHD.Rows[curow].Cells[8].Value.ToString();
            txtPhantram.Text = dataGridViewHD.Rows[curow].Cells[9].Value.ToString();
            txtTongTien.Text = dataGridViewHD.Rows[curow].Cells[10].Value.ToString();
            txtTienlai.Text = dataGridViewHD.Rows[curow].Cells[11].Value.ToString();
            cbMaNV.Text = dataGridViewHD.Rows[curow].Cells[12].Value.ToString();
            txtTenNV.Text = dataGridViewHD.Rows[curow].Cells[13].Value.ToString();
            dtNgaylap.Text = dataGridViewHD.Rows[curow].Cells[14].Value.ToString();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection mycon = new SqlConnection(sqlcon))
                {
                    using (SqlCommand com = new SqlCommand("", mycon))
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "tblHoaDon_UPDATE";
                        if (dataGridViewHD.Rows.Count == 0)
                        {
                            MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtMaHD.Text == "") //nếu chưa chọn bản ghi nào
                        {
                            MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                        com.Parameters.AddWithValue("@sMaHD", txtMaHD.Text);
                        com.Parameters.AddWithValue("@sMaSoTK", cbMaSoTK.Text);
                        com.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
                        com.Parameters.AddWithValue("@sSotiengui", txtSotiengui.Text);
                        com.Parameters.AddWithValue("@sTienlai", txtTienlai.Text);
                        com.Parameters.AddWithValue("@sTongtien", txtTongTien.Text);
                        com.Parameters.AddWithValue("@sMaNV", cbMaNV.Text);
                        com.Parameters.AddWithValue("@sMaKH", txtMaKH.Text);
                        com.Parameters.AddWithValue("@sMaLoaiTK", txtMaLoaiTK.Text);
                        com.Parameters.AddWithValue("@sTenLoaiTk", txtTenLoaiTK.Text);
                        com.Parameters.AddWithValue("@sKyhan", txtKyhan.Text);
                        com.Parameters.AddWithValue("@sPhantram", txtPhantram.Text);
                        com.Parameters.AddWithValue("@sNgaygui", DateTime.Parse(txtNgaygui.Text));
                        com.Parameters.AddWithValue("@sNgaylap", DateTime.Parse(dtNgaylap.Text));
                        com.Parameters.AddWithValue("@sTenNV", txtTenNV.Text);
                        mycon.Open();
                        int kq=com.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Sửa thành công !", "Thành công!", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại !", "Thất bại!", MessageBoxButtons.OK);
                        }
                        
                        mycon.Close();
                        hienthi(dataGridViewHD);
                        bt_F5_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa dữ liệu thất bại", "ERROR!", MessageBoxButtons.OK);
            }


        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection mycon = new SqlConnection(sqlcon))
            {
                using (SqlCommand com = new SqlCommand("", mycon))
                {
                    if (dataGridViewHD.Rows.Count == 0)
                    {
                        MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    com.CommandType = CommandType.StoredProcedure;

                    com.CommandText = "tblHoaDon_DELETE";
                    com.Parameters.AddWithValue("@sMaHD", txtMaHD.Text);
               
                    mycon.Open();
                    int kq=com.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công !", "Thành công!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !", "Thất bại!", MessageBoxButtons.OK);
                    }
                    mycon.Close();
                    hienthi(dataGridViewHD);
                    bt_F5_Click(sender,e);

                }
            }
        }

        private void bt_F5_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            cbMaSoTK.Text = string.Empty;
            txtMaKH.Clear();
            txtTenKH.Clear(); 
            txtMaLoaiTK.Clear(); 
            txtTenLoaiTK.Clear();
            txtSotiengui.Clear();
            txtNgaygui.Clear();
            txtKyhan.Clear();
            txtPhantram.Clear();
            txtTongTien.Clear();
            txtTienlai.Clear();
            cbMaNV.Text = string.Empty; 
            txtTenNV.Clear();
            dtNgaylap.Refresh(); 

        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            index view = new index();
            view.Show();
            this.Hide();
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            com = mycon.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from tblNhanVien where sMaNV='" + cbMaNV.Text.Trim() + "'";
            com.ExecuteNonQuery();
            dt = new DataTable();
            ad = new SqlDataAdapter(com);
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtTenNV.Text = dr["sTenNV"].ToString();
            }
        }

        private void cbMaSoTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            com = mycon.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from tblSotietkiem where sMaSoTK='" + cbMaSoTK.Text.Trim() + "'";
            com.ExecuteNonQuery();
            dt = new DataTable();
            ad = new SqlDataAdapter(com);
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtMaKH.Text = dr["sMaKH"].ToString();
                txtTenKH.Text = dr["sTenKH"].ToString();
                txtSotiengui.Text = dr["sSotiengui"].ToString();
                txtNgaygui.Text = dr["sNgaygui"].ToString();
                txtTenLoaiTK.Text = dr["sTenLoaiTK"].ToString();
                txtMaLoaiTK.Text = dr["sMaLoaiTk"].ToString();
            }
        }

        private void txtMaLoaiTK_TextChanged(object sender, EventArgs e)
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            com = mycon.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from tblLoaitietkiem where sMaLoaiTK='" + txtMaLoaiTK.Text.Trim() + "'";
            com.ExecuteNonQuery();
            dt = new DataTable();
            ad = new SqlDataAdapter(com);
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtKyhan.Text = dr["sKyhan"].ToString();
                txtPhantram.Text = dr["sPhantram"].ToString();
             
            }
        }
    }
}
