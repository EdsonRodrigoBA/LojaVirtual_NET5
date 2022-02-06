using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Models
{
    public class ValorPrazoFrete
    {
        public decimal valor { get; set; }
        public int prazo { get; set; }
        public String tipofrete { get; set; }
        public String codigo_tipofrete { get; set; }

    }
}
