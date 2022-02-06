using AutoMapper;
using Curso_NetCore_LojaVirtual.Bibliotecas.CarrinhoCompras;
using Curso_NetCore_LojaVirtual.Bibliotecas.Cookie;
using Curso_NetCore_LojaVirtual.Bibliotecas.Filtros;
using Curso_NetCore_LojaVirtual.Bibliotecas.Gerenciador.Frete;
using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Controllers
{


    [ClienteAutorizacaoAtribute]
    public class PagamentoController : BaseController
    {

        private CookieSistema _cookie;
        public PagamentoController(CookieSistema cookie, CookieCarrinhoCompras carrinhoCompras, IprodutosRepositorio iprodutoRepositorio, IMapper imapper, ws_Correios_CalcularFrete ws_Correios_CalcularFrete,
     CalcularPacote calcularPacote, CookieCarrinhoPrazoFrete carrinhoPrazoFrete) : base(carrinhoCompras, iprodutoRepositorio, imapper, ws_Correios_CalcularFrete, calcularPacote, carrinhoPrazoFrete)
        {
            this._cookie = cookie;
        }

        public IActionResult Index()
        {

            // _carrinhoPrazoFrete.Consultar()
            var tipofrete_selecionado = _cookie.consultar("Carrinho.TipoFrete", false);
            if (tipofrete_selecionado != null)
            {

                var frete = _carrinhoPrazoFrete.Consultar().FirstOrDefault(x => x.tipofrete == tipofrete_selecionado);

                if (frete != null)
                {
                    ViewBag.Frete = frete;
                    var produtoscarrinho = Produtos_BD_Carrinho();

                    return View(produtoscarrinho);

                }
            }

            TempData["MSG_ERRO"] = Mensagens.MSG_TIPOFRETEENVIO;

            return RedirectToAction("Index", "Carrinho");



        }
    }


}
