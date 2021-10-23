using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Filtros
{
    public class ClienteAutorizacaoAtribute : Attribute, IAuthorizationFilter
    {

        //Filtro pra verificar se o cliente esta logado.
        LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            var cliente = _loginCliente.ObterCliente();


            if (cliente == null)
            {
                context.Result = new ContentResult() { Content = $"Acesso Negado." };
            }
       
        }
    }
}
