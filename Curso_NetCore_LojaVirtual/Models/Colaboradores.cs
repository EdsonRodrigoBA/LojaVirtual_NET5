using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models
{
    public class Colaboradores
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        public String nome { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        public String email { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        public String senha { get; set; }

        [NotMapped]
       [Compare("senha",ErrorMessage ="A senhas devem ser iguais")]
        public String confirmPassword { get; set; }
        public String tipoColaborador { get; set; }
    }
}
