using graph.Interfaces;
using GraphQL.Types;
namespace graph.Middleware
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IpersonRepository personRepository){
            //指令
            Field<ListGraphType<PersonType>>("person",
            //查詢條件
            arguments:new QueryArguments(new QueryArgument<IntGraphType>{ Name = "id" }),
            resolve: context =>
             {
                 //查詢的id
                  var id = context.GetArgument<int?>("id");
                  //有傳id
                  if(id.HasValue)
                  {
                 return personRepository.GetByID(id.Value);
                 //沒傳id
                  }else{
                      return personRepository.GetALL();  
                  }
            });
            //回傳全部資料
            Field<ListGraphType<PersonType>>("persons",
               resolve: context =>
               {
                   return personRepository.GetALL();
               });
            
            
        }
    }
}