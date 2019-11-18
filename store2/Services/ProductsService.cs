using store2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Services
{
    public class ProductsService : IProductsService
    {
        private List<Product> products = new List<Product>();
        public ProductsService()
        {
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product { Id = Guid.NewGuid(), Name = $"Produkt {i}" });
            }
        }

        public ICollection<Product> GetAll()
        {
            return products;
        }

        public Product GetProduct(Guid Id)
        {
            return products.SingleOrDefault(x => x.Id == Id);
        }

        public Product AddProduct(string Name)
        {
            var product = new Product { Id = Guid.NewGuid(), Name = Name };
            products.Add(product);
            return product;
        }
    }
}
