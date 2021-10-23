using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LojaVirtualContext _BD;
        public ClienteRepositorio(LojaVirtualContext BD)
        {
            this._BD = BD;
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

        public List<Clientes> Get()
        {
            return _BD.clientes.ToList();
        }

        public Clientes Login(string email, string senha)
        {
            var usuario = _BD.clientes.Where(x => x.email.ToUpper() == email.ToUpper() & x.senha == senha).FirstOrDefault();
            return usuario;
        }
    }
}
