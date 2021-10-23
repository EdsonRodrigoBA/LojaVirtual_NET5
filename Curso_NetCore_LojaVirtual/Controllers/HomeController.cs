using Curso_NetCore_LojaVirtual.Bibliotecas.Email;
using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
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

        private readonly IClienteRepositorio _iclienteRepositorio;
        private readonly INewsLettersRepositorio _NewsLettersRepositorio;
        private readonly LoginCliente _loginCliente;


        public HomeController(IClienteRepositorio iclienteRepositorio, INewsLettersRepositorio NewsLettersRepositorio, LoginCliente loginCliente)
        {
            _iclienteRepositorio = iclienteRepositorio;
            this._NewsLettersRepositorio = NewsLettersRepositorio;
            this._loginCliente = loginCliente;
        }
        [HttpGet]
        public IActionResult Index()
        {
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
                    //ContatoEmail.EnviarConatoPorEmail(contato);
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Clientes clientes)
        {
            if (String.IsNullOrEmpty(clientes.email))
            {
                ModelState.AddModelError("email", "E-mail Invalido");
                return View();

            }

            if (String.IsNullOrEmpty(clientes.senha))
            {
                ModelState.AddModelError("senha", "Senha Invalida");
            }


            var result = _iclienteRepositorio.Login(clientes.email, clientes.senha);
            if (result != null)
            {
                _loginCliente.Login(result);

                return RedirectToAction(nameof(Painel));

            }
            else
            {
                ViewData["MSG_ERRO"] = "Usuario não encontrado. Verifique o E-mail e Senha Informado.";
                return View();

            }
        }

        [ClienteAutorizacaoAtribute]
        public IActionResult Painel()
        {

            return View();
        }

        public IActionResult CadastroCliente()
        {
            return new ContentResult() { Content = $"Este é o painel do cliente." };
        }
        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                _iclienteRepositorio.Cadastrar(clientes);

                TempData["MSG_SUCESSO"] = "Cadastro efetuado com sucesso.";

                return RedirectToAction(nameof(CadastroCliente));
            }
            else
            {
                return View();

            }
        }

        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
