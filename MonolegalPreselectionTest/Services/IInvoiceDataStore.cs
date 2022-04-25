using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

public interface IInvoiceDataStore
{
    List<Invoice> GetAllInvoicesAsync();
    void UpdateState(string id, string state);
}