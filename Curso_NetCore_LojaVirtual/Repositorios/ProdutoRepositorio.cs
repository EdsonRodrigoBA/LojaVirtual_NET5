using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Curso_NetCore_LojaVirtual.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios
{
    public class ProdutoRepositorio : IprodutosRepositorio
    {

        private readonly LojaVirtualContext _BD;
        private readonly IConfiguration _iconfiguration;
        public ProdutoRepositorio(LojaVirtualContext BD, IConfiguration configuration)
        {
            this._BD = BD;
            this._iconfiguration = configuration;
        }
        public void Atualizar(Produtos model)
        {
            _BD.Produtos.Update(model);

            _BD.SaveChanges();
        }



        public void Cadastrar(Produtos model)
        {
            _BD.Produtos.Add(model);
            _BD.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var produto = Get(Id);
            _BD.Remove(produto);
            _BD.SaveChanges();
        }

        public Produtos Get(int id)
        {
            var produtos = _BD.Produtos.Include(x => x.Imagens).FirstOrDefault(x => x.Id == id);

            return produtos;
        }

        public List<Produtos> Get()
        {
            return _BD.Produtos.ToList();
        }

        public IPagedList<Produtos> Get(int? pagina, String pesquisa)
        {
            return Get_Paginacao_Ordencacao(pagina, pesquisa, "A", null);

        }

        public IPagedList<Produtos> Get_Paginacao_Ordencacao(int? pagina, string pesquisa, string ordenacao, List<Categoria> categorias)
        {
            int numeroPagina = pagina ?? 1;
            var listaprodutos = _BD.Produtos.AsQueryable();
            if (!String.IsNullOrEmpty(pesquisa))
            {
                listaprodutos = _BD.Produtos.Where(
                         x => x.nome.Trim().ToUpper().Contains(pesquisa.ToUpper().Trim())
                        );
            }
            if (ordenacao == "A")
            {
                listaprodutos = listaprodutos.OrderBy(x => x.nome);
            }
            if (ordenacao == "ME")
            {
                listaprodutos = listaprodutos.OrderBy(x => x.valor);

            }
            if (ordenacao == "MA")
            {
                listaprodutos = listaprodutos.OrderByDescending(x => x.valor);

            }
            //return listaprodutos.ToPagedList(numeroPagina, _iconfiguration.GetValue<int>("Numero_RegisroPaginacao"));

            if (categorias != null)
            {
                if (categorias.Count > 0)
                {


                    listaprodutos = listaprodutos.Where(x => categorias.Select(a => a.Id).Contains(x.categoria_id));
                }
            }

            return listaprodutos.Include(x => x.Imagens).ToPagedList(numeroPagina, _iconfiguration.GetValue<int>("Numero_RegisroPaginacao"));
        }
    }
}
