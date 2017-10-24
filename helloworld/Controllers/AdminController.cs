using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloworld.Models;
using System.IO;

namespace helloworld.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        QuanlytruyenEntities db = new QuanlytruyenEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loadtruyen()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Logins", "admin");
            else
            {
                var ds = db.TRUYENs.ToList();
                return View(ds);
            }
        }


        [HttpGet]
        public ActionResult Logins()
        {

                return View();
            
        }

        public ActionResult Logins(FormCollection f)
        {
            string user = f["user"];
            string pass = f["pass"];
            Admin ad = db.Admins.SingleOrDefault(n => n.UserName == user && n.Password == pass);
            if (ad != null)
            {
                Session["Taikhoanadmin"] = ad;
                return RedirectToAction("loadtruyen", "Admin");
            }
            ViewBag.thongbao = "Sai mat khau hoac tai khoản";
            return this.Logins();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Maloai = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            ViewBag.Manxb = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.Tennxb), "Manxb", "Tennxb");
            ViewBag.Matacgia = new SelectList(db.TACGIAs.ToList().OrderBy(n => n.Tentacgia), "Matacgia", "Tentacgia");
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Logins", "admin");
            else
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TRUYEN tr, HttpPostedFileBase fileup)
        {
            ViewBag.Maloai = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            ViewBag.Manxb = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.Tennxb), "Manxb", "Tennxb");
            ViewBag.Matacgia = new SelectList(db.TACGIAs.ToList().OrderBy(n => n.Tentacgia), "Matacgia", "Tentacgia");

            if (fileup == null)
            {
                ViewBag.thongbao = "chon ảnh";
                return View();
            }

            else
            {
                if (!ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileup.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), filename);

                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.thongbao = "hinh da ton tai";
                    }
                    else
                    {
                        fileup.SaveAs(path);
                    }
                    tr.Anhbia = filename;
                    db.TRUYENs.Add(tr);
                    db.SaveChanges();
                }
                return RedirectToAction("loadtruyen");
            }
        }

        public ActionResult Details(int id)
        {
            TRUYEN tr = db.TRUYENs.SingleOrDefault(n => n.Matruyen == id);
            //  ViewBag.Matruyen = tr.Matruyen;
            if (tr == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tr);
        }

        public ActionResult Delete(int id)
        {
            TRUYEN tr = db.TRUYENs.SingleOrDefault(n => n.Matruyen == id);
            if (tr == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tr);
        }
        [HttpPost]
        public ActionResult Delete(TRUYEN tr, int id)
        {
            tr = db.TRUYENs.SingleOrDefault(n => n.Matruyen == id);
            if (tr == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TRUYENs.Remove(tr);
            db.SaveChanges();
            return RedirectToAction("loadtruyen");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TRUYEN tr = db.TRUYENs.SingleOrDefault(n => n.Matruyen == id);
            //  ViewBag.Matruyen = tr.Matruyen;
            if (tr == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.Maloai = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai",tr.Maloai);
            ViewBag.Manxb = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.Tennxb), "Manxb", "Tennxb",tr.Manxb);
            ViewBag.Matacgia = new SelectList(db.TACGIAs.ToList().OrderBy(n => n.Tentacgia), "Matacgia", "Tentacgia",tr.Matacgia);
            return View(tr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TRUYEN tr, HttpPostedFileBase fileUpload)
        {
            ViewBag.Maloai = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.Tenloai), "Maloai", "Tenloai");
            ViewBag.Manxb = new SelectList(db.NHAXUATBANs.ToList().OrderBy(n => n.Tennxb), "Manxb", "Tennxb");
            ViewBag.Matacgia = new SelectList(db.TACGIAs.ToList().OrderBy(n => n.Tentacgia), "Matacgia", "Tentacgia");

            if (fileUpload == null)
            {
                ViewBag.thongbao = "chon ảnh";
                return View();
            }

            else
            {
                if (!ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), filename);

                    if (System.IO.File.Exists(path))

                        ViewBag.thongbao = "hinh da ton tai";

                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    tr.Anhbia = filename;
                    // db.Entry(tr).State = System.Data.Entity.EntityState.Modified;
                  //  UpdateModel(tr);
                    db.Entry(tr).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("loadtruyen");
            }
        }

        public ActionResult dsnguoidung()
        {
            if (Session["Taikhoanadmin"] == null)
                return RedirectToAction("Logins", "admin");
            else
            {
                var nd = db.NGUOIDUNGs.ToList();
                return View(nd);
            }
        }

        [HttpGet]
        public ActionResult Deletend(int id)
        {
            NGUOIDUNG nd = db.NGUOIDUNGs.SingleOrDefault(n => n.Mand == id);
            if (nd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NGUOIDUNGs.Remove(nd);
            db.SaveChanges();
            return RedirectToAction("dsnguoidung");
        }


        
        ////public ActionResult Deletend(NGUOIDUNG nd,int id)
        ////{
        ////   nd = db.NGUOIDUNGs.SingleOrDefault(n => n.Mand == id);
        ////    if (nd == null)
        ////    {
        ////        Response.StatusCode = 404;
        ////        return null;
        ////    }
        ////    db.NGUOIDUNGs.Remove(nd);
        ////    db.SaveChanges();
        ////    return RedirectToAction("loadtruyen");
        //}


    }
}