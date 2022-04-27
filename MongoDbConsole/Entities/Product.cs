using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbConsole.Entities
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
