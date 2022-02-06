using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Curso_NetCore_LojaVirtual.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LojaVirtualContext _BD;
        private readonly IConfiguration _iconfiguration;
        public ClienteRepositorio(LojaVirtualContext BD, IConfiguration configuration)
        {
            this._BD = BD;
            this._iconfiguration = configuration;
        }
        public void Atualizar(Clientes clientes)
        {
            _BD.clientes.Update(clientes);
            _BD.SaveChanges();
        }

        public void Cadastrar(Clientes clientes)
        {
            _BD.clientes.Add(clientes);
            _BD.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var cliente = Get(Id);
            _BD.Remove(cliente);
            _BD.SaveChanges();
        }

        public Clientes Get(int id)
        {
            var cliente = _BD.clientes.Find(id);

            return cliente;
        }

        public IPagedList<Clientes> Get(int? pagina, String pesquisa)
        {
            int numeroPagina = pagina ?? 1;
            if (String.IsNullOrEmpty(pesquisa))
            {
                return _BD.clientes.ToPagedList(numeroPagina, _iconfiguration.GetValue<int>("Numero_RegisroPaginacao"));

            }
            return _BD.clientes.Where(
                         x => x.nome.Trim().ToUpper().Contains(pesquisa.ToUpper().Trim()) ||
                         x.email.Trim().ToUpper().Contains(pesquisa.ToUpper().Trim())
                        ).ToPagedList(numeroPagina, _iconfiguration.GetValue<int>("Numero_RegisroPaginacao"));

        }

        public Clientes Login(string email, string senha)
        {
            var usuario = _BD.clientes.Where(x => x.email.ToUpper() == email.ToUpper() & x.senha == senha).FirstOrDefault();
            return usuario;
        }
    }
}
