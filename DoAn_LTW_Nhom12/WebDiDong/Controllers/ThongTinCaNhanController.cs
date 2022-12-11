using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebDiDong.Models;
using WebDiDong.Models.BUS;

namespace WebDiDong.Controllers
{
    public class ThongTinCaNhanController : Controller
    {
        [Authorize]
        // GET: ThongTinCaNhan
        public ActionResult Index()
        {
            var ds = ThongTinCaNhanBUS.LoadThongTin(User.Identity.GetUserId());
            return View(ds);
        }
        public ActionResult Them()
        {
            DBDiDongEntities db = new DBDiDongEntities();

            ViewBag.GioiTinh = db.ThongTinCaNhans.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Them(ThongTinCaNhan ttcn)
        {
            try
            {
                int IsInserted = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                db.ThongTinCaNhans.Add(ttcn);
                IsInserted = db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}