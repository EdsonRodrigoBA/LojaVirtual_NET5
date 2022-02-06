using Curso_NetCore_LojaVirtual.Bibliotecas.CarrinhoCompras;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;

using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Bibliotecas.Gerenciador.Frete;
using Curso_NetCore_LojaVirtual.Models.Constantes;
using Curso_NetCore_LojaVirtual.Models;

namespace Curso_NetCore_LojaVirtual.Controllers
{
    public class CarrinhoController : BaseController
    {
 

        public CarrinhoController(CookieCarrinhoCompras carrinhoCompras, IprodutosRepositorio iprodutoRepositorio, IMapper imapper, ws_Correios_CalcularFrete ws_Correios_CalcularFrete,
            CalcularPacote calcularPacote, CookieCarrinhoPrazoFrete carrinhoPrazoFrete):base(carrinhoCompras, iprodutoRepositorio, imapper, ws_Correios_CalcularFrete, calcularPacote, carrinhoPrazoFrete)
        {
       
        }

        public IActionResult Index()
        {
            var produtoscarrinho = Produtos_BD_Carrinho();

            return View(produtoscarrinho);
        }


        public IActionResult AdicionarItem(int id)
        {
            var produto = _iprodutoRepositorio.Get(id);
            if (produto == null)
            {
                return View("NaoExisteItem");
            }
            else
            {
                var item = new ProdutosItem()
                {
                    Id = id,
                    quantidade_carrinho = 1
                };
                _cookiecarrinhoCompras.Cadastrar(item);
                return RedirectToAction(nameof(Index));
            }


        }

        [HttpGet]
        public IActionResult AlterarQuantidade(int id, int quantidade)
        {
            var produto = _iprodutoRepositorio.Get(id);
            if (quantidade < 1)
            {
                return BadRequest(new { mensagem = Mensagens.MSG_ESTOQUE_NEGATIVO });
            }
            else if (quantidade > produto.quantidade)
            {

                //retorna a quantidade e atualizar o campo ao inves de exibir mensagem.
                return BadRequest(new { mensagem = Mensagens.MSG_ESTOQUE_IDISPONIVEL });

            }
            else
            {
                var item = new ProdutosItem()
                {
                    Id = id,
                    quantidade_carrinho = quantidade
                };
                _cookiecarrinhoCompras.Atualizar(item);
                return Ok();
            }


        }
        public IActionResult RemoverItem(int id)
        {
            _cookiecarrinhoCompras.Remover(new ProdutosItem() { Id = id });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CalcularFreteCorreio(String cedpdestino)
        {
            try
            {


                var produtoscarrinho = Produtos_BD_Carrinho();
                var pacotes = _calcularPacote.CalcularPacote_Produtos(produtoscarrinho);
                var result_PAC = await _ws_Correios_CalcularFrete.CalcularFrete(cedpdestino, TipoFreteCorreioConstantes.PAC, pacotes);
                var result_SEDEX = await _ws_Correios_CalcularFrete.CalcularFrete(cedpdestino, TipoFreteCorreioConstantes.SEDEX, pacotes);
                //var result_SEDEX10 = await _ws_Correios_CalcularFrete.CalcularFrete(cedpdestino, TipoFreteCorreioConstantes.SEDEX10, pacotes);
                List<ValorPrazoFrete> valores = new List<ValorPrazoFrete>();
                if (result_PAC != null)
                {
                    valores.Add(result_PAC);

                }
                if (result_SEDEX != null)
                {
                    valores.Add(result_SEDEX);

                }
                //valores.Add(result_SEDEX10);
                this._carrinhoPrazoFrete.Cadastrar(valores);


                return Ok(valores);
            }
            catch (Exception ex)
            {
                this._carrinhoPrazoFrete.Remover();
                return BadRequest(ex.Message);
            }
        }
    }
}
