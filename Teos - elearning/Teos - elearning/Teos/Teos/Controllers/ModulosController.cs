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
    public class ModulosController: Controller
    {
        private TeosContext db = new TeosContext();
        //private ModulosViewModel modulosView = new ModulosViewModel();

        // GET: Módulos
        [Authorize]
        public ActionResult Index()
        {

            return View(db.Modulos.OrderBy(c => c.Nome));


            //var modulosviewfiltra = from m in db.Modulos
            //                        join c in db.Cursos
            //                        on m.CursosId equals c.Id
            //                        orderby c.Nome
            //                        select new ModulosViewModel
            //                        {
            //                            Codigo_Modulo = m.Id,
            //                            Nome_Modulo = m.Nome,
            //                            Nome_Curso = c.Nome
            //                        };



            // return View(modulosviewfiltra.ToList());
        }

        // GET: Módulos/Details/5
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

        // GET: Turmas/Create
        public ActionResult Create()
        {
            ViewBag.CursosId = new SelectList(db.Cursos.OrderBy(c => c.Nome), "Id", "Nome");
            var cursoselecionado = db.Cursos.Find(1);
            ViewBag.Curso_Selecionado = cursoselecionado.Id;
            return View();
        }


        // GET: Turmas/Create/id => Vindo do Controller EntrarCurso
        public ActionResult CreateNew(int? id)
        {
            var cursoselecionado = db.Cursos.Find(id);
            ViewBag.NomeCurso = cursoselecionado.Nome;
            ViewBag.IdCurso = cursoselecionado.Id;
            ViewBag.CursosId = new SelectList(db.Cursos.OrderBy(c => c.Nome), "Id", "Nome");

            return View();
        }

        // POST: Módulos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CursosId")] Modulos modulos)
        {
            if (ModelState.IsValid)
            {
                db.Modulos.Add(modulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modulos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Include = "Id,Nome,CursosId")] Modulos modulos)
        {
            if (ModelState.IsValid)
            {
                db.Modulos.Add(modulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modulos);
        }

        // GET: Turmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulos modulos = db.Modulos.Find(id);
            ViewBag.CursosId = new SelectList(db.Cursos.OrderBy(c => c.Nome), "Id", "Nome", modulos.CursosId);
            if (modulos == null)
            {
                return HttpNotFound();
            }
            return View(modulos);
        }

        // POST: Turmas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CursosId")] Modulos modulos)
        {

            if (ModelState.IsValid)
            {
                db.Entry(modulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modulos);
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