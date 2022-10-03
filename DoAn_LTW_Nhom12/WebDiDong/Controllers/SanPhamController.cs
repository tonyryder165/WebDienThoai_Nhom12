using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index(string search="")
        {
            DBDiDongEntities db = new DBDiDongEntities();
            //List<SanPham> sanPhams = db.SanPhams.ToList();
            List<SanPham> sanPhams = db.SanPhams.Where<SanPham>(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(sanPhams);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham p)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            db.SanPhams.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == id).FirstOrDefault();
            return View(sanPham);
        }
        
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == sp.MaSanPham).FirstOrDefault();

            sanPham.TenSanPham = sp.TenSanPham;
            sanPham.MaNhaSanXuat = sp.MaNhaSanXuat;
            sanPham.MaLoaiSanPham = sp.MaLoaiSanPham;
            sanPham.HinhChinh = sp.HinhChinh;
            sanPham.Gia = sp.Gia;
            sanPham.MaSanPham = sp.MaSanPham;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == id).FirstOrDefault();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Delete(string id, SanPham sp)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == id).FirstOrDefault();
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}