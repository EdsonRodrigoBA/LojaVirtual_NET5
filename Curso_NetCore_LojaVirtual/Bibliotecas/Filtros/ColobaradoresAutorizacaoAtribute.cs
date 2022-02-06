using Curso_NetCore_LojaVirtual.Bibliotecas.Login;
using Curso_NetCore_LojaVirtual.Models.Constantes;
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

        private readonly String _tipoUsuario;
        //Filtro pra verificar se o cliente esta logado.
        LoginColaboradores _loginColaboradores;
        public ColobaradoresAutorizacaoAtribute(String tipoUsuario = TiposColaboradores_Constantes.COMUM)
        {
            this._tipoUsuario = tipoUsuario;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaboradores = (LoginColaboradores)context.HttpContext.RequestServices.GetService(typeof(LoginColaboradores));
            var colaborador = _loginColaboradores.ObterColaborador();


            if (colaborador == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else
            {
                if (colaborador.tipoColaborador == TiposColaboradores_Constantes.COMUM && _tipoUsuario == TiposColaboradores_Constantes.COMUM)
                {
                    context.Result = new ForbidResult();
                }
            }

        }
    }
}
