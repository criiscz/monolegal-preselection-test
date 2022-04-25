namespace MonolegalPreselectionTest.Connection;

public class DatabaseSettings
{
    // Cadena de conexión a la base de datos
    public string ConnectionString { get; set; } = null!;

    // Nombre de la base de datos
    public string DatabaseName { get; set; } = null!;

    // Nombre de la colección de datos
    public string InvoiceCollectionName { get; set; } = null!;

    // Nombre de la colección de datos
    public string ClientCollectionName { get; set; } = null!;
}