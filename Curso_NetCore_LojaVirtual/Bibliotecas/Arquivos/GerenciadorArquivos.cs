using Curso_NetCore_LojaVirtual.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Arquivos
{
    public class GerenciadorArquivos
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            var nomeArquivo = Path.GetFileName(file.FileName);
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\Temp_ImgProduto\\", nomeArquivo);
            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine("/uploads/Temp_ImgProduto/", nomeArquivo);
        }

        public static bool ExcluirImagemProduto(String path)
        {
            var diretorioPadroao = Directory.GetCurrentDirectory() + "\\";
            var caminho = diretorioPadroao + "wwwroot\\" + path.TrimStart('/').Replace("/", "\\");
            if (File.Exists(caminho))
            {
                File.Delete(caminho);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static List<Imagens> MoverImagensProduto(List<string> lista_caminhoImagens, int produtoId)
        {

            String diretorioPadrao = Directory.GetCurrentDirectory();
            List<Imagens> imagenssalvas = new List<Imagens>();
            var caminhoPastaPadrao = Path.Combine(diretorioPadrao, "wwwroot\\uploads\\img_produtos");

            if (!Directory.Exists(caminhoPastaPadrao))
            {
                Directory.CreateDirectory(caminhoPastaPadrao);
            }
            var caminhoPastaProduto = Path.Combine(diretorioPadrao, "wwwroot\\uploads\\img_produtos\\", produtoId.ToString());
            if (!Directory.Exists(caminhoPastaProduto))
            {
                Directory.CreateDirectory(caminhoPastaProduto);
            }

            //validação pra atualizar produto.


            foreach (var caminho_temporario in lista_caminhoImagens)
            {
                if (!String.IsNullOrEmpty(caminho_temporario))
                {


                    var nomearquivo = Path.GetFileName(caminho_temporario);
                    var caminho_form = caminho_temporario.Replace("/", "\\");

                    var caminhoabsoluto_Temp = diretorioPadrao + "\\wwwroot\\" + caminho_form;
                    var caminhoabsoluto = caminhoPastaProduto + $"\\{nomearquivo}";

                    var caminho_definitivo_verificaralteracao = $"/uploads/img_produtos/{produtoId.ToString()}/{nomearquivo}";
                    //var caminho_temp_verificaralteracao = $"/uploads/Temp_ImgProduto/{nomearquivo}";

                    if (caminho_definitivo_verificaralteracao != caminho_temporario)
                    {
                        if (File.Exists(caminhoabsoluto_Temp.Replace("\\\\", "\\")))
                        {
                            //se existir a imagem apagar no destino
                            if (File.Exists(caminhoabsoluto))
                            {
                                File.Delete(caminhoabsoluto);
                            }

                            File.Copy(caminhoabsoluto_Temp, caminhoabsoluto);
                            if (File.Exists(caminhoabsoluto))
                            {
                                File.Delete(caminhoabsoluto_Temp);
                            }

                            String caminhoRetorno = $"/uploads/img_produtos/{ produtoId.ToString()}/{nomearquivo}";

                            imagenssalvas.Add(new Imagens()
                            {

                                caminho = caminhoRetorno.Replace("\\", "/"),
                                ProdutoId = produtoId

                            });
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        String caminhoRetorno = $"/uploads/img_produtos/{ produtoId.ToString()}/{nomearquivo}";

                        imagenssalvas.Add(new Imagens()
                        {

                            caminho = caminhoRetorno.Replace("\\", "/"),
                            ProdutoId = produtoId

                        });
                    }

                }
            }
            return imagenssalvas;
        }
    }
}
