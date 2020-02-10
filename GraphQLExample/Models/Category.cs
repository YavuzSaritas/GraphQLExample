using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Product> Products { get; set; }
    }
}
