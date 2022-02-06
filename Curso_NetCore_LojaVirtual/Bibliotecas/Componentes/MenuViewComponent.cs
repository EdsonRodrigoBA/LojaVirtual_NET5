using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Componentes
{

    public class MenuViewComponent : ViewComponent
    {
        private readonly ICategoriaRepositorio _icategoriarepositorio;
        public MenuViewComponent(ICategoriaRepositorio icategoriarepositorio)
        {
            this._icategoriarepositorio = icategoriarepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          var categorias =  _icategoriarepositorio.GetTodos();
            return View(categorias);
        }
    }
}
