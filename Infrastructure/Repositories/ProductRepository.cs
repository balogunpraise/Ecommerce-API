using Core.Interfaces;
using ECommerceAPI.Data;
using ECommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var products = await context.Products.ToListAsync();
            return products;
        }
    }
}
