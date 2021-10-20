namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int index = 0;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex();
                return items[Count - 1 - index]
            }
            set
            {
                ValidateIndex();
                items[index] = value
            }
        }

        public int Count { get { return index }; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();

            array[index++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
			{
                if (items[i] == item)
	            {
                    return true;
	            }
			}

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
			{
                if (items[i] == item)
	            {
                    return Count - 1 - i;
	            }
			}

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            for (int i = Count; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
            this.index++;
        }

        public bool Remove(T item)
        {
            int currentIndex = IndexOf(item);

            RemoveAt(currentIndex);
            this.index--;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[Count - 1] = default;
            this.index--;
        }

         public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
			{
                yield return items[i];
			}
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();

         private T[] DoubleArraySize(T[] array)
        {

            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private void GrowIfNecessary()
        {
            if (this.index == array.Length)
            {
                array = DoubleArraySize(array);
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }
}