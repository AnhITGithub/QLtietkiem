

alter proc dangnhap(@taikhoan nvarchar(50), @matkhau nvarchar(50))
as
begin
	select * from tblNhanVien where sTaiKhoan=@taikhoan and sMatKhau=@matkhau
end

alter proc quenmatkhau(@tk nvarchar(50), @matkhaumoi nvarchar(50))
as
begin
	update tblNhanVien
	set sMatKhau=@matkhaumoi
	where sTaiKhoan=@tk
end

alter proc hien_nv
as
begin
	select * from tblNhanVien
end

exec hien_nv


alter proc them_nv 
	@manv nvarchar(20),
	@tennv nvarchar(50),
	@taikhoan nvarchar(50),
	@matkhau nvarchar(20),
	@sdt nvarchar(50),
	@diachi nvarchar(50)
as
begin
	insert into tblNhanVien(sMaNV,sTenNV,sTaiKhoan,sMatKhau,sSDT,sDiaChi)
	values(@manv,@tennv,@taikhoan,@matkhau,@sdt,@diachi )
end

alter proc sua_nv
	@manv nvarchar(20),
	@tennv nvarchar(50),
	@taikhoan nvarchar(50),
	@matkhau nvarchar(20),
	@sdt nvarchar(50),
	@diachi nvarchar(50)
as
begin
	update tblNhanVien
	set sMaNV=@manv,sTenNV=@tennv,sTaiKhoan=@taikhoan,sMatKhau=@matkhau,sSDT=@sdt,sDiaChi=@diachi
	where sMaNV=@manv
end

alter proc xoa_nv
	@manv nvarchar(20)
as
begin
	delete 
	from tblNhanVien
	where sMaNV=@manv
end

CREATE PROCEDURE tblLoaitietkiem_INSERT 
	@MaloaiTK nvarchar(50),
	@TenLoaiTK nvarchar(50),
	@Phantram nvarchar(50),
	@Kyhan nvarchar(50)

AS 
BEGIN
	INSERT INTO tblLoaitietkiem
	VALUES (@MaloaiTK,@TenLoaiTK,@Phantram,@Kyhan)
	IF @@ROWCOUNT >0 
		BEGIN 
			RETURN 1 
		END
	ELSE 
		RETURN 0 
end


CREATE PROCEDURE tblLoaitietkiem_UPDATE 
	@MaloaiTK nvarchar(50),
	@TenLoaiTK nvarchar(50),
	@Phantram nvarchar(50),
	@Kyhan nvarchar(50)

AS 
BEGIN
	UPDATE tblLoaitietkiem
	SET
		sTenLoaiTK =@TenLoaiTK,
		sPhantram= @Phantram,
		sKyhan = @Kyhan
	
	WHERE sMaLoaiTK = @MaloaiTK;
	
	IF @@ROWCOUNT >0 BEGIN RETURN 1 END
	ELSE BEGIN RETURN 0 END
END


CREATE PROCEDURE tblHoaDon_INSERT 
	@sMaHD nvarchar(50),
	@sMaSoTK nvarchar(50),
	@sTenKH nvarchar(50),
	@sSotiengui nvarchar(50),
	@sTienlai nvarchar(50),
	@sTongtien nvarchar(50),
	@sMaNV nvarchar(50),
	@sMaKH nvarchar(50),
	@sMaLoaiTK nvarchar(50),
	@sTenLoaiTk nvarchar(50),
	@sKyhan nvarchar(50),
	@sPhantram nvarchar(50),
	@sNgaygui datetime,
	@sNgaylap datetime,
	@sTenNV nvarchar(50)
AS 
BEGIN
	INSERT INTO tblHoaDon(sMaHD,sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui,sKyhan,sPhantram,sTongtien,sTienlai,sMaNV,sTenNV,sNgaylap)
	VALUES (@sMaHD ,@sMaSoTK ,@sMaKH ,@sTenKH ,@sMaLoaiTK ,@sTenLoaiTK,@sSotiengui,@sNgaygui,@sKyhan,@sPhantram,@sTongtien,@sTienlai,@sMaNV,@sTenNV,@sNgaylap );
	IF @@ROWCOUNT >0 BEGIN RETURN 1 END
	ELSE BEGIN RETURN 0 END;
END


CREATE PROCEDURE tblHoaDon_UPDATE 
	@sMaHD nvarchar(50),
	@sMaSoTK nvarchar(50),
	@sTenKH nvarchar(50),
	@sSotiengui nvarchar(50),
	@sTienlai nvarchar(50),
	@sTongtien nvarchar(50),
	@sMaNV nvarchar(50),
	@sMaKH nvarchar(50),
	@sMaLoaiTK nvarchar(50),
	@sTenLoaiTk nvarchar(50),
	@sKyhan nvarchar(50),
	@sPhantram nvarchar(50),
	@sNgaygui datetime,
	@sNgaylap datetime,
	@sTenNV nvarchar(50)
AS 
BEGIN
	UPDATE tblHoaDon
	SET
		sMaHD=@sMaHD,
		sMaSoTK=@sMaSoTK,
		sMaKH=@sMaKH,
		sTenKH=@sTenKH,
		sMaLoaiTK=@sMaLoaiTK,
		sTenLoaiTK=@sTenLoaiTk,
		sSotiengui=@sSotiengui,
		sNgaygui=@sNgaygui,
		sKyhan=@sKyhan,
		sPhantram=@sPhantram,
		sTongtien=@sTongtien,
		sTienlai=@sTienlai,
		sMaNV=@sMaNV,
		sTenNV=@sTenNV,
		sNgaylap=@sNgaylap

	WHERE sMaHD = @sMaHD;
	IF @@ROWCOUNT >0 BEGIN RETURN 1 END
	ELSE BEGIN RETURN 0 END;
END

CREATE PROCEDURE tblHoaDon_DELETE 
	@sMaHD nvarchar(50),
AS 
BEGIN
	DELETE 
	from tblHoaDon
	WHERE sMaHD = @sMaHD;
	IF @@ROWCOUNT >0 BEGIN RETURN 1 END
	ELSE BEGIN RETURN 0 END;
END

alter proc load_cbLoaiTK
as
begin
	select sMaLoaiTK
	from tblLoaitietkiem
end

alter proc load_cbMaKH
as
begin
	select sMaKH
	from tblKhachHang
end