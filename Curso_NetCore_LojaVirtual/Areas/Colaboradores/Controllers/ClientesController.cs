using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
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
    [ColobaradoresAutorizacaoAtribute(tipoUsuario: TiposColaboradores_Constantes.COMUM)]

    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _iclienteRepositorio;
        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            this._iclienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index(int ? pagina, String pesquisa)
        {
            var clientes = _iclienteRepositorio.Get(pagina, pesquisa);
            return View(clientes);
        }


        [ValidadeHttpReference]
        public IActionResult Ativar_Desativar(int id)
        {
            var cliente = _iclienteRepositorio.Get(id);
            if(cliente.Situacao == SituacaoCadastrosConstantes.ATIVO)
            {
                cliente.Situacao = SituacaoCadastrosConstantes.INATIVO;
            }
            else
            {
                cliente.Situacao = SituacaoCadastrosConstantes.ATIVO;

            }
            _iclienteRepositorio.Atualizar(cliente);

            TempData["MSG_SUCESSO"] = Mensagens.MSG_SUCESSO;
            return RedirectToAction(nameof(Index));
        }


    }
}
