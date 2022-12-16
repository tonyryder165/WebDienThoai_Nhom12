using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class GioHangBUS
    {
        public static IEnumerable<GioHang> DanhSach(string mataikhoan)
        {
            using (var db = new DBDiDongEntities())
            {
                return db.GioHangs.SqlQuery("select * from GioHang where MaTaiKhoan = '" + mataikhoan + "'").ToList();
            }
        }
        public static void Them(int masanpham, string mataikhoan, int soluong, int gia, string tensanpham)
        {

            using (var db = new DBDiDongEntities())
            {
                var x = db.GioHangs.SqlQuery("select * from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSanPham = '" + masanpham + "'").ToList();
                if (x.Count() > 0)
                {
                    // gọi hàm update so lượng
                    int a = (int)x.ElementAt(0).SoLuong + soluong;
                    CapNhat(masanpham, mataikhoan, a, gia, tensanpham);
                }
                else
                {
                    GioHang giohang = new GioHang()
                    {
                        MaSanPham = masanpham,
                        MaTaiKhoan = mataikhoan,
                        SoLuong = soluong,
                        Gia = gia,
                        TenSanPham = tensanpham,
                        TongTien = gia * soluong
                    };
                    db.GioHangs.Add(giohang);
                    int IsInserted = db.SaveChanges();
                }

            }
        }

        public static void CapNhat(int masanpham, string mataikhoan, int soluong, int gia, string tensanpham)
        {
            var db = new DBDiDongEntities();
            GioHang giohang = new GioHang()
            {
                MaSanPham = masanpham,
                MaTaiKhoan = mataikhoan,
                SoLuong = soluong,
                Gia = gia,
                TenSanPham = tensanpham,
                TongTien = gia * soluong
            };
            var tamp = db.Database.SqlQuery<int>("Select idGH from GioHang Where MaTaiKhoan = '" + mataikhoan + "' and MaSanPham = '" + masanpham + "'").FirstOrDefault();
            var update = db.Database.ExecuteSqlCommand("Update GioHang set SoLuong = " + giohang.SoLuong + ", TongTien = " + giohang.TongTien + " where IdGH = " + tamp + "");
        }

        public static int TongTien(string mataikhoan)
        {
            using (var db = new DBDiDongEntities())
            {
                var a = db.GioHangs.SqlQuery("select * from GioHang where MaTaiKhoan = '" + mataikhoan + "'");
                if (a.Count() == 0)
                {
                    return 0;
                }
                return db.Database.SqlQuery<int>("select sum(TongTien) from GioHang where MaTaiKhoan = '" + mataikhoan + "' ").FirstOrDefault();

            }
        }
        public static string Image(string id)
        {
            using (var db = new DBDiDongEntities())
            {
                
                return db.Database.SqlQuery<string>("select HinhChinh from SanPham where MaSanPham = '" + id + "' ").FirstOrDefault();

            }
        }

        public static void Xoa(int masanpham, string mataikhoan)
        {
            using (var db = new DBDiDongEntities())
            {
                var noOfRowDeleted = db.Database.ExecuteSqlCommand("delete from GioHang where MaSanPham = "+masanpham+" and MaTaiKhoan = '"+mataikhoan+"'");
            }
        }

    }
}