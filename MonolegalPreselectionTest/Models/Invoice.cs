using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonolegalPreselectionTest.Models;

public class Invoice
{
    // Id genereado por MongoDB
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    // Codigo de la factura
    [BsonElement("CodigoFactura")]
    [JsonPropertyName("CodigoFactura")]
    public string InvoiceNumber { get; set; } = "";

    // Nombre del cliente
    [BsonElement("Cliente")]
    [JsonPropertyName("Cliente")]
    public string Client { get; set; } = null!;

    // Ciudad de la factura
    [BsonElement("Ciudad")]
    [JsonPropertyName("Ciudad")]
    public string InvoiceCity { get; set; } = "";

    // NIT de la factura
    [BsonElement("NIT")]
    [JsonPropertyName("NIT")]
    public string Nit { get; set; } = "";

    // Monto Total de la factura
    [BsonElement("TotalFactura")]
    [JsonPropertyName("TotalFactura")]
    public float InvoiceTotal { get; set; } = 0;

    // Monto subtotal de la factura (total - iva)
    [BsonElement("SubTotal")]
    [JsonPropertyName("SubTotal")]
    public float InvoiceSubTotal { get; set; } = 0;

    // Monto iva de la factura
    [BsonElement("IVA")]
    [JsonPropertyName("Iva")]
    public float Iva { get; set; } = 0;

    // Retencion de la factura
    [BsonElement("Retencion")]
    [JsonPropertyName("Retencion")]
    public float Retention { get; set; } = 0;

    // Fecha de creacion de la factura
    [BsonElement("FechaCreacion")]
    [JsonPropertyName("FechaCreacion")]
    public DateTime CreationDate { get; set; } = DateTime.Now;

    // Estado de la factura => [primerRecordatorio, segundoRecordatorio, desactivada]
    [BsonElement("Estado")]
    [JsonPropertyName("Estado")]
    public string State { get; set; } = "";

    // Factura pagada o no.
    [BsonElement("Pagada")]
    [JsonPropertyName("Pagada")]
    public bool IsPaid { get; set; } = false;

    // Fecha de pago de la factura
    [BsonElement("FechaPago")]
    [JsonPropertyName("FechaPago")]
    public DateTime? PaymentDate { get; set; } = null;

    // Correo electronico del cliente
    [BsonElement("Correo")]
    [JsonPropertyName("Correo")]
    public string Email { get; set; } = "";

    // Cambia el estado de la factura al siguiente estado.
    public string ChangeState()
    {
        State = State switch
        {
            "primerRecordatorio" => "segundoRecordatorio",
            "segundoRecordatorio" => "desactivada",
            _ => State
        };

        return State;
    }
}