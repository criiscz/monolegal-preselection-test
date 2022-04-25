using MonolegalPreselectionTest.Models;

namespace MonolegalPreselectionTest.Services;

public interface IEmailService
{
    void Notify(Invoice invoice);
}