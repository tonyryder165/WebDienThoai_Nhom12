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
        [Authorize(Roles = "Admin")]
        // GET: Admin/NhaSanXuat
        public ActionResult Index(string search = "", int page = 1)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<NhaSanXuat> nsx = db.NhaSanXuats.Where<NhaSanXuat>(row => row.TenNhaSanXuat.Contains(search)).ToList();
            ViewBag.Search = search;
            if (nsx.Count == 0)
            {
                TempData["InfoMessage"] = "Currently products not available in the Database.";
            }

            //Paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(nsx.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            nsx = nsx.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

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
            try
            {
                if(ModelState.IsValid)
                {
                    int IsInserted = 0;
                    DBDiDongEntities db = new DBDiDongEntities();
                    db.NhaSanXuats.Add(nsx);
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

        // GET: Admin/NhaSanXuat/Edit/5
        public ActionResult Edit(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            if(nhaSanXuat == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(nhaSanXuat);
        }

        // POST: Admin/NhaSanXuat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, NhaSanXuat nsx)
        {
            try
            {
                int IsUpdate = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == nsx.MaNhaSanXuat).FirstOrDefault();

                nhaSanXuat.MaNhaSanXuat = nsx.MaNhaSanXuat;
                nhaSanXuat.TenNhaSanXuat = nsx.TenNhaSanXuat;
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

        // GET: Admin/NhaSanXuat/Delete/5
        public ActionResult Delete(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
            if (nhaSanXuat == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(nhaSanXuat);
        }

        // POST: Admin/NhaSanXuat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NhaSanXuat nsx)
        {
            try
            {
                int IsDeleted = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                NhaSanXuat nhaSanXuat = db.NhaSanXuats.Where<NhaSanXuat>(row => row.MaNhaSanXuat == id).FirstOrDefault();
                db.NhaSanXuats.Remove(nhaSanXuat);
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
