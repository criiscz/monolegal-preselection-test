using MonolegalPreselectionTest.Models;
using MonolegalPreselectionTest.Services;

namespace MonolegalTest;

public class EmailServiceFake : IEmailService
{
    public void Notify(Invoice invoice, string email)
    {
        // Do nothing
    }
}