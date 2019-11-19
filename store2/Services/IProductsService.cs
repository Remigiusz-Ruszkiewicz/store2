using store2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Services
{
    public interface IProductsService 
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> GetProductAsync(Guid Id);
        Task<Product> AddProductAsync(string Name);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Guid Id);

    }
}
