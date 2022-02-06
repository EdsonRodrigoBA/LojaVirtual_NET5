using Curso_NetCore_LojaVirtual.Bibliotecas.Email;
using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Bibliotecas.Texto;
using Curso_NetCore_LojaVirtual.Models.Constantes;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Areas.Colaboradores.Controllers
{
    [Area("Colaboradores")]
    [ColobaradoresAutorizacaoAtribute(tipoUsuario: TiposColaboradores_Constantes.GERENTE)]

    public class ColaboradorController : Controller
    {
        private readonly IColaboradoresRepositorio _icolaboradoresRepositorio;
        private readonly GerenciarEnvioEmails _gerenciarEnvioEmails;

        public ColaboradorController(IColaboradoresRepositorio colaboradoresRepositorio, GerenciarEnvioEmails gerenciarEnvioEmails)
        {
            this._icolaboradoresRepositorio = colaboradoresRepositorio;
            this._gerenciarEnvioEmails = gerenciarEnvioEmails;
        }
        public IActionResult Index(int? pagina)
        {
            var lista = _icolaboradoresRepositorio.Get(pagina);
            return View(lista);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Models.Colaboradores model)
        {
            ModelState.Remove("senha");
            ModelState.Remove("confirmPassword");
            model.tipoColaborador = TiposColaboradores_Constantes.COMUM;
            if (ModelState.IsValid)
            {
                var senha = KeyGenerator.GetUniqueKey(6);
                model.senha = senha;
                _icolaboradoresRepositorio.Cadastrar(model);
                _gerenciarEnvioEmails.EnviarSenhaColaboradorPorEmail(model);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult GerarSenha(int id)
        {
            var colaborador = _icolaboradoresRepositorio.Get(id);

            var senha = KeyGenerator.GetUniqueKey(6);
            colaborador.senha = senha;
            _icolaboradoresRepositorio.AtualizarSenha(colaborador);
            _gerenciarEnvioEmails.EnviarSenhaColaboradorPorEmail(colaborador);
            TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO_EMAIL;
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var colaborador = _icolaboradoresRepositorio.Get(id);
            return View(colaborador);
        }

        [HttpPost]
        public IActionResult Atualizar(Models.Colaboradores model)
        {
            ModelState.Remove("senha");
            ModelState.Remove("confirmPassword");
            if (ModelState.IsValid)
            {

                _icolaboradoresRepositorio.Atualizar(model);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ValidadeHttpReference]
        public IActionResult Excluir(int id)
        {
            _icolaboradoresRepositorio.Excluir(id);
            TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
            return RedirectToAction(nameof(Index));
        }
    }
}
