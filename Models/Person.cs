namespace graph.Models
{
    //Model
    public class Person
    {
        public int Id  {get;set;}
        public string Name {get;set;}

        public string Email{get;set;}

        public Person[] Parents{get;set;}

    }
}