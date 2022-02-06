using Curso_NetCore_LojaVirtual.Bibliotecas.Seguranca;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Cookie
{
    public class CookieSistema
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public CookieSistema(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public void Cadastrar(string key, string valor)
        {
            CookieOptions Options = new CookieOptions

            {

                Expires = DateTime.Now.AddDays(7),

                HttpOnly = true,

                IsEssential = true,

                Secure = true,

                SameSite = SameSiteMode.None

            };

            var valorencrypt = StringCipher.Encrypt(valor, _configuration.GetValue<String>("ChaveSiteEncrypt"));
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, valorencrypt, Options);

        }

        public void Atualizar(string key, string valor)
        {
            if (exists(key))
            {
                Remover(key);
            }
            Cadastrar(key, valor);
        }
        public void Remover(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);

        }
        public string consultar(string key, bool cript = true)
        {
            var valor = _httpContextAccessor.HttpContext.Request.Cookies[key];
            if (cript)
            {
                valor = StringCipher.Decrypt(valor, _configuration.GetValue<String>("ChaveSiteEncrypt"));

            }
            return valor;

        }

        public bool exists(string key)
        {
           
            if (_httpContextAccessor.HttpContext.Request.Cookies[key] == null)
            {
                return false;
            }

            return true;

        }

        public void RemoverTodos()
        {
            var listaCookies = _httpContextAccessor.HttpContext.Request.Cookies.ToList();
            foreach (var item in listaCookies)
            {
                Remover(item.Key);
            }
       
        }
    }
}
