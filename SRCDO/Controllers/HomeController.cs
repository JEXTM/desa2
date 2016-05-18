using SRCDO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRCDO.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        SRCOEntities3 usuario = new SRCOEntities3();
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register() 
        {
            return View();
        }
       [HttpPost]
        public ActionResult Login()
        {
            String nickname = (String)HttpContext.Request.Params.Get("txt_nickname");
            String pass = (String)HttpContext.Request.Params.Get("txt_password");

            user user1 = new user();
            user1.nickname = nickname;
            user1.pass = pass;

            if (user1.nickname == "" || user1.pass == "")
            {
               return  RedirectToAction("Index"); 
            }
            SRCDO.Models.user user = usuario.user.Single(emp => emp.nickname == user1.nickname && emp.pass == user1.pass);
            if (user != null)
            {
                Session.Add("usuario", user);
                //ViewBag["success"] = "Inicio de Session Correcto";
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag["error"] = "Ocurrio un error";
                return RedirectToAction("Login");
            }

        }

    }
}
