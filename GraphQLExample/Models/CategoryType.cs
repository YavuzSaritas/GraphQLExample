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
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x => x.Id).Description("Category Id");
            Field(x => x.Name, nullable: true).Description("Category Name");
            Field<ListGraphType<ProductType>>(
                "Products",
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result.ToList());
        }
    }
}
