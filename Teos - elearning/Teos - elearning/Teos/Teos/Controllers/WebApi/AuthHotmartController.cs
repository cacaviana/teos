using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Teos.Models;
using Teos.Models.DTO;

namespace Teos.Controllers.WebApi
{
    public class AuthHotmartController : ApiController
    {

        TeosContext db = new TeosContext();

        HttpClient client = new HttpClient();

        HttpResponseMessage response = new HttpResponseMessage();

        public AuthHotmartController()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            
             
        }

        
        // GET: api/AuthHotmart/code - Autenticação para receber AccessToken
        public string GetAccessToken([FromUri]string code, [FromBody]HotmartCredenciais hotmartCredenciacias)
        {
            //Buscando o Basic do Hotmart
            string basic = db.WebServicesApis.Find(2).Basic;

            String uri = $"https://api-sec-vlc.hotmart.com/security/oauth/token?grant_type=authorization_code&code={code}&client_id={client}&redirect_uri=http://localhost:53520/api/AuthHotmart/";


            client.DefaultRequestHeaders.Add("Authorization", $"Basic {basic}");
            response = client.PostAsJsonAsync<HotmartCredenciais>("www", hotmartCredenciacias).Result;

            hotmartCredenciacias = response.Content.ReadAsAsync<HotmartCredenciais>().Result;
            
            return "value";
        }

        // POST: api/AuthHotmart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AuthHotmart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AuthHotmart/5
        public void Delete(int id)
        {
        }
    }
}
