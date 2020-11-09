using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class ProductDetails
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}