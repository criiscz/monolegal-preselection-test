using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Models;
using MonolegalPreselectionTest.Services;

namespace MonolegalPreselectionTest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    // Inyeccion de dependencias para el servicio de facturas
    private readonly InvoiceService _invoiceService;

    // Constructor de la clase para inyectar el servicio de facturas
    public InvoiceController(InvoiceService invoiceService) => _invoiceService = invoiceService;

    // GET: api/Invoice - Obtiene todas las facturas del servicio
    [HttpGet]
    public async Task<List<Invoice>> Get() => await _invoiceService.Get();
}