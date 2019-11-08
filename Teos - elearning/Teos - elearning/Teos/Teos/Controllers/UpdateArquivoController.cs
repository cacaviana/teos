using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teos.ViewModels;

namespace Teos.Controllers
{
    public class UpdateArquivoController : Controller
    {
        // GET: UpdateArquivo
        public ActionResult Index()
        {
            return View();
        }

        // GET: UpdateArquivo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpdateArquivo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateArquivo/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Arquivos")] AdicionarArquivoViewModel arquivos)
        {
            try
            {
                // TODO: Add insert logic here




                for (int i = 0; i < Request.Files.Count; i++)
                { 
                HttpPostedFileBase arquivo = Request.Files[i];
                
                    if (arquivo.ContentLength > 0)
                    {
                        var UploadPath = Server.MapPath("~/Arquivos/Cursos");
                        var localsalve = Path.Combine(UploadPath, arquivo.FileName);
                        arquivo.SaveAs(localsalve);
                    }
                }



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UpdateArquivo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpdateArquivo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UpdateArquivo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpdateArquivo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
