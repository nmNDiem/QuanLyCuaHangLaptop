create database QLCHLap
go

use QLCHLap
go


create table SanPham
(
	ID int identity primary key,
	TenSP nvarchar(255) not null,
	ThongSo nvarchar(255),
	Gia decimal not null,
	SoLuong int
)
go

create table KhachHang
(
	ID int identity primary key,
	TenKH nvarchar(100) not null,
	SDT char(10),
	DiaChi nvarchar(255)
)
go

create table HoaDonBanHang
(
	ID int identity primary key,
	SoLuong int not null,
	Tien float not null,
	IDKhachHang int not null,
	foreign key (IDKhachHang) references dbo.KhachHang(ID),
)
go

create table SanPham_HoaDonBanHang
(
	IDSanPham int not null,
	IDHoaDonBanHang int not null,
	NgayTao DateTime not null,
	primary key (IDSanPham, IDHoaDonBanHang),
	foreign key (IDSanPham) references dbo.SanPham(ID),
	foreign key (IDHoaDonBanHang) references dbo.HoaDonBanHang(ID)
)
go

create table PhieuNhapKho
(
	ID int identity primary key,
	Gia float not null,
	SoLuong int not null
)
go

create table SanPham_PhieuNhapKho
(
	IDSanPham int not null,
	IDPhieuNhapKho int not null,
	NgayNhap DateTime not null,
	primary key (IDSanPham, IDPhieuNhapKho),
	foreign key (IDSanPham) references dbo.SanPham(ID),
	foreign key (IDPhieuNhapKho) references dbo.PhieuNhapKho(ID)
)
go

create table PhieuXuatKho
(
	ID int identity primary key,
	Gia float not null,
	SoLuong int not null
)
go

create table SanPham_PhieuXuatKho
(
	IDSanPham int,
	IDPhieuXuatKho int,
	NgayXuat DateTime not null,
	primary key (IDSanPham, IDPhieuXuatKho),
	foreign key (IDSanPham) references dbo.SanPham(ID),
	foreign key (IDPhieuXuatKho) references dbo.PhieuXuatKho(ID)
)
go

create table PhieuBaoHanh
(
	ID int identity primary key,
	TenSP nvarchar(255) not null,
	ThoiHanBaoHanh int not null,
	IDHoaDonBanHang int,
	foreign key (IDHoaDonBanHang) references dbo.HoaDonBanHang(ID)
)
go

create table HoaDonBaoHanh
(
	ID int identity primary key,
	LyDoBH nvarchar(255),
	IDPhieuBaoHanh int not null,
	foreign key (IDPhieuBaoHanh) references dbo.PhieuBaoHanh(ID)
)
go