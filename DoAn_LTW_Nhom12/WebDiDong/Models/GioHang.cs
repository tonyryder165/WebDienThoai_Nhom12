using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDiDong.Models
{
    public class GioHang
    {
        DBDiDongEntities db = new DBDiDongEntities();
        public int sMaSanPham { get; set; }
        public string sTenSanPham { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        public GioHang(int maSP)
        {
            sMaSanPham = maSP;
            SanPham sanPham = db.SanPhams.Single(s => s.MaSanPham == sMaSanPham);
            sTenSanPham = sanPham.TenSanPham;
            sAnhBia = sanPham.HinhChinh;
            dDonGia = double.Parse(sanPham.Gia.ToString());
            iSoLuong = 1;
        }
    }
}