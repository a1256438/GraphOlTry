using System.Collections.Generic;
using graph.Models;
namespace graph.Interfaces
{
     //介面
    public interface IpersonRepository
    {
       
        IEnumerable<Person> GetALL();


        IEnumerable<Person> GetByID(int id);

        
    }
}