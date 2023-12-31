using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheLastBuildWeek.Models;

namespace TheLastBuildWeek.Controllers
{
    public class ProdottiController : Controller

    {
        private ModelDBContext db = new ModelDBContext();

        private class Prodotto
        {
            public string Nome { get; set; }
            public string Descrizione { get; set; }
            public int Armadietto { get; set; }
            public int Cassetto { get; set; }
        }

        // GET: Prodotti
        public ActionResult Index()
        {
            //List<T_DittaFarmaceutica> listaDitte = new List<T_DittaFarmaceutica>();
            

           
            return View(db.T_Prodotti.ToList());
        }

        // Create

        public ActionResult Create()
        {
            ViewBag.FKIDDitta = new SelectList(db.T_DittaFarmaceutica, "IDDitta", "Nome");
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

        public ActionResult Details(int id, string CodiceFiscale)
        {
            
            //var IdCliente = db.T_Clienti.Select(m => new {m.IDCliente}).FirstOrDefault();
            //string veroIdCliente = db.T_Clienti.Select(c => c.CodiceFiscale == CodiceFiscale).FirstOrDefault();
            int veroIdCliente = db.T_Clienti.Where(cl => cl.CodiceFiscale == CodiceFiscale).Select(cl => cl.IDCliente).FirstOrDefault();
           
            
            
            T_Prodotti t_Prodotti = db.T_Prodotti.Find(id);
            string connectionstring= ConfigurationManager.ConnectionStrings["ModelDBContext"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            


            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO  T_Vendita (FKIDcliente,FKIDprodotto,NumeroRicetta,DataVendita) VALUES(@FKIDcliente,@FKIDprodotto,@NumeroRicetta,@DataVendita)";
                cmd.Parameters.AddWithValue("FKIDcliente", veroIdCliente );
                cmd.Parameters.AddWithValue("FKIDprodotto", t_Prodotti.IDProdotto);
                cmd.Parameters.AddWithValue("NumeroRicetta","pippo");
                cmd.Parameters.AddWithValue("DataVendita",DateTime.Now );
              

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            
            }

            return RedirectToAction("Index","Vendita");


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
            ViewBag.FKIDDitta = new SelectList(db.T_DittaFarmaceutica, "IDDitta", "Nome", t_Prodotti.FKIDDitta);
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


        public ActionResult GetProdotti (string nome)
        {
            List<Prodotto> ProdottoList = new List<Prodotto>();

            foreach (T_Prodotti prodotto in db.T_Prodotti.ToList())
                ProdottoList.Add(new Prodotto
                {
                    Nome = prodotto.NomeProdotto,
                    Descrizione = prodotto.Descrizione,
                    Armadietto = prodotto.NumArmadietto,
                    Cassetto = prodotto.NumCassetto
                }) ;
            return Json(ProdottoList.Where(p => p.Nome == nome), JsonRequestBehavior.AllowGet);
        }
    }
}