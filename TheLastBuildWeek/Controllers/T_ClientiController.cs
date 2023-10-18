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
    public class T_ClientiController : Controller
    {
        private ModelDBContext db = new ModelDBContext();

        // GET: T_Clienti
        public ActionResult Index()
        {
            return View(db.T_Clienti.ToList());
        }

        // GET: T_Clienti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Clienti t_Clienti = db.T_Clienti.Find(id);
            if (t_Clienti == null)
            {
                return HttpNotFound();
            }
            return View(t_Clienti);
        }

        // GET: T_Clienti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Clienti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCliente,Nome,Cognome,CodiceFiscale")] T_Clienti t_Clienti)
        {
            if (ModelState.IsValid)
            {
                db.T_Clienti.Add(t_Clienti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Clienti);
        }

        // GET: T_Clienti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Clienti t_Clienti = db.T_Clienti.Find(id);
            if (t_Clienti == null)
            {
                return HttpNotFound();
            }
            return View(t_Clienti);
        }

        // POST: T_Clienti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCliente,Nome,Cognome,CodiceFiscale")] T_Clienti t_Clienti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Clienti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Clienti);
        }

        // GET: T_Clienti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Clienti t_Clienti = db.T_Clienti.Find(id);
            if (t_Clienti == null)
            {
                return HttpNotFound();
            }
            return View(t_Clienti);
        }

        // POST: T_Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Clienti t_Clienti = db.T_Clienti.Find(id);
            db.T_Clienti.Remove(t_Clienti);
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
