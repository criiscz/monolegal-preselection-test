using System;
using System.Collections.Generic;
using System.Linq;
using MonolegalPreselectionTest.Data;
using MonolegalPreselectionTest.Models;

namespace MonolegalTest;

public class InvoiceDataStoreFake : IClientDataStore
{
    public List<Invoice> GetAllInvoices()
    {
        return new List<Invoice>(new Invoice[]
        {
            new()
            {
                InvoiceNumber = "2",
                CreationDate = DateTime.Now,
                InvoiceTotal = 2000,
                InvoiceCity = "Bogota",
                InvoiceSubTotal = 1900,
                Iva = 100,
                Id = "2",
                Nit = "123456789",
                Retention = 0,
                State = "primerRecordatorio",
                IsPaid = false,
                PaymentDate = DateTime.Now
            },
            new()
            {
                InvoiceNumber = "1",
                CreationDate = DateTime.Now,
                InvoiceTotal = 1000,
                InvoiceCity = "Bogota",
                InvoiceSubTotal = 900,
                Iva = 100,
                Id = "1",
                Nit = "123456789",
                Retention = 0,
                State = "segundoRecordatorio",
                IsPaid = false,
                PaymentDate = DateTime.Now
            }
        });
    }

    public List<Client> GetAllClients()
    {
        return new List<Client>(new[]
        {
            new Client()
            {
                Id = "1",
                Nombre = "Cliente 1",
                Correo = "correo@mail.com",
                Facturas = new List<Invoice>(new[]
                {
                    new Invoice()
                    {
                        InvoiceNumber = "2",
                        CreationDate = DateTime.Now,
                        InvoiceTotal = 2000,
                        InvoiceCity = "Bogota",
                        InvoiceSubTotal = 1900,
                        Iva = 100,
                        Id = "2",
                        Nit = "123456789",
                        Retention = 0,
                        State = "primerRecordatorio",
                        IsPaid = false,
                        PaymentDate = DateTime.Now
                    },
                    new Invoice()
                    {
                        InvoiceNumber = "3",
                        CreationDate = DateTime.Now,
                        InvoiceTotal = 2000,
                        InvoiceCity = "Bogota",
                        InvoiceSubTotal = 1900,
                        Iva = 100,
                        Id = "2",
                        Nit = "123456789",
                        Retention = 0,
                        State = "primerRecordatorio",
                        IsPaid = false,
                        PaymentDate = DateTime.Now
                    }
                })
            },
            new Client()
            {
                Id = "2",
                Nombre = "Cliente 2",
                Correo = "correo@mail.com",
                Facturas = new List<Invoice>(new[]
                {
                    new Invoice()
                    {
                        InvoiceNumber = "5",
                        CreationDate = DateTime.Now,
                        InvoiceTotal = 2000,
                        InvoiceCity = "Bogota",
                        InvoiceSubTotal = 1900,
                        Iva = 100,
                        Id = "2",
                        Nit = "123456789",
                        Retention = 0,
                        State = "primerRecordatorio",
                        IsPaid = false,
                        PaymentDate = DateTime.Now
                    },
                    new Invoice()
                    {
                        InvoiceNumber = "4",
                        CreationDate = DateTime.Now,
                        InvoiceTotal = 2000,
                        InvoiceCity = "Bogota",
                        InvoiceSubTotal = 1900,
                        Iva = 100,
                        Id = "2",
                        Nit = "123456789",
                        Retention = 0,
                        State = "primerRecordatorio",
                        IsPaid = false,
                        PaymentDate = DateTime.Now
                    }
                })
            }
        });
    }

    public Client GetClient(string id)
    {
        return GetAllClients().FirstOrDefault(x => x.Id == id)!;
    }

    public List<Invoice> GetClientInvoices(string id)
    {
        return GetAllClients().FirstOrDefault(x => x.Id == id)!.Facturas;
    }

    public void UpdateClientInvoices(string id, string invoiceId)
    {
        var client = GetClient(id);
        var invoice = client.Facturas.FirstOrDefault(x => x.InvoiceNumber == invoiceId);
        invoice!.ChangeState();
    }
}