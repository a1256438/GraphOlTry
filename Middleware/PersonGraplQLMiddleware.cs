using System.IO;
using System.Threading.Tasks;
using graph.Interfaces;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace graph.Middleware
{
    public class PersonGraplQLMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IpersonRepository _personRepository;

        //注入
        public PersonGraplQLMiddleware(RequestDelegate next,IpersonRepository personRepository){

                _next=next;
                _personRepository = personRepository;
        }

        public async Task Invoke(HttpContext httpContext){

            if(httpContext.Request.Path.StartsWithSegments("/graphql"))
            {   
                using(var stream = new StreamReader(httpContext.Request.Body)){
                
                    var query=await stream.ReadToEndAsync();
                    if(!string.IsNullOrWhiteSpace(query)){

                                var schema=new Schema{ Query =  new PersonQuery(_personRepository)  };
                                var result = await new DocumentExecuter()
                                .ExecuteAsync(options =>
                                {
                                options.Schema=schema;
                                options.Query=query;
                                });
                                await WriteResultAsync(httpContext,result);
                }else{
                        await _next(httpContext);
                    }
            }


        }
        }

        private async Task WriteResultAsync(HttpContext httpContext,ExecutionResult executionResult){
            var json=new DocumentWriter(indent:true).Write(executionResult);
            httpContext.Response.StatusCode=200;
            httpContext.Response.ContentType="application/json";
            await httpContext.Response.WriteAsync(json);

        }
        //http://localhost:5000/graphql
        
    //      	{
 	// persons{
 	// name
 	// }
 	// }

    //--------------------------

    //   	{
 	// person(id:1){
 	// name
 	// }
 	// }
}
}



