using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

public class EmailService
{
    private readonly MailAddress _from;
    private readonly string _password;
    private readonly string _subject;
    private readonly string _body;
    private readonly string _server;
    private readonly int _port;
    private readonly bool _enableSsl;

    public EmailService(IOptions<EmailSettings> emailSettings)
    {
        _from = new MailAddress(emailSettings.Value.SmtpUser);
        _password = emailSettings.Value.SmtpPassword;
        _subject = emailSettings.Value.Subject;
        _body = emailSettings.Value.Body;
        _server = emailSettings.Value.SmtpServer;
        _port = emailSettings.Value.SmtpPort;
        _enableSsl = emailSettings.Value.SmtpUseSsl;
    }

    public void Notify(Invoice invoice)
    {
        var smtp = new SmtpClient
        {
            Host = _server,
            Port = _port,
            EnableSsl = _enableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_from.Address, _password),
        };

        var toAddress = new MailAddress(invoice.Email);
        using var message = new MailMessage(_from, toAddress)
        {
            Subject = _subject,
            Body = _body
        };
        smtp.Send(message);
    }
}