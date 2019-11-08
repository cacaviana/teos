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
    public class PerguntasController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: Perguntas
        public ActionResult Index()
        {
            return View(db.Perguntas.ToList());
        }

        // GET: Perguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perguntas perguntas = db.Perguntas.Find(id);
            if (perguntas == null)
            {
                return HttpNotFound();
            }
            return View(perguntas);
        }

        // GET: Perguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perguntas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pergunta,DateTime,MembrosId")] Perguntas perguntas)
        {
            if (ModelState.IsValid)
            {
                db.Perguntas.Add(perguntas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perguntas);
        }

        // GET: Perguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perguntas perguntas = db.Perguntas.Find(id);
            if (perguntas == null)
            {
                return HttpNotFound();
            }
            return View(perguntas);
        }

        // POST: Perguntas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pergunta,DateTime,MembrosId")] Perguntas perguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perguntas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perguntas);
        }

        // GET: Perguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perguntas perguntas = db.Perguntas.Find(id);
            if (perguntas == null)
            {
                return HttpNotFound();
            }
            return View(perguntas);
        }

        // POST: Perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perguntas perguntas = db.Perguntas.Find(id);
            db.Perguntas.Remove(perguntas);
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
