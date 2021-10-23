using Curso_NetCore_LojaVirtual.Bibliotecas.Sessao;
using Curso_NetCore_LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Login
{
    public class LoginCliente
    {
        private string string_key = "login.cliente";
        private readonly SessoesSistema _sessao;
        public LoginCliente(SessoesSistema sessoesSistema)
        {
            _sessao = sessoesSistema;
        }

        public void Login(Clientes clientes)
        {
            String clienteString = JsonConvert.SerializeObject(clientes);
            _sessao.Cadastrar(string_key, clienteString);
        }

        public Clientes ObterCliente()
        {
            if (_sessao.exists(string_key))
            {


                var clienteString = _sessao.consultar(string_key);
                return JsonConvert.DeserializeObject<Clientes>(clienteString);
            }
            else
            {
                return null;
            }
        }

        public void Logout(Clientes clientes)
        {
            _sessao.Remover(string_key);
        }
    }
}
