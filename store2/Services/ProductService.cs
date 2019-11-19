using Microsoft.EntityFrameworkCore;
using store2.Data;
using store2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store2.Services
{
    public class ProductService : IProductsService
    {
        private readonly DataContext dbContext;

        public ProductService(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(Guid Id)
        {
            return await dbContext.Products.SingleOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Product> AddProductAsync(string Name)
        {
            var product = new Product { Id = Guid.NewGuid(), Name = Name };
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            dbContext.Products.Update(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var product = await dbContext.Products.SingleOrDefaultAsync(x => x.Id == Id);
            if (product == null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
