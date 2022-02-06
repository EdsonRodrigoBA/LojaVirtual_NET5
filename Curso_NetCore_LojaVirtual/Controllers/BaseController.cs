using AutoMapper;
using Curso_NetCore_LojaVirtual.Bibliotecas.CarrinhoCompras;
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
    public class BaseController : Controller
    {

        public readonly CookieCarrinhoCompras _cookiecarrinhoCompras;
        public readonly CookieCarrinhoPrazoFrete _carrinhoPrazoFrete;

        public readonly IprodutosRepositorio _iprodutoRepositorio;
        public readonly IMapper _imapper;
        public readonly ws_Correios_CalcularFrete _ws_Correios_CalcularFrete;
        public readonly CalcularPacote _calcularPacote;

        public BaseController(CookieCarrinhoCompras carrinhoCompras, IprodutosRepositorio iprodutoRepositorio, IMapper imapper, ws_Correios_CalcularFrete ws_Correios_CalcularFrete,
            CalcularPacote calcularPacote, CookieCarrinhoPrazoFrete carrinhoPrazoFrete)
        {
            _cookiecarrinhoCompras = carrinhoCompras;
            this._iprodutoRepositorio = iprodutoRepositorio;
            this._imapper = imapper;
            this._ws_Correios_CalcularFrete = ws_Correios_CalcularFrete;
            this._calcularPacote = calcularPacote;
            this._carrinhoPrazoFrete = carrinhoPrazoFrete;
        }


        public List<ProdutosItem> Produtos_BD_Carrinho()
        {
            var produtoscarrinho = _cookiecarrinhoCompras.Consultar();
            List<ProdutosItem> produtos_ExibiCarrinho = new List<ProdutosItem>();
            foreach (var item in produtoscarrinho)
            {

                Produtos produto = _iprodutoRepositorio.Get(item.Id);

                ProdutosItem produtosItem = _imapper.Map<ProdutosItem>(produto);
                produtosItem.quantidade_carrinho = item.quantidade_carrinho;

                produtos_ExibiCarrinho.Add(produtosItem);
            }

            return produtos_ExibiCarrinho;
        }
    }
}
