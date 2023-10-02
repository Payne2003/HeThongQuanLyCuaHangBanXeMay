create database Motorcycle_shop_manager
go 
use Motorcycle_shop_manager
go

CREATE TABLE Theloai (
    MaTheLoai NVARCHAR(255) PRIMARY KEY,
    TenTheLoai NVARCHAR(255)
);

CREATE TABLE Dongco (
    MaDongCo NVARCHAR(255) PRIMARY KEY,
    TenDongCo NVARCHAR(255)
);

CREATE TABLE Mausac (
    MaMau NVARCHAR(255) PRIMARY KEY,
    TenMau NVARCHAR(255)
);

CREATE TABLE Tinhtrang (
    MaTinhTrang NVARCHAR(255) PRIMARY KEY,
    TenTinhTrang NVARCHAR(255)
);

CREATE TABLE Nuocsanxuat (
    MaNuocSX NVARCHAR(255) PRIMARY KEY,
    TenNuocSX NVARCHAR(255)
);

CREATE TABLE Hangsanxuat (
    MaHangSX NVARCHAR(255) PRIMARY KEY,
    TenHangSX NVARCHAR(255)
);

CREATE TABLE Phanhxe (
    MaPhanh NVARCHAR(255) PRIMARY KEY,
    TenPhanh NVARCHAR(255)
);

CREATE TABLE Dmh (
    MaHang NVARCHAR(255) PRIMARY KEY,
    TenHang NVARCHAR(255),
    MaTheLoai NVARCHAR(255),
    MaHangSX NVARCHAR(255),
    MaMau NVARCHAR(255),
    NamSX NVARCHAR(255),
    MaPhanh NVARCHAR(255),
    MaDongCo NVARCHAR(255),
    DungTichBinhXang DECIMAL(10, 2),
    MaNuocSX NVARCHAR(255),
    MaTinhTrang NVARCHAR(255),
    Anh VARBINARY(MAX), -- S? d?ng VARBINARY ?? l?u tr? hình ?nh
    SoLuong INT,
    DonGiaNhap DECIMAL(10, 2),
    DonGiaBan DECIMAL(10, 2),
    ThoiGianBaoHanh INT,
    -- Ràng bu?c khóa ngo?i
    FOREIGN KEY (MaTheLoai) REFERENCES Theloai(MaTheLoai),
    FOREIGN KEY (MaHangSX) REFERENCES Hangsanxuat(MaHangSX),
    FOREIGN KEY (MaMau) REFERENCES Mausac(MaMau),
    FOREIGN KEY (MaPhanh) REFERENCES Phanhxe(MaPhanh),
    FOREIGN KEY (MaDongCo) REFERENCES Dongco(MaDongCo),
    FOREIGN KEY (MaNuocSX) REFERENCES Nuocsanxuat(MaNuocSX),
    FOREIGN KEY (MaTinhTrang) REFERENCES Tinhtrang(MaTinhTrang)
);

CREATE TABLE Nhanvien (
    MaNV NVARCHAR(255) PRIMARY KEY,
    TenNV NVARCHAR(255),
    GioiTinh NVARCHAR(5),
    NgaySinh DATE,
    DienThoai NVARCHAR(15),
    DiaChi NVARCHAR(255),
    MaCV NVARCHAR(255),
    -- Ràng bu?c khóa ngo?i
    FOREIGN KEY (MaCV) REFERENCES Congviec(MaCV)
);

CREATE TABLE TaiKhoan (
    Username NVARCHAR(255) PRIMARY KEY,
    Password NVARCHAR(255), -- Hãy luôn mã hóa mật khẩu và không lưu mật khẩu dạng text
    MaNV NVARCHAR(255),
    -- Ràng buộc khóa ngoại
    FOREIGN KEY (MaNV) REFERENCES Nhanvien(MaNV)
);

CREATE TABLE Congviec (
    MaCV NVARCHAR(255) PRIMARY KEY,
    TenCV NVARCHAR(255),
    LuongThang DECIMAL(10, 2)
);

CREATE TABLE DonDatHang (
    SoDDH NVARCHAR(255) PRIMARY KEY,
    MaNV NVARCHAR(255),
    MaKhach NVARCHAR(255),
    NgayMua DATE,
    DatCoc DECIMAL(10, 2),
    Thue DECIMAL(10, 2),
    TongTien DECIMAL(10, 2),
    -- Ràng bu?c khóa ngo?i
    FOREIGN KEY (MaNV) REFERENCES Nhanvien(MaNV),
    FOREIGN KEY (MaKhach) REFERENCES KhachHang(MaKhach)
);

CREATE TABLE HoaDonNhap (
    SoHDN NVARCHAR(255) PRIMARY KEY,
    MaNV NVARCHAR(255),
    NgayNhap DATE,
    MaNCC NVARCHAR(255),
    TongTien DECIMAL(10, 2),
    -- Ràng bu?c khóa ngo?i
    FOREIGN KEY (MaNV) REFERENCES Nhanvien(MaNV),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);

CREATE TABLE KhachHang (
    MaKhach NVARCHAR(255) PRIMARY KEY,
    TenKhach NVARCHAR(255),
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(15)
);

CREATE TABLE ChiTietDonDatHang (
    SoDDH NVARCHAR(255),
    MaHang NVARCHAR(255),
    SoLuong INT,
    GiamGia DECIMAL(10, 2),
    ThanhTien DECIMAL(10, 2),
    PRIMARY KEY (SoDDH, MaHang),
    -- Ràng bu?c khóa ngo?i
    FOREIGN KEY (SoDDH) REFERENCES DonDatHang(SoDDH),
    FOREIGN KEY (MaHang) REFERENCES Dmh(MaHang)
);

CREATE TABLE ChiTietHoaDonNhap (
    SoHDN NVARCHAR(255),
    MaHang NVARCHAR(255),
    SoLuong INT,
    DonGia DECIMAL(10, 2),
    GiamGia DECIMAL(10, 2),
    ThanhTien DECIMAL(10, 2),
    PRIMARY KEY (SoHDN, MaHang),
    -- Ràng bu?c khóa ngo?i
    FOREIGN KEY (SoHDN) REFERENCES HoaDonNhap(SoHDN),
    FOREIGN KEY (MaHang) REFERENCES Dmh(MaHang)
);

CREATE TABLE NhaCungCap (
    MaNCC NVARCHAR(255) PRIMARY KEY,
    TenNCC NVARCHAR(255),
    DiaChi NVARCHAR(255),
    DienThoai NVARCHAR(15)
);
