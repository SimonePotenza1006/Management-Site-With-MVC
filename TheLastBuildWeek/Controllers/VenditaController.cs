using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    public class VenditaController : Controller
    {
        private class Vendita
        {
            public int Id { get; set; }
            public DateTime DataVendita { get; set; }
            

        }
        private ModelDBContext db = new ModelDBContext();

        // GET: Vendita
        public ActionResult Index()
        {
            return View(db.T_Vendita.ToList());
        }

        public ActionResult CREAVendita()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CREAVendita(T_Vendita vendita) {
            if (ModelState.IsValid)

            {

                int quantita = 1;
                decimal totale = 0;


                var prodotto = db.T_Prodotti.Find(vendita.FKIDProdotto);
                if(prodotto != null)
                {


                    totale = (decimal)(prodotto.Prezzo * Convert.ToDecimal( quantita));

                    db.T_Vendita.Add(vendita);
                    db.SaveChanges();
                }
                return View();
            }

            return View(vendita);
        }
        public ActionResult GetVenditeByDate(DateTime date)
        {
            List<Vendita> VenditeList = new List<Vendita>();
            foreach(T_Vendita vendita in db.T_Vendita.ToList()) {
                VenditeList.Add(new Vendita
                {
                    Id = vendita.IDVendita,
                    DataVendita = vendita.DataVendita,
                });
                
            }
            return Json(VenditeList.Where(v => v.DataVendita == date), JsonRequestBehavior.AllowGet);
        }

    }
}