using aspnetcoregraphql.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Models
{
    /*
    Paketi projemize ekledikten sonra, ilk olarak GraphQL Object Type‘larını tanımlamaya başlayalım.  Object type‘ları ve field’lar GraphQL schema’sının en temel bileşenlerini oluşturmaktadır. Yani, oluşturacağımız servis üzerinden hangi objeleri alabileceğimizi ve hangi field’lara sahip olduğunu belirtmektedir.
   */
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository)
        {
            Field(x => x.Id).Description("Product Id");
            Field(x => x.Name).Description("Product Name");
            Field(x => x.Description, nullable: true).Description("Product Description");
            Field(x => x.Price).Description("Product Price");
            Field<CategoryType>(
                "Category",
                resolve: context => categoryRepository.GetCategoryAsync(context.Source.CategoryId));
        }
    }
}
