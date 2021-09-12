namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = head;

            while(currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements in the queue!");
            }

            var oldHead = head;
            head = oldHead.Next;
            Count--;

            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);

            if (Count == 0)
            {
                head = newNode;
                tail = newNode;
                Count++;
                return;
            }

            tail.Next = newNode;  //1 2
            tail = newNode;
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements in the queue!");
            }
            return head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

    }
}