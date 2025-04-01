using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CSDLNC
{
    public partial class SUSHIX : Form
    {
        public int CurrentEmployeeId { get; set; }
        public SUSHIX()
        {
            InitializeSignUpComponent();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text.Trim();
            string matKhau = (string)(txtMatKhau.Text.Trim());
            string maNhanVien = txtMaNhanVien.Text.Trim();

            if (string.IsNullOrEmpty(maKhachHang) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QDDK8KF\\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    // Kiểm tra mã khách hàng
                    string checkCustomerQuery = "SELECT COUNT(*) FROM KHACH_HANG WHERE MA_KHACH_HANG = @MaKhachHang";
                    using (SqlCommand cmd = new SqlCommand(checkCustomerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        int customerExists = (int)cmd.ExecuteScalar();

                        if (customerExists == 0)
                        {
                            MessageBox.Show("Mã khách hàng không tồn tại.");
                            return;
                        }
                    }

                    // Tạo mã tài khoản duy nhất
                    int maTaiKhoanMoi;
                    string generateAccountQuery = "SELECT ISNULL(MAX(MA_TAI_KHOAN), 0) + 1 FROM TAI_KHOAN_KHACH_HANG";
                    using (SqlCommand cmd = new SqlCommand(generateAccountQuery, conn))
                    {
                        maTaiKhoanMoi = (int)cmd.ExecuteScalar();
                    }

                    // Thêm tài khoản mới
                    string insertAccountQuery = @"
                INSERT INTO TAI_KHOAN_KHACH_HANG (MA_TAI_KHOAN, MAT_KHAU, MA_KHACH_HANG)
                VALUES (@MaTaiKhoan, @MatKhau, @MaKhachHang)";
                    using (SqlCommand cmd = new SqlCommand(insertAccountQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoanMoi);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                        cmd.ExecuteNonQuery();
                    }

                    // Tạo mã thẻ thành viên duy nhất
                    int maTheThanhVienMoi;
                    string generateCardQuery = "SELECT ISNULL(MAX(MA_THE_THANH_VIEN), 0) + 1 FROM THE_THANH_VIEN";
                    using (SqlCommand cmd = new SqlCommand(generateCardQuery, conn))
                    {
                        maTheThanhVienMoi = (int)cmd.ExecuteScalar();
                    }

                    // Thêm thẻ thành viên mới
                    string insertCardQuery = @"
                INSERT INTO THE_THANH_VIEN (MA_THE_THANH_VIEN, DIEM, NGAY_LAP_THE, LOAI_THE, MA_KHACH_HANG, MA_NHAN_VIEN)
                VALUES (@MaTheThanhVien, @Diem, @NgayLapThe, @LoaiThe, @MaKhachHang, @MaNhanVien)";
                    using (SqlCommand cmd = new SqlCommand(insertCardQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTheThanhVien", maTheThanhVienMoi);
                        cmd.Parameters.AddWithValue("@Diem", 0); // Điểm mặc định là 0
                        cmd.Parameters.AddWithValue("@NgayLapThe", DateTime.Now); // Ngày lập thẻ là hôm nay
                        cmd.Parameters.AddWithValue("@LoaiThe", "Thường"); // Loại thẻ là thường
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang); // Mã khách hàng
                        cmd.Parameters.AddWithValue("@MaNhanVien", string.IsNullOrEmpty(maNhanVien) ? DBNull.Value : maNhanVien); // Kiểm tra mã nhân viên

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đăng ký tài khoản và thẻ thành viên thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {

        }
    }
}
