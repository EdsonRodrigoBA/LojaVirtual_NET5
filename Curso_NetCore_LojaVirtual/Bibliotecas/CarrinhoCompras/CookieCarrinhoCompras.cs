using Curso_NetCore_LojaVirtual.Bibliotecas.Cookie;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.CarrinhoCompras
{
    public class CookieCarrinhoCompras
    {
        private string string_key = "carrinhoteste.compras";

        private readonly CookieSistema _cookieSistema;

        public CookieCarrinhoCompras(CookieSistema cookieSistema)
        {
            _cookieSistema = cookieSistema;
        }

        public void Cadastrar(ProdutosItem item)
        {
            List<ProdutosItem> lista;
            if (_cookieSistema.exists(string_key))
            {
                lista = Consultar();
                var itemlocalizado = lista.SingleOrDefault(x => x.Id == item.Id);
                if (itemlocalizado == null)
                {
                    lista.Add(item);

                }
                else
                {
                    itemlocalizado.quantidade_carrinho = itemlocalizado.quantidade_carrinho + 1;
                }
            }
            else
            {
                lista = new List<ProdutosItem>();
                lista.Add(item);
            }

            Salvar(lista);
        }



        public void Atualizar(ProdutosItem item)
        {
            var itens_Carrinho = Consultar();
            var itemlocalizado = itens_Carrinho.SingleOrDefault(x => x.Id == item.Id);

            if (itemlocalizado != null)
            {
                itemlocalizado.quantidade_carrinho = item.quantidade_carrinho;
                Salvar(itens_Carrinho);
            }

        }
        public List<ProdutosItem> Consultar()
        {
            if (_cookieSistema.exists(string_key))
            {
                var valor = _cookieSistema.consultar(string_key);

                return JsonConvert.DeserializeObject<List<ProdutosItem>>(valor);

            }
            else
            {
                return new List<ProdutosItem>();
            }
        }

        public void Remover(ProdutosItem item)
        {
            var itens_Carrinho = Consultar();
            var itemlocalizado = itens_Carrinho.SingleOrDefault(x => x.Id == item.Id);

            if (itemlocalizado != null)
            {
                itens_Carrinho.Remove(itemlocalizado);
                Salvar(itens_Carrinho);

            }
        }

        public void RemoverTodos()
        {
            _cookieSistema.Remover(string_key);
        }

        public bool Exists()
        {
            if (!_cookieSistema.exists(string_key))
            {
                return false;
            }

            return false;
        }

        private void Salvar(List<ProdutosItem> lista)
        {
            var lista_salvar = JsonConvert.SerializeObject(lista);
            _cookieSistema.Cadastrar(string_key, lista_salvar);
        }
    }

}
