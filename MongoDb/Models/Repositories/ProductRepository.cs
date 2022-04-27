using MongoDb.Models.Entities;
using MongoDB.Driver;

namespace MongoDb.Models.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<Product> productCollection;
        public ProductRepository()
        {
            var client = new MongoClient();
            db = client.GetDatabase("TestDb");
            productCollection = db.GetCollection<Product>("Product");
        }

        public void Add(Product product)
        {
            productCollection.InsertOne(product);
        }


    }
}
