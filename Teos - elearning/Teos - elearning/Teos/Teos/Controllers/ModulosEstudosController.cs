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
    public class ModulosEstudosController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: ModulosEstudos
        public ActionResult Index()
        {
            var modulos = db.Modulos.Include(m => m.Cursos);
            return View(modulos.ToList());
        }

        // GET: ModulosEstudos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulos modulos = db.Modulos.Find(id);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            return View(modulos);
        }

        // GET: ModulosEstudos/Create
        public ActionResult Create()
        {
            ViewBag.CursosId = new SelectList(db.Cursos, "Id", "Nome");
            return View();
        }

        // POST: ModulosEstudos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Hierarquia,CursosId")] Modulos modulos)
        {
            if (ModelState.IsValid)
            {
                db.Modulos.Add(modulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursosId = new SelectList(db.Cursos, "Id", "Nome", modulos.CursosId);
            return View(modulos);
        }

        // GET: ModulosEstudos/Edit/5
        public ActionResult Edit(int? id, string nome, string List)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulos modulos = db.Modulos.Find(id);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursosId = new SelectList(db.Cursos, "Id", "Nome", modulos.CursosId);
            return View(modulos);
        }

        // POST: ModulosEstudos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Hierarquia,CursosId")] Modulos modulos, Cursos cursos, string name )
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursosId = new SelectList(db.Cursos, "Id", "Nome", modulos.CursosId);
            return View(modulos);
        }

        // GET: ModulosEstudos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulos modulos = db.Modulos.Find(id);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            return View(modulos);
        }

        // POST: ModulosEstudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modulos modulos = db.Modulos.Find(id);
            db.Modulos.Remove(modulos);
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
