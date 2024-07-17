using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_Anhdhv.Queue_Stack
{
    public class Queue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public Queue()
        {
            head = null;
            tail = null;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (tail != null)
            {
                tail.Next = newNode;
            }
            tail = newNode;
            if (head == null)
            {
                head = tail;
            }
        }

        public T Get()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T value = head.Data;
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            return value;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }

}
