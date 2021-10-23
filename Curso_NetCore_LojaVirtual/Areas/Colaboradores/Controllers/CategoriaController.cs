using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Areas.Colaboradores.Controllers
{

    [Area("Colaboradores")]
    [ColobaradoresAutorizacaoAtribute]

    public class CategoriaController : Controller
    {

        private readonly ICategoriaRepositorio _icategoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio icategoriaRepositorio)
        {
            this._icategoriaRepositorio = icategoriaRepositorio;
        }
        public IActionResult Index(int? pagina)
        {
            var lista = _icategoriaRepositorio.Get(pagina);
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Select(a => new SelectListItem(a.nome, a.Id.ToString()));

            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(Categoria model)
        {
            if (ModelState.IsValid)
            {
                _icategoriaRepositorio.Cadastrar(model);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO; ;
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Select(a => new SelectListItem(a.nome, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int id)
        {
            ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Where(x => x.Id != id).Select(a => new SelectListItem(a.nome, a.Id.ToString()));

            var categorias = _icategoriaRepositorio.Get(id);
            return View(categorias);
        }

        [HttpPost]
        public IActionResult Atualizar(Categoria model)
        {
            if (ModelState.IsValid)
            {
                _icategoriaRepositorio.Atualizar(model);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO; ;
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Where(x => x.Id != model.Id).Select(a => new SelectListItem(a.nome, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            _icategoriaRepositorio.Excluir(id);
            TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO; ;
            return RedirectToAction(nameof(Index));
        }
    }
}
