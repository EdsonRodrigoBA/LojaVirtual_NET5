using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Models.ViewModels;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Componentes
{

    public class ProdutosListagemViewComponent : ViewComponent
    {
        private readonly IprodutosRepositorio _iprodutosRepositorio;
        private readonly ICategoriaRepositorio _icategoriaRepositorio;

        public ProdutosListagemViewComponent(IprodutosRepositorio iprodutosRepositorio, ICategoriaRepositorio icategoriaRepositorio)
        {
            this._iprodutosRepositorio = iprodutosRepositorio;
            this._icategoriaRepositorio = icategoriaRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int pagina = 1;
            String pesquisa = "";
            String ordenacao = "A";
            List<Categoria> categorias = null;
            if (HttpContext.Request.Query.ContainsKey("pagina"))
            {
                pagina = int.Parse(HttpContext.Request.Query["pagina"]);
            }
            if (HttpContext.Request.Query.ContainsKey("pesquisa"))
            {
                pesquisa = HttpContext.Request.Query["pesquisa"].ToString();
            }
            if (HttpContext.Request.Query.ContainsKey("ordenacao"))
            {
                ordenacao = HttpContext.Request.Query["ordenacao"].ToString();
            }

            if (ViewContext.RouteData.Values.ContainsKey("slug"))
            {
                var slug = ViewContext.RouteData.Values["slug"].ToString();
                var categoriaPrincipal = _icategoriaRepositorio.Get(slug);
                categorias = _icategoriaRepositorio.Get_CategoriasRecursiva(categoriaPrincipal).ToList();
            }

            var listaprodutos = _iprodutosRepositorio.Get_Paginacao_Ordencacao(pagina, pesquisa, ordenacao, categorias);

            ProdutosListagemViewModel viewModel = new ProdutosListagemViewModel()
            {
                Produtos = listaprodutos
            };
            return View(viewModel);
        }
    }
}
