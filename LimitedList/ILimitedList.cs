using System;
using System.Collections.Generic;

namespace LimitedList
{
    public interface ILimitedList<T> : IEnumerable<T>
    {
        T this[int index] { get; }

        int Count { get; }
        bool IsFull { get; }

        void ActionAll(Action<T> action);
        bool Add(T item);
        //IEnumerator<T> GetEnumerator();
        bool Remove(T item);
    }
}