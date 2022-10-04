using System;
using PagedList;
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
        public ActionResult Index(string search = "", int page = 1, int pagesize = 6)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<LoaiSanPham> loaiSanPhams = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.TenLoaiSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(loaiSanPhams.ToPagedList(page, pagesize));
        }

        // GET: LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            db.LoaiSanPhams.Add(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LoaiSanPham/Edit/5
        public ActionResult Edit(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == id).FirstOrDefault();
            return View(loaiSanPham);
        }

        // POST: LoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(LoaiSanPham lsp)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == lsp.MaLoaiSanPham).FirstOrDefault();

            loaiSanPham.MaLoaiSanPham = lsp.MaLoaiSanPham;
            loaiSanPham.TenLoaiSanPham = lsp.TenLoaiSanPham;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LoaiSanPham/Delete/5
        public ActionResult Delete(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == id).FirstOrDefault();
            return View(loaiSanPham);
        }

        // POST: LoaiSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, LoaiSanPham lsp)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == id).FirstOrDefault();
            db.LoaiSanPhams.Remove(loaiSanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
