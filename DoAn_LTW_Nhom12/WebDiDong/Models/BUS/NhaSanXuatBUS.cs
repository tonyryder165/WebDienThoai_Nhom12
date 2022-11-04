using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class NhaSanXuatBUS
    {
        public static IEnumerable<NhaSanXuat> DanhSach()
        {
            var db = new DBDiDongEntities();
            return db.NhaSanXuats.SqlQuery("Select * from NhaSanXuat");
        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            var db = new DBDiDongEntities();
            return db.SanPhams.SqlQuery("Select * from SanPham where MaNhaSanXuat = " + id + "");
        }
    }
}