USE [master]
GO
/****** Object:  Database [DBDiDong]    Script Date: 11/4/2022 6:26:17 PM ******/
CREATE DATABASE [DBDiDong]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBDiDong', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\DBDiDong.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBDiDong_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\DBDiDong_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBDiDong] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBDiDong].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBDiDong] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBDiDong] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBDiDong] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBDiDong] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBDiDong] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBDiDong] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBDiDong] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBDiDong] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBDiDong] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBDiDong] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBDiDong] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBDiDong] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBDiDong] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBDiDong] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBDiDong] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBDiDong] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBDiDong] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBDiDong] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBDiDong] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBDiDong] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBDiDong] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBDiDong] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBDiDong] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBDiDong] SET  MULTI_USER 
GO
ALTER DATABASE [DBDiDong] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBDiDong] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBDiDong] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBDiDong] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBDiDong] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBDiDong] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DBDiDong] SET QUERY_STORE = OFF
GO
USE [DBDiDong]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 11/4/2022 6:26:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSanPham] [nvarchar](50) NULL,
	[TinhTrang] [nvarchar](3) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 11/4/2022 6:26:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNhaSanXuat] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaSanXuat] [nvarchar](50) NULL,
	[TinhTrang] [nvarchar](3) NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaNhaSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/4/2022 6:26:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiSanPham] [int] NULL,
	[MaNhaSanXuat] [int] NULL,
	[TenSanPham] [nvarchar](max) NULL,
	[CauHinh] [text] NULL,
	[HinhChinh] [nvarchar](50) NULL,
	[Hinh1] [nvarchar](50) NULL,
	[Hinh2] [nvarchar](50) NULL,
	[Hinh3] [nvarchar](50) NULL,
	[Hinh4] [nvarchar](50) NULL,
	[Gia] [int] NULL,
	[SoLuongDaBan] [int] NULL,
	[LuotView] [int] NULL,
	[TinhTrang] [bit] NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (1, N'Cao Cấp', N'0')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (2, N'Trung Bình', N'0')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (3, N'Sang Chảnh', N'0')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON 

INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (1, N'Iphone', N'0')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (2, N'Samsung', N'0')
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (3, N'Oppo', N'0')
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (1, 1, 1, N'Iphone 11 64GB', N'Chua xác d?nh', N'1.png', NULL, NULL, NULL, NULL, 10990000, 0, 0, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (2, 2, 1, N'Iphone 12 64GB', N'Chua xác d?nh', N'2.png', NULL, NULL, NULL, NULL, 15990000, 0, 0, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (3, 2, 1, N'Iphone 13 64GB', N'Chua xác d?nh', N'3.png', NULL, NULL, NULL, NULL, 20990000, 0, 8, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (4, 3, 1, N'Iphone 14 64GB', N'Chua xác d?nh', N'4.png', NULL, NULL, NULL, NULL, 25990000, 0, 7, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (5, 1, 2, N'Samsung A73', N'Chua xác d?nh', N'5.png', NULL, NULL, NULL, NULL, 7000000, 0, 0, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (6, 1, 2, N'Samsung S22', N'Chua xác d?nh', N'6.png', NULL, NULL, NULL, NULL, 15000000, 0, 0, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (7, 2, 2, N'Samsung M52', N'Chua xác d?nh', N'7.png', NULL, NULL, NULL, NULL, 60000000, 0, 0, 0, N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (8, 3, 2, N'Samsung Z Fold', N'Chua xác d?nh', N'8.png', NULL, NULL, NULL, NULL, 40000000, 0, 5, 0, N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (9, 1, 3, N'Oppo Reno 8', N'Chua xác d?nh', N'9.png', NULL, NULL, NULL, NULL, 15000000, 0, 0, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (10, 1, 3, N'Oppo Reno 7', N'Chua xác d?nh', N'10.png', NULL, NULL, NULL, NULL, 13000000, 0, 0, 0, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (11, 2, 3, N'Oppo A90', N'Chua xác d?nh', N'11.png', NULL, NULL, NULL, NULL, 5900000, 0, 0, 0, N'New')
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [LuotView], [TinhTrang], [GhiChu]) VALUES (12, 3, 3, N'Oppo Find X', N'Chua xác d?nh', N'12.png', NULL, NULL, NULL, NULL, 18000000, 0, 6, 0, N'New')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
ALTER TABLE [dbo].[LoaiSanPham] ADD  CONSTRAINT [DF_LoaiSanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[NhaSanXuat] ADD  CONSTRAINT [DF_NhaSanXuat_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_Gia]  DEFAULT ((0)) FOR [Gia]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_SoLuongDaBan]  DEFAULT ((0)) FOR [SoLuongDaBan]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_LuotView]  DEFAULT ((0)) FOR [LuotView]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_GhiChu]  DEFAULT (N'New') FOR [GhiChu]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSanPham])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaSanXuat] FOREIGN KEY([MaNhaSanXuat])
REFERENCES [dbo].[NhaSanXuat] ([MaNhaSanXuat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaSanXuat]
GO
USE [master]
GO
ALTER DATABASE [DBDiDong] SET  READ_WRITE 
GO
