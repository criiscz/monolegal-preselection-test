namespace MonolegalPreselectionTest.Connection;

// Esta clase es la encargada de Mapear los datos de emailsettings de appsettings.json en un objeto de tipo EmailSettings
public class EmailSettings
{
    // Host de correo saliente
    public string SmtpServer { get; set; } = "";

    // Puerto de correo saliente
    public int SmtpPort { get; set; } = 0;

    // Nombre de usuario de correo saliente
    public string SmtpUser { get; set; } = "";

    // Contraseña de usuario de correo saliente
    public string SmtpPassword { get; set; } = "";

    // Define si el correo saliente es ssl o no
    public bool SmtpUseSsl { get; set; } = true;

    // Cuerpo del correo
    public string Body { get; set; } = "";

    // Asunto del correo
    public string Subject { get; set; } = "";
}