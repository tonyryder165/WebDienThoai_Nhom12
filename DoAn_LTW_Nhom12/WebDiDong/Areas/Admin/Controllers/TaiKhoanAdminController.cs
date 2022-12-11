using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;

namespace WebDiDong.Areas.Admin.Controllers
{
    public class TaiKhoanAdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Admin/TaiKhoanAdmin
        public ActionResult Index(string search = "", int page = 1)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<ThongTinCaNhan> thongTinCaNhans = db.ThongTinCaNhans.Where<ThongTinCaNhan>(row => row.TenTaiKhoan.Contains(search)).ToList();
            ViewBag.Search = search;
            if (thongTinCaNhans.Count == 0)
            {
                TempData["InfoMessage"] = "Currently products not available in the Database.";
            }

            //Paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(thongTinCaNhans.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            thongTinCaNhans = thongTinCaNhans.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(thongTinCaNhans);
        }

        public ActionResult Sua(int id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            ThongTinCaNhan thongTinCaNhan = db.ThongTinCaNhans.Where<ThongTinCaNhan>(row => row.id == id).FirstOrDefault();
            ViewBag.GioiTinh = db.ThongTinCaNhans.ToList();
            if (thongTinCaNhan == null)
            {
                TempData["InfoMessage"] = "Account not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(thongTinCaNhan);
        }

        // POST: Admin/TaiKhoanAdmin/Create
        [HttpPost]
        public ActionResult Sua(ThongTinCaNhan ttcn)
        {
            try
            {
                int IsUpdate = 0;
                DBDiDongEntities db = new DBDiDongEntities();
                ThongTinCaNhan thongTinCaNhan = db.ThongTinCaNhans.Where<ThongTinCaNhan>(row => row.MaTaiKhoan == ttcn.MaTaiKhoan).FirstOrDefault();

                thongTinCaNhan.MaTaiKhoan = ttcn.MaTaiKhoan;
                thongTinCaNhan.TenTaiKhoan = ttcn.TenTaiKhoan;
                thongTinCaNhan.SoDienThoai = ttcn.SoDienThoai;
                thongTinCaNhan.NgaySinh = ttcn.NgaySinh;
                thongTinCaNhan.DiaChi = ttcn.DiaChi;
                thongTinCaNhan.GioiTinh = ttcn.GioiTinh;
                thongTinCaNhan.id = ttcn.id;


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

        public ActionResult Delete(string id)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            AspNetUser aspNetUser = db.AspNetUsers.Where<AspNetUser>(row => row.Id == id).FirstOrDefault();

            if (aspNetUser == null)
            {
                TempData["InfoMessage"] = "User not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }

            string tenTaiKhoan = db.Database.SqlQuery<string>("select TenTaiKhoan from AspNetUsers asp, ThongTinCaNhan ttcn where asp.Id = ttcn.MaTaiKhoan and asp.Id = '" + id + "'").FirstOrDefault();
            ViewBag.TenTK = tenTaiKhoan;

            return View(aspNetUser);
        }

        [HttpPost]
        public ActionResult Delete(string id, AspNetUser asp)
        {
            try
            {
                DBDiDongEntities db = new DBDiDongEntities();

                int xoaTT = db.Database.ExecuteSqlCommand("delete from ThongTinCaNhan where MaTaiKhoan = '" + id + "'");
                int delete = db.Database.ExecuteSqlCommand("delete from AspNetUsers where Id = '" + id + "'");

                if (delete == 1)
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

        public ActionResult CapQuyen(string id)
        {
            var br = new DBDiDongEntities();
            AspNetUser aspNetUser = br.AspNetUsers.Where<AspNetUser>(row => row.Id == id).FirstOrDefault();
            string check = br.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserId = '" + id + "'").FirstOrDefault();
            if (check == "a791d34b-e28b-472e-a5bf-ed093343d276")
            {
                ViewBag.CapQuyen = "Admin";
            }
            else ViewBag.CapQuyen = "Dân";


            return View(aspNetUser);
        }

        [HttpPost]
        public ActionResult CapQuyen(string id, string CapQuyen)
        {
            var br = new DBDiDongEntities();
            string check = br.Database.SqlQuery<string>("select RoleId from AspNetUserRoles where UserId = '" + id + "'").FirstOrDefault();
            if (check != "a791d34b-e28b-472e-a5bf-ed093343d276")
            {
                if (CapQuyen == "Admin")
                {
                    // tạo mới
                    int them = br.Database.ExecuteSqlCommand("insert into AspNetUserRoles(UserId, RoleId) values('"+ id + "', 'a791d34b-e28b-472e-a5bf-ed093343d276')");
                    if (them == 1)
                    {
                        TempData["SuccessMessage"] = "Bạn đã cập nhật quyền thành công...!";
                    }
                }
            }
            else
            {
                int xoa = br.Database.ExecuteSqlCommand("delete from AspNetUserRoles where UserId = '" + id + "'");
                if (xoa == 1)
                {
                    TempData["SuccessMessage"] = "Bạn đã cập nhật quyền thành công...!";
                }
            }

            

            return RedirectToAction("Index");
        }

    }
}