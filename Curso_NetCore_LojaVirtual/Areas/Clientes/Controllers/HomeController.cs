using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Models.Constantes;

namespace Curso_NetCore_LojaVirtual.Areas.Clientes.Controllers
{

    [Area("Clientes")]
    public class HomeController : Controller
    {

        private readonly LoginCliente _loginCliente;
        private readonly IClienteRepositorio _iclienteRepositorio;

        public HomeController(LoginCliente loginCliente, IClienteRepositorio iclienteRepositorio)
        {
            _loginCliente = loginCliente;
            _iclienteRepositorio = iclienteRepositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Models.Clientes clientes, String returnUrl = null)
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

                if (!String.IsNullOrEmpty(returnUrl))
                {
                    //var request = HttpContext.Request;

                    return RedirectPermanent(returnUrl);
                }


                return LocalRedirectPermanent(nameof(Painel));

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
            return View();
        }
        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Models.Clientes clientes, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                clientes.Situacao = SituacaoCadastrosConstantes.ATIVO;
                _iclienteRepositorio.Cadastrar(clientes);

                TempData["MSG_SUCESSO"] = "Cadastro efetuado com sucesso.";
                _loginCliente.Login(clientes);
                if (returnUrl == null)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });

                }
                else
                {
                    return LocalRedirectPermanent(returnUrl);
                }
            }
            else
            {
                return View();

            }
        }
    }
}
