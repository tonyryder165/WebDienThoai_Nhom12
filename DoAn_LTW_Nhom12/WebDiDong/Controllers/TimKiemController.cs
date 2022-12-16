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
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult KetQuaTimKiem(string search = "", int page = 1)
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<SanPham> sanPhams = db.SanPhams.Where<SanPham>(row => row.TenSanPham.Contains(search)).ToList();
            ViewBag.Check = sanPhams.Count();
            if (sanPhams.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm!";
            }
            ViewBag.Search = search;
            //Paging
            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sanPhams.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            sanPhams = sanPhams.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(sanPhams);
        }
    }
}