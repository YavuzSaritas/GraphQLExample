using aspnetcoregraphql.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcoregraphql.Controllers
{
    /*
      İlk olarak “Route” attribute’ü ile endpoint’i belirledik ve ardından “IDocumentExecuter” ve “ISchema” interface’lerinin inject işlemlerini gerçekleştirdik. Bu noktada “IDocumentExecuter“, “ExecutionOptions” parametresini execute ederek, client’ın istemiş olduğu data’yı oluşturacaktır. 
     */
    [ApiController]
    [Route("graphql")]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphQLController(IDocumentExecuter documentExecuter,ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var executionOption = new ExecutionOptions { Schema = _schema, Query = query.Query };
            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOption).ConfigureAwait(false);
                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }
                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
