using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class ThongTinCaNhanBUS
    {
        public static IEnumerable<ThongTinCaNhan> LoadThongTin(string mataikhoan)
        {
            var db = new DBDiDongEntities();
            return db.ThongTinCaNhans.SqlQuery("select * from ThongTinCaNhan where MaTaiKhoan = '" + mataikhoan + "'");
        }
        public static IEnumerable<ThongTinCaNhan> DanhSachTaiKhoan()
        {
            var db = new DBDiDongEntities();
            return db.ThongTinCaNhans.SqlQuery("select * from ThongTinCaNhan");

        }
        public static AspNetUser LoadTaiKhoan(string mataikhoan)
        {
            var db = new DBDiDongEntities();
            return db.AspNetUsers.SqlQuery("select * from AspNetUsers where Id = '" + mataikhoan + "'").FirstOrDefault();

        }
    }
}