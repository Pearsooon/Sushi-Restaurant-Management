using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CSDLNC;
using Microsoft.Data.SqlClient;

namespace TestWinform
{
    public partial class ChucNangEmp : Form
    {
        private int _maNhanVien;
        private SqlConnection _connection;

        // Constructor nhận mã nhân viên từ Form1
        public ChucNangEmp(int maNhanVien, SqlConnection connection)
        {
            InitializeComponent();
            _maNhanVien = maNhanVien; // Lưu mã nhân viên được truyền vào
            _connection = connection; // Kết nối được truyền vào từ Form1
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT MA_BO_PHAN FROM LAM_VIEC WHERE MA_NHAN_VIEN = @MaNhanVien";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                object result = cmd.ExecuteScalar();
                int maBoPhan = result != DBNull.Value ? (int)result : -1;

                if (maBoPhan <= 4)
                {
                    CreateOrder createOrderForm = new CreateOrder();
                    createOrderForm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        private void XemChiNhanhButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT MA_BO_PHAN FROM LAM_VIEC WHERE MA_NHAN_VIEN = @MaNhanVien";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                object result = cmd.ExecuteScalar();
                int maBoPhan = result != DBNull.Value ? (int)result : -1;

                if (maBoPhan == 4)
                {
                    View_Branch viewBranchForm = new View_Branch();
                    viewBranchForm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
    }
}
