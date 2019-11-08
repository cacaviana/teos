using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Provider;
using Owin.Security.Providers.Vimeo;
using System.Web.Handlers;
using System.Web;

[assembly: OwinStartup(typeof(Teos.Startup))]

namespace Teos
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Para obter mais informações sobre como configurar 
            //seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888

           
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath =new PathString("/Autenticacao/Login")

            });

         
            /*  - Mesmo código acima, sem muita elegância.
            CookieAuthenticationOptions ca = new CookieAuthenticationOptions();
            PathString pathString = new PathString("/Autenticacao/Login");
            ca.LoginPath = pathString;
            ca.AuthenticationType = "dsadas";

            app.UseCookieAuthentication(ca); */


        }
    }
}
