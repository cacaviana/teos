using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using Teos.Models;
using Teos.Models.DTO;
using Teos.Utils;
using Owin.Security.Providers.Vimeo;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Teos.Controllers.WebApi
{
    public class AuthVimeoController : ApiController
    {
        private TeosContext db = new TeosContext();

        HttpClient client = new HttpClient();

        public AuthVimeoController()
        {
            client.DefaultRequestHeaders.Clear();
            
           
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          //  var mediaType = new MediaTypeWithQualityHeaderValue("application/vnd.vimeo.*+json;version=3.4");
           // client.DefaultRequestHeaders.Accept.Add(mediaType);
            //client.DefaultRequestHeaders.AcceptCharset.Add(new StringWithQualityHeaderValue("UTF-8"));

            WebServicesApi webServices = new WebServicesApi();

            //Credencial Vimeo
            //string clientId = "865935be6d8a847f41e4554bd2e5b5af2ed53edf";
            //string clientSecret = "NRl0Ur3GnCQz4wubNSgF8yfiCaW8gKwXYNzyaU/gqqJikqT5UMzpCXH0jo7oJfoPk+LFYz4IjDqHp8ZIx5rNRxJdHeR5PhjRRFO8krUxKZRO/nt2hdSHX8cSOwMmqvQW";
            //string clientId = Hash.GerarHash(webServices.ClientId);
            //string clientSecret = Hash.GerarHash(webServices.ClientSecret);
           
        }


        // GET: api/AuthVimeo/5

        
        public async Task<IActionResult> GetCredenciais([FromUri]string code, [FromUri]string state)
        {
            WebServicesApi webServices = new WebServicesApi();
            
            //Credencial Vimeo
            //string clientId = Hash.GerarHash(webServices.ClientId);
            //string clientSecret = Hash.GerarHash(webServices.ClientSecret);


            if (code != null)
            {
                if (state == "vamosnessa")
                {

                    //Cabeçalho
                    string clientId = "865935be6d8a847f41e4554bd2e5b5af2ed53edf";
                    string clientSecret = "NRl0Ur3GnCQz4wubNSgF8yfiCaW8gKwXYNzyaU/gqqJikqT5UMzpCXH0jo7oJfoPk+LFYz4IjDqHp8ZIx5rNRxJdHeR5PhjRRFO8krUxKZRO/nt2hdSHX8cSOwMmqvQW";
                    //string clientId = Hash.GerarHash(webServices.ClientId);
                    //string clientSecret = Hash.GerarHash(webServices.ClientSecret);

                    string valueAuthorization = $"basic base64_encode({clientId}:{clientSecret})";
                    client.DefaultRequestHeaders.Add("Authorization", valueAuthorization);


                    //VimeoCredenciais vimeo = new VimeoCredenciais();
                    VimeoCredenciais vimeo = new VimeoCredenciais();
                    //Corpo
                    vimeo.GrantType = "authorization_code";
                    vimeo.Code = code;
                    //vimeo.RedirectUri = redirect_uri;
                    vimeo.RedirectUri= new Uri ("http://localhost:53520/api/AuthVimeo/");

                    //var parameters = new Dictionary<string, string>
                    //{
                    //    ["grant_type"] = "authorization_code",
                    //    ["code"] = code,
                    //    ["redirect_uri"] = "http://localhost:53520/api/AuthVimeo/"
                    //};
                    

                    HttpResponseMessage response = client.PostAsJsonAsync<VimeoCredenciais>("http://localhost:53520/api/AuthVimeo/", vimeo).Result;
                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    var codigoerro = response.ReasonPhrase;
                    //}

                    response.EnsureSuccessStatusCode();

                    vimeo = response.Content.ReadAsAsync<VimeoCredenciais>().Result;

                    Credenciais credenciais = new Credenciais
                    {
                        ClientesID = 1,
                        WebServicesApiId = 1
                    };

                    var lista = db.WebServicesApis.Find(1);

                    //lista.TokenAcess = vimeo.TokenType;

                    //db.Credenciais.Add(credenciais);
                    //db.Entry(webServices).State = EntityState.Modified;
                    //db.SaveChanges();
                    //Salvar o Access Token do banco de dados

                    return null;
                }
                else
                    return null;
            }

            return null;
            
        }



        //// PUT: api/AuthVimeo/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult GetCredenciais(int id, Credenciais credenciais)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != credenciais.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(credenciais).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CredenciaisExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/AuthVimeo
        //[ResponseType(typeof(Credenciais))]
        //public IHttpActionResult PostCredenciais(Credenciais credenciais)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Credenciais.Add(credenciais);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = credenciais.Id }, credenciais);
        //}

        //// DELETE: api/AuthVimeo/5
        //[ResponseType(typeof(Credenciais))]
        //public IHttpActionResult DeleteCredenciais(int id)
        //{
        //    Credenciais credenciais = db.Credenciais.Find(id);
        //    if (credenciais == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Credenciais.Remove(credenciais);
        //    db.SaveChanges();

        //    return Ok(credenciais);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CredenciaisExists(int id)
        {
            return db.Credenciais.Count(e => e.Id == id) > 0;
        }
    }
}