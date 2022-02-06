using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models
{
    public class Imagens
    {
        public int Id { get; set; }

        public String caminho { get; set; }
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produtos Produtos { get; set; }
    }
}
