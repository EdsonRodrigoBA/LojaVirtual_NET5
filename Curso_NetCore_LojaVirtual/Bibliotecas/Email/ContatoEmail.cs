using Curso_NetCore_LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Curso_NetCore_LojaVirtual.Bibliotecas.Email
{
    public class ContatoEmail
    {
        public static void EnviarConatoPorEmail(Contato contato)
        {
            String corpoMensagem = String.Format("<h2>Contato Loja Virtual </h2>" +

                "<b>Nome: {0} </b> <br />" +
                "<b>Email: {1} </b> <br />" +
                "<b>Texto: {2} </b> <br />" ,
                contato.nome,
                contato.email,
                contato.texto

                );


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("edsonrodrigoanalista@gmail.com", "");
            smtpClient.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("edsonrodrigoanalista@gmail.com");
            msg.To.Add("edsonrodrigoanalista@gmail.com");
            msg.Subject = "Contato Curso Loja Virtual";



            msg.IsBodyHtml = true;
            msg.Body = corpoMensagem;
            smtpClient.Send(msg);
        }
    }
}
