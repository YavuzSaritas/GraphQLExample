using aspnetcoregraphql.Data;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Models
{
    /*
      * Şimdi query işlemleri için kullanacak olduğumuz root type’ı oluşturacağız. Bunun için “EasyStoreQuery” isminde yeni bir class tanımlayalım ve aşağıdaki gibi kodlayalım.
      * Configure işlemi sırasında “arguments” parametresi ile ise, ilgili field’ın hangi argument’ler doğrultusunda alınabileceğini belirttik.
     */
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Category Id" }),
                resolve: context => categoryRepository.GetCategoryAsync(context.GetArgument<int>("id")).Result);
            Field<ListGraphType<CategoryType>>(
               "allcategory",
               resolve: context => categoryRepository.CategoriesAsync().Result);
            Field<ProductType>(
              "product",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "Product Id" }),
              resolve: context => productRepository.GetProductAsync(context.GetArgument<int>("id")).Result);
            Field<ListGraphType<ProductType>>(
                "allproduct",
                resolve: context => productRepository.GetProductsAsync().Result);
        }
    }
}
