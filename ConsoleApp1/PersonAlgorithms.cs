using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class PersonAlgorithms : IAlgorithm<Person>
    {
        IEnumerable<Person> IAlgorithm<Person>.Sort<T>(IEnumerable<Person> persons)
        {
            return persons.OrderBy(x => x.Age);
        }
    }
}
