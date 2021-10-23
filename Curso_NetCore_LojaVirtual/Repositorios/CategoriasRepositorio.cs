using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios
{
    public class CategoriasRepositorio : ICategoriaRepositorio
    {
        private readonly LojaVirtualContext _BD;
        private readonly IConfiguration _iconfiguration;

        public CategoriasRepositorio(LojaVirtualContext BD, IConfiguration configuration)
        {
            this._BD = BD;
            this._iconfiguration = configuration;

        }
        public void Atualizar(Categoria model)
        {
            _BD.Categorias.Update(model);
            _BD.SaveChanges();
        }

        public void Cadastrar(Categoria model)
        {
            _BD.Categorias.Add(model);
            _BD.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var colaborador = Get(Id);
            _BD.Remove(colaborador);
            _BD.SaveChanges();
        }

        public Categoria Get(int id)
        {
            var Colaborador = _BD.Categorias.Find(id);

            return Colaborador;
        }

        public IPagedList<Categoria> Get(int? pagina)
        {
            int numeroPagina = pagina ?? 1;

            return _BD.Categorias.Include(x => x.CategoriaPai).ToPagedList(numeroPagina, _iconfiguration.GetValue<int>("Numero_RegisroPaginacao"));
        }

        public List<Categoria> GetTodos()
        {
            return _BD.Categorias.ToList();
        }
    }
}
