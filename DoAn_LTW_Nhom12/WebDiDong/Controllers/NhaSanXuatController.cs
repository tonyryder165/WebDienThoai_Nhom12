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
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        public ActionResult Index(int id, int page = 1, int pagesize = 6)
        {
            var ds = NhaSanXuatBUS.ChiTiet(id).ToPagedList(page, pagesize);
            using (var br = new DBDiDongEntities())
            {
                string brand = br.Database.SqlQuery<string>("select TenNhaSanXuat from NhaSanXuat where MaNhaSanXuat = " + id + "").FirstOrDefault();
                ViewBag.Brand = brand;
            }
            return View(ds);
        }
    }
}