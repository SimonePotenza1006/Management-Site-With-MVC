using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    public class AnimaliController : Controller
    {

        private ModelDBContext db = new ModelDBContext();
        // GET: Animali
        public ActionResult Index()
        {
            return View(db.T_Animali.ToList());
        }

        public ActionResult AddAnimale()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAnimale(T_Animali animale)
        {
            animale.FotoAnimale = "";
            if (ModelState.IsValid)
            {
                if (animale.Immagine != null && animale.Immagine.ContentLength > 0) 
                {
                    var immagine = Path.GetFileName(animale.Immagine.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/"), immagine);
                    animale.Immagine.SaveAs(path);
                    var dataRegistrazione = DateTime.Now;

                    animale.FotoAnimale = immagine;
                    animale.DataRegistrazione = dataRegistrazione;
                }
                db.T_Animali.Add(animale);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}