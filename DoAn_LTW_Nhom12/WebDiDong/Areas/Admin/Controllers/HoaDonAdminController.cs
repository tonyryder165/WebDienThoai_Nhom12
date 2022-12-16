using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiDong.Models;
using WebDiDong.Models.BUS;

namespace WebDiDong.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HoaDonAdminController : Controller
    {
        // GET: Admin/HoaDon
        public ActionResult Index(string search = "", int page = 1)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<HoaDon> hoaDons = db.HoaDons.Where<HoaDon>(row => row.NguoiNhan.Contains(search)).ToList();
            ViewBag.Search = search;
            if (hoaDons.Count == 0)
            {
                TempData["InfoMessage"] = "Currently users not available in the Database.";
            }

            //Paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(hoaDons.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            hoaDons = hoaDons.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(hoaDons);
        }

        [HttpGet]
        public ActionResult CapNhat(int mahoadon, int trangthai)
        {
            try
            {
                ThanhToanBUS.SuaDonHang(mahoadon, trangthai);
                TempData["SuccessMessage"] = "Bạn đã sửa thành công...!";
                return RedirectToAction("../HoaDonAdmin/index");
            }
            catch
            {
                return RedirectToAction("../HoaDonAdmin/index");
            }

        }
    }
}