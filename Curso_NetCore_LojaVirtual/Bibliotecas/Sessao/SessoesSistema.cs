using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Sessao
{
    public class SessoesSistema
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessoesSistema(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Cadastrar(string key, string valor)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, valor);
        }

        public void Atualizar(string key, string valor)
        {
            if (exists(key))
            {
                _httpContextAccessor.HttpContext.Session.Remove(key);
            }
            _httpContextAccessor.HttpContext.Session.SetString(key, valor);
        }
        public void Remover(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);

        }
        public string consultar(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);

        }

        public bool exists(string key)
        {
            var exists = _httpContextAccessor.HttpContext.Session.GetString(key);
            if (exists == null)
            {
                return false;
            }

            return true;

        }

        public void RemoverTodo()
        {
             _httpContextAccessor.HttpContext.Session.Clear();
        }
    }
}
