using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    public class HomeController : Controller
    {
        private ModelDBContext db = new ModelDBContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login([Bind(Include = "Username, Password, Role")] T_User users)
        {

            var user = db.T_User.FirstOrDefault(u => u.Username == users.Username && u.Password == users.Password && u.Role == "Veterinario");

            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(users.Username, false);
                return RedirectToAction("LoggedIn", "Home");
            }

            return View();
        }

        //[Authorize(Roles="Veterinario")]
        public ActionResult LoggedIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /////////////////////////////////////////////// ACTION PER VIEW RICOVERI ///////////////////////////
        [HttpGet]
        public ActionResult Ricoveri (T_Ricovero ricovero)
        {

            //DA FARE: far vedere animali 
            return View(db.T_Ricovero.ToList());
        }

        [HttpGet]
        public ActionResult AnimaleView (T_Animali animale)
        {
            
            return View(db.T_Animali.ToList());
        }
    }
}
