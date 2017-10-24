using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloworld.Models;
using PagedList;
using PagedList.Mvc;

namespace helloworld.Controllers
{
    public class HomeController : Controller
    {

        QuanlytruyenEntities db = new QuanlytruyenEntities();
        //lay ds
        public ActionResult Index(int? page)
        {
            int pagesize = 3;
            int pagenumber = (page ?? 1);
            var truyenmoi = db.TRUYENs.ToList().OrderBy(n=>n.Tentruyen).ToPagedList(pagenumber,pagesize);
            return View(truyenmoi); 
        }

       public ActionResult Detail(int id)
        {
            TRUYEN tr = db.TRUYENs.SingleOrDefault(n => n.Matruyen == id);
                if(tr==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tr);
        }

        public ActionResult theloai()
        {
            var loai = db.THELOAIs.ToList();
            return View(loai);
        }

        public ActionResult sploai(int id)
        {
            THELOAI sp = db.THELOAIs.SingleOrDefault(n => n.Maloai == id);// Lấy ra sản phẩm theo loại
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<TRUYEN> lsttruyen = db.TRUYENs.Where(n => n.Maloai == id).ToList();
            if(lsttruyen.Count==0)
            {
                ViewBag.thongbao = "ko co truyen";
            }
            return View(lsttruyen);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}