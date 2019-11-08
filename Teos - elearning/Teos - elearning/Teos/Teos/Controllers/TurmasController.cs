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
    public class TurmasController : Controller
    {
        private TeosContext db = new TeosContext();
        private TurmasViewModel turmas = new TurmasViewModel();


        // GET: Turmas
        [Authorize]
        public ActionResult Index()
        {
            //Fazer funcionar esse código com o Daniel
            //var turminhas = db.Turmas.Include(t => t.Cursos).ToList();
            //return View(turminhas.ToList());


            //var turmasViewsModel = from t in db.Turmas

            //                       join c in db.Cursos
            //                       on t.CursosId equals c.Id
            //                       orderby c.Nome
            //                       select new TurmasViewModel
            //                       {
            //                           Codigo_Turma = t.Id,
            //                           Nome_Turma = t.Nome,
            //                           Nome_Curso = c.Nome
            //                       };

            //return View(turmasViewsModel.ToList());

            return View(db.Turmas);


        }

        // GET: Turmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turmas turmas = db.Turmas.Find(id);
            if (turmas == null)
            {
                return HttpNotFound();
            }
            return View(turmas);
        }

        // GET: Turmas/Create
        public ActionResult Create()
        {
            ViewBag.CursosId = new SelectList(db.Cursos.OrderBy(c => c.Nome), "Id", "Nome");

            return View();
        }

        // POST: Turmas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CursosId")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turmas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turmas);
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turmas turmas = db.Turmas.Find(id);
            ViewBag.CursosId = new SelectList(db.Cursos.OrderBy(c => c.Nome), "Id", "Nome", turmas.CursosId);
            if (turmas == null)
            {
                return HttpNotFound();
            }
            return View(turmas);
        }

        // POST: Turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CursosId")] Turmas turmas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turmas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turmas);
        }

        // GET: Turmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turmas turmas = db.Turmas.Find(id);
            if (turmas == null)
            {
                return HttpNotFound();
            }
            return View(turmas);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turmas turmas = db.Turmas.Find(id);
            db.Turmas.Remove(turmas);
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
