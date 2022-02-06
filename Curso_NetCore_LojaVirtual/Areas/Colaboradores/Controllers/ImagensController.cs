using Curso_NetCore_LojaVirtual.Bibliotecas.Arquivos;
using Curso_NetCore_LojaVirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Areas.Colaboradores.Controllers
{
    [Area("Colaboradores")]
    public class ImagensController : Controller
    {
        [HttpPost]
        public IActionResult CadastrarImagem(IFormFile file)
        {
            Thread.Sleep(5000);

            var imagem = GerenciadorArquivos.CadastrarImagemProduto(file);

            if (imagem.Length > 0)
            {

                return Ok(new { caminho = imagem });

            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        public IActionResult Deletar(string path)
        {
            var result = GerenciadorArquivos.ExcluirImagemProduto(path);
            if (result)
            {
                return Ok();
            }
            else
            {
                return  BadRequest();
            }

        }
    }
}
