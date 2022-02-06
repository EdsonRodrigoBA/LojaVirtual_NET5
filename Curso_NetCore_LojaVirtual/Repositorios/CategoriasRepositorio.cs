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

        public Categoria Get(string slug)
        {
            var Colaborador = _BD.Categorias.FirstOrDefault(x => x.slug == slug);

            return Colaborador;
        }

        public List<Categoria> GetTodos()
        {
            return _BD.Categorias.ToList();
        }

        List<Categoria> categorias;
        private List<Categoria> listCategoria_Recursiva = new List<Categoria>();

        public IEnumerable<Categoria> Get_CategoriasRecursiva(Categoria categoriaPrincipal)
        {
            
            if(categorias == null)
            {
                 categorias = GetTodos();
            }
           


            var listaCategoriaFilho = categorias.Where(x => x.id_categoriapai == categoriaPrincipal.Id);
            if (!listCategoria_Recursiva.Any(x => x.Id == categoriaPrincipal.Id))
            {
                listCategoria_Recursiva.Add(categoriaPrincipal);

            }
            if (categorias.Any(x => x.id_categoriapai == categoriaPrincipal.Id))
            {
                listCategoria_Recursiva.AddRange(listaCategoriaFilho.ToList());
                foreach (var item in listaCategoriaFilho)
                {
                    Get_CategoriasRecursiva( item);
                }
            }

            return listCategoria_Recursiva;
        }

    }
}
