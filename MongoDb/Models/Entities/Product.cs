using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb.Models.Entities
{
    public class Product
    {
        [BsonId]
        public Guid Id { get; set; } // _id
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    }
}
