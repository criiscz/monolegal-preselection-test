using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Data;

public interface IInvoiceDataStore
{
    List<Invoice> GetAllInvoices();
    void UpdateState(string id, string state);
}