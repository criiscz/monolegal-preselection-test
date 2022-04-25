using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Models;
using MonolegalPreselectionTest.Services;

namespace MonolegalPreselectionTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    // Inyeccion de dependencias para el servicio de facturas
    private readonly IInvoiceDataStore _invoiceService;

    // Inyeccion de dependencias para el servicio de correos
    private readonly IEmailService _emailService;

    // Constructor de la clase para inyectar el servicio de facturas
    public InvoiceController(IInvoiceDataStore invoiceService, IEmailService emailService)
    {
        _invoiceService = invoiceService;
        _emailService = emailService;
    }

    // GET: api/Invoice - Obtiene todas las facturas del servicio
    [HttpGet]
    public IActionResult GetAllInvoices() => Ok(_invoiceService.GetAllInvoicesAsync());

    // POST api/Invoice/update - Actualiza el estado de las facturas y envia un correo con el resultado
    [HttpPost("update")]
    public IActionResult UpdateInvoice()
    {
        var list = _invoiceService.GetAllInvoicesAsync();
        foreach (var invoice in list)
        {
            _emailService.Notify(invoice);
            _invoiceService.UpdateState(invoice.InvoiceNumber, invoice
                .ChangeState());
        }
        return Ok(list);
    }
}