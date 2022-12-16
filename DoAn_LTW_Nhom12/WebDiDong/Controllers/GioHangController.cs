using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;
using WebDiDong.Models.BUS;

namespace WebDiDong.Controllers
{
    [Authorize]
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        public ActionResult Index()
        {
            ViewBag.TongTien = GioHangBUS.TongTien(User.Identity.GetUserId());
            DBDiDongEntities db = new DBDiDongEntities();
            var matk = User.Identity.GetUserId();
            List<GioHang> gioHangs = db.GioHangs.Where<GioHang>(row => row.MaTaiKhoan == matk).ToList();
            using (var sl = new DBDiDongEntities())
            {
                var soluong = sl.Database.SqlQuery<int>("select count(SoLuong) from GioHang where MaTaiKhoan = '" + matk + "'").FirstOrDefault();
                ViewBag.TongSoLuong = soluong;
            }
            return View(gioHangs);
        }

        [HttpPost]
        public ActionResult Them(int masanpham, int soluong, int gia, string tensanpham)
        {
            try
            {
                GioHangBUS.Them(masanpham, User.Identity.GetUserId(), soluong, gia, tensanpham);
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }

        [HttpPost]
        public ActionResult CapNhat(int masanpham, int soluong, int gia, string tensanpham)
        {
            try
            {
                GioHangBUS.CapNhat(masanpham, User.Identity.GetUserId(), soluong, gia, tensanpham);
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }

        [HttpGet]
        public ActionResult Xoa(int masanpham)
        {
            try
            {
                GioHangBUS.Xoa(masanpham, User.Identity.GetUserId());
                return RedirectToAction("index");
            }
            catch
            {
                return RedirectToAction("../Shop/index");
            }

        }
    }
}