using Curso_NetCore_LojaVirtual.Bibliotecas.Lang;
using Curso_NetCore_LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador
{
    public class Produtos
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        [JsonIgnore]
        public String nome { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public String descricao { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public decimal valor { get; set; }
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]

        [JsonIgnore]
        public int quantidade { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public decimal peso { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public decimal largura { get; set; }


        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public decimal altura { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public decimal comprimento { get; set; }

        [ForeignKey("categoria_id")]
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }


      
        [Required(ErrorMessageResourceType = typeof(Mensagens), ErrorMessageResourceName = "MSG_ERROR_01")]
        [JsonIgnore]
        public int categoria_id { get; set; }


        [JsonIgnore]
        public virtual ICollection<Imagens> Imagens { get; set; }
    }
}
