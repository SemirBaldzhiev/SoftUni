using System;

namespace CustomList
{
    public class MyList<T>
    {
        private T[] array;
        private int index = 0;
        public MyList(int initialCapacity = 4)
        {
            array = new T[initialCapacity];
        }

        public int Count { get { return index; } }

        public T this[int i]
        {
            get
            {
                return array[i];
            }

            set
            {
                array[i] = value;
            }
        }

        public void Add(T element)
        {
            GrowIfNecessary();

            array[index++] = element;
        }

        public void Insert(T element, int index)
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
