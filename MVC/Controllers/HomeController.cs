using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Gestion.Data;
using MVC.Model.Entities;

namespace MVC.Controllers {
    public class HomeController : Controller {

        
        UsuarioEntity b = new UsuarioEntity();

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public JsonResult GetEntity() {

            UsuarioEntity a = new UsuarioEntity();
            a.ID = 1;
            a.USERNAME = "altairseven";
            a.PASSWORD = "lkasñdjfeinv%#$)(/%)#";
            a.SALT = "%%/(&(&&$&&(#&((¨*[]*]";
            a.EMAIL = "altairseven@mailtrucho.com";
            a.LASTLOGIN = DateTime.Now;
            a.ACCOUNTTYPE = "ADMIN";

            return Json("asdasd", JsonRequestBehavior.AllowGet);
        }





    }
}