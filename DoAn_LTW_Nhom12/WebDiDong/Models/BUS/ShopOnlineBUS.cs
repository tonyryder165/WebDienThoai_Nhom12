using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class ShopOnlineBUS
    {
        public static IEnumerable<SanPham> Top4New()
        {
            var db = new DBDiDongEntities();
            return db.SanPhams.SqlQuery("Select Top 4 * from SanPham where GhiChu = N'New'");
        }

        public static IEnumerable<SanPham> TopHot()
        {
            var db = new DBDiDongEntities();
            return db.SanPhams.SqlQuery("Select Top 4 * from SanPham where LuotView > 0");
        }
    }
}