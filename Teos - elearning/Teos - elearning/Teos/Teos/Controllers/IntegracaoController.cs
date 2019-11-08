using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Teos.Models;

namespace Teos.Controllers
{
    public class IntegracaoController : Controller
    {
        TeosContext db = new TeosContext();
        // GET: Integracao
        public ActionResult Index()
        {
            //HttpClient client = new HttpClient();

            //client.DefaultRequestHeaders.Clear();
            ////msg.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //client.BaseAddress = new Uri("https://api.vimeo.com/");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            return View();
        }
    }
}