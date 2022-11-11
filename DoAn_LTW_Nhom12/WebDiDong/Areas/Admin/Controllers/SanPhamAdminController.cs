using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/SanPham
        public ActionResult Index(string search = "", int page = 1)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<SanPham> sanPhams = db.SanPhams.Where<SanPham>(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Search = search;
            if (sanPhams.Count == 0)
            {
                TempData["InfoMessage"] = "Currently products not available in the Database.";
            }

            //Paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sanPhams.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPhams = sanPhams.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(sanPhams);
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            DBDiDongEntities db = new DBDiDongEntities();

            ViewBag.NSX = db.NhaSanXuats.ToList();
            ViewBag.LSP = db.LoaiSanPhams.ToList();
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SanPham sp)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    int IsInserted = 0;
                    DBDiDongEntities db = new DBDiDongEntities();


                    //Image
                    string fileName = Path.GetFileNameWithoutExtension(sp.HinHChinhFile.FileName);
                    string extension = Path.GetExtension(sp.HinHChinhFile.FileName);
                    fileName = fileName + extension;
                    sp.HinhChinh = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Asset/images/"), fileName);
                    sp.HinHChinhFile.SaveAs(fileName);


                    sp.LuotView = 0;
                    sp.SoLuongDaBan = 0;
                    sp.GhiChu = "New";
                    db.SanPhams.Add(sp);
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

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == id).FirstOrDefault();
            ViewBag.NSX = db.NhaSanXuats.ToList();
            ViewBag.LSP = db.LoaiSanPhams.ToList();
            if (sanPham == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, SanPham sp)
        {
            try
            {
                int IsUpdate = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == sp.MaSanPham).FirstOrDefault();
                var tam = sanPham.HinhChinh;

                var test = sp.HinHChinhFile;
                if(test != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sp.HinHChinhFile.FileName);
                    string extension = Path.GetExtension(sp.HinHChinhFile.FileName);
                    fileName = fileName + extension;
                    sp.HinhChinh = fileName;
                    fileName = Path.Combine(Server.MapPath("~/Asset/images/"), fileName);
                    sp.HinHChinhFile.SaveAs(fileName);

                    sanPham.HinhChinh = sp.HinhChinh;
                }
                else
                {
                    sanPham.HinhChinh = tam;
                }
                //Image
                


                sanPham.MaSanPham = sp.MaSanPham;
                sanPham.TenSanPham = sp.TenSanPham;
                sanPham.MaLoaiSanPham = sp.MaLoaiSanPham;
                sanPham.MaNhaSanXuat = sp.MaNhaSanXuat;

                sanPham.CauHinh = sp.CauHinh;
                sanPham.Gia = sp.Gia;

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

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == id).FirstOrDefault();
            if (sanPham == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SanPham sp)
        {
            try
            {
                int IsDeleted = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                SanPham sanPham = db.SanPhams.Where<SanPham>(row => row.MaSanPham == id).FirstOrDefault();
                db.SanPhams.Remove(sanPham);
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
