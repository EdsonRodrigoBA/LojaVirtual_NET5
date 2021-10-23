using Curso_NetCore_LojaVirtual.Bibliotecas.Sessao;
using Curso_NetCore_LojaVirtual.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Login
{
    public class LoginColaboradores
    {
        private string string_key = "login.colaboradores";
        private readonly SessoesSistema _sessao;
        public LoginColaboradores(SessoesSistema sessoesSistema)
        {
            _sessao = sessoesSistema;
        }

        public void Login(Colaboradores Colaboradores)
        {
            String Colaboradorestring = JsonConvert.SerializeObject(Colaboradores);
            _sessao.Cadastrar(string_key, Colaboradorestring);
        }

        public Colaboradores ObterColaborador()
        {
            if (_sessao.exists(string_key))
            {


                var Colaboradorestring = _sessao.consultar(string_key);
                return JsonConvert.DeserializeObject<Colaboradores>(Colaboradorestring);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _sessao.Remover(string_key);
        }
    }
}
