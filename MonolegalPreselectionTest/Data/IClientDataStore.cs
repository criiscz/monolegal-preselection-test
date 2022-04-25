using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Data;

public interface IClientDataStore
{
    List<Client> GetAllClients();

    Client GetClient(string id);

    List<Invoice> GetClientInvoices(string id);

    void UpdateClientInvoices(string id, string invoiceId);


}