using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios.Contratos
{
    public interface IColaboradoresRepositorio
    {

        Colaboradores Login(String email, String senha);
        void Cadastrar(Colaboradores model);
        void Atualizar(Colaboradores model);
        void AtualizarSenha(Colaboradores model);


        void Excluir(int Id);

        Colaboradores Get(int id);

        List<Colaboradores> Get();
        List<Colaboradores> Get_Por_Email(String email);

        IPagedList<Colaboradores> Get(int? pagina);

    }
}
