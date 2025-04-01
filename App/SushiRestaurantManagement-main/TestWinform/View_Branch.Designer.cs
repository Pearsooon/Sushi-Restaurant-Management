namespace TestWinform
{
    partial class View_Branch
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
            XuatDSMonAn = new DataGridView();
            NhanXemMonAn = new Button();
            txt1NhapMaChiNhanh = new TextBox();
            labelMonAn = new Label();
            labelMaPhieu = new Label();
            txt1NhapMaPhieu = new TextBox();
            NhanXemPhieu = new Button();
            XuatPhieu = new DataGridView();
            labelDoanhThu1ChiNhanh = new Label();
            txt2NhapMaChiNhanh = new TextBox();
            NhanXemDoanhThu1ChiNhanh = new Button();
            XuatDSDoanhThu1ChiNhanh = new DataGridView();
            label1DoanhThu1ChiNhanh = new Label();
            txt2NhapNgay = new TextBox();
            label2DoanhThu1ChiNhanh = new Label();
            txt2NhapGiaTri = new TextBox();
            label3GiaTri = new Label();
            txt3NhapGiaTri = new TextBox();
            label3ThoiGian = new Label();
            txt3NhapThoiGian = new TextBox();
            label3MaChiNhanh = new Label();
            txt3NhapMaChiNhanh = new TextBox();
            button3XemDiemNV = new Button();
            XuatDSNhanVienVaDiem = new DataGridView();
            label4MaNhanVien = new Label();
            txt4NhapMaNhanVien = new TextBox();
            button4XemTTNV = new Button();
            XuatThongTinNhanVien = new DataGridView();
            label5MaHoaDon = new Label();
            txt5NhapMaHoaDon = new TextBox();
            XemHDTheoMa = new DataGridView();
            label6NhapThoiGian = new Label();
            txt6NhapThoiGian = new TextBox();
            button6NhanThang = new Button();
            XuatDSCacHoaDonTheo = new DataGridView();
            button6NhanNgay = new Button();
            button6NhanNam = new Button();
            NhanXemHDtheoMa1_Click_2 = new Button();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)XuatDSMonAn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XuatPhieu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XuatDSDoanhThu1ChiNhanh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XuatDSNhanVienVaDiem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XuatThongTinNhanVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XemHDTheoMa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XuatDSCacHoaDonTheo).BeginInit();
            SuspendLayout();
            // 
            // XuatDSMonAn
            // 
            XuatDSMonAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatDSMonAn.Location = new Point(37, 206);
            XuatDSMonAn.Margin = new Padding(5);
            XuatDSMonAn.Name = "XuatDSMonAn";
            XuatDSMonAn.RowHeadersWidth = 51;
            XuatDSMonAn.Size = new Size(847, 288);
            XuatDSMonAn.TabIndex = 0;
            XuatDSMonAn.CellContentClick += XuatDSMonAn_CellContentClick;
            // 
            // NhanXemMonAn
            // 
            NhanXemMonAn.Location = new Point(618, 504);
            NhanXemMonAn.Margin = new Padding(5);
            NhanXemMonAn.Name = "NhanXemMonAn";
            NhanXemMonAn.Size = new Size(266, 82);
            NhanXemMonAn.TabIndex = 1;
            NhanXemMonAn.Text = "Xem Món Ăn";
            NhanXemMonAn.UseVisualStyleBackColor = true;
            NhanXemMonAn.Click += NhanXemMonAn_Click;
            // 
            // txt1NhapMaChiNhanh
            // 
            txt1NhapMaChiNhanh.Location = new Point(37, 154);
            txt1NhapMaChiNhanh.Margin = new Padding(5);
            txt1NhapMaChiNhanh.Name = "txt1NhapMaChiNhanh";
            txt1NhapMaChiNhanh.Size = new Size(201, 39);
            txt1NhapMaChiNhanh.TabIndex = 2;
            txt1NhapMaChiNhanh.TextChanged += txt1NhapMaChiNhanh_TextChanged;
            // 
            // labelMonAn
            // 
            labelMonAn.AutoSize = true;
            labelMonAn.Location = new Point(39, 101);
            labelMonAn.Margin = new Padding(5, 0, 5, 0);
            labelMonAn.Name = "labelMonAn";
            labelMonAn.Size = new Size(169, 32);
            labelMonAn.TabIndex = 3;
            labelMonAn.Text = "Mã Chi Nhánh";
            labelMonAn.Click += labelMonAn_Click;
            // 
            // labelMaPhieu
            // 
            labelMaPhieu.AutoSize = true;
            labelMaPhieu.Location = new Point(1108, 117);
            labelMaPhieu.Margin = new Padding(5, 0, 5, 0);
            labelMaPhieu.Name = "labelMaPhieu";
            labelMaPhieu.Size = new Size(115, 32);
            labelMaPhieu.TabIndex = 7;
            labelMaPhieu.Text = "Mã Phiếu";
            labelMaPhieu.Click += labelMaPhieu_Click;
            // 
            // txt1NhapMaPhieu
            // 
            txt1NhapMaPhieu.Location = new Point(1108, 154);
            txt1NhapMaPhieu.Margin = new Padding(5);
            txt1NhapMaPhieu.Name = "txt1NhapMaPhieu";
            txt1NhapMaPhieu.Size = new Size(201, 39);
            txt1NhapMaPhieu.TabIndex = 6;
            txt1NhapMaPhieu.TextChanged += txt1NhapMaPhieu_TextChanged;
            // 
            // NhanXemPhieu
            // 
            NhanXemPhieu.Location = new Point(1574, 504);
            NhanXemPhieu.Margin = new Padding(5);
            NhanXemPhieu.Name = "NhanXemPhieu";
            NhanXemPhieu.Size = new Size(266, 82);
            NhanXemPhieu.TabIndex = 5;
            NhanXemPhieu.Text = "Xem Phiếu";
            NhanXemPhieu.UseVisualStyleBackColor = true;
            NhanXemPhieu.Click += NhanXemPhieu_Click;
            // 
            // XuatPhieu
            // 
            XuatPhieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatPhieu.Location = new Point(1108, 206);
            XuatPhieu.Margin = new Padding(5);
            XuatPhieu.Name = "XuatPhieu";
            XuatPhieu.RowHeadersWidth = 51;
            XuatPhieu.Size = new Size(733, 288);
            XuatPhieu.TabIndex = 4;
            XuatPhieu.CellContentClick += XuatPhieu_CellContentClick;
            // 
            // labelDoanhThu1ChiNhanh
            // 
            labelDoanhThu1ChiNhanh.AutoSize = true;
            labelDoanhThu1ChiNhanh.Location = new Point(41, 634);
            labelDoanhThu1ChiNhanh.Margin = new Padding(5, 0, 5, 0);
            labelDoanhThu1ChiNhanh.Name = "labelDoanhThu1ChiNhanh";
            labelDoanhThu1ChiNhanh.Size = new Size(169, 32);
            labelDoanhThu1ChiNhanh.TabIndex = 11;
            labelDoanhThu1ChiNhanh.Text = "Mã Chi Nhánh";
            labelDoanhThu1ChiNhanh.Click += labelDoanhThu1ChiNhanh_Click;
            // 
            // txt2NhapMaChiNhanh
            // 
            txt2NhapMaChiNhanh.Location = new Point(39, 686);
            txt2NhapMaChiNhanh.Margin = new Padding(5);
            txt2NhapMaChiNhanh.Name = "txt2NhapMaChiNhanh";
            txt2NhapMaChiNhanh.Size = new Size(201, 39);
            txt2NhapMaChiNhanh.TabIndex = 10;
            txt2NhapMaChiNhanh.TextChanged += txt2NhapMaChiNhanh_TextChanged;
            // 
            // NhanXemDoanhThu1ChiNhanh
            // 
            NhanXemDoanhThu1ChiNhanh.Location = new Point(618, 1037);
            NhanXemDoanhThu1ChiNhanh.Margin = new Padding(5);
            NhanXemDoanhThu1ChiNhanh.Name = "NhanXemDoanhThu1ChiNhanh";
            NhanXemDoanhThu1ChiNhanh.Size = new Size(266, 82);
            NhanXemDoanhThu1ChiNhanh.TabIndex = 9;
            NhanXemDoanhThu1ChiNhanh.Text = "Xem Doanh Thu";
            NhanXemDoanhThu1ChiNhanh.UseVisualStyleBackColor = true;
            NhanXemDoanhThu1ChiNhanh.Click += NhanXemDoanhThu1ChiNhanh_Click;
            // 
            // XuatDSDoanhThu1ChiNhanh
            // 
            XuatDSDoanhThu1ChiNhanh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatDSDoanhThu1ChiNhanh.Location = new Point(39, 739);
            XuatDSDoanhThu1ChiNhanh.Margin = new Padding(5);
            XuatDSDoanhThu1ChiNhanh.Name = "XuatDSDoanhThu1ChiNhanh";
            XuatDSDoanhThu1ChiNhanh.RowHeadersWidth = 51;
            XuatDSDoanhThu1ChiNhanh.Size = new Size(845, 288);
            XuatDSDoanhThu1ChiNhanh.TabIndex = 8;
            XuatDSDoanhThu1ChiNhanh.CellContentClick += XuatDSDoanhThu1ChiNhanh_CellContentClick;
            // 
            // label1DoanhThu1ChiNhanh
            // 
            label1DoanhThu1ChiNhanh.AutoSize = true;
            label1DoanhThu1ChiNhanh.Location = new Point(307, 618);
            label1DoanhThu1ChiNhanh.Margin = new Padding(5, 0, 5, 0);
            label1DoanhThu1ChiNhanh.Name = "label1DoanhThu1ChiNhanh";
            label1DoanhThu1ChiNhanh.Size = new Size(273, 64);
            label1DoanhThu1ChiNhanh.TabIndex = 13;
            label1DoanhThu1ChiNhanh.Text = "Thời gian \r\n(Ngày/Tháng/Quý/Năm)\r\n";
            label1DoanhThu1ChiNhanh.Click += label1DoanhThu1ChiNhanh_Click;
            // 
            // txt2NhapNgay
            // 
            txt2NhapNgay.Location = new Point(307, 686);
            txt2NhapNgay.Margin = new Padding(5);
            txt2NhapNgay.Name = "txt2NhapNgay";
            txt2NhapNgay.Size = new Size(201, 39);
            txt2NhapNgay.TabIndex = 12;
            txt2NhapNgay.TextChanged += txt2NhapNgay_TextChanged;
            // 
            // label2DoanhThu1ChiNhanh
            // 
            label2DoanhThu1ChiNhanh.AutoSize = true;
            label2DoanhThu1ChiNhanh.Location = new Point(630, 634);
            label2DoanhThu1ChiNhanh.Margin = new Padding(5, 0, 5, 0);
            label2DoanhThu1ChiNhanh.Name = "label2DoanhThu1ChiNhanh";
            label2DoanhThu1ChiNhanh.Size = new Size(77, 32);
            label2DoanhThu1ChiNhanh.TabIndex = 15;
            label2DoanhThu1ChiNhanh.Text = "Giá trị";
            label2DoanhThu1ChiNhanh.Click += label2DoanhThu1ChiNhanh_Click;
            // 
            // txt2NhapGiaTri
            // 
            txt2NhapGiaTri.Location = new Point(630, 686);
            txt2NhapGiaTri.Margin = new Padding(5);
            txt2NhapGiaTri.Name = "txt2NhapGiaTri";
            txt2NhapGiaTri.Size = new Size(201, 39);
            txt2NhapGiaTri.TabIndex = 14;
            txt2NhapGiaTri.TextChanged += txt2NhapGiaTri_TextChanged;
            // 
            // label3GiaTri
            // 
            label3GiaTri.AutoSize = true;
            label3GiaTri.Location = new Point(1637, 634);
            label3GiaTri.Margin = new Padding(5, 0, 5, 0);
            label3GiaTri.Name = "label3GiaTri";
            label3GiaTri.Size = new Size(77, 32);
            label3GiaTri.TabIndex = 23;
            label3GiaTri.Text = "Giá trị";
            label3GiaTri.Click += label3GiaTri_Click;
            // 
            // txt3NhapGiaTri
            // 
            txt3NhapGiaTri.Location = new Point(1637, 686);
            txt3NhapGiaTri.Margin = new Padding(5);
            txt3NhapGiaTri.Name = "txt3NhapGiaTri";
            txt3NhapGiaTri.Size = new Size(201, 39);
            txt3NhapGiaTri.TabIndex = 22;
            txt3NhapGiaTri.TextChanged += txt3NhapGiaTri_TextChanged;
            // 
            // label3ThoiGian
            // 
            label3ThoiGian.AutoSize = true;
            label3ThoiGian.Location = new Point(1317, 618);
            label3ThoiGian.Margin = new Padding(5, 0, 5, 0);
            label3ThoiGian.Name = "label3ThoiGian";
            label3ThoiGian.Size = new Size(273, 64);
            label3ThoiGian.TabIndex = 21;
            label3ThoiGian.Text = "Thời gian \r\n(Ngày/Tháng/Quý/Năm)\r\n";
            label3ThoiGian.Click += label3ThoiGian_Click;
            // 
            // txt3NhapThoiGian
            // 
            txt3NhapThoiGian.Location = new Point(1366, 686);
            txt3NhapThoiGian.Margin = new Padding(5);
            txt3NhapThoiGian.Name = "txt3NhapThoiGian";
            txt3NhapThoiGian.Size = new Size(201, 39);
            txt3NhapThoiGian.TabIndex = 20;
            txt3NhapThoiGian.TextChanged += txt3NhapThoiGian_TextChanged;
            // 
            // label3MaChiNhanh
            // 
            label3MaChiNhanh.AutoSize = true;
            label3MaChiNhanh.Location = new Point(1108, 634);
            label3MaChiNhanh.Margin = new Padding(5, 0, 5, 0);
            label3MaChiNhanh.Name = "label3MaChiNhanh";
            label3MaChiNhanh.Size = new Size(169, 32);
            label3MaChiNhanh.TabIndex = 19;
            label3MaChiNhanh.Text = "Mã Chi Nhánh";
            label3MaChiNhanh.Click += label3MaChiNhanh_Click;
            // 
            // txt3NhapMaChiNhanh
            // 
            txt3NhapMaChiNhanh.Location = new Point(1108, 686);
            txt3NhapMaChiNhanh.Margin = new Padding(5);
            txt3NhapMaChiNhanh.Name = "txt3NhapMaChiNhanh";
            txt3NhapMaChiNhanh.Size = new Size(201, 39);
            txt3NhapMaChiNhanh.TabIndex = 18;
            txt3NhapMaChiNhanh.TextChanged += txt3NhapMaChiNhanh_TextChanged;
            // 
            // button3XemDiemNV
            // 
            button3XemDiemNV.Location = new Point(1574, 1037);
            button3XemDiemNV.Margin = new Padding(5);
            button3XemDiemNV.Name = "button3XemDiemNV";
            button3XemDiemNV.Size = new Size(266, 82);
            button3XemDiemNV.TabIndex = 17;
            button3XemDiemNV.Text = "Xem Điểm Nhân Viên";
            button3XemDiemNV.UseVisualStyleBackColor = true;
            button3XemDiemNV.Click += button3XemDiemNV_Click;
            // 
            // XuatDSNhanVienVaDiem
            // 
            XuatDSNhanVienVaDiem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatDSNhanVienVaDiem.Location = new Point(1108, 739);
            XuatDSNhanVienVaDiem.Margin = new Padding(5);
            XuatDSNhanVienVaDiem.Name = "XuatDSNhanVienVaDiem";
            XuatDSNhanVienVaDiem.RowHeadersWidth = 51;
            XuatDSNhanVienVaDiem.Size = new Size(733, 288);
            XuatDSNhanVienVaDiem.TabIndex = 16;
            XuatDSNhanVienVaDiem.CellContentClick += XuatDSNhanVienVaDiem_CellContentClick;
            // 
            // label4MaNhanVien
            // 
            label4MaNhanVien.AutoSize = true;
            label4MaNhanVien.Location = new Point(41, 1120);
            label4MaNhanVien.Margin = new Padding(5, 0, 5, 0);
            label4MaNhanVien.Name = "label4MaNhanVien";
            label4MaNhanVien.Size = new Size(168, 32);
            label4MaNhanVien.TabIndex = 27;
            label4MaNhanVien.Text = "Mã Nhân Viên";
            label4MaNhanVien.Click += label2_Click;
            // 
            // txt4NhapMaNhanVien
            // 
            txt4NhapMaNhanVien.Location = new Point(37, 1157);
            txt4NhapMaNhanVien.Margin = new Padding(5);
            txt4NhapMaNhanVien.Name = "txt4NhapMaNhanVien";
            txt4NhapMaNhanVien.Size = new Size(201, 39);
            txt4NhapMaNhanVien.TabIndex = 26;
            txt4NhapMaNhanVien.TextChanged += txt4NhapMaNhanVien_TextChanged;
            // 
            // button4XemTTNV
            // 
            button4XemTTNV.Location = new Point(561, 1507);
            button4XemTTNV.Margin = new Padding(5);
            button4XemTTNV.Name = "button4XemTTNV";
            button4XemTTNV.Size = new Size(323, 82);
            button4XemTTNV.TabIndex = 25;
            button4XemTTNV.Text = "Xem Thông Tin Nhân Viên";
            button4XemTTNV.UseVisualStyleBackColor = true;
            button4XemTTNV.Click += button4XemTTNV_Click;
            // 
            // XuatThongTinNhanVien
            // 
            XuatThongTinNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatThongTinNhanVien.Location = new Point(37, 1210);
            XuatThongTinNhanVien.Margin = new Padding(5);
            XuatThongTinNhanVien.Name = "XuatThongTinNhanVien";
            XuatThongTinNhanVien.RowHeadersWidth = 51;
            XuatThongTinNhanVien.Size = new Size(847, 288);
            XuatThongTinNhanVien.TabIndex = 24;
            XuatThongTinNhanVien.CellContentClick += XuatThongTinNhanVien_CellContentClick;
            // 
            // label5MaHoaDon
            // 
            label5MaHoaDon.AutoSize = true;
            label5MaHoaDon.Location = new Point(2001, 117);
            label5MaHoaDon.Margin = new Padding(5, 0, 5, 0);
            label5MaHoaDon.Name = "label5MaHoaDon";
            label5MaHoaDon.Size = new Size(184, 32);
            label5MaHoaDon.TabIndex = 31;
            label5MaHoaDon.Text = "Mã Khách Hàng";
            label5MaHoaDon.Click += label5MaHoaDon_Click;
            // 
            // txt5NhapMaHoaDon
            // 
            txt5NhapMaHoaDon.Location = new Point(2001, 154);
            txt5NhapMaHoaDon.Margin = new Padding(5);
            txt5NhapMaHoaDon.Name = "txt5NhapMaHoaDon";
            txt5NhapMaHoaDon.Size = new Size(201, 39);
            txt5NhapMaHoaDon.TabIndex = 30;
            txt5NhapMaHoaDon.TextChanged += txt5NhapMaHoaDon_TextChanged;
            // 
            // XemHDTheoMa
            // 
            XemHDTheoMa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XemHDTheoMa.Location = new Point(2001, 206);
            XemHDTheoMa.Margin = new Padding(5);
            XemHDTheoMa.Name = "XemHDTheoMa";
            XemHDTheoMa.RowHeadersWidth = 51;
            XemHDTheoMa.Size = new Size(733, 288);
            XemHDTheoMa.TabIndex = 28;
            XemHDTheoMa.CellContentClick += XemHDTheoMa_CellContentClick;
            // 
            // label6NhapThoiGian
            // 
            label6NhapThoiGian.AutoSize = true;
            label6NhapThoiGian.Location = new Point(2001, 618);
            label6NhapThoiGian.Margin = new Padding(5, 0, 5, 0);
            label6NhapThoiGian.Name = "label6NhapThoiGian";
            label6NhapThoiGian.Size = new Size(522, 64);
            label6NhapThoiGian.TabIndex = 35;
            label6NhapThoiGian.Text = "Thời gian cần xét\r\n(Ngày: 20241030, Tháng: 20241030, Năm: 2024)";
            label6NhapThoiGian.Click += label3_Click;
            // 
            // txt6NhapThoiGian
            // 
            txt6NhapThoiGian.Location = new Point(2001, 686);
            txt6NhapThoiGian.Margin = new Padding(5);
            txt6NhapThoiGian.Name = "txt6NhapThoiGian";
            txt6NhapThoiGian.Size = new Size(201, 39);
            txt6NhapThoiGian.TabIndex = 34;
            txt6NhapThoiGian.TextChanged += txt6NhapThoiGian_TextChanged;
            // 
            // button6NhanThang
            // 
            button6NhanThang.Location = new Point(2330, 1037);
            button6NhanThang.Margin = new Padding(5);
            button6NhanThang.Name = "button6NhanThang";
            button6NhanThang.Size = new Size(203, 82);
            button6NhanThang.TabIndex = 33;
            button6NhanThang.Text = "Tháng";
            button6NhanThang.UseVisualStyleBackColor = true;
            button6NhanThang.Click += button6NhanThang_Click;
            // 
            // XuatDSCacHoaDonTheo
            // 
            XuatDSCacHoaDonTheo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            XuatDSCacHoaDonTheo.Location = new Point(2001, 739);
            XuatDSCacHoaDonTheo.Margin = new Padding(5);
            XuatDSCacHoaDonTheo.Name = "XuatDSCacHoaDonTheo";
            XuatDSCacHoaDonTheo.RowHeadersWidth = 51;
            XuatDSCacHoaDonTheo.Size = new Size(847, 288);
            XuatDSCacHoaDonTheo.TabIndex = 32;
            XuatDSCacHoaDonTheo.CellContentClick += XuatDSCacHoaDonTheo_CellContentClick;
            // 
            // button6NhanNgay
            // 
            button6NhanNgay.Location = new Point(2001, 1037);
            button6NhanNgay.Margin = new Padding(5);
            button6NhanNgay.Name = "button6NhanNgay";
            button6NhanNgay.Size = new Size(203, 82);
            button6NhanNgay.TabIndex = 36;
            button6NhanNgay.Text = "Ngày";
            button6NhanNgay.UseVisualStyleBackColor = true;
            button6NhanNgay.Click += button6NhanNgay_Click;
            // 
            // button6NhanNam
            // 
            button6NhanNam.Location = new Point(2645, 1037);
            button6NhanNam.Margin = new Padding(5);
            button6NhanNam.Name = "button6NhanNam";
            button6NhanNam.Size = new Size(203, 82);
            button6NhanNam.TabIndex = 37;
            button6NhanNam.Text = "Năm";
            button6NhanNam.UseVisualStyleBackColor = true;
            button6NhanNam.Click += button6NhanNam_Click;
            // 
            // NhanXemHDtheoMa1_Click_2
            // 
            NhanXemHDtheoMa1_Click_2.Location = new Point(2533, 504);
            NhanXemHDtheoMa1_Click_2.Name = "NhanXemHDtheoMa1_Click_2";
            NhanXemHDtheoMa1_Click_2.Size = new Size(201, 82);
            NhanXemHDtheoMa1_Click_2.TabIndex = 38;
            NhanXemHDtheoMa1_Click_2.Text = "Xem hoá đơn";
            NhanXemHDtheoMa1_Click_2.UseVisualStyleBackColor = true;
            NhanXemHDtheoMa1_Click_2.Click += NhanXemHDtheoMa1_Click_2_Click;

            // 
            // View_Branch
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2884, 1688);
            Controls.Add(BackButton);
            Controls.Add(NhanXemHDtheoMa1_Click_2);
            Controls.Add(button6NhanNam);
            Controls.Add(button6NhanNgay);
            Controls.Add(label6NhapThoiGian);
            Controls.Add(txt6NhapThoiGian);
            Controls.Add(button6NhanThang);
            Controls.Add(XuatDSCacHoaDonTheo);
            Controls.Add(label5MaHoaDon);
            Controls.Add(txt5NhapMaHoaDon);
            Controls.Add(XemHDTheoMa);
            Controls.Add(label4MaNhanVien);
            Controls.Add(txt4NhapMaNhanVien);
            Controls.Add(button4XemTTNV);
            Controls.Add(XuatThongTinNhanVien);
            Controls.Add(label3GiaTri);
            Controls.Add(txt3NhapGiaTri);
            Controls.Add(label3ThoiGian);
            Controls.Add(txt3NhapThoiGian);
            Controls.Add(label3MaChiNhanh);
            Controls.Add(txt3NhapMaChiNhanh);
            Controls.Add(button3XemDiemNV);
            Controls.Add(XuatDSNhanVienVaDiem);
            Controls.Add(label2DoanhThu1ChiNhanh);
            Controls.Add(txt2NhapGiaTri);
            Controls.Add(label1DoanhThu1ChiNhanh);
            Controls.Add(txt2NhapNgay);
            Controls.Add(labelDoanhThu1ChiNhanh);
            Controls.Add(txt2NhapMaChiNhanh);
            Controls.Add(NhanXemDoanhThu1ChiNhanh);
            Controls.Add(XuatDSDoanhThu1ChiNhanh);
            Controls.Add(labelMaPhieu);
            Controls.Add(txt1NhapMaPhieu);
            Controls.Add(NhanXemPhieu);
            Controls.Add(XuatPhieu);
            Controls.Add(labelMonAn);
            Controls.Add(txt1NhapMaChiNhanh);
            Controls.Add(NhanXemMonAn);
            Controls.Add(XuatDSMonAn);
            Margin = new Padding(5);
            Name = "View_Branch";
            Text = "View_Branch";
            Load += View_Branch_Load;
            ((System.ComponentModel.ISupportInitialize)XuatDSMonAn).EndInit();
            ((System.ComponentModel.ISupportInitialize)XuatPhieu).EndInit();
            ((System.ComponentModel.ISupportInitialize)XuatDSDoanhThu1ChiNhanh).EndInit();
            ((System.ComponentModel.ISupportInitialize)XuatDSNhanVienVaDiem).EndInit();
            ((System.ComponentModel.ISupportInitialize)XuatThongTinNhanVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)XemHDTheoMa).EndInit();
            ((System.ComponentModel.ISupportInitialize)XuatDSCacHoaDonTheo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView XuatDSMonAn;
        private Button NhanXemMonAn;
        private TextBox txt1NhapMaChiNhanh;
        private Label labelMonAn;
        private Label labelMaPhieu;
        private TextBox txt1NhapMaPhieu;
        private Button NhanXemPhieu;
        private DataGridView XuatPhieu;
        private Label labelDoanhThu1ChiNhanh;
        private TextBox txt2NhapMaChiNhanh;
        private Button NhanXemDoanhThu1ChiNhanh;
        private DataGridView XuatDSDoanhThu1ChiNhanh;
        private Label label1DoanhThu1ChiNhanh;
        private TextBox txt2NhapNgay;
        private Label label2DoanhThu1ChiNhanh;
        private TextBox txt2NhapGiaTri;
        private Label label3GiaTri;
        private TextBox txt3NhapGiaTri;
        private Label label3ThoiGian;
        private TextBox txt3NhapThoiGian;
        private Label label3MaChiNhanh;
        private TextBox txt3NhapMaChiNhanh;
        private Button button3XemDiemNV;
        private DataGridView XuatDSNhanVienVaDiem;
        private Label label4MaNhanVien;
        private TextBox txt4NhapMaNhanVien;
        private Button button4XemTTNV;
        private DataGridView XuatThongTinNhanVien;
        private Label label5MaHoaDon;
        private TextBox txt5NhapMaHoaDon;

        public Button NhanXemHDtheoMa { get; private set; }

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button NhanXemHDtheoMa1_Click_2;
        private DataGridView XemHDTheoMa;
        private Label label6NhapThoiGian;
        private TextBox txt6NhapThoiGian;
        private Button button6NhanThang;
        private DataGridView XuatDSCacHoaDonTheo;
        private Button button6NhanNgay;
        private Button button6NhanNam;
        private Button BackButton;

        public Button NhanXemHDtheoMa1 { get; private set; }

        
    }
}