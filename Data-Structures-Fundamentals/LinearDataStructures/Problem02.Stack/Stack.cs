namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T> where T : IComparable<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = _top;

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

        public T Peek()
        {
            EnsureNotEmpty();
            return _top.Item;
        }

        public T Pop()
        {
            EnsureNotEmpty();
            T itemToRem = _top.Item;
            var newTop = _top.Next;

            _top.Next = null;
            _top = newTop;
            --Count;

            return itemToRem;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item, _top);
            _top = newNode;
            ++Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _top;

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
            if (_top == null)
            {
                throw new InvalidOperationException("Empty stack");
            }
        }
    }


}