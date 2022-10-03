﻿using System;
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
        public ActionResult Index(string search="")
        {
            DBDiDongEntities db = new DBDiDongEntities();
            List<NhaSanXuat> nhaSanXuats = db.NhaSanXuats.Where<NhaSanXuat>(row => row.TenNhaSanXuat.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(nhaSanXuats);
        }
    }
}