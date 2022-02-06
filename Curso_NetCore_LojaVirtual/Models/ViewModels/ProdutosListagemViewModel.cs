using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Models.ViewModels
{
    public class ProdutosListagemViewModel
    {
        public IPagedList<Produtos> Produtos { get; set; }
        public List<SelectListItem> ordenacao
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem("Alfabetica","A"),
                    new SelectListItem("Menor Preço","ME"),
                    new SelectListItem("Maior Preço","MA"),
                };
            }
            private set { }

        }
    }
}
