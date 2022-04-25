using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Data;
using MonolegalPreselectionTest.Services;

namespace MonolegalPreselectionTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientDataStore _clientService;
    private readonly IEmailService _emailService;

    public ClientController(IEmailService emailService, IClientDataStore clientService)
    {
        _clientService = clientService;
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult GetAllClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var client = _clientService.GetClient(id);
        return Ok(client);
    }

    [HttpGet("{id}/invoices")]
    public IActionResult GetInvoices(string id)
    {
        var invoices = _clientService.GetClientInvoices(id);
        return Ok(invoices);
    }

    [HttpPost("{id}/update")]
    public IActionResult UpdateInvoices(string id)
    {
        var client = _clientService.GetClient(id);
        var invoices = client.Facturas;
        foreach (var invoice in invoices)
        {
            _emailService.Notify(invoice, client.Correo);
            _clientService.UpdateClientInvoices(id, invoice.InvoiceNumber);
        }

        return Ok(invoices);
    }

    [HttpPost("invoices/update")]
    public IActionResult UpdateAllInvoices()
    {
        var clients = _clientService.GetAllClients();
        foreach (var client in clients.Where(client => client.Id != null))
        {
            if (client.Id != null)
            {
                UpdateInvoices(client.Id);
            }
            else return BadRequest();
        }

        return Ok(clients);
    }
}