using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_Anhdhv.Queue_Stack
{
    public class Stack<T>
    {
        private Node<T> top;

        public Stack()
        {
            top = null;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
        }

        public T Get()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T value = top.Data;
            top = top.Next;
            return value;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }

}
