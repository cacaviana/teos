using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teos.Models;
using Teos.Utils;

namespace Teos.Controllers
{
    public class WebServicesApisController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: WebServicesApis
        public ActionResult Index()
        {
            return View(db.WebServicesApis.ToList());
        }

        // GET: WebServicesApis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebServicesApi webServicesApi = db.WebServicesApis.Find(id);
            if (webServicesApi == null)
            {
                return HttpNotFound();
            }
            return View(webServicesApi);
        }

        // GET: WebServicesApis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebServicesApis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,ClientId,ClientSecret,Basic,TokenAcess")] WebServicesApi webServicesApi)
        {
            if (ModelState.IsValid)
            {

                string clientIdHash = Hash.GerarHash(webServicesApi.ClientId);
                webServicesApi.ClientId = clientIdHash;


                if (webServicesApi.ClientSecret != null)
                {
                    string clienteSecret = Hash.GerarHash(webServicesApi.ClientSecret);
                    webServicesApi.ClientSecret = clienteSecret;
                }

                if (webServicesApi.Basic != null)
                {
                    string basic = Hash.GerarHash(webServicesApi.Basic);
                    webServicesApi.Basic = basic;
                }

                if (webServicesApi.TokenAcess != null)
                {
                    string tokenacess = Hash.GerarHash(webServicesApi.TokenAcess);
                    webServicesApi.TokenAcess = tokenacess;
                }


                db.WebServicesApis.Add(webServicesApi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webServicesApi);
        }

        // GET: WebServicesApis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebServicesApi webServicesApi = db.WebServicesApis.Find(id);
            if (webServicesApi == null)
            {
                return HttpNotFound();
            }
            return View(webServicesApi);
        }

        // POST: WebServicesApis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,ClientId,ClientSecret,Basic,TokenAcess")] WebServicesApi webServicesApi)
        {
            if (ModelState.IsValid)
            {

                string clientIdHash = Hash.GerarHash(webServicesApi.ClientId);
                webServicesApi.ClientId = clientIdHash;


                if (webServicesApi.ClientSecret != null)
                {
                    string clientSecret = Hash.GerarHash(webServicesApi.ClientSecret);
                    webServicesApi.ClientSecret = clientSecret;
                }

                if (webServicesApi.Basic != null)
                {
                    string basic = Hash.GerarHash(webServicesApi.Basic);
                    webServicesApi.Basic = basic;
                }

                if (webServicesApi.TokenAcess != null)
                {
                    string tokenacess = Hash.GerarHash(webServicesApi.TokenAcess);
                    webServicesApi.TokenAcess = tokenacess;
                }


                db.Entry(webServicesApi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(webServicesApi);
        }

        // GET: WebServicesApis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WebServicesApi webServicesApi = db.WebServicesApis.Find(id);
            if (webServicesApi == null)
            {
                return HttpNotFound();
            }
            return View(webServicesApi);
        }

        // POST: WebServicesApis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WebServicesApi webServicesApi = db.WebServicesApis.Find(id);
            db.WebServicesApis.Remove(webServicesApi);
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
