using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Models
{
    /*
       Artık dışarıya expose edecek olduğumuz data’mızın, structure’ını tanımlayacak olan schema’yı oluşturabiliriz. Bunun için “EasyStoreSchema” adında bir class daha oluşturalım ve “Schema” class’ından türeterek, aşağıdaki gibi kodlayalım.
       Bir schema’nın sahip olabileceği iki adet temel type bulunmaktadır. Bunlardan ilki “Query”, diğeri ise “Mutation” type’ıdır. Biz ise burada sadece “Query” type’ını kullandık.
     */
    public class EasyStoreSchema : Schema
    {     
        public EasyStoreSchema(Func<Type,GraphType> resolveType)
            :base(resolveType)
        {
            Query = (EasyStoreQuery)resolveType(typeof(EasyStoreQuery));
        }
    }
}
