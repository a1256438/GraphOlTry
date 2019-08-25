using System.Collections.Generic;
using graph.Models;
using System.Linq;

namespace graph.Interfaces
{
    //實作
    public class personRepository : IpersonRepository
    {
        //假資料
        public IEnumerable<Person> GetALL()
        {
            var michael =new Person{
                Id=1,
                Name="w",
                Email= "michael@"
            };
            var Lily = new Person
            {
                Id = 2,
                Name = "Lily",
                Email = "Lily@"
            };
            var Persons=new List<Person>{michael, Lily };
            return Persons;
        }
        //呼叫的查詢條件
        public IEnumerable<Person> GetByID(int id){
            return GetALL().Where(x=>x.Id==id);
        }
    }
}