using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom.Compiler;

namespace QLtietkiem
{
    public partial class loaitietkiem : Form
    {
        public loaitietkiem()
        {
            InitializeComponent();
            hienthi(dataGridView1);
        }
        
        public static string sqlcon = @"Data Source=DESKTOP-7N23OPA\HQTCSDL;Initial Catalog=QLtietkiem;Integrated Security=True";
        public static SqlConnection mycon;
        public static SqlCommand com;
        public static SqlDataAdapter ad;
        public static DataTable dt;


        private void hienthi(DataGridView dataGridView1)
        {
            
            string chuoi=@"Select * FROM tblLoaitietkiem";
            ad = new SqlDataAdapter(chuoi,sqlcon);
            dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "MÃ LOẠI TK";
            dataGridView1.Columns[1].HeaderText = "TÊN LOẠI TK";
            dataGridView1.Columns[2].HeaderText = "PHẦN TRĂM";
            dataGridView1.Columns[3].HeaderText = "KỲ HẠN";

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
                        com.CommandText = "tblLoaitietkiem_INSERT";
                        if (TenLoaiTK.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn phải nhập Tên TK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TenLoaiTK.Focus();
                            return;
                        }

                        if (Phantram.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn phải nhập phần trăm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TenLoaiTK.Focus();
                            return;
                        }
                       
                        if (Kyhan.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn phải nhập kỳ hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TenLoaiTK.Focus();
                            return;
                        }


                      
                        com.Parameters.AddWithValue("@MaLoaiTK", MaLoaiTK.Text);
                        com.Parameters.AddWithValue("@TenLoaiTK", TenLoaiTK.Text);
                        com.Parameters.AddWithValue("@Phantram", Phantram.Text);
                        com.Parameters.AddWithValue("@Kyhan", Kyhan.Text);                 
                        mycon.Open();
                        com.ExecuteNonQuery();                       
                        MessageBox.Show("Thêm thành công ", "thông báo");
                        hienthi(dataGridView1);
                        mycon.Close();
                       
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int curow = dataGridView1.CurrentRow.Index;//khaibaobien curow
            MaLoaiTK.Text = dataGridView1.Rows[curow].Cells[0].Value.ToString();
            TenLoaiTK.Text = dataGridView1.Rows[curow].Cells[1].Value.ToString();
            Phantram.Text = dataGridView1.Rows[curow].Cells[2].Value.ToString();
            Kyhan.Text = dataGridView1.Rows[curow].Cells[3].Value.ToString();

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
                        com.CommandText = "tblLoaitietkiem_UPDATE";
                        if (dataGridView1.Rows.Count == 0)
                        {
                            MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (MaLoaiTK.Text == "") //nếu chưa chọn bản ghi nào
                        {
                            MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (TenLoaiTK.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                        {
                            MessageBox.Show("Bạn chưa nhập tên TK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (Phantram.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                        {
                            MessageBox.Show("Bạn chưa nhập phần trăm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                       
                        if (Kyhan.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                        {
                            MessageBox.Show("Bạn chưa nhập kỳ hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        com.Parameters.AddWithValue("@MaLoaiTK", MaLoaiTK.Text);
                        com.Parameters.AddWithValue("@TenLoaiTK", TenLoaiTK.Text);
                        com.Parameters.AddWithValue("@Phantram", Phantram.Text);
                        
                        com.Parameters.AddWithValue("@Kyhan", Kyhan.Text);
                        mycon.Open();                     
                        com.ExecuteNonQuery();
                        MessageBox.Show("'Sửa thành công !", "thành công!", MessageBoxButtons.OK);
                        mycon.Close();
                        hienthi(dataGridView1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa dữ liệu thất bại", "ERROR!", MessageBoxButtons.OK);
            }
        }

        private void bt_delete_Click(object sender, EventArgs e)
        {
            string sql = "delete tblLoaitietkiem where sMaLoaiTK='" + MaLoaiTK.Text + "'";
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MaLoaiTK.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                mycon = new SqlConnection(sqlcon);
                mycon.Open();
                com = new SqlCommand(sql, mycon);
                com.ExecuteNonQuery();
                MessageBox.Show("'Xóa thành công !", "thành công!", MessageBoxButtons.OK);
                mycon.Close();
                hienthi(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa dữ liệu thất bại", "ERROR!", MessageBoxButtons.OK);
            }
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            MaLoaiTK.Clear();
            TenLoaiTK.Clear();
            Phantram.Clear();
            Kyhan.Text = "";
            MaLoaiTK.Focus();
            
        }

        //private void bt_close_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel) ==DialogResult.OK) 
        //    {
        //        this.Close();
        //    }    
        //}

       

        private void Timma_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "sMaLoaiTK", "*" + Timma.Text + "*");
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void Timten_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "sTenLoaiTK", "*" + Timten.Text + "*");
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void Huytim_Click(object sender, EventArgs e)
        {
            Timma.Clear();
            Timten.Clear();
        }



        private void bt_in_Click(object sender, EventArgs e)
        {
            //kết xuất nguồn dữ liệu cho Report
            mycon = new SqlConnection(sqlcon);
            mycon.Open();
            string sql = @"Select * FROM tblLoaitietkiem ";
            com = new SqlCommand(sql, mycon);
            ad.SelectCommand = com;
            DataTable dt = new DataTable();
            ad.Fill(dt);
            rptLoaitietkiem baocao = new rptLoaitietkiem();
            baocao.SetDataSource(dt);
            BaocaoloaiTK f = new BaocaoloaiTK();
            f.crystalReportViewerloaiTK.ReportSource = baocao;
            f.ShowDialog();
        }

        

        private void loaitietkiem_Load(object sender, EventArgs e)
        {
           
            
        }

  

        private void back_Click(object sender, EventArgs e)
        {
            index view = new index();
            view.Show();
            this.Hide();
        }
    }
}
