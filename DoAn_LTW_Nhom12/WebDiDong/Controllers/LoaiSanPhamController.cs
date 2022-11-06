using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;
using WebDiDong.Models.BUS;

namespace WebDiDong.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        public ActionResult Index(int id, int page = 1, int pagesize = 6)
        {
            var ds = LoaiSanPhamBUS.ChiTiet(id).ToPagedList(page, pagesize);
            using (var br = new DBDiDongEntities())
            {
                string loai = br.Database.SqlQuery<string>("select TenLoaiSanPham from LoaiSanPham where MaLoaiSanPham = " + id + "").FirstOrDefault();
                ViewBag.loai = loai;
            }
            return View(ds);
        }
    }
}