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
    public partial class View_Company : Form
    {
        string connString = @"Data Source=DESKTOP-QDDK8KF\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True";
        public View_Company()
        {
            InitializeComponent();
        }

        private void label1NhapThoiGian_Click(object sender, EventArgs e)
        {

        }

        private void txt1NhapThoiGian_TextChanged(object sender, EventArgs e)
        {

        }

        private void XuatDSDoanhThuCacChiNhanhTheo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1NhanNgay_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị
            if (!int.TryParse(txt1NhapThoiGian.Text, out int Val))
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
                    using (SqlCommand cmd = new SqlCommand("doanhThuChiNhanhTheoNgay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", dateValue);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSDoanhThuCacChiNhanhTheo.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có Doanh thu nào trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1NhanThang_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị
            if (!int.TryParse(txt1NhapThoiGian.Text, out int Val))
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
                    using (SqlCommand cmd = new SqlCommand("doanhThuChiNhanhTheoThang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", dateValue);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSDoanhThuCacChiNhanhTheo.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có Doanh thu nào trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1NhanNam_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị
            if (!int.TryParse(txt1NhapThoiGian.Text, out int Val))
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
                    using (SqlCommand cmd = new SqlCommand("doanhThuChiNhanhTheoNam", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", dateValue);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Hiển thị dữ liệu trong DataGridView
                        XuatDSDoanhThuCacChiNhanhTheo.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có Doanh thu nào trong thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2MaNV_Click(object sender, EventArgs e)
        {

        }

        private void txt2NhapMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2MaBoPhan_Click(object sender, EventArgs e)
        {

        }

        private void txt2MaBoPhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2MaCN_Click(object sender, EventArgs e)
        {

        }

        private void txt2MaChiNhanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2Confirm_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên
            if (!int.TryParse(txt2NhapMaNV.Text, out int maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txt2MaBoPhan.Text, out int maBP))
            {
                MessageBox.Show("Vui lòng nhập mã bộ phận hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txt2MaChiNhanh.Text, out int maCN))
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
                    using (SqlCommand cmd = new SqlCommand("chuyenNhanSu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNV);
                        cmd.Parameters.AddWithValue("@MaBoPhan", maBP);
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maCN);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        MessageBox.Show("Chuyển thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3InfoEmp_Click(object sender, EventArgs e)
        {

        }

        private void label3MaNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void txt3MaNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3HoTen_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3NgaySinh_Click(object sender, EventArgs e)
        {

        }

        private void txt3NgaySinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3Confirm_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên
            if (!int.TryParse(txt3MaNhanVien.Text, out int maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên hợp lệ (số nguyên).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra ngày sinh
            if (!int.TryParse(txt3NgaySinh.Text, out int DATE))
            {
                MessageBox.Show("Vui lòng nhập ngày sinh hợp lệ (số nguyên). (VD: 19960320)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                string HoTen = textBox2.Text;
                string SDT = txt3SDT.Text;
                // Chuyển đổi giá trị int sang kiểu DateTime
                string dateString = DATE.ToString();
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
                    using (SqlCommand cmd = new SqlCommand("capNhatThongTinNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNV);
                        cmd.Parameters.AddWithValue("@HoTen", HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", dateValue);
                        cmd.Parameters.AddWithValue("@SDT", SDT);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3SDT_Click(object sender, EventArgs e)
        {

        }

        private void txt3SDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
