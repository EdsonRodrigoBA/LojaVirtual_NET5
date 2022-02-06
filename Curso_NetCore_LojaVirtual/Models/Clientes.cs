using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models
{
    public class Clientes
    {
        public int id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        public String nome { get; set; }
        public String sexo { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        public String cpf { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_02")]

        public String email { get; set; }

        public String telefone { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        public String senha { get; set; }

        [NotMapped]
        [Compare("senha", ErrorMessage = "A senhas devem ser iguais")]
        public String confirmPassword { get; set; }
        public DateTime Nascimento { get; set; }

       
        public String Situacao { get; set; }



    }
}
