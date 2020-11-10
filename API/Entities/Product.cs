using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Entities
{
    public class Product : ProductDetails
    {
        [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
    }
}