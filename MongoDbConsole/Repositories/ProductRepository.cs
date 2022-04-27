using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbConsole.Repositories
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

        public List<Product> GetList() { 
        
            return productCollection.Find(new BsonDocument()).ToList();
        }

        public Product FindById(Guid Id)
        {
            var filter = Builders<Product>.Filter.Eq("Id", Id);

            return productCollection.Find(filter).FirstOrDefault(); 
        }

        public void Edit(Guid Id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, Id);
            var productForUpdate = Builders<Product>.Update
                .Set(x => x.Name, product.Name)
                .Set(x => x.Description, product.Description)
                .Set(x => x.Price, product.Price)
                .Set(x => x.Category, product.Category);
            var resultUpdate = productCollection.UpdateOne(filter, productForUpdate);
            if (resultUpdate.MatchedCount == 1 && resultUpdate.ModifiedCount == 1)
            {
                Console.WriteLine("update was finished successfully.....");
                
            }
        }


        public void Delete(Guid Id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, Id);
            productCollection.DeleteOne(filter);
        }

    }
}
