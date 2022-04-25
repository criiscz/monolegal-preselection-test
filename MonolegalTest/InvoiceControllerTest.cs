using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Controllers;
using MonolegalPreselectionTest.Data;
using MonolegalPreselectionTest.Models;
using MonolegalPreselectionTest.Services;
using Xunit;
using Xunit.Abstractions;

namespace MonolegalTest;

public class InvoiceControllerTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ClientController _invoiceController;
    private readonly IClientDataStore _invoiceDataStore;
    private readonly IEmailService _emailService;

    public InvoiceControllerTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _invoiceDataStore = new InvoiceDataStoreFake();
        _emailService = new EmailServiceFake();
        _invoiceController = new ClientController(_emailService, _invoiceDataStore);
    }

    [Fact]
    public void GetAllInvoices_ReturnsOkResult()
    {
        // Act
        var okResult = _invoiceController.GetInvoices("1");

        // Assert
        Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
    }

    [Fact]
    public void GetAllInvoices_ReturnsAllItems()
    {
        // Act
        var okResult = _invoiceController.GetInvoices("1") as OkObjectResult;

        // Assert
        var items = Assert.IsType<List<Invoice>>(okResult?.Value);
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public void UpdateInvoice_ReturnsOkResult()
    {
        // Act
        var okResult = _invoiceController.UpdateAllInvoices();

        // Assert
        Assert.IsType<OkObjectResult>(okResult);
    }

    [Fact]
    public void UpdateInvoice_UpdateStateOfInvoice()
    {
        // Act
        var okResult = _invoiceController.GetInvoices("1") as OkObjectResult;
        var items = Assert.IsType<List<Invoice>>(okResult?.Value);
        var okResult2 = _invoiceController.UpdateInvoices("1") as OkObjectResult;
        var items2 = Assert.IsType<List<Invoice>>(okResult2?.Value);
        // Assert
        Assert.NotEqual(items[0].State, items2[0].State);;
    }

    [Fact]
    public void UpdateAllInvoices_UpdateStateOfAllInvoices()
    {
        // Act
        var okResult = _invoiceController.GetAllClients() as OkObjectResult;
        var clients = Assert.IsType<List<Client>>(okResult?.Value);
        var okResult2 = _invoiceController.UpdateAllInvoices() as OkObjectResult;
        var clients2 = Assert.IsType<List<Client>>(okResult2?.Value);

        // Assert

        Assert.Equal(clients.Count, clients2.Count);
        Assert.NotEqual(clients[0].Facturas[0].State, clients2[0].Facturas[0].State);
    }
    // public void UpdateInvoice_UpdateStateOfAllInvoices()
    // {
    //     // Act
    //     var okResult = _invoiceController.GetInvoices() as ObjectResult;
    //     var invoices = Assert.IsType<List<Invoice>>(okResult?.Value);
    //     var result = _invoiceController.UpdateInvoice() as ObjectResult;
    //     var invoicesUpdated = Assert.IsType<List<Invoice>>(result?.Value);
    //
    //     // Assert
    //     Assert.NotEqual(invoices[0].State, invoicesUpdated[0].State);
    //     Assert.NotEqual(invoices[1].State, invoicesUpdated[1].State);
    //     Assert.Equal("segundoRecordatorio", invoicesUpdated[0].State);
    //     Assert.Equal("desactivada", invoicesUpdated[1].State);
    // }
}