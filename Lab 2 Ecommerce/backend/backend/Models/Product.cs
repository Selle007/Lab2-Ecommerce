using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Product
{
    // this is only a placeholder and will be replaced with real code.
    // only for initialization purposes
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Price")]
    public decimal Price { get; set; }

    [BsonElement("Description")]
    public string Description { get; set; }

    [BsonElement("Category")]
    public string Category { get; set; }
}
