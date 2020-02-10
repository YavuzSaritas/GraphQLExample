using aspnetcoregraphql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public CategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category{Id=1,Name="Computers"},
                new Category{Id=2,Name="Mobile Phone"}
            };
        }
        public Task<List<Category>> CategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return Task.FromResult(_categories.FirstOrDefault(p => p.Id == id));
        }
    }
}
