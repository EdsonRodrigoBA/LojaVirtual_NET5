using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios.Contratos
{
    public interface IClienteRepositorio
    {
        Clientes Login(String email, String senha);
        void Cadastrar(Clientes clientes);
        void Atualizar(Clientes clientes);

        void Excluir(int Id);

        Clientes Get(int id);

        IPagedList<Clientes> Get(int ? pagina, String pesquisa);

    }
}
