using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Repositorios
{
    public class NewsLettersRepositorio : INewsLettersRepositorio
    {
        private readonly LojaVirtualContext _BD;
        public NewsLettersRepositorio(LojaVirtualContext BD)
        {
            this._BD = BD;
        }
        public void Cadastrar(NewsLettersEmail model)
        {
            _BD.NewsLettersEmail.Add(model);
            _BD.SaveChanges();
        }

        public List<NewsLettersEmail> Get()
        {
            return _BD.NewsLettersEmail.ToList();
        }
    }
}
