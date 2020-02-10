using aspnetcoregraphql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Data
{
    public interface ICategoryRepository
    {
        Task<List<Category>> CategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}
