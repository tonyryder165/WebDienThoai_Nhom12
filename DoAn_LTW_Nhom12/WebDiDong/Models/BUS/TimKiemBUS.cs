using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class TimKiemBUS
    {
        public static IEnumerable<SanPham> TimKiem(string timKiem)
        {
            var db = new DBDiDongEntities();
            return db.SanPhams.SqlQuery("select * from SanPham where TenSanPham like '%" + timKiem + "%'");
        }
    }
}