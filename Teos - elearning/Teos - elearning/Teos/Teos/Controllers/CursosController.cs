using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teos.Models;

namespace Teos.Controllers
{
    
    public class CursosController : Controller
    {
        private TeosContext db = new TeosContext();

        // GET: Cursos
        public ActionResult Index()
        {
            return View(db.Cursos.OrderBy(c => c.Nome).ToList());
        }

        // GET: Cursos/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }


        //GET: Entrar no Curso

        [Authorize]
        public ActionResult EntrarCurso(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Cursos cursos = db.Cursos.Find(id);

            if (cursos == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.NomedoCurso = cursos.Nome;
            ViewBag.IdCurso = cursos.Id;

            return View(db.Modulos.Where(lm => lm.CursosId == id));

            //List<Modulos> listModulos = new List<Modulos>();
            //int a = db.Modulos.Count();
            //db.Modulos.

            //foreach (var item_modulo in db.Modulos.Select(lm => lm.CursosId))
            //{
            //    listModulos.Add(item_modulo);
            //}


            //listModulos.Add(db.Modulos.Select(lm => lm.CursosId);
            //var filtroModulos = listModulos.Select(lm => lm.CursosId == id);



        }


        //GET: Assistir Aula
        // id = id do conteúdo
        public ActionResult AssistirAula(int? id, int idmodulo, bool clickvoltar=false, bool clickavancar=false)
        {
            //se for vazio
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var modulo = db.Modulos.Find(idmodulo);
            var ncurso = db.Cursos.Find(modulo.CursosId);

            ViewBag.IdModulo = idmodulo;
            ViewBag.NomedoModulo = modulo.Nome;
            ViewBag.NomedoCurso = ncurso.Nome;


            //Implementação da navegação dos botões << Voltar e Avançar >>
            //Botão << Voltar
            if (clickvoltar)
                {

                    if (db.Conteudos.Where(c => c.ModulosId == idmodulo).FirstOrDefault() != db.Conteudos.Find(id))
                    {
                        var listatemp = db.Conteudos.Find(id);
                        int hierarquia = listatemp.Hierarquia -1;
                        var oficial = db.Conteudos.Where(h => h.Hierarquia == hierarquia)
                            .Where(c => c.ModulosId == idmodulo).ToList();

                        ViewBag.IdConteudo = oficial[0].Id;
                        id = oficial[0].Id;
                        ViewBag.NomedoConteudo = db.Conteudos.Find(id).Nome;
                      
                        return View(db.Conteudos.Where(i => i.ModulosId == idmodulo));
                    }
                }

            //Botão Avançar >>
            if (clickavancar)
            {
                
                if (db.Conteudos.Where(c => c.ModulosId == idmodulo).ToList().LastOrDefault() != db.Conteudos.Find(id))
                {
                    var listatemp = db.Conteudos.Find(id);
                    int hierarquia = listatemp.Hierarquia + 1;
                    var oficial = db.Conteudos.Where(h => h.Hierarquia == hierarquia)
                        .Where(c => c.ModulosId == idmodulo).ToList();

                    ViewBag.IdConteudo = oficial[0].Id;
                    ViewBag.NomedoConteudo = oficial[0].Nome;

                    return View(db.Conteudos.Where(i => i.ModulosId == idmodulo));
                }
            }
         
            ViewBag.IdConteudo = id;
            ViewBag.NomedoConteudo = db.Conteudos.Find(id).Nome;
            return View(db.Conteudos.Where(i => i.ModulosId == idmodulo));
        }


        // GET: Cursos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Promessa,Url_Pg_Vendas,Link_Certificado")] Cursos cursos)
        {
            if (ModelState.IsValid)
            {

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase arquivo = Request.Files[i];

                    
                    if (arquivo.ContentLength > 0)
                    {
                        if (arquivo.ContentType == "image/png" || arquivo.ContentType == "image/jpg" || arquivo.ContentType == "image/jpge" )
                        {
                            var UploadPath = Server.MapPath("~/Arquivos/Cursos");
                            var localsalve = Path.Combine(UploadPath, arquivo.FileName);
                            arquivo.SaveAs(localsalve);

                            ArquivosCursos arquivosCursos = new ArquivosCursos
                            {
                                NomeArquivo = arquivo.FileName,
                                CursosID = cursos.Id,
                                Extensao = arquivo.ContentType,
                                Tamanho = arquivo.ContentLength.ToString()
                            };
                           
                            db.Entry(arquivosCursos).State = EntityState.Added;

                            db.Cursos.Add(cursos);
                            db.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            string extensaoarquivo = arquivo.ContentType;
                            string [] dois = extensaoarquivo.Split('/');
                            ViewBag.Messagem = $"Você colocou um arquivo do tipo '{dois[1]}'. " +
                                $"- Por favor, coloque um arquito do tipo Imagem";
                            return View();
                        }
                            
                       
                    }
                }


               
            }

            return View(cursos);
        }

        // GET: Cursos/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Promessa")] Cursos cursos)
        {

            ArquivosCursos DBarquivosCursos = new ArquivosCursos();

            if (ModelState.IsValid)
            {
                HttpPostedFileBase arquivo = Request.Files.Get(0);


                if (arquivo.ContentLength > 0)
                {
                    if (arquivo.ContentType == "image/png" || arquivo.ContentType == "image/jpg" || arquivo.ContentType == "image/jpeg")
                    {
                        //Preparação inicial para Salvar novo arquivo
                        var UploadPath = Server.MapPath("~/Arquivos/Cursos");
                        var localsalve = Path.Combine(UploadPath, arquivo.FileName);
                        var arquivoscursos = db.ArquivosCursos.FirstOrDefault(c => c.CursosID == cursos.Id);

                        //Verifica se tem Imagem Salva daquele curso no banco Arquivos Cursos
                        if (arquivoscursos != null)
                        {
                            string nomearquivoanterior = arquivoscursos.NomeArquivo;

                            Random r = new Random();

                            string[] NomesAleatorios = {"A", "B", "C", "D", "E", "F", "G", "H",
                            "I", "J", "K", "L", "M", "N", "O", "P","Q",
                            "R", "S", "T", "U", "V", "X", "W", "Y", "Z",
                            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", 
                            "k", "l", "m", "n", "o", "p","q",
                            "r", "s", "t", "u", "v", "x", "w", "y", "z",
                            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                             "_","-", "¨"};


                            for (int i = 0; i < 7; i++)
                            {
                                int a = r.Next(NomesAleatorios.Length);
                                string nomegerado = NomesAleatorios[i];
                                string resultado = a.ToString();
                                
                            }

                            
                            


                            var localsalveanterior = Path.Combine(UploadPath, nomearquivoanterior);
                            //Apagar arquivo antigo
                            FileInfo fileInfo = new FileInfo(localsalveanterior);
                            fileInfo.Delete();
                            
                            arquivo.SaveAs(localsalve);

                            //Atualiza o banco ArquivosCursos
                            //DBarquivosCursos.Id = arquivoscursos.Id; 
                            arquivoscursos.NomeArquivo = arquivo.FileName;
                            arquivoscursos.CursosID = cursos.Id;
                            arquivoscursos.Extensao = arquivo.ContentType;
                            arquivoscursos.Tamanho = arquivo.ContentLength.ToString();

                            db.Entry(arquivoscursos).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else
                        {
                            arquivo.SaveAs(localsalve);
                            //Cria o registro no Banco ArquivosCursos
                            DBarquivosCursos.NomeArquivo = arquivo.FileName;
                            DBarquivosCursos.CursosID = cursos.Id;
                            DBarquivosCursos.Extensao = arquivo.ContentType;
                            DBarquivosCursos.Tamanho = arquivo.ContentLength.ToString();

                            db.ArquivosCursos.Add(DBarquivosCursos);
                            db.SaveChanges();

                        }
                    }
                    else
                    {
                        string extensaoarquivo = arquivo.ContentType;
                        string[] dois = extensaoarquivo.Split('/');
                        ViewBag.Messagem = $"Você colocou um arquivo do tipo '{dois[1]}'. " +
                            $"- Por favor, coloque um arquito do tipo Imagem";
                        return View();
                    }
                }
                
                db.Entry(cursos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cursos);
        }


        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cursos cursos = db.Cursos.Find(id);
            if (cursos == null)
            {
                return HttpNotFound();
            }
            return View(cursos);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cursos cursos = db.Cursos.Find(id);
            db.Cursos.Remove(cursos);
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
