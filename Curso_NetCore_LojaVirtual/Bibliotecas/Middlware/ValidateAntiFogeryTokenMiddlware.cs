using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Middlware
{
    public class ValidateAntiFogeryTokenMiddlware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;

        public ValidateAntiFogeryTokenMiddlware(RequestDelegate next, IAntiforgery antiforgery)
        {
            this._antiforgery = antiforgery;
            this._next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var cabecalho = httpContext.Request.Headers["x-requested-with"];
            bool ajax = (cabecalho == "XMLHttpRequest") ? true : false;
            int iCountArquivos = 0;

            if (HttpMethods.IsPost(httpContext.Request.Method))
            {
                if (httpContext.Request.Form != null)
                {
                    if (httpContext.Request.Form.Files.Count > 0)
                    {
                        iCountArquivos = 1;
                    }

                }
                if (!(iCountArquivos == 1 && ajax))
                {
                    await _antiforgery.ValidateRequestAsync(httpContext);
                }
                    

                
            }

            await _next(httpContext);
        }
    }
}
