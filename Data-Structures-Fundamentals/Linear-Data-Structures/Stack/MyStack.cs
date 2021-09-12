using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MyStack<T>
    {
        private Node<T> top;

        public MyStack()
        {

        }

        public int Count { get; set; }

        public void Push(T element)
        {
            var newNode = new Node<T>(element);
            newNode.Next = top;

            top = newNode;
            Count++;
        }

       public T Peek()
       {
            return top.Value;
       }

        public T Pop()
        {
            T topNodeValue = top.Value;

            var newTop = top.Next;

            top.Next = null;
            top = newTop;

            Count--;

            return topNodeValue;
        }
    }
}
