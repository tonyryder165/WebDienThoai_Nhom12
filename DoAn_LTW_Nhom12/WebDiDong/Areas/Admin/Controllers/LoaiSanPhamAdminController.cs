using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/LoaiSanPham
        public ActionResult Index(string search = "", int page = 1)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<LoaiSanPham> loaiSanPhams = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.TenLoaiSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            if (loaiSanPhams.Count == 0)
            {
                TempData["InfoMessage"] = "Currently products not available in the Database.";
            }

            //Paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(loaiSanPhams.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            loaiSanPhams = loaiSanPhams.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(loaiSanPhams);
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int IsInserted = 0;
                    DBDiDongEntities db = new DBDiDongEntities();
                    db.LoaiSanPhams.Add(lsp);
                    IsInserted = db.SaveChanges();
                    if (IsInserted == 1)
                    {
                        TempData["SuccessMessage"] = "Bạn đã thêm thành công...!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Product is already available/ Unable to save the product details.";
                    }
                }

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public ActionResult Edit(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == id).FirstOrDefault();
            if (loaiSanPham == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LoaiSanPham lsp)
        {
            try
            {
                int IsUpdate = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == lsp.MaLoaiSanPham).FirstOrDefault();

                loaiSanPham.MaLoaiSanPham = lsp.MaLoaiSanPham;
                loaiSanPham.TenLoaiSanPham = lsp.TenLoaiSanPham;

                IsUpdate = db.SaveChanges();
                if (IsUpdate == 1)
                {
                    TempData["SuccessMessage"] = "Bạn đã cập nhật thành công...!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Product is already available/ Unable to update the product details.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == id).FirstOrDefault();
            if (loaiSanPham == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(loaiSanPham);
        }

        // POST: Admin/LoaiSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, LoaiSanPham lsp)
        {
            try
            {
                int IsDeleted = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                LoaiSanPham loaiSanPham = db.LoaiSanPhams.Where<LoaiSanPham>(row => row.MaLoaiSanPham == id).FirstOrDefault();
                db.LoaiSanPhams.Remove(loaiSanPham);
                IsDeleted = db.SaveChanges();
                if (IsDeleted == 1)
                {
                    TempData["SuccessMessage"] = "Bạn đã xóa thành công...!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Product is already available/ Unable to update the product details.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
