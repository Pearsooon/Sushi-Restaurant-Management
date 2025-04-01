using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CSDLNC
{
    public partial class CreateOrder : Form
    {

        public int CurrentEmployeeId { get; set; }
        public CreateOrder()
        {
            InitializeOrderFormComponents();
            LoadAvailableDishesForBranch();


        }



        private void LoadDishesByEmployee(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNhanVien.Text.Trim(), out int maNhanVien))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên hợp lệ.");
                return;
            }

            CurrentEmployeeId = maNhanVien; // Gán mã nhân viên hiện tại
            LoadAvailableDishesForBranch(); // Gọi phương thức tải danh sách món ăn
        }

        private void LoadAvailableDishesForBranch()
        {
            if (CurrentEmployeeId == 0)
            {
                MessageBox.Show("Mã nhân viên hiện tại chưa được thiết lập. Vui lòng kiểm tra.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QDDK8KF\\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    // Lấy mã chi nhánh từ bảng LAM_VIEC
                    string getBranchQuery = @"
                SELECT MA_CHI_NHANH
                FROM LAM_VIEC 
                WHERE MA_NHAN_VIEN = @MaNhanVien";

                    string maChiNhanh = null;

                    using (SqlCommand cmd = new SqlCommand(getBranchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", CurrentEmployeeId);

                        // Kiểm tra xem mã chi nhánh có tồn tại
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Không tìm thấy mã chi nhánh cho nhân viên này.");
                            return;
                        }

                        maChiNhanh = result.ToString();
                    }

                    // Lấy danh sách món ăn không bị giới hạn tại chi nhánh
                    string query = @"
                SELECT MA_MON_AN, TEN_MON_AN
                FROM MON_AN
                WHERE MA_MON_AN NOT IN (
                    SELECT MA_MON_AN
                    FROM MON_AN_KHONG_PHUC_VU
                    WHERE MA_CHI_NHANH = @MaChiNhanh
                )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maChiNhanh);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Không có món ăn nào được tìm thấy cho chi nhánh này.");
                                return;
                            }

                            // Xóa các mục trước đó để tránh trùng lặp
                            cmbMonAn.Items.Clear();

                            // Duyệt qua danh sách món ăn và thêm vào ComboBox
                            while (reader.Read())
                            {
                                cmbMonAn.Items.Add(new
                                {
                                    Text = reader["TEN_MON_AN"].ToString(),
                                    Value = reader["MA_MON_AN"].ToString()
                                });
                            }

                            cmbMonAn.DisplayMember = "Text";
                            cmbMonAn.ValueMember = "Value";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách món ăn: {ex.Message}");
            }
        }








        private void AddDishToOrder(object sender, EventArgs e)
        {
            if (cmbMonAn.SelectedItem == null || !int.TryParse(txtSoLuong.Text.Trim(), out int soLuong))
            {
                MessageBox.Show("Vui lòng chọn món ăn và nhập số lượng hợp lệ.");
                return;
            }

            // Lấy mã món ăn từ ComboBox
            var selectedDish = (dynamic)cmbMonAn.SelectedItem;
            string maMonAn = selectedDish.Value;
            string tenMonAn = selectedDish.Text;

            lstOrderDetails.Items.Add($"{maMonAn} - {tenMonAn} - Số lượng: {soLuong}");

            MessageBox.Show($"Món '{tenMonAn}' đã được thêm vào danh sách.");
        }





        private void CreateDineInOrder(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaBan.Text.Trim()) || string.IsNullOrEmpty(txtMaKhachHang.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã bàn và mã khách hàng.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QDDK8KF\\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True"))
                {
                    conn.Open();

                    // Generate mã phiếu tự động
                    int maPhieuMoi;
                    string generateOrderIdQuery = "SELECT ISNULL(MAX(MA_PHIEU), 0) + 1 FROM PHIEU_DAT";
                    using (SqlCommand cmd = new SqlCommand(generateOrderIdQuery, conn))
                    {
                        maPhieuMoi = (int)cmd.ExecuteScalar();
                    }

                    // Lấy mã chi nhánh

                    string maChiNhanh = "";
                    string getBranchCodeQuery = "SELECT MA_CHI_NHANH FROM LAM_VIEC WHERE MA_NHAN_VIEN = @MaNhanVien";
                    using (SqlCommand cmd = new SqlCommand(getBranchCodeQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNhanVien", CurrentEmployeeId);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Không tìm thấy chi nhánh của nhân viên hiện tại.");
                            return;
                        }
                        maChiNhanh = result.ToString();
                    }


                    // Thêm mã phiếu vào bảng PHIEU_DAT
                    string insertMainOrderQuery = @"
        INSERT INTO PHIEU_DAT (MA_PHIEU, NGAY_LAP_PHIEU, LOAI_PHIEU, NHAN_VIEN_LAP_PHIEU, MA_KHACH_HANG, MA_CHI_NHANH)
        VALUES (@MaPhieu, @NgayLapPhieu, @LoaiPhieu, @MaNhanVien, @MaKhachHang, @MaChiNhanh)";

                    using (SqlCommand cmd = new SqlCommand(insertMainOrderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                        cmd.Parameters.AddWithValue("@NgayLapPhieu", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LoaiPhieu", "Tại chỗ");
                        cmd.Parameters.AddWithValue("@MaNhanVien", CurrentEmployeeId);
                        cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@MaChiNhanh", maChiNhanh);
                        cmd.ExecuteNonQuery();
                    }

                    // Thêm phiếu vào bảng PHIEU_DAT_TAI_CHO
                    string insertOrderQuery = @"
                INSERT INTO PHIEU_DAT_TAI_CHO (MA_PHIEU, MA_BAN, GHI_MON_MON_AN)
                VALUES (@MaPhieu, @MaBan, @GhiChu)";
                    using (SqlCommand cmd = new SqlCommand(insertOrderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                        cmd.Parameters.AddWithValue("@MaBan", txtMaBan.Text.Trim());
                        cmd.Parameters.AddWithValue("@GhiChu", "Món ăn tại chỗ");
                        cmd.ExecuteNonQuery();
                    }

                    // Thêm món ăn vào bảng SO_LUONG_MON_AN
                    foreach (string item in lstOrderDetails.Items)
                    {
                        string[] details = item.Split('-');
                        string maMonAn = details[0].Trim(); // Mã món ăn
                        int soLuong = int.Parse(details[2].Split(':')[1].Trim());

                        string insertDishQuery = @"
                    INSERT INTO SO_LUONG_MON_AN (MA_PHIEU, MA_MON_AN, SO_LUONG)
                    VALUES (@MaPhieu, @MaMonAn, @SoLuong)";
                        using (SqlCommand cmd = new SqlCommand(insertDishQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                            cmd.Parameters.AddWithValue("@MaMonAn", maMonAn);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Phiếu ăn tại chỗ đã được tạo thành công với mã phiếu: {maPhieuMoi}!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo phiếu: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {

        }
    }
}
