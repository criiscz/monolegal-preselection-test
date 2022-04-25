using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Controllers;
using MonolegalPreselectionTest.Models;
using MonolegalPreselectionTest.Services;
using Xunit;
using Xunit.Abstractions;

namespace MonolegalTest;

public class InvoiceControllerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly InvoiceController _invoiceController;
    private readonly IInvoiceDataStore _invoiceDataStore;
    private readonly IEmailService _emailService;

    public InvoiceControllerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _invoiceDataStore = new InvoiceDataStoreFake();
        _emailService = new EmailServiceFake();
        _invoiceController = new InvoiceController(_invoiceDataStore, _emailService);
    }

    [Fact]
    public void GetAllInvoices_ReturnsOkResult()
    {
        // Act
        var okResult = _invoiceController.GetAllInvoices();

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void GetAllInvoices_ReturnsAllItems()
    {
        // Act
        var okResult = _invoiceController.GetAllInvoices() as OkObjectResult;

        // Assert
        var items = Assert.IsType<List<Invoice>>(okResult?.Value);
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public void UpdateInvoice_ReturnsOkResult()
    {
        // Act
        var okResult = _invoiceController.UpdateInvoice();

        // Assert
        Assert.IsType<OkObjectResult>(okResult);
    }

    [Fact]
    public void UpdateInvoice_UpdateStateOfAllInvoices()
    {
        // Act
        var okResult = _invoiceController.GetAllInvoices() as ObjectResult;
        var invoices = Assert.IsType<List<Invoice>>(okResult?.Value);
        var result = _invoiceController.UpdateInvoice() as ObjectResult;
        var invoicesUpdated = Assert.IsType<List<Invoice>>(result?.Value);

        // Assert
        Assert.NotEqual(invoices[0].State,invoicesUpdated[0].State);
        Assert.NotEqual(invoices[1].State,invoicesUpdated[1].State);
        Assert.Equal("segundoRecordatorio",invoicesUpdated[0].State);
        Assert.Equal("desactivada",invoicesUpdated[1].State);
    }
}