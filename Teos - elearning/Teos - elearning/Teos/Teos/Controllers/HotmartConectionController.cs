using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Teos.Models;
using Teos.Models.DTO;

namespace Teos.Controllers
{
    public class HotmartConectionController : Controller
    {
        HttpClient client = new HttpClient();
        HotmartCredenciais hotmartCredenciais = new HotmartCredenciais();
        TeosContext db = new TeosContext();

        public HotmartConectionController()
        {
            //Autenticar oAuth

            //client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            
        }

        // GET: HotmartConection
        public ActionResult Autenticar(string code)
        {


            string URL = $"https://api-sec-vlc.hotmart.com/security/oauth/token?grant_type=authorization_code&code={code}&client_id=cacc845e-c27e-4aab-ab5b-a8ea6a759f58&redirect_uri=http://localhost:53520/HotmartConection/Autenticar";

            //Autorização do AuTh - Hotmart
            client.DefaultRequestHeaders.Add("Authorization", "Basic Y2FjYzg0NWUtYzI3ZS00YWFiLWFiNWItYThlYTZhNzU5ZjU4OmZmNWNkMWU1LWUwN2YtNDQ0NS05ZGQyLWU0MjM0OTc5ZWZiOA==");

            HttpResponseMessage response = 
                client.PostAsJsonAsync<HotmartCredenciais>(URL, hotmartCredenciais).Result;

            if (response.IsSuccessStatusCode)
            {
                hotmartCredenciais = response.Content.ReadAsAsync<HotmartCredenciais>().Result;

                WebServicesApi webServices = new WebServicesApi();
                webServices = db.WebServicesApis.Find(2);

                webServices.TokenAcess = hotmartCredenciais.AccessToken;
                db.Entry(webServices).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


                return View(webServices);
            }

            return View();
        
        }

        
        public ActionResult Index()
        {
            
            
            return View();
        }

        // GET: HotmartConection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HotmartConection/Create
        public ActionResult Create()
        {
            return View();
        }

        

        // GET: HotmartConection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        

        // GET: HotmartConection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
