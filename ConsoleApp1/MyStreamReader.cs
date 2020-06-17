using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class MyStreamReader<T> : IEnumerable<T>, IDisposable
    {
        private string data;
        private ISerializer serializer;

        public MyStreamReader(string data, ISerializer serializer)
        {
            this.data = data;
            this.serializer = serializer;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T element in serializer.Deserialize<T[]>(data))
            {
                yield return element;
            }
        }

        ~MyStreamReader()
        {
            Dispose(false);
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (T element in serializer.Deserialize<T[]>(data))
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
