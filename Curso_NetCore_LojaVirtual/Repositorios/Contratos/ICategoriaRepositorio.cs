using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios.Contratos
{
    public interface ICategoriaRepositorio
    {

        void Cadastrar(Categoria model);
        void Atualizar(Categoria model);

        void Excluir(int Id);

        Categoria Get(int id);
        List<Categoria> GetTodos();

        IPagedList<Categoria> Get(int? pagina);
    }
}
