using store2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Services
{
    public interface IProductsService 
    {
        ICollection<Product> GetAll();
        Product GetProduct(Guid Id);
        Product AddProduct(string Name);

    }
}
