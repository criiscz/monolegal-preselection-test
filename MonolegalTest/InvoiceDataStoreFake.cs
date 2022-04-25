using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonolegalPreselectionTest.Models;
using MonolegalPreselectionTest.Services;

namespace MonolegalTest;

public class InvoiceDataStoreFake : IInvoiceDataStore
{
    public List<Invoice> GetAllInvoicesAsync()
    {
        return new List<Invoice>(new Invoice[]
        {
            new Invoice()
            {
                Client = "Cliente 2",
                InvoiceNumber = "2",
                CreationDate = DateTime.Now,
                InvoiceTotal = 2000,
                InvoiceCity = "Bogota",
                InvoiceSubTotal = 1900,
                Iva = 100,
                Email = "mail2@mail.com",
                Id = "2",
                Nit = "123456789",
                Retention = 0,
                State = "primerRecordatorio",
                IsPaid = false,
                PaymentDate = DateTime.Now
            },
            new Invoice()
            {
                Client = "Cliente 1",
                InvoiceNumber = "1",
                CreationDate = DateTime.Now,
                InvoiceTotal = 1000,
                InvoiceCity = "Bogota",
                InvoiceSubTotal = 900,
                Iva = 100,
                Email = "mail2@mail.com",
                Id = "1",
                Nit = "123456789",
                Retention = 0,
                State = "segundoRecordatorio",
                IsPaid = false,
                PaymentDate = DateTime.Now

            }
        });
    }

    public void UpdateState(string id, string state)
    {
        var invoices = GetAllInvoicesAsync();
        foreach (var invoice in invoices.Where(invoice => invoice.Id == id))
        {
            invoice.State = state;
        }
    }
}