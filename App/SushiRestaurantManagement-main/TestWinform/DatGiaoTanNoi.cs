using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TestWinform
{
    public partial class DatGiaoTanNoi : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QDDK8KF\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True");
        DataTable selectedItemsTable = new DataTable();
        int selectedBranchId = 0; // Biến lưu mã chi nhánh đã chọn

        private int maKhachHang; // Lưu trữ mã khách hàng

        public DatGiaoTanNoi(int maKhachHang)
        {
            InitializeComponent();
            this.maKhachHang = maKhachHang; // Gán mã khách hàng vào biến toàn cục
            LoadChiNhanh();
            InitializeSelectedItemsTable();
            PrepareForm();
        }

        private void PrepareForm()
        {
            // Ẩn các TextBox và Label khi form load
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            ConfirmGiaoTanNoi.Visible = false;
            ConfirmOrderButton.Visible = false;
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

        private void InitializeSelectedItemsTable()
        {
            selectedItemsTable.Columns.Add("Mã món ăn");
            selectedItemsTable.Columns.Add("Tên món ăn");
            selectedItemsTable.Columns.Add("Số lượng");
            dataGridView2.DataSource = selectedItemsTable;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    dataGridView2.Visible = true;
                    ConfirmOrderButton.Visible = true;
                    DataGridViewRow row = dataGridView3.Rows[e.RowIndex];

                    string maMonAn = row.Cells["MA_MON_AN"].Value.ToString();
                    string tenMonAn = row.Cells["TEN_MON_AN"].Value.ToString();
                    int hoTroGiaoTanNoi = Convert.ToInt32(row.Cells["HO_TRO_GIAO_TAN_NOI"].Value); // Lấy giá trị cột HO_TRO_GIAO_TAN_NOI

                    // Kiểm tra nếu món ăn không hỗ trợ giao tận nơi
                    if (hoTroGiaoTanNoi == 0)
                    {
                        MessageBox.Show("Món ăn này không hỗ trợ giao tận nơi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra nếu món ăn đã tồn tại, tăng số lượng
                    DataRow existingRow = selectedItemsTable.AsEnumerable()
                        .FirstOrDefault(r => r["Mã món ăn"].ToString() == maMonAn);

                    if (existingRow != null)
                    {
                        int currentQuantity = int.Parse(existingRow["Số lượng"].ToString());
                        existingRow["Số lượng"] = currentQuantity + 1;
                    }
                    else
                    {
                        selectedItemsTable.Rows.Add(maMonAn, tenMonAn, 1);
                    }

                    // Refresh lại DataGridView để cập nhật dữ liệu
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = selectedItemsTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm món ăn: " + ex.Message);
                }
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

            try
            {
                // Mở kết nối
                conn.Open();

                // Kiểm tra HO_TRO_GIAO_TAN_NOI của chi nhánh
                SqlCommand checkBranchCmd = new SqlCommand("SELECT HO_TRO_GIAO_TAN_NOI FROM CHI_NHANH WHERE MA_CHI_NHANH = @MaChiNhanh", conn);
                checkBranchCmd.Parameters.AddWithValue("@MaChiNhanh", selectedBranchId);

                object result = checkBranchCmd.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Mã chi nhánh không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int hoTroGiaoTanNoi = Convert.ToInt32(result);

                // Kiểm tra nếu chi nhánh không hỗ trợ giao tận nơi
                if (hoTroGiaoTanNoi == 0)
                {
                    MessageBox.Show("Chi nhánh này không hỗ trợ giao tận nơi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị danh sách món ăn của chi nhánh hỗ trợ giao hàng
                SqlCommand cmd = new SqlCommand("EXEC duyetMonAn @MaChiNhanh", conn);
                cmd.Parameters.AddWithValue("@MaChiNhanh", selectedBranchId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView3.DataSource = dt; // Hiển thị danh sách món ăn
                dataGridView3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách món ăn: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            // Hiển thị các TextBox để nhập thông tin giao hàng
            textBox1.Visible = true; // SĐT
            textBox2.Visible = true; // Địa chỉ giao hàng
            textBox3.Visible = true; // Ghi chú món ăn

            // Hiển thị label để hướng dẫn
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;

            ConfirmGiaoTanNoi.Visible = true;
        }

        private void ConfirmGiaoTanNoi_Click(object sender, EventArgs e)
        {
            string sdt = textBox1.Text.Trim();
            string diaChi = textBox2.Text.Trim();
            string ghiChu = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("SĐT và Địa chỉ giao hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int maNhanVien = new Random().Next(0, 465); 

                conn.Open();

                int maPhieu;

                using (SqlCommand cmd = new SqlCommand("sp_DatGiaoTanNoi", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang); // Sử dụng mã khách hàng
                    cmd.Parameters.AddWithValue("@MaChiNhanh", selectedBranchId);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmd.Parameters.AddWithValue("@SDTKhachHang", sdt);
                    cmd.Parameters.AddWithValue("@DiaChiGiao", diaChi);
                    cmd.Parameters.AddWithValue("@GhiChuMonAn", ghiChu);

                    // Thêm tham số output để lấy mã phiếu tự động sinh
                    SqlParameter outputParam = new SqlParameter("@MaPhieu", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    // Lấy mã phiếu từ tham số output
                    maPhieu = (int)outputParam.Value;
                }

                // Thêm dữ liệu vào bảng SO_LUONG_MON_AN
                foreach (DataRow row in selectedItemsTable.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO SO_LUONG_MON_AN (MA_PHIEU, MA_MON_AN, SO_LUONG) VALUES (@MaPhieu, @MaMonAn, @SoLuong)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieu", maPhieu); // Sử dụng mã phiếu từ procedure
                        cmd.Parameters.AddWithValue("@MaMonAn", row["Mã món ăn"]);
                        cmd.Parameters.AddWithValue("@SoLuong", row["Số lượng"]);
                        cmd.ExecuteNonQuery();
                    }
                }



                MessageBox.Show("Đặt giao hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form về trạng thái ban đầu
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                selectedItemsTable.Clear();
                dataGridView2.DataSource = null;
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

    }
}
