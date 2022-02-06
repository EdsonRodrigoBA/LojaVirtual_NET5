using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Repositorios.Contratos
{
    public interface IImagensRepositorio
    {
        void Cadastrar(Imagens model);

        void Excluir(int Id);

        void ExcluirImagensdoProduto(int ProdutoId);
        void CadastrarImagem(List<Imagens> imagens);
    }
}
