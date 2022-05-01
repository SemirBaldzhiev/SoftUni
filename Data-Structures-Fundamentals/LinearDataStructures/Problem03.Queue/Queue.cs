namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T> where T : IComparable<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Item.CompareTo(item) == 0)
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();
            T itemToRem = _head.Item;
            var newHead = _head.Next;

            _head.Next = null;
            _head = newHead;
            --Count;

            return itemToRem;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);


            if (_head == null)
            {
                _head = newNode;
                ++Count;
                return;
            }

            var currentNode = _head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }


            currentNode.Next = newNode;
            ++Count;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Empty stack");
            }
        }
    }
}