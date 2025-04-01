using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TestWinform
{
    public partial class XemThongTinKH : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QDDK8KF\INSTANCE22127366;Initial Catalog=SUSHIX_FINAL;Integrated Security=True;Trust Server Certificate=True");

        public XemThongTinKH()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            int maTaiKhoan;
            string matKhau;

            if (!int.TryParse(txt_Username.Text, out maTaiKhoan))
            {
                MessageBox.Show("Username must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            matKhau = txt_password.Text;

            try
            {
                SqlCommand cmd = new SqlCommand("sp_HienThiThongTinKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No customer data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
