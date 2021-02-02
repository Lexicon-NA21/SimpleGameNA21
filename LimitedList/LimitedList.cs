using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LimitedList
{
    public class LimitedList<T>
    {
        private readonly int capacity;
        private readonly List<T> list;

        public int Count => list.Count;
        public bool IsFull => capacity <= Count;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            list = new List<T>(capacity);
        }

        public bool Add(T item)
        {
            if (IsFull) return false;
            list.Add(item);
            return true;
        }
    }
}
