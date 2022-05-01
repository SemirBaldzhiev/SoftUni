namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, _head);
            _head = newNode;
            ++Count;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item, null);

            if (_head is null)
                _head = newNode;
            else
            {
                var current = _head;

                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            ++Count;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();
            return _head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            var current = _head;
            while (current.Next != null)
                current = current.Next;

            return current.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var headItem = _head.Item;
            var newHead = _head.Next;
            _head.Next = null;
            _head = newHead;
            --Count;

            return headItem;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            if (_head.Next == null)
                return RemoveFirst();

            var current = _head;

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            var lastItem = current.Next.Item;
            current.Next = null;
            --Count;

            return lastItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException("Empty linked list");
        }
    }
}