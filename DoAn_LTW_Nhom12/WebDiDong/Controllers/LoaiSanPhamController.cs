using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        public ActionResult Index(string search="")
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<LoaiSanPham> loaiSanPhams = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.TenLoaiSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(loaiSanPhams);
        }
    }
}