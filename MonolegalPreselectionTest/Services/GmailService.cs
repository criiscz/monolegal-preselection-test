using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

// Servicio de correo encargado de notificar via correo
public class GmailService : IEmailService
{

    // Correo de envio
    private readonly MailAddress _from;
    // Contraseña de envio
    private readonly string _password;
    // Asunto del correo
    private readonly string _subject;
    // Cuerpo del correo
    private readonly string _body;
    // Servidor de correo
    private readonly string _server;
    // Puerto de correo
    private readonly int _port;
    // Activar o desactivar SSL
    private readonly bool _enableSsl;

    // Inicializamos servicio de correo con las opciones de configuracion
    public GmailService(IOptions<EmailSettings> emailSettings)
    {
        _from = new MailAddress(emailSettings.Value.SmtpUser);
        _password = emailSettings.Value.SmtpPassword;
        _subject = emailSettings.Value.Subject;
        _body = emailSettings.Value.Body;
        _server = emailSettings.Value.SmtpServer;
        _port = emailSettings.Value.SmtpPort;
        _enableSsl = emailSettings.Value.SmtpUseSsl;
    }

    // Metodo para notificar via correo
    public void Notify(Invoice invoice, string emailClient)
    {
        if (invoice.State == "desactivada") return;
        var smtp = new SmtpClient
        {
            Host = _server,
            Port = _port,
            EnableSsl = _enableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_from.Address, _password),
        };

        var toAddress = new MailAddress(emailClient);
        using var message = new MailMessage(_from, toAddress)
        {
            Subject = string.Format(_subject, invoice.InvoiceNumber),
            Body = string.Format(_body, invoice.InvoiceNumber, invoice.GetNextState()),
        };
        smtp.Send(message);
    }
}