using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestWinform
{
    public partial class View_Branch : Form
    {
        string connString = @"Data Source=DESKTOP-QDDK8KF\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True";
        public View_Branch()
        {
            InitializeComponent();
        }

        private void labelMonAn_Click(object sender, EventArgs e)
        {

        }

        private void txt1NhapMaChiNhanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatDSMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NhanXemMonAn_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã chi nhánh
            if (!int.TryParse(txt1NhapMaChiNhanh.Text, out int maChiNhanh))
            {
                MessageBox.Show("Vui lòng nhập mã chi nhánh hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("duyetMonAn", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maChiNhanh);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSMonAn.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có món ăn nào cho chi nhánh này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelMaPhieu_Click(object sender, EventArgs e)
        {

        }

        private void txt1NhapMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NhanXemPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã phiếu đặt
            if (!int.TryParse(txt1NhapMaPhieu.Text, out int maPhieuDat))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_TraCuuPhieuDat_O", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaPhieu", maPhieuDat);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatPhieu.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có phiếu đặt nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelDoanhThu1ChiNhanh_Click(object sender, EventArgs e)
        {

        }

        private void label1DoanhThu1ChiNhanh_Click(object sender, EventArgs e)
        {

        }

        private void label2DoanhThu1ChiNhanh_Click(object sender, EventArgs e)
        {

        }

        private void txt2NhapMaChiNhanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2NhapNgay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2NhapGiaTri_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatDSDoanhThu1ChiNhanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NhanXemDoanhThu1ChiNhanh_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            if (!int.TryParse(txt2NhapMaChiNhanh.Text, out int maChiNhanh))
            {
                MessageBox.Show("Vui lòng nhập mã chi nhánh hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra loại thời gian (Ngày/Tháng/Quý/Năm)
            string thoiGian = txt2NhapNgay.Text;
            if (thoiGian != "Ngày" && thoiGian != "Tháng" && thoiGian != "Quý" && thoiGian != "Năm")
            {
                MessageBox.Show("Vui lòng chọn loại thời gian cần tra cứu (Ngày/Tháng/Quý/Năm).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txt2NhapGiaTri.Text, out int thoiGianValue))
            {
                MessageBox.Show("Vui lòng nhập giá trị thời gian hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_TraCuuDoanhThu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maChiNhanh);
                        cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);
                        cmd.Parameters.AddWithValue("@ThoiGianValue", thoiGianValue);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong DataGridView
                        XuatDSDoanhThu1ChiNhanh.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu doanh thu cho thời gian và chi nhánh đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void View_Branch_Load(object sender, EventArgs e)
        {

        }

        private void label3MaChiNhanh_Click(object sender, EventArgs e)
        {

        }

        private void label3ThoiGian_Click(object sender, EventArgs e)
        {

        }

        private void label3GiaTri_Click(object sender, EventArgs e)
        {

        }

        private void txt3NhapMaChiNhanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3NhapThoiGian_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3NhapGiaTri_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatDSNhanVienVaDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3XemDiemNV_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox cho mã chi nhánh
            if (!int.TryParse(txt3NhapMaChiNhanh.Text, out int maChiNhanh))
            {
                MessageBox.Show("Vui lòng nhập mã chi nhánh hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy giá trị loại thời gian (Ngày, Tháng, Quý, Năm)
            string loaiThoiGian = txt3NhapThoiGian.Text;
            if (loaiThoiGian != "Ngay" && loaiThoiGian != "Thang" && loaiThoiGian != "Quy" && loaiThoiGian != "Nam")
            {
                MessageBox.Show("Vui lòng chọn loại thời gian cần tra cứu (Ngày/Tháng/Quý/Năm).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy giá trị thời gian từ TextBox (Ngày, Tháng, Quý, Năm)
            string thoiGian = txt3NhapGiaTri.Text;
            if (string.IsNullOrEmpty(thoiGian))
            {
                MessageBox.Show("Vui lòng nhập giá trị thời gian hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Kết nối với SQL Server
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Thực hiện gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_XemDanhSachNhanVienDiemPhucVu_O", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maChiNhanh);
                        cmd.Parameters.AddWithValue("@LoaiThoiGian", loaiThoiGian);
                        cmd.Parameters.AddWithValue("@ThoiGian", thoiGian);

                        // Lấy dữ liệu từ Stored Procedure vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị kết quả trong DataGridView
                        XuatDSNhanVienVaDiem.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu nhân viên theo thời gian và chi nhánh đã chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt4NhapMaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4XemTTNV_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên
            if (!int.TryParse(txt4NhapMaNhanVien.Text, out int maNhanVien))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("timKiemThongTinNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatThongTinNhanVien.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có nhân viên nào có mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5MaHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void txt5NhapMaHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void XemHDTheoMa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt6NhapThoiGian_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatDSCacHoaDonTheo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6NhanNgay_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị
            if (!int.TryParse(txt6NhapThoiGian.Text, out int Val))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Chuyển đổi giá trị int sang kiểu DateTime
                string dateString = Val.ToString();
                if (dateString.Length != 8 ||
                    !DateTime.TryParseExact(dateString, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                {
                    MessageBox.Show("Vui lòng nhập ngày hợp lệ theo định dạng: yyyyMMdd (VD: 20240122).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("timKiemHoaDonTheoNgay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", dateValue);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSCacHoaDonTheo.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có Hóa đơn nào trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6NhanThang_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị
            if (!int.TryParse(txt6NhapThoiGian.Text, out int Val))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Chuyển đổi giá trị int sang kiểu DateTime
                string dateString = Val.ToString();
                if (dateString.Length != 8 ||
                    !DateTime.TryParseExact(dateString, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out DateTime dateValue))
                {
                    MessageBox.Show("Vui lòng nhập ngày hợp lệ theo định dạng: yyyyMMdd (VD: 20240122).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("timKiemHoaDonTheoThang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", dateValue);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSCacHoaDonTheo.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có Hóa đơn nào trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6NhanNam_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị
            if (!int.TryParse(txt6NhapThoiGian.Text, out int Val))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("timKiemHoaDonTheoNam", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", Val);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSCacHoaDonTheo.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có Hóa đơn nào trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhanXemHDtheoMa1_Click_2_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên
            if (!int.TryParse(txt5NhapMaHoaDon.Text, out int maKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("timKiemHoaDonMaKhachHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKH);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XemHDTheoMa.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có khách hàng nào có mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
