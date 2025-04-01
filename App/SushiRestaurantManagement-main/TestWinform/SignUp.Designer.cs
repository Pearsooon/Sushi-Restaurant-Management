using System.Windows.Forms;

namespace CSDLNC
{
    partial class SUSHIX
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtMaKhachHang;
        private TextBox txtMatKhau;
        private Button btnRegister;
        private TextBox txtMaNhanVien;
        


        /// <summary>
        /// Phương thức giải phóng tài nguyên.
        /// </summary>
        /// <param name="disposing">True nếu tài nguyên cần giải phóng; False nếu không.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Phương thức khởi tạo giao diện.
        /// </summary>
        private void InitializeSignUpComponent()
        {
            txtMaNhanVien = new TextBox();
            txtMaKhachHang = new TextBox();
            txtMatKhau = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(150, 50);
            txtMaNhanVien.Margin = new Padding(3, 4, 3, 4);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.PlaceholderText = "Mã Nhân Viên";
            txtMaNhanVien.Size = new Size(200, 27);
            txtMaNhanVien.TabIndex = 0;
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Location = new Point(150, 100);
            txtMaKhachHang.Margin = new Padding(3, 4, 3, 4);
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.PlaceholderText = "Mã Khách Hàng";
            txtMaKhachHang.Size = new Size(200, 27);
            txtMaKhachHang.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(150, 150);
            txtMatKhau.Margin = new Padding(3, 4, 3, 4);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Mật Khẩu";
            txtMatKhau.Size = new Size(200, 27);
            txtMatKhau.TabIndex = 1;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(200, 200);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 38);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Đăng Ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // SUSHIX
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 336);
            Controls.Add(btnRegister);
            Controls.Add(txtMaKhachHang);
            Controls.Add(txtMatKhau);
            Controls.Add(txtMaNhanVien);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SUSHIX";
            Text = "SUSHIX - Đăng Ký Tài Khoản";
            ResumeLayout(false);
            PerformLayout();
        }

    }
}
