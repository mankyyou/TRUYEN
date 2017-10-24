using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloworld.Models;

namespace helloworld.Controllers
{
    public class NguoidungController : Controller
    {
        // GET: Nguoidung
        QuanlytruyenEntities db = new QuanlytruyenEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dangky()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky(NGUOIDUNG nd)
        {
            if (ModelState.IsValid)
            {
                db.NGUOIDUNGs.Add(nd);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return this.Dangky();
        }

        public ActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Dangnhap(FormCollection f)
        {
            string taikhoan = f["txttaikhoan"].ToString();
            string matkhau = f["txtmatkhau"].ToString();
            NGUOIDUNG nd = db.NGUOIDUNGs.SingleOrDefault(n => n.Taikhoan == taikhoan && n.Matkhau == matkhau);
            if(nd!=null)
            {
                ViewBag.thongbao = "Dang nhap thành công";
                return View();
            }
            ViewBag.thongbao = "Sai matkhau hoac tai khoan";
            return View();

        }

        
    }
}