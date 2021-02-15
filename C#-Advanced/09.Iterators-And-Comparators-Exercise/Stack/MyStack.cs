using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> items;

        public MyStack()
        {
            items = new List<T>();
        }

        public MyStack(List<T> items)
        {
            this.items = items;
        }

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            int index = items.Count - 1;

            if (index < 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T item = items[index];
            items.Remove(item);

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
