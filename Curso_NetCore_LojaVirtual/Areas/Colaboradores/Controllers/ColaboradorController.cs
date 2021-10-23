using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Areas.Colaboradores.Controllers
{
    [Area("Colaboradores")]

    public class ColaboradorController : Controller
    {
        private readonly IColaboradoresRepositorio _icolaboradoresRepositorio;
        public ColaboradorController(IColaboradoresRepositorio colaboradoresRepositorio)
        {
            this._icolaboradoresRepositorio = colaboradoresRepositorio;
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
            if (ModelState.IsValid)
            {
                _icolaboradoresRepositorio.Cadastrar(model);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult GerarSenha(int id)
        {
            return View();
        }

        public IActionResult Atualizar(int id)
        {
            var colaborador = _icolaboradoresRepositorio.Get(id);
            return View(colaborador);
        }

        [HttpPost]
        public IActionResult Atualizar(Models.Colaboradores model)
        {
            if (ModelState.IsValid)
            {
                //model.tipoColaborador = "C";
                _icolaboradoresRepositorio.Atualizar(model);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            _icolaboradoresRepositorio.Excluir(id);
            TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO; 
            return RedirectToAction(nameof(Index));
        }
    }
}
