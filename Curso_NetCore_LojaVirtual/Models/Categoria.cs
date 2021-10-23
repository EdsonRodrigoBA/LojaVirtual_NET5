using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        public String nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        public String slug { get; set; }

        [Display(Name ="Categoria Pai")]
        public int ? id_categoriapai { get; set; }

        [ForeignKey("id_categoriapai")]
        public virtual Categoria CategoriaPai { get; set; }
    }
}
