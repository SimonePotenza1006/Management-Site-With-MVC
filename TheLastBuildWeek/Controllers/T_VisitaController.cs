using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    public class T_VisitaController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: T_Visita
        public ActionResult Index()
        {
            var t_Visita = db.T_Visita.Include(t => t.T_Animali);
            return View(t_Visita.ToList());
        }

        // GET: T_Visita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Visita t_Visita = db.T_Visita.Find(id);
            if (t_Visita == null)
            {
                return HttpNotFound();
            }
            return View(t_Visita);
        }

        // GET: T_Visita/Create
        public ActionResult Create()
        {
            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale");
            return View();
        }

        // POST: T_Visita/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDVisita,DataVisita,Esame,Descrizione,FKIDAnimale")] T_Visita t_Visita)
        {
            if (ModelState.IsValid)
            {
                db.T_Visita.Add(t_Visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale", t_Visita.FKIDAnimale);
            return View(t_Visita);
        }

        // GET: T_Visita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Visita t_Visita = db.T_Visita.Find(id);
            if (t_Visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale", t_Visita.FKIDAnimale);
            return View(t_Visita);
        }

        // POST: T_Visita/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDVisita,DataVisita,Esame,Descrizione,FKIDAnimale")] T_Visita t_Visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale", t_Visita.FKIDAnimale);
            return View(t_Visita);
        }

        // GET: T_Visita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Visita t_Visita = db.T_Visita.Find(id);
            if (t_Visita == null)
            {
                return HttpNotFound();
            }
            return View(t_Visita);
        }

        // POST: T_Visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Visita t_Visita = db.T_Visita.Find(id);
            db.T_Visita.Remove(t_Visita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
