namespace TestWinform
{
    partial class View_Company
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            XuatDSDoanhThuCacChiNhanhTheo = new DataGridView();
            button1NhanNgay = new Button();
            txt1NhapThoiGian = new TextBox();
            label1NhapThoiGian = new Label();
            button1NhanThang = new Button();
            button1NhanNam = new Button();
            label2MaNV = new Label();
            txt2NhapMaNV = new TextBox();
            label2MaBoPhan = new Label();
            txt2MaBoPhan = new TextBox();
            label2MaCN = new Label();
            txt2MaChiNhanh = new TextBox();
            label4 = new Label();
            button2Confirm = new Button();
            button3Confirm = new Button();
            label3InfoEmp = new Label();
            label3NgaySinh = new Label();
            txt3NgaySinh = new TextBox();
            label3HoTen = new Label();
            textBox2 = new TextBox();
            label3MaNhanVien = new Label();
            txt3MaNhanVien = new TextBox();
            label3SDT = new Label();
            txt3SDT = new TextBox();
            ((System.ComponentModel.ISupportInitialize)XuatDSDoanhThuCacChiNhanhTheo).BeginInit();
            SuspendLayout();
            // 
            // XuatDSDoanhThuCacChiNhanhTheo
            // 
            XuatDSDoanhThuCacChiNhanhTheo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatDSDoanhThuCacChiNhanhTheo.Location = new Point(48, 120);
            XuatDSDoanhThuCacChiNhanhTheo.Name = "XuatDSDoanhThuCacChiNhanhTheo";
            XuatDSDoanhThuCacChiNhanhTheo.RowHeadersWidth = 51;
            XuatDSDoanhThuCacChiNhanhTheo.Size = new Size(354, 483);
            XuatDSDoanhThuCacChiNhanhTheo.TabIndex = 0;
            XuatDSDoanhThuCacChiNhanhTheo.CellContentClick += XuatDSDoanhThuCacChiNhanhTheo_CellContentClick;
            // 
            // button1NhanNgay
            // 
            button1NhanNgay.Location = new Point(431, 120);
            button1NhanNgay.Name = "button1NhanNgay";
            button1NhanNgay.Size = new Size(143, 58);
            button1NhanNgay.TabIndex = 1;
            button1NhanNgay.Text = "Ngày";
            button1NhanNgay.UseVisualStyleBackColor = true;
            button1NhanNgay.Click += button1NhanNgay_Click;
            // 
            // txt1NhapThoiGian
            // 
            txt1NhapThoiGian.Location = new Point(47, 79);
            txt1NhapThoiGian.Name = "txt1NhapThoiGian";
            txt1NhapThoiGian.Size = new Size(195, 27);
            txt1NhapThoiGian.TabIndex = 2;
            txt1NhapThoiGian.TextChanged += txt1NhapThoiGian_TextChanged;
            // 
            // label1NhapThoiGian
            // 
            label1NhapThoiGian.AutoSize = true;
            label1NhapThoiGian.Location = new Point(49, 49);
            label1NhapThoiGian.Name = "label1NhapThoiGian";
            label1NhapThoiGian.Size = new Size(193, 20);
            label1NhapThoiGian.TabIndex = 3;
            label1NhapThoiGian.Text = "Thời gian cần xét doanh thu";
            label1NhapThoiGian.Click += label1NhapThoiGian_Click;
            // 
            // button1NhanThang
            // 
            button1NhanThang.Location = new Point(431, 215);
            button1NhanThang.Name = "button1NhanThang";
            button1NhanThang.Size = new Size(143, 58);
            button1NhanThang.TabIndex = 4;
            button1NhanThang.Text = "Tháng";
            button1NhanThang.UseVisualStyleBackColor = true;
            button1NhanThang.Click += button1NhanThang_Click;
            // 
            // button1NhanNam
            // 
            button1NhanNam.Location = new Point(431, 317);
            button1NhanNam.Name = "button1NhanNam";
            button1NhanNam.Size = new Size(143, 58);
            button1NhanNam.TabIndex = 5;
            button1NhanNam.Text = "Năm";
            button1NhanNam.UseVisualStyleBackColor = true;
            button1NhanNam.Click += button1NhanNam_Click;
            // 
            // label2MaNV
            // 
            label2MaNV.AutoSize = true;
            label2MaNV.Location = new Point(815, 139);
            label2MaNV.Name = "label2MaNV";
            label2MaNV.Size = new Size(102, 20);
            label2MaNV.TabIndex = 7;
            label2MaNV.Text = "Mã Nhân Viên";
            label2MaNV.Click += label2MaNV_Click;
            // 
            // txt2NhapMaNV
            // 
            txt2NhapMaNV.Location = new Point(813, 169);
            txt2NhapMaNV.Name = "txt2NhapMaNV";
            txt2NhapMaNV.Size = new Size(195, 27);
            txt2NhapMaNV.TabIndex = 6;
            txt2NhapMaNV.TextChanged += txt2NhapMaNV_TextChanged;
            // 
            // label2MaBoPhan
            // 
            label2MaBoPhan.AutoSize = true;
            label2MaBoPhan.Location = new Point(813, 210);
            label2MaBoPhan.Name = "label2MaBoPhan";
            label2MaBoPhan.Size = new Size(88, 20);
            label2MaBoPhan.TabIndex = 9;
            label2MaBoPhan.Text = "Mã Bộ Phận";
            label2MaBoPhan.Click += label2MaBoPhan_Click;
            // 
            // txt2MaBoPhan
            // 
            txt2MaBoPhan.Location = new Point(811, 240);
            txt2MaBoPhan.Name = "txt2MaBoPhan";
            txt2MaBoPhan.Size = new Size(195, 27);
            txt2MaBoPhan.TabIndex = 8;
            txt2MaBoPhan.TextChanged += txt2MaBoPhan_TextChanged;
            // 
            // label2MaCN
            // 
            label2MaCN.AutoSize = true;
            label2MaCN.Location = new Point(813, 290);
            label2MaCN.Name = "label2MaCN";
            label2MaCN.Size = new Size(102, 20);
            label2MaCN.TabIndex = 11;
            label2MaCN.Text = "Mã Chi Nhánh";
            label2MaCN.Click += label2MaCN_Click;
            // 
            // txt2MaChiNhanh
            // 
            txt2MaChiNhanh.Location = new Point(811, 320);
            txt2MaChiNhanh.Name = "txt2MaChiNhanh";
            txt2MaChiNhanh.Size = new Size(195, 27);
            txt2MaChiNhanh.TabIndex = 10;
            txt2MaChiNhanh.TextChanged += txt2MaChiNhanh_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(851, 86);
            label4.Name = "label4";
            label4.Size = new Size(117, 20);
            label4.TabIndex = 12;
            label4.Text = "Chuyển Nhân Sự";
            label4.Click += label4_Click;
            // 
            // button2Confirm
            // 
            button2Confirm.Location = new Point(851, 382);
            button2Confirm.Name = "button2Confirm";
            button2Confirm.Size = new Size(94, 29);
            button2Confirm.TabIndex = 13;
            button2Confirm.Text = "Xác Nhận";
            button2Confirm.UseVisualStyleBackColor = true;
            button2Confirm.Click += button2Confirm_Click;
            // 
            // button3Confirm
            // 
            button3Confirm.Location = new Point(1388, 469);
            button3Confirm.Name = "button3Confirm";
            button3Confirm.Size = new Size(94, 29);
            button3Confirm.TabIndex = 21;
            button3Confirm.Text = "Xác Nhận";
            button3Confirm.UseVisualStyleBackColor = true;
            button3Confirm.Click += button3Confirm_Click;
            // 
            // label3InfoEmp
            // 
            label3InfoEmp.AutoSize = true;
            label3InfoEmp.Location = new Point(1338, 86);
            label3InfoEmp.Name = "label3InfoEmp";
            label3InfoEmp.Size = new Size(213, 20);
            label3InfoEmp.TabIndex = 20;
            label3InfoEmp.Text = "Cập Nhật Thông Tin Nhân Viên";
            label3InfoEmp.Click += label3InfoEmp_Click;
            // 
            // label3NgaySinh
            // 
            label3NgaySinh.AutoSize = true;
            label3NgaySinh.Location = new Point(1340, 290);
            label3NgaySinh.Name = "label3NgaySinh";
            label3NgaySinh.Size = new Size(76, 20);
            label3NgaySinh.TabIndex = 19;
            label3NgaySinh.Text = "Ngày Sinh";
            label3NgaySinh.Click += label3NgaySinh_Click;
            // 
            // txt3NgaySinh
            // 
            txt3NgaySinh.Location = new Point(1338, 320);
            txt3NgaySinh.Name = "txt3NgaySinh";
            txt3NgaySinh.Size = new Size(195, 27);
            txt3NgaySinh.TabIndex = 18;
            txt3NgaySinh.TextChanged += txt3NgaySinh_TextChanged;
            // 
            // label3HoTen
            // 
            label3HoTen.AutoSize = true;
            label3HoTen.Location = new Point(1340, 210);
            label3HoTen.Name = "label3HoTen";
            label3HoTen.Size = new Size(56, 20);
            label3HoTen.TabIndex = 17;
            label3HoTen.Text = "Họ Tên";
            label3HoTen.Click += label3HoTen_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1338, 240);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(195, 27);
            textBox2.TabIndex = 16;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3MaNhanVien
            // 
            label3MaNhanVien.AutoSize = true;
            label3MaNhanVien.Location = new Point(1342, 139);
            label3MaNhanVien.Name = "label3MaNhanVien";
            label3MaNhanVien.Size = new Size(102, 20);
            label3MaNhanVien.TabIndex = 15;
            label3MaNhanVien.Text = "Mã Nhân Viên";
            label3MaNhanVien.Click += label3MaNhanVien_Click;
            // 
            // txt3MaNhanVien
            // 
            txt3MaNhanVien.Location = new Point(1340, 169);
            txt3MaNhanVien.Name = "txt3MaNhanVien";
            txt3MaNhanVien.Size = new Size(195, 27);
            txt3MaNhanVien.TabIndex = 14;
            txt3MaNhanVien.TextChanged += txt3MaNhanVien_TextChanged;
            // 
            // label3SDT
            // 
            label3SDT.AutoSize = true;
            label3SDT.Location = new Point(1342, 378);
            label3SDT.Name = "label3SDT";
            label3SDT.Size = new Size(102, 20);
            label3SDT.TabIndex = 23;
            label3SDT.Text = "Số Điện Thoại";
            label3SDT.Click += label3SDT_Click;
            // 
            // txt3SDT
            // 
            txt3SDT.Location = new Point(1340, 408);
            txt3SDT.Name = "txt3SDT";
            txt3SDT.Size = new Size(195, 27);
            txt3SDT.TabIndex = 22;
            txt3SDT.TextChanged += txt3SDT_TextChanged;
            // 
            // View_Company
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(label3SDT);
            Controls.Add(txt3SDT);
            Controls.Add(button3Confirm);
            Controls.Add(label3InfoEmp);
            Controls.Add(label3NgaySinh);
            Controls.Add(txt3NgaySinh);
            Controls.Add(label3HoTen);
            Controls.Add(textBox2);
            Controls.Add(label3MaNhanVien);
            Controls.Add(txt3MaNhanVien);
            Controls.Add(button2Confirm);
            Controls.Add(label4);
            Controls.Add(label2MaCN);
            Controls.Add(txt2MaChiNhanh);
            Controls.Add(label2MaBoPhan);
            Controls.Add(txt2MaBoPhan);
            Controls.Add(label2MaNV);
            Controls.Add(txt2NhapMaNV);
            Controls.Add(button1NhanNam);
            Controls.Add(button1NhanThang);
            Controls.Add(label1NhapThoiGian);
            Controls.Add(txt1NhapThoiGian);
            Controls.Add(button1NhanNgay);
            Controls.Add(XuatDSDoanhThuCacChiNhanhTheo);
            Name = "View_Company";
            Text = "View_Company";
            ((System.ComponentModel.ISupportInitialize)XuatDSDoanhThuCacChiNhanhTheo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView XuatDSDoanhThuCacChiNhanhTheo;
        private Button button1NhanNgay;
        private TextBox txt1NhapThoiGian;
        private Label label1NhapThoiGian;
        private Button button1NhanThang;
        private Button button1NhanNam;
        private Label label2MaNV;
        private TextBox txt2NhapMaNV;
        private Label label2MaBoPhan;
        private TextBox txt2MaBoPhan;
        private Label label2MaCN;
        private TextBox txt2MaChiNhanh;
        private Label label4;
        private Button button2Confirm;
        private Button button3Confirm;
        private Label label3InfoEmp;
        private Label label3NgaySinh;
        private TextBox txt3NgaySinh;
        private Label label3HoTen;
        private TextBox textBox2;
        private Label label3MaNhanVien;
        private TextBox txt3MaNhanVien;
        private Label label3SDT;
        private TextBox txt3SDT;
    }
}