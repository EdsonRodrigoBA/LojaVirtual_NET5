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
    public class ColaboradoresRepositorio : IColaboradoresRepositorio
    {

        private readonly LojaVirtualContext _BD;
        private readonly IConfiguration _iconfiguration;
        public ColaboradoresRepositorio(LojaVirtualContext BD, IConfiguration configuration)
        {
            this._BD = BD;
            this._iconfiguration = configuration;
        }
        public void Atualizar(Colaboradores model)
        {
            _BD.Colaboradores.Update(model);
            _BD.Entry(model).Property(x => x.senha).IsModified = false;

            _BD.SaveChanges();
        }

        public void AtualizarSenha(Colaboradores model)
        {
            _BD.Colaboradores.Update(model);
            _BD.Entry(model).Property(x => x.nome).IsModified = false;
            _BD.Entry(model).Property(x => x.tipoColaborador).IsModified = false;
            _BD.Entry(model).Property(x => x.email).IsModified = false;

            _BD.SaveChanges();
        }

        public void Cadastrar(Colaboradores model)
        {
            _BD.Colaboradores.Add(model);
            _BD.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var colaborador = Get(Id);
            _BD.Remove(colaborador);
            _BD.SaveChanges();
        }

        public Colaboradores Get(int id)
        {
            var Colaborador = _BD.Colaboradores.Find(id);

            return Colaborador;
        }

        public List<Colaboradores> Get()
        {
            return _BD.Colaboradores.ToList();
        }

        public IPagedList<Colaboradores> Get(int? pagina)
        {
            int numeroPagina = pagina ?? 1;

            return _BD.Colaboradores.ToPagedList(numeroPagina, _iconfiguration.GetValue<int>("Numero_RegisroPaginacao"));
        }

        public List<Colaboradores> Get_Por_Email(string email)
        {
            return _BD.Colaboradores.AsNoTracking().Where(x => x.email == email).ToList();
        }

        public Colaboradores Login(string email, string senha)
        {
            var usuario = _BD.Colaboradores.Where(x => x.email.ToUpper() == email.ToUpper() & x.senha == senha).FirstOrDefault();
            return usuario;
        }
    }
}
