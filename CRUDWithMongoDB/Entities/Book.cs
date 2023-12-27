using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUDWithMongoDB.Entities
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("Name")]
        public string BookName { get; set; } = null!;
        public string? Category { get; set; }
        public decimal Price { get; set; }
    }
}
