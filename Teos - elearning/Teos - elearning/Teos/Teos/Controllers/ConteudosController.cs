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
    public class ConteudosController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: Conteudos
        public ActionResult Index()
        {
            return View(db.Conteudos.OrderBy(c => c.Modulos.Nome).ToList());
        }

        // GET: Conteudos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteudos conteudos = db.Conteudos.Find(id);
            if (conteudos == null)
            {
                return HttpNotFound();
            }
            return View(conteudos);
        }

        // GET: Conteudos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conteudos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)] - se eu quisesse que todo formulário permitisse HTML
        public ActionResult Create([Bind(Include = "Id,Nome,Avaliacao,Texto_Embed,Hierarquia,ModulosId")] Conteudos conteudos)
        {
            if (ModelState.IsValid)
            {
                db.Conteudos.Add(conteudos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conteudos);
        }

        // GET: Conteudos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteudos conteudos = db.Conteudos.Find(id);
            if (conteudos == null)
            {
                return HttpNotFound();
            }
            return View(conteudos);
        }

        // POST: Conteudos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Avaliacao,Texto_Embed,Hierarquia,ModulosId")] Conteudos conteudos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conteudos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conteudos);
        }

        // GET: Conteudos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conteudos conteudos = db.Conteudos.Find(id);
            if (conteudos == null)
            {
                return HttpNotFound();
            }
            return View(conteudos);
        }

        // POST: Conteudos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conteudos conteudos = db.Conteudos.Find(id);
            db.Conteudos.Remove(conteudos);
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
