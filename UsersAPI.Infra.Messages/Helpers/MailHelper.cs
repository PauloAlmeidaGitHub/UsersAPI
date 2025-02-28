using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Infra.Messages.Models;

namespace UsersAPI.Infra.Messages.Helpers
{
    /// <summary>
    /// Classe auxiliar para fazermos os envios de email
    /// </summary>
    public class MailHelper
    {
        #region Atributos

        private readonly string _host = "localhost";
        private readonly int _port = 1025;
        private readonly string _from = "noreply@example.com";

        #endregion

        public void SendMail(RegisteredUser user)
        {
            // Escrevendo o assunto do e-mail
            var subject = "🎉 Sua conta foi criada com sucesso - COTI Informática";

            // Escrevendo o corpo do e-mail
            var body = @$"
                <div style='font-family: Verdana, sans-serif; background-color: #f4f4f4; padding: 20px; text-align: center;'>
                    <div style='max-width: 600px; background-color: #ffffff; padding: 20px; border-radius: 8px; margin: auto; box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);'>
                        <img src='https://www.gestaoemmolduras.com.br/Images/logo-1.png' 
                                alt='COTI Informática' 
                                style='max-width: 200px; margin-bottom: 20px;' />

                        <h2 style='color: #333;'>Olá {user.Name},</h2>
                        <p style='font-size: 16px; color: #666;'>Sua conta foi criada com sucesso! 🎉</p>

                        <div style='background-color: #f0f0f0; padding: 15px; border-radius: 5px; margin: 20px 0;'>
                            <p style='font-size: 16px; color: #333;'><strong>Seja bem-vindo ao sistema COTI Informática!</strong></p>
                            <p style='font-size: 14px; color: #555;'>O seu perfil de acesso é <strong>{user.Role}</strong>.</p>
                        </div>

                        <p style='font-size: 14px; color: #777;'>Se precisar de ajuda, entre em contato com nosso suporte.</p>

                        <hr style='border: none; border-top: 1px solid #ddd; margin: 20px 0;' />

                        <p style='font-size: 12px; color: #999;'>Atenciosamente,</p>
                        <p style='font-size: 14px; font-weight: bold; color: #333;'>Equipe COTI Informática</p>
                    </div>
                </div>";


            //Criando o objeto que fará o envio dos emails
            var smtpClient = new SmtpClient(_host, _port) { EnableSsl = false };

            //Configurando o remetente, destinatário, assunto e corpo da mensagem
            var mailMessage = new MailMessage(_from, user.Email, subject, body);

            //Configurando o corpo da mensagem para HTML
            mailMessage.IsBodyHtml = true;

            //enviando a mensagem
            smtpClient.Send(mailMessage);
        }
    }
}




/*
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sua Mensagem Melhorada</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            color: #333;
            margin: 0;
            padding: 0;
            text-align: center;
        }
        .container {
            padding: 20px;
            max-width: 800px;
            margin: 0 auto;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .logo {
            text-align: center;
            margin-bottom: 20px;
        }
        .logo img {
            max-width: 150px;
        }
        h1 {
            color: #007b5e;
            font-size: 2em;
            margin-bottom: 20px;
        }
        p {
            font-size: 1.1em;
            line-height: 1.6;
            margin-bottom: 20px;
        }
        .button {
            display: inline-block;
            padding: 10px 20px;
            font-size: 1em;
            color: #fff;
            background-color: #007b5e;
            text-decoration: none;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }
        .button:hover {
            background-color: #005f46;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="logo">
            <img src="https://www.gestaoemmolduras.com.br/Images/logo-1.png" alt="Logo">
        </div>
        <h1>Sua Mensagem Melhorada</h1>
        <p>Este é um exemplo de como você pode melhorar o conteúdo da sua mensagem utilizando estilos CSS. Você pode personalizar as cores, fontes e o layout conforme suas necessidades.</p>
        <a href="#" class="button">Clique Aqui</a>
    </div>
</body>
</html>
 
*/
