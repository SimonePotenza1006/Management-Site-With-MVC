using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

        public ActionResult EditAnimale(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Animali animale = db.T_Animali.Find(id);
            if (animale == null)
            {
                return HttpNotFound();
            }
            return View(animale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAnimale(T_Animali animale)
        {
            if (ModelState.IsValid)
            {
                animale.DataRegistrazione = DateTime.Now;
                db.Entry(animale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult CancelAnimal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Animali animale = db.T_Animali.Find(id);
            if (animale == null)
            {
                return HttpNotFound();
            }
            return View(animale);
        }

        [HttpPost, ActionName("CancelAnimal")]
        [ValidateAntiForgeryToken]
        public ActionResult CancelAnimal2(int id)
        {
            T_Animali animale = db.T_Animali.Find(id);
            db.T_Animali.Remove(animale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}