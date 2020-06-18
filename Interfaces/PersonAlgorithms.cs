using System.Collections.Generic;
using System.Linq;

namespace Interfaces
{
    public class PersonAlgorithms : IAlgorithm<Person>
    {
        IEnumerable<Person> IAlgorithm<Person>.Sort(IEnumerable<Person> persons)
        {
            return persons.OrderBy(x => x.Age);
        }
    }
}
