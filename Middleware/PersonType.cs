using graph.Models;
using GraphQL.Types;
namespace graph.Middleware
{
    public class PersonType : ObjectGraphType<Person>
    {
        //對應資料
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x=>x.Email);
            Field<ListGraphType<PersonType>>("Parents");
        }
    }
}