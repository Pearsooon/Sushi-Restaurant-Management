using System.Windows.Forms;

namespace CSDLNC
{
    partial class CreateOrder
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtMaKhachHang;
        private TextBox txtMatKhau;
        private Button btnRegister;
        private TextBox txtMaNhanVien;
        private TextBox txtMaBan;
        private TextBox txtSoLuong;
        private ComboBox cmbMonAn;
        private Button btnLoadDishes;
        private Button btnAddDish;
        private Button btnCreateOrder;
        private ListBox lstOrderDetails;




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
        private void InitializeOrderFormComponents()
        {
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.txtMaBan = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cmbMonAn = new System.Windows.Forms.ComboBox();
            this.btnLoadDishes = new System.Windows.Forms.Button();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.lstOrderDetails = new System.Windows.Forms.ListBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();

            // txtMaKhachHang
            this.txtMaKhachHang.Location = new System.Drawing.Point(20, 40);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(200, 22);
            this.txtMaKhachHang.TabIndex = 3;
            this.txtMaKhachHang.PlaceholderText = "Mã khách hàng";

            // txtMaNhanVien
            this.txtMaNhanVien.Location = new System.Drawing.Point(20, 10);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(200, 22);
            this.txtMaNhanVien.TabIndex = 0;
            this.txtMaNhanVien.PlaceholderText = "Mã nhân viên";

            // txtMaBan
            this.txtMaBan.Location = new System.Drawing.Point(20, 70);
            this.txtMaBan.Name = "txtMaBan";
            this.txtMaBan.Size = new System.Drawing.Size(200, 22);
            this.txtMaBan.TabIndex = 1;
            this.txtMaBan.PlaceholderText = "Mã bàn";

            // txtSoLuong
            this.txtSoLuong.Location = new System.Drawing.Point(20, 100);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 22);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.PlaceholderText = "Số lượng món";

            // cmbMonAn
            this.cmbMonAn.Location = new System.Drawing.Point(20, 140);
            this.cmbMonAn.Name = "cmbMonAn";
            this.cmbMonAn.Size = new System.Drawing.Size(200, 24);
            this.cmbMonAn.TabIndex = 3;
            this.cmbMonAn.DropDownStyle = ComboBoxStyle.DropDownList;

            // btnLoadDishes
            this.btnLoadDishes.Location = new System.Drawing.Point(240, 20);
            this.btnLoadDishes.Name = "btnLoadDishes";
            this.btnLoadDishes.Size = new System.Drawing.Size(100, 30);
            this.btnLoadDishes.TabIndex = 4;
            this.btnLoadDishes.Text = "Tải món ăn";
            this.btnLoadDishes.UseVisualStyleBackColor = true;
            this.btnLoadDishes.Click += new System.EventHandler(this.LoadDishesByEmployee);

            // btnAddDish
            this.btnAddDish.Location = new System.Drawing.Point(240, 140);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(100, 30);
            this.btnAddDish.TabIndex = 5;
            this.btnAddDish.Text = "Thêm món";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.AddDishToOrder);

            // lstOrderDetails
            this.lstOrderDetails.Location = new System.Drawing.Point(20, 180);
            this.lstOrderDetails.Name = "lstOrderDetails";
            this.lstOrderDetails.Size = new System.Drawing.Size(320, 100);
            this.lstOrderDetails.TabIndex = 6;

            // btnCreateOrder
            this.btnCreateOrder.Location = new System.Drawing.Point(20, 300);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(100, 30);
            this.btnCreateOrder.TabIndex = 7;
            this.btnCreateOrder.Text = "Tạo phiếu";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.CreateDineInOrder);

            // Thêm các điều khiển vào giao diện
            this.Controls.Add(this.txtMaNhanVien);
            this.Controls.Add(this.txtMaBan);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.cmbMonAn);
            this.Controls.Add(this.btnLoadDishes);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.lstOrderDetails);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.txtMaKhachHang);

            // Cài đặt form
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Text = "Tạo phiếu ăn tại chỗ";
            this.StartPosition = FormStartPosition.CenterScreen;
        }



}
}
