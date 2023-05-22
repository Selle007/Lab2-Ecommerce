using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;

namespace backend.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("shippingDetails")]
        public ShippingDetails ShippingDetails { get; set; }

        [BsonElement("items")]
        public List<Item> Items { get; set; }


        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("total")]
        [BsonRepresentation(BsonType.Decimal128)]
        public double Total { get; set; }
    }

    public class ShippingDetails
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("zipCode")]
        public string ZipCode { get; set; }
    }

    public class Item
    {
        [BsonElement("productId")]
        public string ProductId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("total")]
        [BsonRepresentation(BsonType.Decimal128)]
        public double Total { get; set; }
    }
}
