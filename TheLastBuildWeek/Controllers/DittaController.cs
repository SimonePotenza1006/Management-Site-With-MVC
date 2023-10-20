using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    [Authorize(Roles = "Farmacista")]
    public class DittaController : Controller
    {  private ModelDBContext db = new ModelDBContext();
        // GET: Ditta
        public ActionResult Index()
        {
            return View(db.T_DittaFarmaceutica.ToList());
        }


        public ActionResult CreateDitta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDitta(T_DittaFarmaceutica d)
        {
            if(ModelState.IsValid)
            {

                db.T_DittaFarmaceutica.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");   
            }

            return View(d);
        }

        public ActionResult Edit(int id)
        {
            T_DittaFarmaceutica d = db.T_DittaFarmaceutica.Find(id);
            return View(d);
        }
        [HttpPost]
        public ActionResult Edit(T_DittaFarmaceutica d) { 
        
         if(ModelState.IsValid) {
                db.Entry(d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
         return View(d);
        
        }

        public ActionResult delete(int id)
        {
            T_DittaFarmaceutica d = db.T_DittaFarmaceutica.Find(id);
            return View(d);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {

            T_DittaFarmaceutica d = db.T_DittaFarmaceutica.Find(id);
            db.T_DittaFarmaceutica.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}