using Curso_NetCore_LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Email
{
    public class GerenciarEnvioEmails
    {
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _iconfiguration;
        public GerenciarEnvioEmails(SmtpClient smtpClient, IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _iconfiguration = configuration;
        }


        public  void EnviarConatoPorEmail(Contato contato)
        {
            String corpoMensagem = String.Format("<h2>Contato Loja Virtual </h2>" +

                "<b>Nome: {0} </b> <br />" +
                "<b>Email: {1} </b> <br />" +
                "<b>Texto: {2} </b> <br />" ,
                contato.nome,
                contato.email,
                contato.texto

                );
 
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_iconfiguration.GetValue<String>("Email:usuario"));
            msg.To.Add("edsonrodrigoanalista@gmail.com");
            msg.Subject = "Contato Curso Loja Virtual";
            msg.IsBodyHtml = true;
            msg.Body = corpoMensagem;
            _smtpClient.Send(msg);
        }



        public void EnviarSenhaColaboradorPorEmail(Colaboradores colaboradores)
        {
            String corpoMensagem = String.Format("<h2>Colaborado Loja Virtual </h2>" +

                "<h3>Sua Senha de Acesso ao Portal Administrativo é:</h3> <br />" +
                 "<h3 " + "style=color: red" + ">Senha:  {0} </h3>" +
                "<h3>Para sua Segurança!.Recomendamos que altere sua Senha ao Efetuar o Login</h3> <br />" ,

                colaboradores.senha

                );

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_iconfiguration.GetValue<String>("Email:usuario"));
            msg.To.Add(colaboradores.email);
            msg.Subject = "Acesso Colaborador - Loja Virtual" + colaboradores.nome;
            msg.IsBodyHtml = true;
            msg.Body = corpoMensagem;
            _smtpClient.Send(msg);
        }
    }
}
