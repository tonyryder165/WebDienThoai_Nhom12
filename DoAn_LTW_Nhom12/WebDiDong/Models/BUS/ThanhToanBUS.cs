using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class ThanhToanBUS
    {
        public static void ThemOrder(string nguoinhan, string sdt, string diachi, string mataikhoan)
        {

            using (
                var db = new DBDiDongEntities())
            {
                //------------------Thêm đơn hàng ------------------
                HoaDon donhang = new HoaDon()
                {
                    NgayTao = DateTime.Now,
                    NguoiDat = mataikhoan,
                    NguoiNhan = nguoinhan,
                    SDT = sdt,
                    DiaChi = diachi,
                    TongTien = GioHangBUS.TongTien(mataikhoan),
                    TrangThai = 0

                };

                var insert = db.Database.ExecuteSqlCommand("Insert into HoaDon(NgayTao, NguoiDat, NguoiNhan, SDT, DiaChi, TongTien, TrangThai) Values('" + donhang.NgayTao + "', '" + donhang.NguoiDat + "', N'" + donhang.NguoiNhan + "','" + donhang.SDT + "',N'" + donhang.DiaChi + "'," + donhang.TongTien + "," + donhang.TrangThai + ") ");
                //db.HoaDons.Add(donhang);
                //db.SaveChanges();
                //--------------------Thêm Chi tiết đơn hàng
                List<GioHang> gh = GioHangBUS.DanhSach(mataikhoan).ToList();
                ChiTietHoaDon odct = new ChiTietHoaDon();
                int i = 0;
                int id = LayIdOrder(mataikhoan);
                foreach (var item in gh)
                {
                    odct.OrderID = id;
                    odct.MaSanPham = item.MaSanPham;
                    odct.TenSanPham = item.TenSanPham;
                    odct.SoLuong = item.SoLuong;
                    odct.Gia = item.Gia;
                    odct.TongTien = item.TongTien;
                    i++;
                    var insert2 = db.Database.ExecuteSqlCommand("Insert into ChiTietHoaDon(MaSanPham, OrderID, TenSanPham, SoLuong, Gia, TongTien) Values(" + odct.MaSanPham + ", " + odct.OrderID + ", '" + odct.TenSanPham + "'," + odct.SoLuong + "," + odct.Gia + "," + odct.TongTien + ") ");
                }
                foreach (var item in gh)
                {
                    GioHangBUS.Xoa(item.MaSanPham, item.MaTaiKhoan);
                }
            }

        }

        public static int LayIdOrder(string mataikhoan)
        {
            using (var db = new DBDiDongEntities())
            {
                return db.Database.SqlQuery<int>("select ID from HoaDon Where NguoiDat ='" + mataikhoan + "' Order by NgayTao Desc").FirstOrDefault();

            }
        }

        public static IEnumerable<HoaDon> DanhSachHoaDon()
        {
            using (var db = new DBDiDongEntities())
            {
                string a = "select * from HoaDon";
                return db.Database.SqlQuery<HoaDon>(a);

            }
        }
        public static IEnumerable<ChiTietHoaDon> ChiTietHoaDon(int mahoadon)
        {
            using (var db = new DBDiDongEntities())
            {
                string a = "select * from ChiTietHoaDon where OrderID =" + mahoadon + "";
                return db.Database.SqlQuery<ChiTietHoaDon>(a);

            }
        }

        public static void SuaDonHang(int mahoadon, int tinhtrang)
        {
            using (var db = new DBDiDongEntities())
            {
                db.Database.ExecuteSqlCommand("Update HoaDon set TrangThai = "+tinhtrang+" where ID = "+mahoadon+"");
            }
        }
    }
}
        