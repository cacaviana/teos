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
    public class PapeisController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: Papeis
        public ActionResult Index()
        {
            return View(db.Papeis.ToList());
        }

        // GET: Papeis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papeis papeis = db.Papeis.Find(id);
            if (papeis == null)
            {
                return HttpNotFound();
            }
            return View(papeis);
        }

        // GET: Papeis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Papeis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Papeis papeis)
        {
            if (ModelState.IsValid)
            {
                db.Papeis.Add(papeis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(papeis);
        }

        // GET: Papeis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papeis papeis = db.Papeis.Find(id);
            if (papeis == null)
            {
                return HttpNotFound();
            }
            return View(papeis);
        }

        // POST: Papeis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Papeis papeis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(papeis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(papeis);
        }

        // GET: Papeis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Papeis papeis = db.Papeis.Find(id);
            if (papeis == null)
            {
                return HttpNotFound();
            }
            return View(papeis);
        }

        // POST: Papeis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Papeis papeis = db.Papeis.Find(id);
            db.Papeis.Remove(papeis);
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
