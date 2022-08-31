using CadastroGeral.Interfaces;
using System.Net;
using System.Net.Mail;

namespace CadastroGeral.Helper
{
    public class Email : IEmail
    {
        //Buscar configurações de envio
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            //Precisa configurar gmail em duas etapas (SMTP) appsettings.json

            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Name");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Password");
                int porta = _configuration.GetValue<int>("SMTP:Port");

                //Instanciar MailMessage
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome),
                };
                
                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                //Envio
                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }

            }
            catch (Exception)
            {

                //gravar log de erro enviar e-mail
                return false;
            }
        }
    }
}
