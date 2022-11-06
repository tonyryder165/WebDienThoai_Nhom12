using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new DBDiDongEntities();
            return db.LoaiSanPhams.SqlQuery("Select * from LoaiSanPham");
        }

        public static IEnumerable<SanPham> ChiTiet(int id)
        {
            var db = new DBDiDongEntities();
            return db.SanPhams.SqlQuery("Select * from SanPham where MaLoaiSanPham = " + id + "");
        }
    }
}