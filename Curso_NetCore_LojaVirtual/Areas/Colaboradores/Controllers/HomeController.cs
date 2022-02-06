using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Areas.Colaboradores.Controllers
{

    [Area("Colaboradores")]
    public class HomeController : Controller
    {
        private readonly IColaboradoresRepositorio _icolaboradoresRepositorio;
        private readonly LoginColaboradores _loginColaboradores;


        public HomeController(IColaboradoresRepositorio icolaboradoresRepositorio, LoginColaboradores loginColaboradores)
        {
            this._icolaboradoresRepositorio = icolaboradoresRepositorio;
            this._loginColaboradores = loginColaboradores;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login([FromForm] Models.Colaboradores colaboradores)
        {
            ModelState.Remove("email");
            if (String.IsNullOrEmpty(colaboradores.email) || String.IsNullOrEmpty(colaboradores.senha))
            {
                ModelState.AddModelError("email", "E-mail / Senha Invalidos");
                return View();

            }


            var result = _icolaboradoresRepositorio.Login(colaboradores.email, colaboradores.senha);
            if (result != null)
            {
                _loginColaboradores.Login(result);

                return RedirectToAction(nameof(PainelAdministrador));

            }
            else
            {
                ViewData["MSG_ERRO"] = "Usuario não encontrado. Verifique o E-mail e Senha Informado.";
                return View();

            }
        }

        [ValidadeHttpReference]
        public IActionResult Logout()
        {
            _loginColaboradores.Logout();
            return RedirectToAction(nameof(Login));
        }




        public IActionResult RecuperarSenha()
        {
            return View();
        }

        public IActionResult CadastrarNovaSenha()
        {
            return View();
        }

        [ColobaradoresAutorizacaoAtribute]
        public IActionResult PainelAdministrador()
        {
            return View();
        }
    }
}
