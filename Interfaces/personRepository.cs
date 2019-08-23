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
                Email="aaa"
            };
            var Persons=new List<Person>{michael};
            return Persons;
        }
        //呼叫的查詢條件
        public Person GetByID(int id){
            return GetALL().SingleOrDefault(x =>x.Id == id);
        }
    }
}