using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonolegalPreselectionTest.Connection;
using MonolegalPreselectionTest.Data;
using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

public class ClientService : IClientDataStore
{
    private readonly IMongoClient _client;
    private readonly IMongoCollection<Client> _collection;
    private readonly DatabaseSettings _settings;

    public ClientService(IMongoClient client, IMongoDatabase database, IOptions<DatabaseSettings> settings)
    {
        _client = client;
        _collection = database.GetCollection<Client>(settings.Value.ClientCollectionName);
        _settings = settings.Value;
    }

    public List<Client> GetAllClients() => _collection.Find(_ => true).ToList();

    public Client GetClient(string id) => _collection
        .Find(client => client.Id != null && id == client.Id).FirstOrDefault();

    public List<Invoice> GetClientInvoices(string id)
    {
        var client = GetClient(id);
        return client.Facturas.ToList();
    }

    // public void UpdateClientInvoices(string id)
    // {
    //     var client = GetClient(id);
    //     var invoices = GetClientInvoices(id);
    //     foreach (var invoice in invoices)
    //     {
    //
    //     }
    // }

    public void UpdateClientInvoices(string idClient, string idInvoice)
    {
        var newClient = GetClient(idClient);
        var invoice = newClient.Facturas.FirstOrDefault(i => i.InvoiceNumber == idInvoice);
        newClient.Facturas.Find( i => i.InvoiceNumber == invoice!.InvoiceNumber)!.State = invoice!
            .ChangeState();
        _collection.FindOneAndReplace( client => client.Id == idClient, newClient);
    }
}