using System.Net;
using System.Net.Mail;
using DotNetEnv;

public class EmailProvider
{

    private string? _emailRemetente { get; set; }
    private string? _senhaRemete { get; set; }
    private MailMessage _mail { get; set; }

    public EmailProvider()
    {
        Env.Load();
        _emailRemetente = Environment.GetEnvironmentVariable("email");
        _senhaRemete = Environment.GetEnvironmentVariable("senha");

        // para testes que não utilizam variáveis de ambiente
        if (_emailRemetente == null)
        {
            _emailRemetente = "desafio.diamante.nicholas@gmail.com";
            _senhaRemete = "desafiodiamante123";
        }

        
        _mail = new MailMessage();

        _mail.From = new MailAddress(_emailRemetente!);
        
    }

    public void EnviarEmail(string emailDestino, string mensagem)
    {
        _mail.To.Add(emailDestino);
        _mail.Subject = "Conteúdo Exibido Desafio Diamantes";
        _mail.Body = mensagem;

        using (var smtp = new SmtpClient("smtp.gmail.com", 587))
        {
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(_emailRemetente, _senhaRemete);

            try
            {
                smtp.Send(_mail);
                Console.WriteLine("Envio bem sucedido");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}