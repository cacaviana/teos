using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Teos.Models.DTO;
using Microsoft.Web.WebPages.OAuth;

namespace Teos.Controllers
{
    public class CursosAPIController : Controller
    {

        HttpClient client = new HttpClient();

        //Construtor
        public CursosAPIController()
        {
            //Uri uri = new Uri("http://www.cafderl.com");

            //client.BaseAddress = new Uri("http://www.deveup.com.br/notas/api");
            client.BaseAddress = new Uri("https://localhost:44349");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        

        // GET: CursosAPI
        public ActionResult Index()
        {
            //List<CursosApi> cursosApi = new List<CursosApi>();

            //HttpResponseMessage response = client.GetAsync("api/cursos?pagina=3&tamanhapagina=10").Result;

            //if (response.IsSuccessStatusCode)
            //    cursosApi = response.Content.ReadAsAsync<List<CursosApi>>().Result;


            //return View(cursosApi);
            return View();
        }

        // GET: CursosAPI/Details/5
        public ActionResult Details(int id)
        {
            CursosApi cursosApi = new CursosApi();

            HttpResponseMessage response = client.GetAsync("api/cursos/"+id).Result;

            if (response.IsSuccessStatusCode)
                cursosApi = response.Content.ReadAsAsync<CursosApi>().Result;


            return View(cursosApi);
        }

        // GET: CursosAPI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursosAPI/Create
        [HttpPost]
        public ActionResult Create(CursosApi cursosApi)
        {
            try
            {
                // TODO: Add insert logic here
                HttpResponseMessage response = client.
                    PostAsJsonAsync<CursosApi>("api/cursos", cursosApi).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Erro ao criar o curso";
                    ModelState.AddModelError("Titulo", response.StatusCode.ToString());
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosAPI/Edit/5
        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = client.GetAsync($"api/cursos/{id}").Result;
            CursosApi cursosApi = response.Content.ReadAsAsync<CursosApi>().Result;

            if (cursosApi != null)
                return View(cursosApi);
            else
                return HttpNotFound();
        }

        // POST: CursosAPI/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CursosApi cursosApi)
        {
            try
            {
                HttpResponseMessage response = client.
                    PutAsJsonAsync<CursosApi>($"api/cursos/{id}", cursosApi).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error while editing note.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: CursosAPI/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.GetAsync($"api/cursos/{id}").Result;
            CursosApi cursosApi = response.Content.ReadAsAsync<CursosApi>().Result;


            if (cursosApi != null)
                return View(cursosApi);
            else
                return HttpNotFound();
        }

        // POST: CursosAPI/Delete/5
        
        public ActionResult Delete(int id, CursosApi cursosApi)
        {
            try
            {
                // TODO: Add delete logic here
                HttpResponseMessage response = client.DeleteAsync($"api/cursos/{id}").Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Error = "Error while deleting note.";
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }
    }
}
