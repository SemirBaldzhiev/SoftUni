using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> items)
        {
            this.items = items;
            index = 0;
        }

        public bool HasNext()
        {
            return index < this.items.Count - 1;
        }

        public bool Move()
        {
            bool hasNext = HasNext();

            if (hasNext)
            {
                index++;
            }

            return hasNext;
        }
        public void Print()
        {
            if (index >= items.Count)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            else
            {
                Console.WriteLine(this.items[index]);
            }
        }
    }
}
