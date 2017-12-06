using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_2._3_Delete_Node
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintHeaderMsg(2, 3, "Delete Node");

            Random rnd = new Random();

            Node head = CreateSinglyLinkedList(1000);

            int next = rnd.Next(1000);

            Node n = GetNode(next, head);

            DeleteNode(n);

            Console.ReadLine();
        }

        private static void DeleteNode(Node node_to_delete)
        {
            if ((node_to_delete == null) || (node_to_delete.next == null))
            {
                throw new Exception();
            }

            // copy next node over current node
            node_to_delete.Data = node_to_delete.next.Data;

            // (garbage collection will delete the orphaned node)
        }

        private static Node GetNode(int node_to_delete, Node passed_head)
        {
            Node runner = passed_head;

            for (int i = 0; i < node_to_delete; ++i)
            {
                runner = runner.next;
            }

            return runner;
        }

        private static Node CreateSinglyLinkedList(int count)
        {
            if (count < 1)
                return null;

            Random rnd = new Random();

            Node head = new Node(rnd.Next(0, 1000));

            Node n = head;

            for (int i = 0; i < count - 1; ++i)
            {
                n.next = new Node(rnd.Next(0, 1000));
                n = n.next;
            }

            return head;
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }

    class Node
    {
        public Node next = null;

        public int Data;

        public Node(int d) => Data = d;
    }
}
