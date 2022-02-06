using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios.Contratos
{
    public interface IprodutosRepositorio
    {
        void Cadastrar(Produtos model);
        void Atualizar(Produtos model);

        void Excluir(int Id);

        Produtos Get(int id);

        IPagedList<Produtos> Get(int? pagina, String pesquisa);
        IPagedList<Produtos> Get_Paginacao_Ordencacao(int? pagina, String pesquisa, String ordenacao, List<Categoria> categorias);
    }
}
