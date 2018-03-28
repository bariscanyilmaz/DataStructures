using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.Insert(25);
            tree.Insert(13);
            tree.Insert(90);
            tree.Insert(7);
            tree.Insert(22);
            tree.Insert(48);
            tree.Insert(38);
            tree.Insert(110);
            tree.Insert(56);
            tree.Insert(78);
            tree.Insert(24);
            Console.WriteLine("Inorder Displaying");
            tree.InOrder(tree.Root);
            tree.DeleteNode(tree.Root,38,tree.Root);
            Console.WriteLine("22 silindikten sonra");
            Console.WriteLine("Inorder Displaying");
            tree.InOrder(tree.Root);
        }
    }

    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }

    class BinarySearchTree
    {
        public Node Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int data)
        {
            Node node = new Node(data);

            if (Root==null)
            {
                this.Root = node;
            }
            else
            {
                Node current = Root;
                Node parent = null;

                while (current!=null)
                {
                    parent = current;
                    if (data < current.Data)
                    {
                        current = current.Left;
                        if (current==null)
                        {
                            parent.Left = node;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current==null)
                        {
                            parent.Right = node;
                        }
                    }

                }
            }

        }

        public void InOrder(Node node)
        {
            if (node!=null)
            {
                InOrder(node.Left);
                Console.WriteLine(node.Data);
                InOrder(node.Right);
            }
        }

        public Node Max(Node node)
        {
            while (node!=null)
            {
                node = node.Right;
            }
            return node;
        }

        public Node Min(Node node)
        {
            while (node.Left!=null)
            {
                node = node.Left;
            }
            return node;
        }

        public Node BinarySearch(int target)
        {
           Node current = Root;
           Node temp=null;
           while (current!=null)
           {
               if (target < current.Data)
               {
                   current = current.Left;
                   
               }
               else if (target > current.Data)
               {
                   current = current.Right;
                   
               }
               else if (current.Data == target)
               {
                   temp = current;
                   current = null;// hedef bulunduktan sonra current null atandı.
               }
           }
           return temp;
        }

        public void DeleteNode(Node root,int target,Node _parentNode)
        {
            Node parentNode=_parentNode;

            if (target<root.Data)
            {

                DeleteNode(root.Left, target,root);

            }
            else if(target>root.Data)
            {
                parentNode = root;
                DeleteNode(root.Right, target,root);
            }
            else
            {
                if (parentNode.Left==root)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }
            }
            
        }
    }

   
}

