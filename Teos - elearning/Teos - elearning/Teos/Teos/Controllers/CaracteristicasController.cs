using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teos.Models;

namespace Teos.Controllers
{
    public class CaracteristicasController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: Caracteristicas
        public ActionResult Index()
        {
            return View(db.Caracteristicas.ToList());
        }

        // GET: Caracteristicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // GET: Caracteristicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Caracteristicas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Mostra_vitrine,Permitir_Perguntas")] Caracteristicas caracteristicas)
        {
            if (ModelState.IsValid)
            {
                db.Caracteristicas.Add(caracteristicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caracteristicas);
        }

        // GET: Caracteristicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // POST: Caracteristicas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Mostra_vitrine,Permitir_Perguntas")] Caracteristicas caracteristicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caracteristicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caracteristicas);
        }

        // GET: Caracteristicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            if (caracteristicas == null)
            {
                return HttpNotFound();
            }
            return View(caracteristicas);
        }

        // POST: Caracteristicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caracteristicas caracteristicas = db.Caracteristicas.Find(id);
            db.Caracteristicas.Remove(caracteristicas);
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
