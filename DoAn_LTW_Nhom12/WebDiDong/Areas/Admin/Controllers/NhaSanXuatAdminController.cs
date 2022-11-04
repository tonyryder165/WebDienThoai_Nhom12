using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Areas.Admin.Controllers
{
    public class NhaSanXuatAdminController : Controller
    {
        // GET: Admin/NhaSanXuat
        public ActionResult Index()
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<NhaSanXuat> nsx = db.NhaSanXuats.ToList();
            return View(nsx);
        }

        // GET: Admin/NhaSanXuat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaSanXuat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaSanXuat/Create
        [HttpPost]
        public ActionResult Create(NhaSanXuat nsx)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            db.NhaSanXuats.Add(nsx);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/NhaSanXuat/Edit/5
        public ActionResult Edit(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            return View(nhaSanXuat);
        }

        // POST: Admin/NhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NhaSanXuat nsx)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == nsx.MaNhaSanXuat).FirstOrDefault();

            nhaSanXuat.MaNhaSanXuat = nsx.MaNhaSanXuat;
            nhaSanXuat.TenNhaSanXuat = nsx.TenNhaSanXuat;
            nhaSanXuat.TinhTrang = nsx.TinhTrang;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/NhaSanXuat/Delete/5
        public ActionResult Delete(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            return View(nhaSanXuat);
        }

        // POST: Admin/NhaSanXuat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NhaSanXuat nsx)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            db.NhaSanXuats.Remove(nhaSanXuat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
