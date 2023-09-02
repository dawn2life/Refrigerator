using Refrigerator.Api.Domain.Models;

namespace Refrigerator.Api.Data.SeedData
{
    public class RefrigeratorDbSeedData
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product() {Id = 1, Name = "Milk", BaseUnit ="Millilitre", ExpirationDate = DateTime.Parse("2023-08-24")},
                new Product() {Id = 2, Name = "Apple Juice", BaseUnit ="Millilitre", ExpirationDate = DateTime.Parse("2023-09-24")},
                new Product() {Id = 3, Name = "Apple", BaseUnit ="Gram", ExpirationDate = DateTime.Parse("2023-08-30")},
                new Product() {Id = 4, Name = "Banana", BaseUnit ="Number", ExpirationDate = DateTime.Parse("2023-08-26")},
                new Product() {Id = 5, Name = "Orange", BaseUnit ="Gram", ExpirationDate = DateTime.Parse("2023-08-30")},
                new Product() {Id = 6, Name = "Ice Cream", BaseUnit ="Gram", ExpirationDate = DateTime.Parse("2023-09-30")},
                new Product() {Id = 7, Name = "Mixed Juice", BaseUnit ="Millilitre", ExpirationDate = DateTime.Parse("2023-09-24")},
                new Product() {Id = 8, Name = "Bread", BaseUnit ="Gram", ExpirationDate = DateTime.Parse("2023-08-28")},
                new Product() {Id = 9, Name = "Egg", BaseUnit ="Number", ExpirationDate = DateTime.Parse("2023-09-26")},
                new Product() {Id = 10, Name = "Donuts", BaseUnit ="Number", ExpirationDate = DateTime.Parse("2023-08-30")}
            };
        }
    }
}
