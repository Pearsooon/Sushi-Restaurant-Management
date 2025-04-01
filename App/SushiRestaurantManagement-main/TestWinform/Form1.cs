using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using CSDLNC;

namespace TestWinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QDDK8KF\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True;MultipleActiveResultSets=True");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int username;
            string password;

            // Kiểm tra và chuyển đổi username sang kiểu int
            if (!int.TryParse(txt_Username.Text, out username))
            {
                MessageBox.Show("Username must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            password = txt_password.Text;

            try
            {
                string query = "SELECT MA_TAI_KHOAN FROM TAI_KHOAN_KHACH_HANG WHERE MAT_KHAU = @password AND MA_TAI_KHOAN = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int maKhachHang = (int)reader["MA_TAI_KHOAN"];

                    SaveLoginHistory(maKhachHang);

                    ChucNangKH chucNangKH = new ChucNangKH
                    {
                        MaKhachHang = maKhachHang // Truyền mã khách hàng qua thuộc tính
                    };
                    chucNangKH.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Username.Clear();
                    txt_password.Clear();
                    txt_Username.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int username;
            string password;

            // Kiểm tra và chuyển đổi username sang kiểu int
            if (!int.TryParse(txt_Username.Text, out username))
            {
                MessageBox.Show("Username must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            password = txt_password.Text;

            try
            {
                conn.Open();

                // Kiểm tra đăng nhập
                string query = @"
            SELECT NV.MA_TAI_KHOAN, LV.MA_BO_PHAN
            FROM TAI_KHOAN_NHAN_VIEN NV
            LEFT JOIN LAM_VIEC LV ON NV.MA_TAI_KHOAN = LV.MA_NHAN_VIEN
            WHERE NV.MAT_KHAU = @password AND NV.MA_TAI_KHOAN = @username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int maBoPhan = reader["MA_BO_PHAN"] != DBNull.Value ? (int)reader["MA_BO_PHAN"] : -1;

                    reader.Close(); // Đóng reader trước khi mở form mới.

                    if (maBoPhan == 5)
                    {
                        // Mở form View_Company nếu MA_BO_PHAN = 5
                        View_Company viewCompanyForm = new View_Company();
                        viewCompanyForm.Show();
                    }
                    else
                    {
                        // Mở form ChucNangEmp nếu MA_BO_PHAN != 5
                        ChucNangEmp chucNangEmpForm = new ChucNangEmp(username, conn);
                        chucNangEmpForm.Show();
                    }

                    this.Hide(); // Ẩn form hiện tại
                }
                else
                {
                    MessageBox.Show("Invalid login detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Username.Clear();
                    txt_password.Clear();
                    txt_Username.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        private void SignUpButton_Click(object sender, EventArgs e)
        {
            SUSHIX signUpForm = new SUSHIX();
            signUpForm.Show();
        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveLoginHistory(int maKhachHang)
        {
            SqlCommand cmd = null; // Khởi tạo SqlCommand bên ngoài khối try
            try
            {
                cmd = new SqlCommand("sp_LichSuDangNhap", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Thêm tham số đầu vào
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                // Mở kết nối nếu nó đang đóng
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save login history: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi hoàn tất
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                // Giải phóng tài nguyên của SqlCommand nếu đã được khởi tạo
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
        }

    }
}
