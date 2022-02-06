using AutoMapper;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.AutoMapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Produtos, ProdutosItem>();
        }
    }
}
