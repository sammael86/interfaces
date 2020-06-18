using System.Collections.Generic;

namespace Interfaces
{
    public interface IAlgorithm<T>
    {
        IEnumerable<T> Sort(IEnumerable<T> notSortedItems);
    }
}
