using Curso_NetCore_LojaVirtual.Bibliotecas.Arquivos;
using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;

using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Areas.Colaboradores.Controllers
{


    [Area("Colaboradores")]
    [ColobaradoresAutorizacaoAtribute]
    public class ProdutosController : Controller
    {
        private readonly IprodutosRepositorio _iprodutosRepositorio;
        private readonly ICategoriaRepositorio _icategoriaRepositorio;
        private readonly IImagensRepositorio _imagensRepositorio;


        public ProdutosController(IprodutosRepositorio iprodutosRepositorio, ICategoriaRepositorio icategoriaRepositorio, IImagensRepositorio imagensRepositorio)
        {
            this._iprodutosRepositorio = iprodutosRepositorio;
            this._icategoriaRepositorio = icategoriaRepositorio;
            this._imagensRepositorio = imagensRepositorio;
        }
        public IActionResult Index(int? pagina, String pesquisa)
        {
            var produtos = _iprodutosRepositorio.Get(pagina, pesquisa);
            return View(produtos);
        }


        public IActionResult Cadastrar()
        {
            ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Select(a => new SelectListItem(a.nome, a.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produtos model)
        {
            if (ModelState.IsValid)
            {

                _iprodutosRepositorio.Cadastrar(model);
                List<String> listaImagens = new List<string>(Request.Form["imagem"]);
                var imagensprodutos = GerenciadorArquivos.MoverImagensProduto(listaImagens, model.Id);
                _imagensRepositorio.CadastrarImagem(imagensprodutos);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Select(a => new SelectListItem(a.nome, a.Id.ToString()));
                model.Imagens = new List<string>(Request.Form["imagem"]).Where(x => x.Trim().Length > 0).Select(x => new Imagens()
                {

                    caminho = x
                }).ToList();
                return View(model);
            }

        }

        public IActionResult Atualizar(int id)
        {
            var produto = _iprodutosRepositorio.Get(id);
            ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Select(a => new SelectListItem(a.nome, a.Id.ToString()));

            return View(produto);
        }

        [HttpPost]
        public IActionResult Atualizar(Produtos model)
        {
            if (ModelState.IsValid)
            {
                _iprodutosRepositorio.Atualizar(model);
                List<String> listaImagens = new List<string>(Request.Form["imagem"]);
                var imagensprodutos = GerenciadorArquivos.MoverImagensProduto(listaImagens, model.Id);
                _imagensRepositorio.ExcluirImagensdoProduto(model.Id);
                _imagensRepositorio.CadastrarImagem(imagensprodutos);
                TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Categorias = _icategoriaRepositorio.GetTodos().Select(a => new SelectListItem(a.nome, a.Id.ToString()));
                model.Imagens = new List<string>(Request.Form["imagem"]).Where(x => x.Trim().Length > 0).Select(x => new Imagens()
                {

                    caminho = x
                }).ToList();
                return View(model);
            }
        }

        [ValidadeHttpReference]

        public IActionResult Excluir(int id)
        {


            var produtos = _iprodutosRepositorio.Get(id);
            if (produtos.Imagens != null)
            {
                foreach (var item in produtos.Imagens)
                {
                    GerenciadorArquivos.ExcluirImagemProduto(item.caminho);
                }
            }
            _iprodutosRepositorio.Excluir(id);
            TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
            return RedirectToAction(nameof(Index));

        }

    }
}
