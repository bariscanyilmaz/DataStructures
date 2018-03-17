using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean aBoolean = true;
            char aChar = 'C';
            string aString = "merhaba";
            int aInt = 1231;

            Stack stack = new Stack();
            stack.Push(aBoolean);
            stack.Push(aChar);
            stack.Push(aString);
            stack.Push(aInt);

            object popItem = stack.Pop();
            Console.WriteLine(popItem);
            object popItem2 = stack.Pop();
            Console.WriteLine(popItem2);
            stack.Top();

        }
    }

    class StackNode
    {
        private object data;
        private StackNode next;

        public StackNode(object dataValue):this(dataValue,null)
        { }

        public StackNode(object dataValue,StackNode nextValue)
        {
            data = dataValue;
            next = nextValue;
        }

        public object Data
        {
            get { return data; }
        }

        public StackNode Next
        {
            get { return next; }
            set { next = value; }
        }

    }

    class Stack
    {
        private StackNode top;
        private StackNode last;
        public void Push(object inserItem)
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    top = new StackNode(inserItem);
                }
                else
                {
                    top = new StackNode(inserItem,top);
                    
                }
            }
        }

        public object Pop()
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    throw new Exception();
                }

                object popItem = top.Data;

                if (top==last)
                {
                    top = last = null;
                }
                else
                {
                    top = top.Next;
                }

                return popItem;
            }
        }

        public void Top()
        {
            lock (this)
            {
                Console.WriteLine(top.Data);
            }
        }



        public bool IsEmpty()
        {
            return top == null;
        }
    }
}
