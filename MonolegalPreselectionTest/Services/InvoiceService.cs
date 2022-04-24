using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

public class InvoiceService
{
    // Inyectamos la conexión a la base de datos
    private readonly IMongoCollection<Invoice> _invoiceCollection;

    // Inyectamos las opciones de configuración de la base de datos
    // para obtener la colección de facturas
    public InvoiceService(IOptions<InvoiceDatabaseSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);

        var database = client.GetDatabase(settings.Value.DatabaseName);
        _invoiceCollection = database.GetCollection<Invoice>(
            settings.Value.InvoiceCollectionName);
    }

    // Obtiene todas las facturas de la base de datos.
    public async Task<List<Invoice>> Get() =>
        await _invoiceCollection.Find(_ => true).ToListAsync();

    // Actualiza el estado de una factura
    public async Task UpdateState(string id, string newState)
    {
        var newInvoice = _invoiceCollection.Find(i => i.InvoiceNumber == id).FirstOrDefault();
        newInvoice.State = newState;
        await _invoiceCollection.ReplaceOneAsync(
            i => i.InvoiceNumber == id,
            newInvoice
        );
    }
}