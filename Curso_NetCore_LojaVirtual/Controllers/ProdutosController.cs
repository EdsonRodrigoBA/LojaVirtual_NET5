using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ICategoriaRepositorio _icategoriaRepositorio;
        private readonly IprodutosRepositorio _iprodutosRepositorio;

        public ProdutosController(ICategoriaRepositorio icategoriaRepositorio, IprodutosRepositorio iprodutosRepositorio)
        {
            this._icategoriaRepositorio = icategoriaRepositorio;
            this._iprodutosRepositorio = iprodutosRepositorio;
        }

        [HttpGet]
        [Route("produtos-{slug}")]
        public IActionResult Listagem_Por_Categoria(string slug)
        {

            var categoria = _icategoriaRepositorio.Get(slug);
            return View(categoria);
        }


        [HttpGet]

        [Route("produto-{slug}")]
        public IActionResult Detail(int slug)
        {
          
            return View(_iprodutosRepositorio.Get(slug));
        }

    }
}
