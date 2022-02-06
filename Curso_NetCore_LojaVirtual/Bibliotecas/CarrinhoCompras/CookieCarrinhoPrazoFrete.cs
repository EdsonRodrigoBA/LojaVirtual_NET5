using Curso_NetCore_LojaVirtual.Bibliotecas.Cookie;
using Curso_NetCore_LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.CarrinhoCompras
{
    public class CookieCarrinhoPrazoFrete
    {
        private string string_key = "carrinho.compras.PrazoFrete";

        private readonly CookieSistema _cookieSistema;

        public CookieCarrinhoPrazoFrete(CookieSistema cookieSistema)
        {
            _cookieSistema = cookieSistema;
        }

        public void Cadastrar(List<ValorPrazoFrete> lista)
        {
            var lista_salvar = JsonConvert.SerializeObject(lista);
            _cookieSistema.Cadastrar(string_key, lista_salvar);
        }

        public List<ValorPrazoFrete> Consultar()
        {
            if (_cookieSistema.exists(string_key))
            {
                var valor = _cookieSistema.consultar(string_key);

                return JsonConvert.DeserializeObject<List<ValorPrazoFrete>>(valor);

            }
            else
            {
                return null;
            }
        }
        public void Remover()
        {
            _cookieSistema.Remover(string_key);
        }

    }
}
