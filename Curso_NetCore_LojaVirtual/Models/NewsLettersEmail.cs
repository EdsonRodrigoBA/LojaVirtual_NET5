using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models
{
    public class NewsLettersEmail
    {
        public int id { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]


        [EmailAddress(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_02")]
        public String email { get; set; }
    }
}
