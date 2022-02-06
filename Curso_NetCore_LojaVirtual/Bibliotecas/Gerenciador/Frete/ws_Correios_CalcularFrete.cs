using Curso_NetCore_LojaVirtual.Models;
using Curso_NetCore_LojaVirtual.Models.Constantes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ws_Correios;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Gerenciador.Frete
{
    public class ws_Correios_CalcularFrete
    {

        private readonly IConfiguration _configuration;

        private readonly CalcPrecoPrazoWSSoap _ws_correrio_CalcPrecoPrazoWSSoap;


        public ws_Correios_CalcularFrete(IConfiguration configuration, CalcPrecoPrazoWSSoap ws_correrio_CalcPrecoPrazoWSSoap)
        {
            _configuration = configuration;
            _ws_correrio_CalcPrecoPrazoWSSoap = ws_correrio_CalcPrecoPrazoWSSoap;
        }

        public async Task<ValorPrazoFrete> CalcularFrete(string cepDestino, string tipofrete, List<Pacote> pacotes)
        {
            List<ValorPrazoFrete> valorPacotesPorFrete = new List<ValorPrazoFrete>();

            foreach (var pacote in pacotes)
            {
                var result = await CalcularValorPrazoFreteAsync(cepDestino, tipofrete, pacote);
                if (result != null)
                {
                    valorPacotesPorFrete.Add(result);

                }

            }

            if (valorPacotesPorFrete.Count > 0)
            {
                ValorPrazoFrete valorFretes = valorPacotesPorFrete.GroupBy(x => x.tipofrete)
                                    .Select(list => new ValorPrazoFrete
                                    {
                                        tipofrete = list.First().tipofrete,
                                        codigo_tipofrete = list.First().codigo_tipofrete,
                                        prazo = list.Max(x => x.prazo),
                                        valor = list.Sum(x => x.valor)
                                    }).FirstOrDefault();
                return valorFretes;
            }
            else
            {
                return null;
            }


           
        }
        private async Task<ValorPrazoFrete> CalcularValorPrazoFreteAsync(string cepDestino, string tipofrete, Pacote pacote)
        {
            var cep_origem = _configuration.GetValue<String>("Frete:cep_origem");
            var maopropria = _configuration.GetValue<String>("Frete:maopropria");
            var valordeclarado = _configuration.GetValue<decimal>("Frete:valordeclarado");
            var AvisoRecebimento = _configuration.GetValue<String>("Frete:AvisoRecebimento");
            var diametro = Math.Max(Math.Max(pacote.comprimentro, pacote.largura), pacote.altura);
            var result = await _ws_correrio_CalcPrecoPrazoWSSoap.CalcPrecoPrazoAsync("", "", tipofrete, cep_origem, cepDestino, pacote.peso.ToString(), 1, pacote.comprimentro,
                pacote.altura, pacote.largura, diametro, maopropria, valordeclarado, AvisoRecebimento);
            if (result.Servicos[0].Erro == "0")
            {
                //tudo certo
                var valorlimpo = result.Servicos[0].Valor;
                var valorfinal = Convert.ToDecimal(result.Servicos[0].Valor.Replace(".", ""));
                ValorPrazoFrete valorPrazoFrete = new ValorPrazoFrete()
                {
                    tipofrete = TipoFreteCorreioConstantes.GetName( tipofrete),
                    codigo_tipofrete = tipofrete,
                    prazo = Convert.ToInt32(result.Servicos[0].PrazoEntrega),
                    valor = Convert.ToDecimal(result.Servicos[0].Valor.Replace(".", ""))
                };

                return valorPrazoFrete;
            }
            else if (result.Servicos[0].Erro == "008" && result.Servicos[0].Erro == "-888")
            {
                return null;
            }
            else
            {
                throw new Exception("Erro: " + result.Servicos[0].MsgErro);
            }
        }
    }
}
