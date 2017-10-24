using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloworld.Models;
namespace helloworld.Controllers
{
    public class TimkiemController : Controller
    {
        // GET: Timkiem
        QuanlytruyenEntities db = new QuanlytruyenEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ketqua(FormCollection f)
        {
            string tukhoa = f["txtname"];
            List<TRUYEN> lsttruyen = db.TRUYENs.Where(n => n.Tentruyen.Contains(tukhoa)).ToList();// Lấy ra danh sách truyện
            if(lsttruyen.Count==0)
            {
                ViewBag.thongbao = "ko tim thay";
            }
            return View(lsttruyen);
        }
    }
}