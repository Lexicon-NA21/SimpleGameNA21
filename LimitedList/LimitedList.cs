using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace LimitedList
{
    public class LimitedList<T> :  IEnumerable<T>
    {
        private readonly int capacity;
        protected readonly List<T> list;
        public int Count => list.Count;
        public bool IsFull => capacity <= Count;
        public T this[int index] => list[index];

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            list = new List<T>(capacity);
        }

        public virtual bool Add(T item)
        {
            if (IsFull || item is null) return false;
            list.Add(item);
            return true;
        }

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                //...
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void ActionAll(Action<T> action)
        {
            list.ForEach(m => action?.Invoke(m));
        }

    }
}
