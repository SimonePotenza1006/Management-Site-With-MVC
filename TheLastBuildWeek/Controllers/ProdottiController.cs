using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheLastBuildWeek.Data;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    public class ProdottiController : Controller

    {
        private TheLastBuildWeekContext db = new TheLastBuildWeekContext();

        // GET: Prodotti
        public ActionResult Index()
        {
            return View();
        }

        // Create

        public ActionResult Create()
        {
            return View();
        }



        //Edit

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Prodotti t_Prodotti = db.T_Prodotti.Find(id);
            if (t_Prodotti == null)
            {
                return HttpNotFound();
            }
            return View(t_Prodotti);
        }

        // Dettagli


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Prodotti t_Prodotti = db.T_Prodotti.Find(id);
            if (t_Prodotti == null)
            {
                return HttpNotFound();
            }
            return View(t_Prodotti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProdotto,NomeProdotto,FKIDDitta,Prezzo,Descrizione,NumArmadietto,NumCassetto,TipoProdotto")] T_Prodotti t_Prodotti)
        {
            if (ModelState.IsValid)
            {
                db.T_Prodotti.Add(t_Prodotti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Prodotti);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProdotto,NomeProdotto,FKIDDitta,Prezzo,Descrizione,NumArmadietto,NumCassetto,TipoProdotto")] T_Prodotti t_Prodotti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Prodotti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Prodotti);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Prodotti t_Prodotti = db.T_Prodotti.Find(id);
            db.T_Prodotti.Remove(t_Prodotti);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}