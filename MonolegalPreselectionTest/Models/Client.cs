using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonolegalPreselectionTest.Models;

public class Client
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Nombre")]
    [JsonPropertyName("Nombre")]
    public string Nombre { get; set; } ="";

    [BsonElement("Correo")]
    [JsonPropertyName("Correo")]
    public string Correo { get; set; } ="";

    [BsonElement("Facturas")]
    [JsonPropertyName("Facturas")]
    public List<Invoice> Facturas { get; set; } = new();


}