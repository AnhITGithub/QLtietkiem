CREATE DATABASE QLtietkiem
GO
USE QLtietkiem
go
CREATE TABLE tblNhanVien
(
	sMaNV NVARCHAR(20) not null PRIMARY KEY,
	sTenNV NVARCHAR(50),
	sTaiKhoan nvarchar(50), 
	sMatKhau NVARCHAR(20),
	sSDT NVARCHAR(50),
	sDiaChi NVARCHAR(50)
)

alter table tblHoaDon
alter column sMaNV nvarchar(20) not null

alter table tblHoaDon
add constraint fk_hoadon_nhanvien foreign key(sMaNV) references tblNhanVien(sMaNV)

insert into tblNhanVien
values('333', N'Anh Tuấn', 'tuansokiu', '1900561270', '999999999', N'Hà Nội')

update tblNhanVien
set sMaNV='',sTenNV='',sTaiKhoan='',sMatKhau='',sSDT='',sDiaChi=''
where sMaNV=''

delete from tblNhanVien where sMaNV=''

CREATE TABLE tblKhachHang
(
	sMaKH NVARCHAR(50) PRIMARY KEY,
	sTenKH NVARCHAR (50) NOT NULL,
	sGioitinh NVARCHAR (50) NOT NULL,
	tNgaysinh DATE NOT NULL,
	sCMT NVARCHAR (50) NOT NULL,
	sDiachi NVARCHAR (50) NOT NULL,
	sSDT NVARCHAR (50) NOT NULL,
)

alter table tblKhachHang
alter column tNgaysinh datetime

update tblKhachHang
set sMaKH='',sTenKH='',sGioitinh='',tNgaysinh='',sCMT='',sDiachi='', sSDT=''
where sMaKH=''

delete from tblKhachHang where sMaKH=''

insert into tblKhachHang
values('333', N'Anh Tuấn', 'tuansokiu', '1900561270', '999999999', N'Hà Nội', 'Hà Nội')

CREATE TABLE tblLoaitietkiem
(
	sMaLoaiTK NVARCHAR (50) PRIMARY KEY,
	sTenLoaiTK NVARCHAR (50) NOT NULL,
	sPhantram NVARCHAR (50) NOT NULL,
	sKyhan NVARCHAR (50) NOT NULL,
)

alter table tblLoaitietkiem
drop column sThoigian
CREATE TABLE tblSotietkiem
(
	sMaSoTK NVARCHAR (50) PRIMARY KEY,
	sMaKH NVARCHAR (50) NOT NULL,
	sTenKH NVARCHAR (50) NOT NULL,
	sSotiengui NVARCHAR (50) NOT NULL,
	sNgaygui NVARCHAR(70) NOT NULL,
	sMaLoaiTK NVARCHAR (50) NOT NULL,
);

ALTER TABLE tblSotietkiem ADD CONSTRAINT FK_Sotietkiem_KhachHang FOREIGN KEY (sMaKH) REFERENCES tblKhachHang(sMaKH);
ALTER TABLE tblSotietkiem ADD CONSTRAINT FK_Sotietkiem_Loaitietkiem FOREIGN KEY (sMaLoaiTK) REFERENCES tblLoaitietkiem(sMaLoaiTK);
ALTER TABLE tblSotietkiem ADD CONSTRAINT FK_Sotietkiem_Nhanvien FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV);


select sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui,sMaNV,sTenNV
from tblSotietkiem

insert into tblSotietkiem(sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui)
values('','',N'','',N'','','')

update tblSotietkiem
set sMaSoTK='',sMaKH='',sTenKH=N'',sMaLoaiTK='',sTenLoaiTK=N'',sSotiengui='',sNgaygui=''
where sMaSoTK=''


CREATE TABLE tblHoaDon
(
	sMaHD NVARCHAR (50) PRIMARY KEY,
	sMaSoTK NVARCHAR (50) NOT NULL,
	sTenKH NVARCHAR (50) NOT NULL,
	sSotiengui NVARCHAR (50) NOT NULL,
	sSongaygui NVARCHAR (50) NOT NULL,
	sTienlai NVARCHAR (50) NOT NULL,
	sTongtien NVARCHAR (50) NOT NULL,
);	

ALTER TABLE tblHoaDon ADD CONSTRAINT FK_HoaDon_Sotietkiem FOREIGN KEY (sMaSoTK) REFERENCES tblSotietkiem(sMaSoTK);
ALTER TABLE tblHoaDon ADD CONSTRAINT FK_hoadon_nhanvien FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV)
ALTER TABLE tblHoaDon ADD CONSTRAINT FK_hoadon_loaitietkiem FOREIGN KEY (sMaLoaiTK) REFERENCES tblLoaitietkiem(sMaLoaiTK)
ALTER TABLE tblHoaDon ADD CONSTRAINT FK_hoadon_khachhang FOREIGN KEY (sMaKH) REFERENCES tblKhachHang(sMaKH)

select sMaHD,sMaSoTK,sMaKH,sTenKH,sMaLoaiTK,sTenLoaiTK,sSotiengui,sNgaygui,sKyhan,sPhantram,sTongtien,sTienlai,sMaNV,sTenNV,sNgaylap
from tblHoaDon
