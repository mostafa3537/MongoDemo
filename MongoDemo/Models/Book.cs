using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDemo.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Title")]
    public string Title { get; set; } = null!;

    [BsonElement("Author")]
    public string Author { get; set; } = null!;

    [BsonElement("Price")]
    public decimal Price { get; set; }

    [BsonElement("ISBN")]
    public string ISBN { get; set; } = null!;

    [BsonElement("InStock")]
    public bool InStock { get; set; }
}