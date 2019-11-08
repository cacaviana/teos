using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teos.ViewModels;
using Teos.Models;
using System.Net;
using System.Data.Entity;
using Teos.Utils;
using System.Security.Claims;


namespace Teos.Controllers
{
    public class AutenticacaoController : Controller
    {
        private TeosContext db = new TeosContext();



        //Tela que será direcionado o usuário sem o [Authorize] - classe Startup.cs
        //GET
        public ActionResult Login(string ReturnURL)
        {
            var viewmodel = new LoginViewModel{ UrlRetorno = ReturnURL};

            return View(viewmodel);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            
            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == viewModel.Login);
            //usuário não Cadastrado
            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Usuário não cadastrado");
                return View(viewModel);
            }

            //senha incorreta
            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }


            //Declar as Claims do sistema
            var identity = new ClaimsSistema().UserClaims(usuario);
            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
                return Redirect(viewModel.UrlRetorno);
            else
                return RedirectToAction("Index", new { controller = "Cursos"});

            // Eu vou pegar a Claim

            //var identificacao = User.Identity;

            //Claim claim = identity.FindFirst("login");
            //int a = Convert.ToInt32(claim.Value);




            /*
                      //ApplicationCookie está na classe Startup
                       var identity = new ClaimsIdentity(new[]
                       {
                           new Claim(ClaimTypes.Name, usuario.Nome),
                           new Claim("Login", usuario.Login)
                       }, "ApplicationCookie");



                       Request.GetOwinContext().Authentication.SignIn(identity);
          */

            /*
           (criando 3 claim)
           Claim claim2 = new Claim(ClaimTypes.Name, "Fabio Rodrigues Fonseca");
           Claim claim3 = new Claim(ClaimTypes.Role, "Administrador");
           Claim claim4 = new Claim(ClaimTypes.Email, "fabison@ig.com.br");

           (colando numa lista de claim
           IList<Claim> Claims = new List<Claim>() {
                 claim2,
                 claim3,
                 claim4
             };

           //Criando uma Identidade e associando-a ao ambiente.
           ClaimsIdentity identity = new ClaimsIdentity(Claims, "Devimedia");
           ClaimsPrincipal principal = new ClaimsPrincipal(identity);
           Thread.CurrentPrincipal = principal;

           ou 

           Claim claim2 = new Claim(ClaimTypes.Name, "Fabio Rodrigues Fonseca");
           Claim claim3 = new Claim(ClaimTypes.Role, "Administrador");
           Claim claim4 = new Claim(ClaimTypes.Email, "fabison@ig.com.br");

           IList<Claim> Claims = new List<Claim>() {
                 claim2,
                 claim3,
                 claim4
             };

           var identity2 = new ClaimsIdentity();
           identity2.AddClaims(Claims);

           ClaimsIdentity claimsIdentity = new ClaimsIdentity(Claims, "AutenticationCookie");
           claimsIdentity.

           */


        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", new { controller = "Cursos" });

        }



        public ActionResult Index()
        {
            return View(db.Usuarios);
        }

        // GET: Autenticacao

        
        public ActionResult Cadastrar()
        {
            return View();
        }

        //POST: Autenticacao
        //Tela para cadastro de usuários 'padrão'
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(CadastroUsuarioViewModels ViewModels)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewModels);
            }

            //evitar logins duplicados
            if (db.Usuarios.Count(c => c.Login == ViewModels.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já está em uso");
                return View(ViewModels);
            }

            Usuarios usuario = new Usuarios
            {
                Nome = ViewModels.Nome,
                SobreNome = ViewModels.SobreNome,
                Login = ViewModels.Login,
                Senha = Hash.GerarHash(ViewModels.Senha),
                PapeisId = 2,
                ClientesId = 1
                
                
            };

            db.Usuarios.Add(usuario);
            db.SaveChanges();


            //Essa variável é um objeto ClaimsIdentity
            var identity = new ClaimsIdentity(new[] 
            {
                new Claim(ClaimTypes.Name, usuario.Nome), 
                new Claim("Login", usuario.Login)
            }, 
                "ApplicationCookie");

            //Salvar Autenticação no Cookie
            Request.GetOwinContext().Authentication.SignIn(identity);

            return RedirectToAction("Index", new { controller = "Cursos" });         

        }

        //GET: 

       public ActionResult AlterarSenha() 
        {
            return View();
        
        }

        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel) 
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var identity = User.Identity as ClaimsIdentity;
            var claimsuser = identity.Claims.FirstOrDefault(c => c.Type == "Login");
            Usuarios usuarios = db.Usuarios.FirstOrDefault(l => l.Login == claimsuser.Value);

           
            
            if (usuarios.Senha != Hash.GerarHash(viewModel.SenhaAtual))
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                TempData["MensagemErro"] = "Erro";
                return View();
            }

            usuarios.Senha = Hash.GerarHash(viewModel.NovaSenha);
            db.Entry(usuarios).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Mensagem"] = "Senha alterada com sucesso";
            

            return View();
            
        
        }
        
        
        
        
        //GET: Papeis/Edit/5

        public ActionResult Edit(int? id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Usuarios usuarios = db.Usuarios.Find(id);

            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Nome, Sobrenome, Login, Senha, PapeisId")] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return View(usuarios);
            }

            db.Entry(usuarios).State = EntityState.Modified;
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