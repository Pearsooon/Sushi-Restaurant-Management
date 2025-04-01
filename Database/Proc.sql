GO 
USE SUSHIX_Final  

-- 1. Stored Procedure: Hiển thị thông tin khách hàng (Từ đăng nhập)
go
CREATE PROCEDURE sp_HienThiThongTinKhachHang
    @MaTaiKhoan INT ,@MatKhau varchar(50)
AS
BEGIN
	if exists (select ma_tai_khoan from TAI_KHOAN_KHACH_HANG where MA_TAI_KHOAN = @MaTaiKhoan)
		begin
			if exists (select ma_tai_khoan from TAI_KHOAN_KHACH_HANG where MA_TAI_KHOAN = @MaTaiKhoan and MAT_KHAU = @MatKhau)
				begin
					SELECT KH.*
					FROM TAI_KHOAN_KHACH_HANG TK
					JOIN KHACH_HANG KH ON TK.MA_KHACH_HANG = KH.MA_KHACH_HANG
					WHERE TK.MA_TAI_KHOAN = @MaTaiKhoan
				end
			else
			 raiserror ('Mat Khau khong chinh xac',16,1);
		end
	else
		raiserror ('Tai khoan khong ton tai',16,1);
END

-- 2. Stored Procedure: Làm lại thẻ thành viên
CREATE PROCEDURE sp_LamLaiTheThanhVien
    @MaKhachHang INT,
    @MaNhanVien INT
AS
BEGIN
	DECLARE @MaTheThanhVien INT;
    
    -- Tạo mã thẻ mới, bạn có thể thay đổi logic này theo nhu cầu
    SELECT @MaTheThanhVien = ISNULL(MAX(MA_THE_THANH_VIEN), 0) + 1 
    FROM THE_THANH_VIEN;
	BEGIN
		Delete from THE_THANH_VIEN where MA_KHACH_HANG = @MaKhachHang
		INSERT INTO THE_THANH_VIEN (DIEM, NGAY_LAP_THE, LOAI_THE, MA_KHACH_HANG, MA_NHAN_VIEN, MA_THE_THANH_VIEN)
		VALUES (0, GETDATE(), N'Thường', @MaKhachHang, @MaNhanVien, @MaTheThanhVien);
	END
END
GO

-- 3. Stored Procedure: Đăng ký thẻ thành viên (Tuc tao moi 1 khach hang)
CREATE PROCEDURE sp_DangKyTheThanhVien
    @MaNhanVien INT,
	@MatKhau varchar(30)
AS
BEGIN
    DECLARE @MaTheThanhVien INT;
	DECLARE @MaKhachHang INT;
	DECLARE @MaTaiKhoan INT;
    
    -- Tạo mã thẻ mới, bạn có thể thay đổi logic này theo nhu cầu
    SELECT @MaTheThanhVien = ISNULL(MAX(MA_THE_THANH_VIEN), 0) + 1 
    FROM THE_THANH_VIEN;
	SELECT @MaKhachHang = ISNULL(MAX(MA_KHACH_HANG), 0) + 1 
    FROM KHACH_HANG;
	SELECT @MaTaiKhoan = ISNULL(MAX(MA_TAI_KHOAN), 0) + 1 
    FROM TAI_KHOAN_KHACH_HANG;


        INSERT INTO KHACH_HANG (MA_KHACH_HANG) VALUES (@MaKhachHang)
		INSERT INTO TAI_KHOAN_KHACH_HANG (MA_TAI_KHOAN,MAT_KHAU,MA_KHACH_HANG) VALUES (@MaTaiKhoan,@MatKhau,@MaKhachHang)
        INSERT INTO THE_THANH_VIEN (DIEM, NGAY_LAP_THE, LOAI_THE, MA_KHACH_HANG, MA_NHAN_VIEN, MA_THE_THANH_VIEN)
        VALUES (0, GETDATE(), N'Thường', @MaKhachHang, @MaNhanVien, @MaTheThanhVien);
END

-- 4. Duyệt món ăn (xuat ra tat cac mon an dang phuc vu tai chi nhanh)

create proc duyetMonAn @MaChiNhanh int
as
begin
	SELECT distinct MA.*
	FROM MON_AN MA
	JOIN THUC_DON TD ON TD.MA_MON_AN = MA.MA_MON_AN
	JOIN CHI_NHANH CN ON CN.MA_KHU_VUC = TD.MA_KHU_VUC
	WHERE CN.MA_CHI_NHANH = @MaChiNhanh and MA.MA_MON_AN not in (SELECT MA_MON_AN FROM MON_AN_KHONG_PHUC_VU WHERE MA_CHI_NHANH = @MaChiNhanh)
end


-- 5. Stored Procedure: Gọi món tại chỗ (Sử dụng NOT EXISTS)
go
CREATE PROCEDURE sp_GoiMonTaiCho
   @MaNhanVien int,
   @MaKhachHang int,
   @MaChiNhanh int,
   @MaMonAn int,
   @SoLuong int
AS
BEGIN
    -- Kiểm tra phiếu đặt có tồn tại trong bảng PHIEU_DAT_TAI_CHO hay không
    -- Kiểm tra món ăn có tồn tại trong bảng MON_AN hay không
    IF NOT EXISTS (
        SELECT * 
        FROM MON_AN 
        WHERE MA_MON_AN = @MaMonAn
    )
    BEGIN
        RAISERROR (N'Món ăn không tồn tại!', 16, 1);
        RETURN;
    END 

    -- Thêm dữ liệu vào bảng THUC_DON
	DECLARE @MaPhieu int;
	SELECT @MaPhieu = ISNULL(MAX(MA_PHIEU), 0) + 1 
    FROM PHIEU_DAT;
	INSERT INTO PHIEU_DAT (MA_PHIEU, LOAI_PHIEU, NHAN_VIEN_LAP_PHIEU, MA_KHACH_HANG,MA_CHI_NHANH) VALUES (@MaPhieu, N'Phiếu đặt tại chỗ', @MaNhanVien, @MaKhachHang, @MaChiNhanh)
	INSERT INTO PHIEU_DAT_TAI_CHO (MA_PHIEU) values (@MaPhieu)
	INSERT INTO SO_LUONG_MON_AN (MA_PHIEU,MA_MON_AN,SO_LUONG) values (@MaPhieu,@MaMonAn,@SoLuong)
    PRINT N'Món ăn đã được gọi thành công!';
END

-- 6. Stored Procedure: Cập nhật phiếu gọi món tại chỗ --chua check ràng buộc món ăn-chi nhánh - đang phục vụ
CREATE PROCEDURE sp_CapNhatPhieuGoiMonTaiCho	@MaPhieu int,
	@MaMonAn int,
	@SoLuong int
as 
begin
	Insert into SO_LUONG_MON_AN values (@MaPhieu, @MaMonAn,@SoLuong)
end
GO

-- 7. Procedure: Lấy điểm thành viên
go
CREATE PROCEDURE sp_LayDiemThanhVien
    @MaKhachHang INT
AS
BEGIN
	select DIEM
	from THE_THANH_VIEN 
	where MA_KHACH_HANG = @MaKhachHang
END
GO


-- 8. Stored Procedure: Tạo hóa đơn thanh toán + Đánh giá
go
CREATE PROCEDURE sp_TaoHoaDonThanhToan
    @MaNhanVien INT,
	@MaKhachHang INT,
    @MaPhieu INT,
    @TongTien INT,
    @PhuongThucThanhToan NVARCHAR(20),
    @DiemPhucVu INT,
    @DiemMonAn INT,
    @DiemGiaCa INT,
    @BinhLuan NVARCHAR(255)
AS
BEGIN
    DECLARE @GiaTriGiam FLOAT;
    DECLARE @TongTienThanhToan FLOAT;
    DECLARE @MaHoaDon INT;
    DECLARE @MaDanhGia INT;
    DECLARE @LoaiThe NVARCHAR(20);

    SELECT @LoaiThe = LOAI_THE
    FROM THE_THANH_VIEN ttv
    WHERE ttv.MA_KHACH_HANG = @MaKhachHang

    SET @GiaTriGiam = CASE 
                        WHEN @LoaiThe = 'MemberShip' THEN 0.02
                        WHEN @LoaiThe = 'Silver' THEN 0.05
                        WHEN @LoaiThe = 'Gold' THEN 0.1
                        ELSE 0
                      END;

    SET @TongTienThanhToan = @TongTien - (@TongTien * @GiaTriGiam);

    SELECT @MaHoaDon = ISNULL(MAX(MA_HOA_DON), 0) + 1 FROM HOA_DON_THANH_TOAN;
    SELECT @MaDanhGia = ISNULL(MAX(MA_DANH_GIA), 0) + 1 FROM DANH_GIA;

    INSERT INTO HOA_DON_THANH_TOAN 
    (MA_HOA_DON, MA_NHAN_VIEN, TONG_TIEN, SO_TIEN_GIAM, TONG_TIEN_THANH_TOAN, PHUONG_THUC_THANH_TOAN, MA_PHIEU)
    VALUES 
    (@MaHoaDon, @MaNhanVien, @TongTien, (@TongTien * @GiaTriGiam), @TongTienThanhToan, @PhuongThucThanhToan, @MaPhieu);

    INSERT INTO DANH_GIA 
    (MA_DANH_GIA, DIEM_PHUC_VU, DIEM_MON_AN, DIEM_GIA_CA, BINH_LUAN, MA_PHIEU)
    VALUES 
    (@MaDanhGia, @DiemPhucVu, @DiemMonAn, @DiemGiaCa, @BinhLuan, @MaPhieu);
END
GO


-- 9. Trigger: Cập nhật lại điểm thành viên cho khách hàng -trigger su dung cho proc 8
CREATE TRIGGER trg_CapNhatDiemThanhVien
ON HOA_DON_THANH_TOAN
AFTER INSERT
AS
BEGIN
    DECLARE @MaKhachHang INT, @TongTienThanhToan INT;

    SELECT @MaKhachHang = P.MA_KHACH_HANG, @TongTienThanhToan = I.TONG_TIEN_THANH_TOAN
    FROM INSERTED I
    JOIN PHIEU_DAT P ON I.MA_PHIEU = P.MA_PHIEU;

    UPDATE THE_THANH_VIEN
    SET DIEM = DIEM + (@TongTienThanhToan / 100000)
    WHERE MA_KHACH_HANG = @MaKhachHang;
END
GO

-- 10. Stored Procedure: Đặt trước
CREATE PROCEDURE sp_DatTruoc
    @MaKhachHang INT,
	@MaChiNhanh INT,
    @NgayDen DATE,
    @GioDat TIME,
    @SoLuongKhach INT,
	@SDT char(10),
	@NhanVienLapPhieu INT,
    @GhiChu NVARCHAR(255)
AS
BEGIN
    DECLARE @MaPhieuDat INT;

    SELECT @MaPhieuDat = ISNULL(MAX(MA_PHIEU), 0) + 1 FROM PHIEU_DAT;


    INSERT INTO PHIEU_DAT (MA_PHIEU, NGAY_LAP_PHIEU, LOAI_PHIEU, NHAN_VIEN_LAP_PHIEU, MA_KHACH_HANG, MA_CHI_NHANH)
    VALUES (@MaPhieuDat, GETDATE(), N'Đặt trước', @NhanVienLapPhieu, @MaKhachHang, @MaChiNhanh );

    INSERT INTO PHIEU_DAT_TRUC_TUYEN (MA_PHIEU, SDT_KHACH_HANG, SO_LUONG_KHACH_DU_KIEN, NGAY_DEN, GIO_DAT, GHI_CHU_MON_AN)
    VALUES (@MaPhieuDat, @SDT, @SoLuongKhach, @NgayDen, @GioDat, @GhiChu);
END
GO

--Add luu lich su dang nhap 
CREATE PROCEDURE sp_LichSuDangNhap
    @MaKhachHang INT
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @MaTruyCap INT;

	SELECT @MaTruyCap = ISNULL(MAX(MA_TRUY_CAP), 0) + 1 FROM LICH_SU_TRUY_CAP_TRUC_TUYEN;
    
    -- Lấy ngày và giờ hiện tại
    DECLARE @NgayTruyCap DATE = GETDATE();
    DECLARE @GioTruyCap TIME = CONVERT(TIME, GETDATE());

    -- Thêm bản ghi mới vào bảng LICH_SU_TRUY_CAP_TRUC_TUYEN
    INSERT INTO LICH_SU_TRUY_CAP_TRUC_TUYEN (MA_TRUY_CAP, NGAY_TRUY_CAP, GIO_TRUY_CAP, MA_KHACH_HANG)
    VALUES (@MaTruyCap, @NgayTruyCap, @GioTruyCap, @MaKhachHang);
END;

-- Proc 11: Đặt giao tận nơi 
CREATE PROCEDURE sp_DatGiaoTanNoi
	@MaPhieu INT OUTPUT,
    @MaKhachHang INT,
    @MaChiNhanh INT,
    @MaNhanVien INT,
    @SDTKhachHang CHAR(10),
    @DiaChiGiao NVARCHAR(50),
    @GhiChuMonAn NVARCHAR(50)
AS
BEGIN
    DECLARE @MaPhieuDat INT;

    -- Tự động tạo mã phiếu mới
    SELECT @MaPhieuDat = ISNULL(MAX(MA_PHIEU), 0) + 1 FROM PHIEU_DAT;

    SET NOCOUNT ON;

    IF EXISTS (SELECT * FROM PHIEU_DAT WHERE @MaPhieuDat = MA_PHIEU) 
    BEGIN
        PRINT(N'Đã tồn tại phiếu này. Vui lòng chọn mã phiếu khác.');
        RETURN;
    END
    ELSE IF NOT EXISTS (SELECT * FROM KHACH_HANG WHERE MA_KHACH_HANG = @MaKhachHang) 
    BEGIN
        PRINT(N'Không tồn tại khách hàng này. Vui lòng thêm khách hàng mới.');
        RETURN;
    END
    ELSE IF NOT EXISTS (SELECT * FROM CHI_NHANH WHERE MA_CHI_NHANH = @MaChiNhanh) 
    BEGIN
        PRINT(N'Không tồn tại chi nhánh này. Vui lòng đổi chi nhánh khác.');
        RETURN;
    END
    ELSE IF NOT EXISTS (SELECT * FROM NHAN_VIEN WHERE MA_NHAN_VIEN = @MaNhanVien) 
    BEGIN
        PRINT(N'Không tồn tại nhân viên này. Vui lòng đổi nhân viên khác.');
        RETURN;
    END
    ELSE
    BEGIN
        -- Thêm phiếu đặt vào bảng PHIEU_DAT
        INSERT INTO PHIEU_DAT (MA_PHIEU, NGAY_LAP_PHIEU, LOAI_PHIEU, NHAN_VIEN_LAP_PHIEU, MA_KHACH_HANG, MA_CHI_NHANH)
        VALUES (@MaPhieuDat, GETDATE(), N'Phiếu đặt giao', @MaNhanVien, @MaKhachHang, @MaChiNhanh);

        -- Thêm chi tiết giao tận nơi vào bảng PHIEU_DAT_GIAO_TAN_NOI
        INSERT INTO PHIEU_DAT_GIAO_TAN_NOI (MA_PHIEU, SDT_KHACH_HANG, DIA_CHI_GIAO, GHI_CHU_MON_AN)
        VALUES (@MaPhieuDat, @SDTKhachHang, @DiaChiGiao, @GhiChuMonAn);
    END

    -- Gán giá trị đầu ra
    SET @MaPhieu = @MaPhieuDat;
END
GO

-- Proc 12: Tra cuu phieu dat
go
CREATE PROCEDURE sp_TraCuuPhieuDat_O @MaPhieu INT 
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM PHIEU_DAT WHERE @MaPhieu = MA_PHIEU)
	BEGIN
		PRINT(N'Không có phiếu đặt này.')
	END
	ELSE
		BEGIN
    SELECT 
        pd.MA_PHIEU,
        pd.NGAY_LAP_PHIEU,
        pd.LOAI_PHIEU,
        nv.HO_TEN AS NHAN_VIEN_LAP_PHIEU,
        kh.HO_TEN AS KHACH_HANG,
        kh.SDT AS SDT_KHACH_HANG,
        kh.DIA_CHI AS DIA_CHI_KHACH_HANG,
        cn.TEN_CHI_NHANH AS TEN_CHI_NHANH,
        pdgn.DIA_CHI_GIAO,
        pdgn.GHI_CHU_MON_AN
    FROM 
        PHIEU_DAT pd
    JOIN 
        NHAN_VIEN nv ON pd.NHAN_VIEN_LAP_PHIEU = nv.MA_NHAN_VIEN
    JOIN 
        KHACH_HANG kh ON pd.MA_KHACH_HANG = kh.MA_KHACH_HANG
    JOIN 
        CHI_NHANH cn ON pd.MA_CHI_NHANH = cn.MA_CHI_NHANH
    LEFT JOIN 
        PHIEU_DAT_GIAO_TAN_NOI pdgn ON pd.MA_PHIEU = pdgn.MA_PHIEU
    WHERE 
        pd.MA_PHIEU = @MaPhieu;
		END
END;


-- Proc 13: Tra cứu doanh thu của 1 chi nhánh
CREATE PROCEDURE sp_TraCuuDoanhThu
    @MaChiNhanh INT,               -- Mã chi nhánh cần tra cứu
    @ThoiGian NVARCHAR(10),        -- Thời gian cần tra cứu (Ngày, Tháng, Quý, Năm)
    @ThoiGianValue INT             -- Giá trị tương ứng cho thời gian (ngày/tháng/quý/năm)
AS
BEGIN
    -- Biến để chứa câu truy vấn động
    DECLARE @Sql NVARCHAR(MAX)

    -- Kiểm tra giá trị ThoiGian và tạo câu truy vấn phù hợp
    IF @ThoiGian = N'Ngày'
    BEGIN
        SET @Sql = N'
            SELECT SUM(HT.TONG_TIEN_THANH_TOAN) AS DoanhThu
            FROM HOA_DON_THANH_TOAN HT
            JOIN PHIEU_DAT PD ON HT.MA_PHIEU = PD.MA_PHIEU
            WHERE PD.MA_CHI_NHANH = @MaChiNhanh
            AND DAY(PD.NGAY_LAP_PHIEU) = @ThoiGianValue
			AND MONTH(PD.NGAY_LAP_PHIEU) = YEAR(GETDATE())
			AND YEAR(PD.NGAY_LAP_PHIEU) = YEAR(GETDATE())
        '
    END
    ELSE IF @ThoiGian = N'Tháng'
    BEGIN
        SET @Sql = N'
            SELECT SUM(HT.TONG_TIEN_THANH_TOAN) AS DoanhThu
            FROM HOA_DON_THANH_TOAN HT
            JOIN PHIEU_DAT PD ON HT.MA_PHIEU = PD.MA_PHIEU
            WHERE PD.MA_CHI_NHANH = @MaChiNhanh
            AND MONTH(PD.NGAY_LAP_PHIEU) = @ThoiGianValue
            AND YEAR(PD.NGAY_LAP_PHIEU) = YEAR(GETDATE())
        '
    END
    ELSE IF @ThoiGian = N'Quý'
    BEGIN
        SET @Sql = N'
            SELECT SUM(HT.TONG_TIEN_THANH_TOAN) AS DoanhThu
            FROM HOA_DON_THANH_TOAN HT
            JOIN PHIEU_DAT PD ON HT.MA_PHIEU = PD.MA_PHIEU
            WHERE PD.MA_CHI_NHANH = @MaChiNhanh
            AND DATEPART(QUARTER, PD.NGAY_LAP_PHIEU) = @ThoiGianValue
            AND YEAR(PD.NGAY_LAP_PHIEU) = YEAR(GETDATE())
        '
    END
    ELSE IF @ThoiGian = N'Năm'
    BEGIN
        SET @Sql = N'
            SELECT SUM(HT.TONG_TIEN_THANH_TOAN) AS DoanhThu
            FROM HOA_DON_THANH_TOAN HT
            JOIN PHIEU_DAT PD ON HT.MA_PHIEU = PD.MA_PHIEU
            WHERE PD.MA_CHI_NHANH = @MaChiNhanh
            AND YEAR(PD.NGAY_LAP_PHIEU) = @ThoiGianValue
        '
    END
    EXEC sp_executesql @Sql, N'@MaChiNhanh INT, @ThoiGianValue INT', @MaChiNhanh, @ThoiGianValue
END


-- Proc 14: Xem nhân viên + diểm phục vụ của cac nhân viên tại 1 chi nhánh

GO
CREATE PROCEDURE sp_XemDanhSachNhanVienDiemPhucVu_O
    @MaChiNhanh INT,
    @LoaiThoiGian NVARCHAR(10),  -- 'Ngay', 'Thang', 'Quy', 'Nam'
    @ThoiGian NVARCHAR(20)       -- Ngày (YYYY-MM-DD) hoặc giá trị số (tháng, quý, năm)
AS
BEGIN
    SET NOCOUNT ON;

    IF @LoaiThoiGian = N'Ngay'
    BEGIN
        SELECT 
            nv.HO_TEN, 
            dv.DIEM_PHUC_VU, 
            CONVERT(DATE, pd.NGAY_LAP_PHIEU) AS NGAY
        FROM PHIEU_DAT pd
        INNER JOIN HOA_DON_THANH_TOAN hdt ON pd.MA_PHIEU = hdt.MA_PHIEU
        INNER JOIN NHAN_VIEN nv ON hdt.MA_NHAN_VIEN = nv.MA_NHAN_VIEN
        INNER JOIN DANH_GIA dv ON pd.MA_PHIEU = dv.MA_PHIEU
        WHERE pd.MA_CHI_NHANH = @MaChiNhanh
          AND CONVERT(DATE, pd.NGAY_LAP_PHIEU) = CONVERT(DATE, @ThoiGian)
        ORDER BY NGAY;
    END
    ELSE IF @LoaiThoiGian = N'Thang'
    BEGIN
        SELECT 
            nv.HO_TEN, 
            dv.DIEM_PHUC_VU, 
            MONTH(pd.NGAY_LAP_PHIEU) AS THANG, 
            YEAR(pd.NGAY_LAP_PHIEU) AS NAM
        FROM PHIEU_DAT pd
        INNER JOIN HOA_DON_THANH_TOAN hdt ON pd.MA_PHIEU = hdt.MA_PHIEU
        INNER JOIN NHAN_VIEN nv ON hdt.MA_NHAN_VIEN = nv.MA_NHAN_VIEN
        INNER JOIN DANH_GIA dv ON pd.MA_PHIEU = dv.MA_PHIEU
        WHERE pd.MA_CHI_NHANH = @MaChiNhanh
          AND MONTH(pd.NGAY_LAP_PHIEU) = CAST(@ThoiGian AS INT)
        ORDER BY THANG, NAM;
    END
    ELSE IF @LoaiThoiGian = N'Quy'
    BEGIN
        SELECT 
            nv.HO_TEN, 
            dv.DIEM_PHUC_VU, 
            CASE 
                WHEN MONTH(pd.NGAY_LAP_PHIEU) BETWEEN 1 AND 3 THEN 'Quy 1'
                WHEN MONTH(pd.NGAY_LAP_PHIEU) BETWEEN 4 AND 6 THEN 'Quy 2'
                WHEN MONTH(pd.NGAY_LAP_PHIEU) BETWEEN 7 AND 9 THEN 'Quy 3'
                ELSE 'Quy 4'
            END AS QUY, 
            YEAR(pd.NGAY_LAP_PHIEU) AS NAM
        FROM PHIEU_DAT pd
        INNER JOIN HOA_DON_THANH_TOAN hdt ON pd.MA_PHIEU = hdt.MA_PHIEU
        INNER JOIN NHAN_VIEN nv ON hdt.MA_NHAN_VIEN = nv.MA_NHAN_VIEN
        INNER JOIN DANH_GIA dv ON pd.MA_PHIEU = dv.MA_PHIEU
        WHERE pd.MA_CHI_NHANH = @MaChiNhanh
          AND (CASE 
                WHEN MONTH(pd.NGAY_LAP_PHIEU) BETWEEN 1 AND 3 THEN 1
                WHEN MONTH(pd.NGAY_LAP_PHIEU) BETWEEN 4 AND 6 THEN 2
                WHEN MONTH(pd.NGAY_LAP_PHIEU) BETWEEN 7 AND 9 THEN 3
                ELSE 4
              END) = CAST(@ThoiGian AS INT)
        ORDER BY QUY, NAM;
    END
    ELSE IF @LoaiThoiGian = N'Nam'
    BEGIN
        SELECT 
            nv.HO_TEN, 
            dv.DIEM_PHUC_VU, 
            YEAR(pd.NGAY_LAP_PHIEU) AS NAM
        FROM PHIEU_DAT pd
        INNER JOIN HOA_DON_THANH_TOAN hdt ON pd.MA_PHIEU = hdt.MA_PHIEU
        INNER JOIN NHAN_VIEN nv ON hdt.MA_NHAN_VIEN = nv.MA_NHAN_VIEN
        INNER JOIN DANH_GIA dv ON pd.MA_PHIEU = dv.MA_PHIEU
        WHERE pd.MA_CHI_NHANH = @MaChiNhanh
          AND YEAR(pd.NGAY_LAP_PHIEU) = CAST(@ThoiGian AS INT)
        ORDER BY NAM;
    END
END;


--15: Tim kiem thong tin nhan vien theo chi nhanh (tim xem nhan vien dang lam o chi nhanh nao)
create proc timKiemThongTinNhanVien @MaNhanVien int
as
begin
	if exists (select Ma_nhan_vien from NHAN_VIEN where MA_NHAN_VIEN = @MaNhanVien)
		begin
			select TOP 1 *
			from NHAN_VIEN nv
			left join DIA_CHI_NHAN_VIEN dc on nv.MA_NHAN_VIEN = dc.MA_NHAN_VIEN
			left join LAM_VIEC lv on nv.MA_NHAN_VIEN = lv.MA_NHAN_VIEN
			where  nv.MA_NHAN_VIEN = @MaNhanVien
			ORDER by MA_DIA_CHI desc
		end
	else 
		raiserror ('Nhan vien khong ton tai',16,1)
end


--16 xoa 1 phieu dat
go
create proc xoaPhieuDat @MaPhieu int
as
begin
	if exists (select Ma_phieu from phieu_dat where MA_PHIEU = @MaPhieu)
	begin 
		delete from PHIEU_DAT where MA_PHIEU = @MaPhieu
	end
	else
	raiserror ('Ma phieu khong ton tai',17,1)
end

--17 xoa 1 the khach hang
go
create proc xoaTheKhachHang @MaKhachHang int
as
begin
	if exists (select MA_KHACH_HANG from THE_THANH_VIEN where MA_KHACH_HANG = @MaKhachHang)
	begin 
		delete from THE_THANH_VIEN where MA_KHACH_HANG = @MaKhachHang
	end
	else
	raiserror ('The khong ton tai',17,1)
end


--18 cap nhat the khach hang
go
create proc capNhatTheKhachHang @MaKhachHang int, @DiemCapNhat int
as
begin
	if exists (select MA_KHACH_HANG from THE_THANH_VIEN where MA_KHACH_HANG = @MaKhachHang)
	begin 
		update THE_THANH_VIEN
		set DIEM = DIEM + @DiemCapNhat
		where MA_KHACH_HANG = @MaKhachHang;
		update THE_THANH_VIEN
		set Loai_the = case 
					when Diem >= 300 then 'GOLD'
					when Diem >= 100 then 'SILVER'
					else  'MEMBER'
					end
		where MA_KHACH_HANG = @MaKhachHang;
	end
	else
		raiserror ('The khong ton tai',17,1)
end


--19 tim kiem hoa don theo ma khach hang

go
create proc timKiemHoaDonMaKhachHang @MaKhachHang int
as
begin
if exists (select MA_KHACH_HANG from KHACH_HANG where MA_KHACH_HANG = @MaKhachHang)
	begin
		select hd.*
		from HOA_DON_THANH_TOAN hd
		join PHIEU_DAT pd
		on hd.MA_PHIEU = pd.MA_PHIEU
		where pd.MA_KHACH_HANG = @MaKhachHang
	end
else 
		raiserror ('Khach hang khong ton tai',17,1)
end


----20--------- Tim kiem hoa don theo ngay/thang/nam
go
create proc timKiemHoaDonTheoNgay @Date date
as
begin
	SELECT *
	FROM HOA_DON_THANH_TOAN hd, Phieu_dat pd
	WHERE pd.Ngay_lap_phieu = @Date and hd.Ma_phieu = pd.Ma_phieu
end

go
create proc timKiemHoaDonTheoThang @Date date
as
begin
	SELECT *
	FROM HOA_DON_THANH_TOAN hd, Phieu_dat pd
	WHERE Month(pd.Ngay_lap_phieu) = Month(@Date) and Year(pd.Ngay_lap_phieu) = year(@Date)and hd.Ma_phieu = pd.Ma_phieu
end
 
go
create proc timKiemHoaDonTheoNam @Date int
as
begin
	SELECT *
	FROM HOA_DON_THANH_TOAN hd, Phieu_dat pd
	WHERE Year(pd.Ngay_lap_phieu) = @Date and hd.Ma_phieu = pd.Ma_phieu
end

go



----21--------- Tra cuu doanh thu cua cac chi nhanh theo ngay/thang/nam
go
create proc doanhThuChiNhanhTheoNgay @Date date
as
begin
	select pd.MA_CHI_NHANH, sum(hd.tong_tien_thanh_toan) as doanh_thu from HOA_DON_THANH_TOAN hd left join PHIEU_DAT pd on hd.MA_PHIEU = pd.MA_PHIEU where pd.NGAY_LAP_PHIEU = @Date group by pd.MA_CHI_NHANH 
end

go
create  proc doanhThuChiNhanhTheoThang @Date date
as
begin
	select pd.MA_CHI_NHANH, sum(hd.tong_tien_thanh_toan) as doanh_thu from HOA_DON_THANH_TOAN hd left join PHIEU_DAT pd on hd.MA_PHIEU = pd.MA_PHIEU 
		where Month(pd.NGAY_LAP_PHIEU) = Month(@Date) and  YEAR(pd.NGAY_LAP_PHIEU) = YEAR(@Date) group by pd.MA_CHI_NHANH order by pd.MA_CHI_NHANH
end

go
create proc doanhThuChiNhanhTheoNam @Date date
as
begin
	select pd.MA_CHI_NHANH, sum(hd.tong_tien_thanh_toan) as doanh_thu from HOA_DON_THANH_TOAN hd left join PHIEU_DAT pd on hd.MA_PHIEU = pd.MA_PHIEU 
		where YEAR(pd.NGAY_LAP_PHIEU) = YEAR(@Date) group by pd.MA_CHI_NHANH order by pd.MA_CHI_NHANH
end


--22----- chuyen nhan su 1 nhan vien
go
create  proc chuyenNhanSu @MaNhanVien int, @MaBoPhan int, @MaChiNhanh int
as
begin
	if exists (select MA_NHAN_VIEN from NHAN_VIEN where MA_NHAN_VIEN = @MaNhanVien)
		begin
			if exists ( select Ma_chi_nhanh from CHI_NHANH where Ma_chi_nhanh = @MaChiNhanh)
				begin
					if exists ( select Ma_bo_phan from BO_PHAN_PHU_TRACH where Ma_bo_phan = @MaBoPhan)
						begin
							declare @newid int
							set @newid = (select max(ma_ghi_nhan_lam_viec) from LAM_VIEC) + 1
							Insert into LAM_VIEC values (@newid,@MaNhanVien,@MaBoPhan,@MaChiNhanh)							
						end 
					else raiserror ('Bo phan khong ton tai',16,1)
				end
			else raiserror ('Chi nhanh khong ton tai',16,1)
		end
	else raiserror ('Nhan vien khong ton tai',16,1)
end


--23--------- Cap nhat thong tin nhan vien
go
create proc capNhatThongTinNhanVien @MaNhanVien int, @HoTen nvarchar(50), @NgaySinh Date, @SDT char(12)
as
begin
	if exists (select ma_nhan_vien from NHAN_VIEN where MA_NHAN_VIEN = @MaNhanVien)
		begin
			UPDATE NHAN_VIEN
			SET HO_TEN = @HoTen, NGAY_SINH = @NgaySinh, SDT = @SDT
			WHERE MA_NHAN_VIEN = @MaNhanVien
		end
	else
		raiserror('Nhan vien khong ton tai',16,1)
end