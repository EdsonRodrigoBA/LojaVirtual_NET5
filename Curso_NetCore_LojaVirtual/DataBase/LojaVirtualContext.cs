using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.DataBase
{
    public class LojaVirtualContext : DbContext
    {
        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Clientes> clientes { get; set; }
        public DbSet<NewsLettersEmail> NewsLettersEmail { get; set; }
        public DbSet<Colaboradores> Colaboradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Imagens> Imagens { get; set; }





    }
}
