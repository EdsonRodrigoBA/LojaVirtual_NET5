using Curso_NetCore_LojaVirtual.Bibliotecas.ProdutoAgregador;
using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Gerenciador.Frete
{
    public class CalcularPacote
    {
        public List<Pacote> CalcularPacote_Produtos(List<ProdutosItem> produtos)
        {
            List<Pacote> pacotes = new List<Pacote>();
            Pacote pacote = new Pacote();


            foreach (var item in produtos)
            {

                for (int i = 0; i < item.quantidade_carrinho; i++)
                {

                    var peso = pacote.peso + item.peso;
                    var comprimento = (pacote.comprimentro > item.comprimento) ? pacote.comprimentro : item.comprimento;
                    var largura = (pacote.largura > item.largura) ? pacote.largura : item.largura;
                    var altura = pacote.altura + item.altura;
                    var dimensao = comprimento + altura + largura;

                    if (peso > 30 || dimensao > 200 || altura > 105 || comprimento > 105 || largura > 105)
                    {
                        pacotes.Add(pacote);
                        pacote = new Pacote();


                    }

                    pacote.peso = pacote.peso + item.peso;
                    pacote.comprimentro = (pacote.comprimentro > item.comprimento) ? pacote.comprimentro : item.comprimento;
                    pacote.largura = (pacote.largura > item.largura) ? pacote.largura : item.largura;
                    pacote.altura = pacote.altura + item.altura;
                }
            
            }

            pacotes.Add(pacote);
            return pacotes;

        }
    }
}
