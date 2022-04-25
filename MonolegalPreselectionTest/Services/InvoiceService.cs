using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

// Servicio de Facturas encargado de Conectarse a la base de datos y operar datos de la misma
public class InvoiceService : IInvoiceDataStore
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly InvoiceDatabaseSettings _settings;

    private readonly IMongoCollection<Invoice> _invoiceCollection;

    // Inyectamos las opciones de configuración de la base de datos
    // para obtener la colección de facturas
    public InvoiceService(IOptions<InvoiceDatabaseSettings> settings, IMongoClient client,
    IMongoDatabase database ){
        _settings = settings.Value;
        _client = client;
        _database = database;
        _invoiceCollection = _database.GetCollection<Invoice>(_settings.InvoiceCollectionName);
    }

    // Obtiene todas las facturas de la base de datos.
    public List<Invoice> GetAllInvoicesAsync() =>
        _invoiceCollection.Find(_ => true).ToListAsync().Result;

    // Actualiza el estado de una factura
    public void UpdateState(string id, string newState)
    {
        var newInvoice = _invoiceCollection.Find(i => i.InvoiceNumber == id).FirstOrDefault();
        newInvoice.State = newState;
        _invoiceCollection.ReplaceOneAsync(
            i => i.InvoiceNumber == id,
            newInvoice
        );
    }
}