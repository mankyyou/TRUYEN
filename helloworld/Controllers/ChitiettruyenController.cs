using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloworld.Models;

namespace helloworld.Controllers
{
    public class ChitiettruyenController : Controller
    {
        // GET: Chitiettruyen
        QuanlytruyenEntities db = new QuanlytruyenEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ChitiettruyenController()
        {

        }
       

        //public ActionResult tonghop(int id)
        //{
        //    if(id==11)
        //    return View("Doreamon");
        //    if (id == 8)
        //        return View("Luffy");
        //    if (id == 13)
        //        return View("Naroto");
        //    else
        //        return RedirectToAction("Index", "Home");
        //}

        [HttpGet]
        public ActionResult luffy(int id)
        {
            if (id == 8)
                return View();
            if (id == 11)
                return View("Doreamon");
            if (id == 13)
                return View("Naroto");
            else
                return RedirectToAction("Index", "Home");
        }
       

        public ActionResult luffy2()
        {
            return View();
        }

        public ActionResult Doreamon()
        {
            return View();
        }

        public ActionResult Doreamon2()
        {
            return View();
        }

        public ActionResult Naroto()
        {
            return View();
        }
    }
}