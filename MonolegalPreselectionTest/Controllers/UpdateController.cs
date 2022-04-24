using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Services;

namespace MonolegalPreselectionTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpdateController : ControllerBase
{
    private readonly InvoiceService _invoiceService;
    private readonly EmailService _emailService;

    public UpdateController(InvoiceService invoiceService, EmailService emailService)
    {
        _invoiceService = invoiceService;
        _emailService = emailService;
    }

    [HttpGet]
    public async Task<OkObjectResult> Get()
    {
        Console.WriteLine("Get");
        var list = _invoiceService.Get().Result;
        foreach (var invoice in list)
        {
            // _emailService.Notify(invoice);
            await _invoiceService.UpdateState(invoice.InvoiceNumber, invoice.ChangeState());
            Console.WriteLine($"Invoice {invoice.InvoiceNumber} updated");
        }
        return Ok("Facturas Actualizadas");
    }
    // POST api/update - Actualiza el estado de las facturas y envia un correo con el resultado
    [HttpPatch]
    public async Task<OkResult> UpdateInvoice()
    {
        var list = _invoiceService.Get().Result;
        foreach (var invoice in list)
        {
            // _emailService.Notify(invoice);
            await _invoiceService.UpdateState(invoice.InvoiceNumber, invoice.ChangeState());
            Console.WriteLine($"Invoice {invoice.InvoiceNumber} updated");
        }
        return Ok();
    }
}