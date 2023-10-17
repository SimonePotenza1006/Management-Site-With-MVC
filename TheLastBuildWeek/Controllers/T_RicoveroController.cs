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
    public class T_RicoveroController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: T_Ricovero
        public ActionResult Index()
        {
            var t_Ricovero = db.T_Ricovero.Include(t => t.T_Animali);
            return View(t_Ricovero.ToList());
        }

        // GET: T_Ricovero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Ricovero t_Ricovero = db.T_Ricovero.Find(id);
            if (t_Ricovero == null)
            {
                return HttpNotFound();
            }
            return View(t_Ricovero);
        }

        // GET: T_Ricovero/Create
        public ActionResult Create()
        {
            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale");
            return View();
        }

        // POST: T_Ricovero/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRicovero,DataRicovero,DescrizioneRicovero,FKIDAnimale")] T_Ricovero t_Ricovero)
        {
            if (ModelState.IsValid)
            {
                db.T_Ricovero.Add(t_Ricovero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale", t_Ricovero.FKIDAnimale);
            return View(t_Ricovero);
        }

        // GET: T_Ricovero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Ricovero t_Ricovero = db.T_Ricovero.Find(id);
            if (t_Ricovero == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale", t_Ricovero.FKIDAnimale);
            return View(t_Ricovero);
        }

        // POST: T_Ricovero/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRicovero,DataRicovero,DescrizioneRicovero,FKIDAnimale")] T_Ricovero t_Ricovero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Ricovero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKIDAnimale = new SelectList(db.T_Animali, "IDAnimale", "NomeAnimale", t_Ricovero.FKIDAnimale);
            return View(t_Ricovero);
        }

        // GET: T_Ricovero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Ricovero t_Ricovero = db.T_Ricovero.Find(id);
            if (t_Ricovero == null)
            {
                return HttpNotFound();
            }
            return View(t_Ricovero);
        }

        // POST: T_Ricovero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Ricovero t_Ricovero = db.T_Ricovero.Find(id);
            db.T_Ricovero.Remove(t_Ricovero);
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
