using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            bool aBoolean = true;
            char aChar = 'B';
            int aInt = 312421;
            string aString = "Hello";

            Queue queue = new Queue();
            queue.Enqueue(aBoolean);
            queue.Enqueue(aChar);
            queue.Enqueue(aInt);
            queue.Enqueue(aString);

            object data = queue.Dequeue();
       
            Console.WriteLine(data);

            object data2 = queue.Dequeue();
            Console.WriteLine(data2);

            object data3 = queue.Dequeue();
            Console.WriteLine(data3);

            object data4 = queue.Dequeue();
            Console.WriteLine(data4);
        }
    }


    class QueueNode
    {
        private object data;
        private QueueNode next;

        public QueueNode(object dataValue):this(dataValue,null)
        {
            data = dataValue;
        }

        public QueueNode(object dataValue,QueueNode nextNode)
        {
            data = dataValue;
            next = nextNode;
        }

        public object Data
        {
            get { return data; }
        }

        public QueueNode Next
        {
            get { return next; }
            set { next = value; }
        }

    }


    class Queue
    {
        private QueueNode head;
        private QueueNode tail;

        public void Enqueue(object insertItem)
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    head = tail = new QueueNode(insertItem);
                }
                else
                {
                    tail =tail.Next= new QueueNode(insertItem);
                }
            }
        }

        public object Dequeue()
        {
            lock (this)
            {

                if (IsEmpty())
                {
                    throw new Exception();
                }

                object dequeueItem = head.Data;
                if (head==tail)
                {
                    head = tail = null;
                }
                else
                {
                    head = head.Next;
                }

                return dequeueItem;
            }
        }

        public bool IsEmpty()
        {
            return head == null;
        }
    }
}
