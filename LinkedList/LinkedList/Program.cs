using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            bool aBoolean = true;
            char bChar = '$';
            int cInteger = 12312;
            string dString = "Barış Can Yılmaz";

            list.InsertAtFront(aBoolean);//true
            list.print();
            list.InsertAtFront(bChar);//$ true
            list.print();
            list.InsertAtLast(cInteger);//$ true 13212
            list.print();
            list.InsertAtLast(dString);//$ true 13212 Barış Can Yılmaz
            list.print();

            object removeObject;
            try
            {
                removeObject = list.RemoveFromFront();
                Console.WriteLine(removeObject + " removed");
                list.print();

                removeObject = list.RemoveFromBack();
                Console.WriteLine(removeObject+" removed");
                list.print();

                removeObject = list.RemoveFromFront();
                Console.WriteLine(removeObject+" removed");
                list.print();

                removeObject = list.RemoveFromBack();
                Console.WriteLine(removeObject + " removed");
                list.print();

            }
            catch (Exception e)
            {

                Console.WriteLine("Hata "+ e);

            }


        }
    }

    public class ListNode
    {
        private object data;
        private ListNode next;

        public ListNode(object DataValeu)
        {
            data = DataValeu;
            next = null;
        }

        public ListNode(object DataValue,ListNode nextNode)
        {
            data = DataValue;
            next = nextNode;
        }

        public ListNode Next
        {
            get { return next; }
            set { next = value; }
        }

        public Object Data
        {
            get { return data; }
        }


    }

    public class List
    {
        private ListNode firstNode;
        private ListNode lastNode;
        private string name;

        public List(string listName)
        {
            name = listName;
            firstNode = lastNode = null;
        }

        public List():this("list")
        {

        }

        public void InsertAtFront(object insertItem)
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    firstNode = lastNode = new ListNode(insertItem);
                }
                else
                {
                    firstNode = new ListNode(insertItem, firstNode);
                }

            }
        }

        public void InsertAtLast(object insertItem)
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    firstNode = lastNode = new ListNode(insertItem);
                }
                else
                {
                    lastNode = lastNode.Next = new ListNode(insertItem);
                }

            }
        }
        
        public object RemoveFromFront()
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    throw new Exception();
                }
                
                object removeItem = firstNode.Data;
               
                if (firstNode==lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    firstNode = firstNode.Next;//firstNode a ikinci node atanır
                }

                return removeItem;

            }
        }

        public object RemoveFromBack()
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    throw new Exception();
                }

                object removeItem = lastNode.Data;

                if (firstNode==lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    ListNode current = firstNode;
                    while (current.Next!=lastNode)//lastNode bir öncesi
                    {
                        current = current.Next;
                    }

                    lastNode = current;
                    current.Next = null;
                }

                return removeItem;
            }
        }
        
        public Boolean IsEmpty()
        {
            return firstNode == null;
        }

        public virtual void print()
        {
            lock (this)
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Lisr is empty");
                    return;
                }


                Console.WriteLine("the name is "+name);
                ListNode current = firstNode;

                while (current!=null)
                {
                    Console.Write(current.Data+" ");
                    current=current.Next;
                }

                Console.WriteLine();
            }
        }
    }
}
