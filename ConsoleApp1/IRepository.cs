using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetOne(Func<T, bool> predicate);
        void Add(T item);
    }
}
