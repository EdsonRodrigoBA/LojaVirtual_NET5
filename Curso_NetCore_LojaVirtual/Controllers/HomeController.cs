using Curso_NetCore_LojaVirtual.Bibliotecas.Email;
using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Models.Constantes;
using Curso_NetCore_LojaVirtual.Models.ViewModels;
using Curso_NetCore_LojaVirtual.Repositorios;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Controllers
{
    

    public class HomeController : Controller
    {

   
        private readonly INewsLettersRepositorio _NewsLettersRepositorio;
        private readonly IprodutosRepositorio _iprodutosRepositorio;

        private readonly GerenciarEnvioEmails _gerenciarEnvioEmails;

        public HomeController( INewsLettersRepositorio NewsLettersRepositorio, 
            GerenciarEnvioEmails gerenciarEnvioEmails, IprodutosRepositorio iprodutosRepositorio)
        {
            this._NewsLettersRepositorio = NewsLettersRepositorio;
           
            this._gerenciarEnvioEmails = gerenciarEnvioEmails;
            this._iprodutosRepositorio = iprodutosRepositorio;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var viewModel = new IndexViewModel()
            //{
            //    Produtos = _iprodutosRepositorio.Get_Paginacao_Ordencacao(pagina, pesquisa, ordenacao),                
            //};
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] NewsLettersEmail newsLettersEmail)

        {
            if (ModelState.IsValid)
            {
                _NewsLettersRepositorio.Cadastrar(newsLettersEmail);

                TempData["MSG_SUCESSO"] = "E-mail cadastrado com sucesso. Em breve entraremos em contato! Fique atento as novidades";

                return RedirectToAction(nameof(Index));
            }
            else
            {
            
                return View();

            }

        }

        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {

            try
            {


                Contato contato = new Contato();
                contato.nome = HttpContext.Request.Form["nome"];
                contato.email = HttpContext.Request.Form["email"];
                contato.texto = HttpContext.Request.Form["texto"];

                var listamensagem = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isvalid = Validator.TryValidateObject(contato, contexto, listamensagem, true);
                if (isvalid)
                {
                    _gerenciarEnvioEmails.EnviarConatoPorEmail(contato);
                }
                else
                {
                    StringBuilder msg = new StringBuilder();
                    foreach (var texto in listamensagem)
                    {
                        msg.Append(texto.ErrorMessage + "<br />");
                    }
                    ViewData["msg_erro"] = msg.ToString();
                    ViewData["contato"] = contato;
                }

                //return new ContentResult() { Content = "Dados recebido com sucesso." };
                ViewData["msg_sucesso"] = "Mensagem de Contato Enviado com Sucesso";
                return View(nameof(Contato));
            }
            catch (Exception ex)
            {
                ViewData["msg_erro"] = "Ocorreu um erro, tente novamente mais tarde. ;)";
                return View(nameof(Contato));


            }
        }



        public IActionResult CarrinhoCompras()
        {
            return View();
        }

        public IActionResult Categoria()
        {
            return View();
        }
    }
}
