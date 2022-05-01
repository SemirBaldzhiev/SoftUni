namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class List<T> : IAbstractList<T> where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _items[index];
            }
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            GrowIfNecessary();

            _items[Count] = item;
            ++Count;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (_items[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            GrowIfNecessary();

            for (int i = Count; i > index; --i)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            ++Count;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count - 1; ++i)
            {
                _items[i] = _items[i + 1];
            }

            --Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i< Count; ++i)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();


        private T[] DoubleArraySize(T[] array)
        {

            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; ++i)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private void GrowIfNecessary()
        {
            if (this.Count == _items.Length)
            {
                _items = DoubleArraySize(_items);
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