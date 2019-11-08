using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Teos.Models;
using System.Net;



namespace Teos.Utils
{
    //Desclar Claims do sistema
    public class ClaimsSistema
    {

        public ClaimsIdentity UserClaims(Usuarios usuarios)
        {

            var identity = new ClaimsIdentity(new[] 
            { 
                new Claim(ClaimTypes.Name, usuarios.Nome),
                new Claim("Login", usuarios.Login),
                new Claim(ClaimTypes.Email, usuarios.Login)
                
            }, "ApplicationCookie");
            

            return identity;
        }

    }
}