using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Repositorios.Contratos
{
    public interface INewsLettersRepositorio
    {
        void Cadastrar(NewsLettersEmail model);

        List<NewsLettersEmail> Get();

    }
}
