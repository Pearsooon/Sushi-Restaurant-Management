using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TestWinform
{
    public partial class DatTruoc : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QDDK8KF\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True");
        private int maKhachHang; // Mã khách hàng
        private int selectedBranchId = 0; // Mã chi nhánh được chọn

        public DatTruoc(int maKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang; // Gán mã khách hàng vào biến toàn cục
            LoadChiNhanh();
            PrepareForm();
        }

        private void PrepareForm()
        {
            // Ẩn các TextBox và Label khi form load
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            ConfirmOrder.Visible = false;
        }

        private void LoadChiNhanh()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM CHI_NHANH", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt; // Hiển thị danh sách chi nhánh
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chi nhánh: " + ex.Message);
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(maChiNhanh_text.Text))
            {
                MessageBox.Show("Vui lòng nhập mã chi nhánh.");
                return;
            }

            if (!int.TryParse(maChiNhanh_text.Text, out selectedBranchId))
            {
                MessageBox.Show("Mã chi nhánh phải là số.");
                return;
            }
            // Hiển thị các TextBox và Label để nhập thông tin đặt trước
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            ConfirmOrder.Visible = true;

            LoadBaiXeMay(selectedBranchId);
            LoadBaiXeHoi(selectedBranchId);
        }

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            string sdt = textBox1.Text.Trim();
            string soLuongKhach = textBox2.Text.Trim();
            string ngayDen = textBox3.Text.Trim();
            string ghiChu = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(soLuongKhach) || string.IsNullOrEmpty(ngayDen))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int maNhanVien = new Random().Next(0, 465); // Random mã nhân viên

                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_DatTruoc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    cmd.Parameters.AddWithValue("@MaChiNhanh", selectedBranchId);
                    cmd.Parameters.AddWithValue("@NgayDen", DateTime.Parse(ngayDen));
                    cmd.Parameters.AddWithValue("@GioDat", DateTime.Now.TimeOfDay);
                    cmd.Parameters.AddWithValue("@SoLuongKhach", int.Parse(soLuongKhach));
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@NhanVienLapPhieu", maNhanVien);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đặt trước thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form về trạng thái ban đầu
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ChucNangKH chucNangKHForm = new ChucNangKH();
            chucNangKHForm.Show();

            this.Close();
        }

        private void LoadBaiXeMay(int branchId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM BAI_XE_MAY_CHI_NHANH WHERE MA_CHI_NHANH = @MaChiNhanh", conn);
                cmd.Parameters.AddWithValue("@MaChiNhanh", branchId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt; // Hiển thị danh sách bãi xe máy
                dataGridView2.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin bãi xe máy: " + ex.Message);
            }
        }

        private void LoadBaiXeHoi(int branchId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM BAI_XE_HOI_CHI_NHANH WHERE MA_CHI_NHANH = @MaChiNhanh", conn);
                cmd.Parameters.AddWithValue("@MaChiNhanh", branchId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt; // Hiển thị danh sách bãi xe hơi
                dataGridView3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin bãi xe hơi: " + ex.Message);
            }
        }

    }
}
