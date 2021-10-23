using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Filtros
{
    public class ColobaradoresAutorizacaoAtribute : Attribute, IAuthorizationFilter
    {

        //Filtro pra verificar se o cliente esta logado.
        LoginColaboradores _loginColaboradores;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaboradores = (LoginColaboradores)context.HttpContext.RequestServices.GetService(typeof(LoginColaboradores));
            var cliente = _loginColaboradores.ObterColaborador();


            if (cliente == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
       
        }
    }
}
