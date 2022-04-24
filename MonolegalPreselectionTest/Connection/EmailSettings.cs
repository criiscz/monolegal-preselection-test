namespace MonolegalPreselectionTest.Connection;

public class EmailSettings
{
    public string SmtpServer { get; set; } = "";
    public int SmtpPort { get; set; } = 0;
    public string SmtpUser { get; set; } = "";
    public string SmtpPassword { get; set; } = "";
    public bool SmtpUseSsl { get; set; } = true;
    public string Body { get; set; } = "";
    public string Subject { get; set; } = "";
}