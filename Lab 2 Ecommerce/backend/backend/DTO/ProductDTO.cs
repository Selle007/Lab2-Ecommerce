using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;


namespace backend.DTO
{
    public class ProductDTO
    {

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("price")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal? Price { get; set; }

        [BsonElement("stock")]
        [BsonSerializer(typeof(Int32Serializer))]
        public int Stock { get; set; }

        [BsonElement("isFeatured")]
        [BsonSerializer(typeof(BooleanSerializer))]
        public bool isFeatured { get; set; }

        [BsonElement("categoryId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }
        public IFormFile File { get; set; }
    }
}
