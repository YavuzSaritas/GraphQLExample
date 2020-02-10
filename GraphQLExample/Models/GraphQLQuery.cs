using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Models
{
    /*
      Artık geriye yapmamız gereken iki şey kaldı. Bunlardan ilki GraphQL endpoint’ini hazırlamak, bir diğeri de service injection işlemlerini gerçekleştirmek. Endpoint’i hazırlamak için öncelikle “Models” klasörü içerisinde “GraphQLQuery” isminde bir request class’ı oluşturalım ve aşağıdaki gibi tanımlayalım.
     */
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public string Variables { get; set; }
    }
}
