using aspnetcoregraphql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Data
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product{Id = 1, CategoryId = 1 , Name ="Apple Macbook Pro 2016",Description = "Touchbar, 3.2GHz",Price = 5000},
                new Product{Id = 2, CategoryId = 1 , Name ="Apple Macbook Pro Air",Description = "2.3GHz 8GB RAM" ,Price = 2000 },
                new Product{Id = 3 ,CategoryId = 1 , Name ="Dell XPS 13", Description = "3.3GHz 12GB RAM",Price=4000}
            };
        }
        public Task<Product> GetProductAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(_products);
        }

        public Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId)
        {
            return Task.FromResult(_products.Where(p => p.CategoryId == categoryId).ToList());
        }
    }
}
