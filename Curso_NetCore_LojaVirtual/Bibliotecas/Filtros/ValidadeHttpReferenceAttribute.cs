using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Filtros
{
    public class ValidadeHttpReferenceAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            String Referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (String.IsNullOrEmpty(Referer))
            {
                context.Result = new ContentResult() { Content = $"Acesso Negado." };

            }
            else
            {
                Uri uri = new Uri(Referer);
                String hostReferer = uri.Host;
                String host_servidor = context.HttpContext.Request.Host.Host;

                if(hostReferer != host_servidor)
                {
                    context.Result = new ContentResult() { Content = $"Acesso Negado." };

                }

            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }


    }
}
