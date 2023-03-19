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
    public partial class QLsotietkiem : Form
    {
        public QLsotietkiem()
        {
            InitializeComponent();
            hienSTK(dataGridViewSTK);
        }


        public string sqlcon = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True";
        public SqlConnection mycon;
        public SqlCommand com;
        public SqlDataAdapter ad;
        public DataTable dt;

        void load_cbLoaiTK()
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            var com = new SqlCommand("load_cbLoaiTK", mycon);
            com.CommandType = CommandType.StoredProcedure;
            var dr=com.ExecuteReader();
            dt=new DataTable();
            dt.Load(dr);
            dr.Dispose();
            ma_loaitk.DisplayMember = "sMaLoaiTK";
            ma_loaitk.DataSource = dt;
            mycon.Close();
        }

        void load_cbMaKH()
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            var com = new SqlCommand("load_cbMaKH", mycon);
            com.CommandType = CommandType.StoredProcedure;
            var dr = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            Ma_kh.DisplayMember = "sMaKH";
            Ma_kh.DataSource = dt;
            mycon.Close();
        }
        private void hienSTK(DataGridView dataGridViewSTK)
        {

            string chuoi = @"select sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui
                            from tblSotietkiem";
            ad = new SqlDataAdapter(chuoi, sqlcon);
            dt = new DataTable();
            ad.Fill(dt);
            dataGridViewSTK.DataSource = dt;
            dataGridViewSTK.Columns[0].HeaderText = "MÃ SỔ TK";
            dataGridViewSTK.Columns[1].HeaderText = "MÃ KH";
            dataGridViewSTK.Columns[2].HeaderText = "TÊN KH";
            dataGridViewSTK.Columns[3].HeaderText = "MÃ LOẠI TK";
            dataGridViewSTK.Columns[4].HeaderText = "LOẠI TK";
            dataGridViewSTK.Columns[5].HeaderText = "SỔ TIỀN GỬI";
            dataGridViewSTK.Columns[6].HeaderText = "NGÀY GỬI";
            
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            

                if (MaSo_tk.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã sổ tiết kiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MaSo_tk.Focus();
                    return;
                }
                if (Ma_kh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã kháchh hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ten_kh.Focus();
                    return;
                }
                if (ma_loaitk.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã loại tiết kiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ten_kh.Focus();
                    return;
                }
                if (sotien_gui.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số tiền gửi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sotien_gui.Focus();
                    return;
                }

                string sql1 = "insert into tblSotietkiem(sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui)" +
                "values('"+MaSo_tk.Text.Trim()+"'," +
                "'"+Ma_kh.Text.Trim()+"'," +
                "N'"+ten_kh.Text.Trim()+"'," +
                "'"+ma_loaitk.Text.Trim()+"'," +
                "N'"+ten_loaitk.Text.Trim()+"'," +
                "'"+sotien_gui.Text.Trim()+"'," +
                "'"+DateTime.Parse(ngay_gui.Text.Trim())+"')";
                mycon = new SqlConnection(sqlcon);
                com = new SqlCommand(sql1, mycon);
                 ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridViewSTK.DataSource = dt;
                MessageBox.Show("Thêm thành công ", "thông báo");
                hienSTK(dataGridViewSTK);
                bt_huy_Click(sender, e);
                mycon.Close();
            
        }

        private void bt_huy_Click(object sender, EventArgs e)
        {
            MaSo_tk.Clear();
            Ma_kh.Text = "";
            ten_kh.Clear();
            sotien_gui.Clear();
            ma_loaitk.Text = "";
            ten_loaitk.Clear();
            ngay_gui.Refresh();
            MaSo_tk.Focus();
        }

        private void dataGridViewSTK_Click(object sender, EventArgs e)
        {
            int curow = dataGridViewSTK.CurrentRow.Index;//khaibaobien curow
            MaSo_tk.Text = dataGridViewSTK.Rows[curow].Cells[0].Value.ToString();
            Ma_kh.Text = dataGridViewSTK.Rows[curow].Cells[1].Value.ToString();
            ten_kh.Text = dataGridViewSTK.Rows[curow].Cells[2].Value.ToString();
            ma_loaitk.Text = dataGridViewSTK.Rows[curow].Cells[3].Value.ToString();
            ten_loaitk.Text = dataGridViewSTK.Rows[curow].Cells[4].Value.ToString();
            sotien_gui.Text = dataGridViewSTK.Rows[curow].Cells[5].Value.ToString();
            ngay_gui.Text = dataGridViewSTK.Rows[curow].Cells[6].Value.ToString();
            
        }
        private void bt_sua_Click(object sender, EventArgs e)
        {

            string sql = "update tblSotietkiem " +
                "set sMaSoTK='"+MaSo_tk.Text.Trim()+"'," +
                "sMaKH='"+Ma_kh.Text.Trim()+"'," +
                "sTenKH=N'"+ten_kh.Text.Trim()+"'," +
                "sMaLoaiTK='"+ma_loaitk.Text.Trim()+"'," +
                "sTenLoaiTK=N'"+ten_loaitk.Text.Trim()+"'," +
                "sSotiengui='"+sotien_gui.Text.Trim()+"'," +
                "sNgaygui='"+DateTime.Parse(ngay_gui.Text.Trim())+"'" +
                "where sMaSoTK='"+ MaSo_tk.Text.Trim() + "'";
            try
            {
                mycon = new SqlConnection(sqlcon);
                mycon.Open();
                com = new SqlCommand(sql, mycon);
                com.ExecuteNonQuery();
                MessageBox.Show("'Sửa thành công !", "thành công!", MessageBoxButtons.OK);
                bt_huy_Click(sender, e);
                hienSTK(dataGridViewSTK);
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa dữ liệu thất bại", "ERROR!", MessageBoxButtons.OK);
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string sql = "delete tblSotietkiem where sMaSoTk='" + MaSo_tk.Text.Trim() + "'";
            try
            {
                mycon = new SqlConnection(sqlcon);
                mycon.Open();
                com = new SqlCommand(sql, mycon);
                com.ExecuteNonQuery();
                MessageBox.Show("'Xóa thành công !", "thành công!", MessageBoxButtons.OK);   
                bt_huy_Click(sender, e);
                hienSTK(dataGridViewSTK);
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa dữ liệu thất bại", "ERROR!", MessageBoxButtons.OK);
            }
        }

        

        private void bt_timma_Click(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "sMaSoTK", "*" + tim_masotk.Text + "*");
            (dataGridViewSTK.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void bt_huytk_Click(object sender, EventArgs e)
        {
            tim_masotk.Clear();
            hienSTK(dataGridViewSTK);
        }

        private void QLsotietkiem_Load(object sender, EventArgs e)
        {
            load_cbMaKH();
            load_cbLoaiTK();
        }

        private void bt_in_Click(object sender, EventArgs e)
        {
            //kết xuất nguồn dữ liệu cho Report
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            string sql = @"select sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui
                            from tblSotietkiem ";
            com = new SqlCommand(sql, mycon);
            ad.SelectCommand = com;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            rptQLSotietkiem baocao = new rptQLSotietkiem();
            baocao.SetDataSource(dt);
            BaoCaoSOTK sotk = new BaoCaoSOTK();
            sotk.crystalReportViewerSOTK.ReportSource = baocao;
            sotk.ShowDialog();
        }

        private void Ma_kh_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            com = mycon.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from tblKhachHang where sMaKH='" + Ma_kh.Text.Trim() + "'";
            com.ExecuteNonQuery();
            dt=new DataTable();
            ad = new SqlDataAdapter(com);
            ad.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                ten_kh.Text = dr["sTenKH"].ToString();
            }
        }

        private void ma_loaitk_SelectedIndexChanged(object sender, EventArgs e)
        {
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            com = mycon.CreateCommand();
            com.CommandType = CommandType.Text;
            com.CommandText = "select * from tblLoaitietkiem where sMaLoaiTK='" + ma_loaitk.Text.Trim() + "'";
            com.ExecuteNonQuery();
            dt = new DataTable();
            ad = new SqlDataAdapter(com);
            ad.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ten_loaitk.Text = dr["sTenLoaiTK"].ToString();
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
