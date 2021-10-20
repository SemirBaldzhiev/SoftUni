namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, null, null);
            
            if (Count == 0)
	        {
                head = newNode;
                tail = newNode;
                Count++;
                return;
	        }

            var oldHead = head;
            oldHead.Previous = newNode;
            head = newNode;
            head.Next = oldHead;

        }

        public void AddLast(T item)
        {
           var newNode = new Node<T>(item, null, null);
            
            if (Count == 0)
	        {
                head = newNode;
                tail = newNode;
                Count++;
                return;
	        }

            var oldTail = tail;
            oldTail.Next = newNode;
            tail = newNode;
            tail.Previous = oldTail;
        }

        public T GetFirst()
        {
            ValidateCollection();
            return head.Item;
        }

        public T GetLast()
        {
            ValidateCollection();
            return tail.Item;
        }

        public T RemoveFirst()
        {
            ValidateCollection();

            var oldHead = head;
            head = head.Next;

            Count--;

            return oldHead.Item;
        }

        public T RemoveLast()
        {
            ValidateCollection();
           
            var oldTail = tail;
            tail = tail.Previous;

            Count--;
            return oldTail.Item;
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

        private void ValidateCollection()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
	
        }
    }
}