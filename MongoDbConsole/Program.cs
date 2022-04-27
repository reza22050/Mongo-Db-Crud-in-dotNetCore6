// See https://aka.ms/new-console-template for more information
using MongoDbConsole.Repositories;


ProductRepository productRepository = new ProductRepository();

/// <summary>
///  Get item to product collection
/// </summary>
productRepository.Add(new MongoDbConsole.Entities.Product()
{
    Name = "Apple AirPods",
    Description = "More than 24 hours total listening time with the Charging Case",
    Category = "Mobile",
    Price = 5500
});

/// <summary>
///  Get list of collection items
/// </summary>
var productList = productRepository.GetList();
foreach (var item in productList)
{
    Console.WriteLine($"Id = {item.Id}  |   Name:{item.Name}    |   Description:{item.Description}  |   Price:{item.Price}");
}


/// <summary>
/// Edit item
/// </summary>
var product = productRepository.FindById(Guid.Parse("Your_Product_Id")); //enter your id
if (product != null)
{
    Console.WriteLine("Product found....");
    product.Name = "iPhone13";
    product.Price = 9000;
    productRepository.Edit(Guid.Parse("Your_Product_Id"), product);

}


/// <summary>
/// Delete item
/// </summary>     
productRepository.Delete(Guid.Parse("Your_Product_Id"));

Console.ReadLine();
