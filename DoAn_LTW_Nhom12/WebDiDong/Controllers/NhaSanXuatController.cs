using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Controllers
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        public ActionResult Index(string search = "", int page = 1, int pagesize = 3)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<NhaSanXuat> nhaSanXuats = db.NhaSanXuats.Where<NhaSanXuat>(row => row.TenNhaSanXuat.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(nhaSanXuats.ToPagedList(page, pagesize));
        }


        // GET: NhaSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaSanXuat/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            db.NhaSanXuats.Add(nsx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: NhaSanXuat/Edit/5
        public ActionResult Edit(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            return View(nhaSanXuat);
        }

        // POST: NhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, NhaSanXuat nsx)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == nsx.MaNhaSanXuat).FirstOrDefault();

            nhaSanXuat.MaNhaSanXuat = nsx.MaNhaSanXuat;
            nhaSanXuat.TenNhaSanXuat = nsx.TenNhaSanXuat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: NhaSanXuat/Delete/5
        public ActionResult Delete(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            return View(nhaSanXuat);
        }

        // POST: NhaSanXuat/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, NhaSanXuat nsx)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            db.NhaSanXuats.Remove(nhaSanXuat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
