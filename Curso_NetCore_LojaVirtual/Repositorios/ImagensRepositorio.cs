using Curso_NetCore_LojaVirtual.DataBase;
using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Repositorios.Contratos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Repositorios
{
    public class ImagensRepositorio : IImagensRepositorio
    {
        private readonly LojaVirtualContext _BD;
        public ImagensRepositorio(LojaVirtualContext BD)
        {
            this._BD = BD;
       
        }

        public void Cadastrar(Imagens model)
        {
            _BD.Imagens.Add(model);

            _BD.SaveChanges();
        }
        public void CadastrarImagem(List<Imagens> imagens)
        {
            if(imagens != null )
            {
                if(imagens.Count > 0)
                {
                    foreach (var img in imagens)
                    {


                        Cadastrar(img);

                    }
                }

            }

        }

        public void Excluir(int Id)
        {
            var imagem = _BD.Imagens.Find(Id);
            _BD.Remove(imagem);
            _BD.SaveChanges();
        }

        public void ExcluirImagensdoProduto(int ProdutoId)
        {
            var imagens = _BD.Imagens.Where(x => x.ProdutoId == ProdutoId).ToList();            
            _BD.RemoveRange(imagens);
            _BD.SaveChanges();
        }
    }
}
