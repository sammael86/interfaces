using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IAlgorithm<T>
    {
        IEnumerable<T> Sort<T1>(IEnumerable<T> notSortedItems);
    }
}
