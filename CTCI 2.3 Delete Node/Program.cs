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

            Node head = CreateSinglyLinkedList(10);

            int next = rnd.Next(10);

            Node n = GetNode(next, head);

            PrintNodes(head);

            Console.WriteLine();
            Console.WriteLine("Deleting node " + next + " value " + n.Data);
            Console.WriteLine();

            DeleteNode(n);

            PrintNodes(head);                

            Console.ReadLine();
        }

        //////////////////////////////////////////////////////////////
        //        
        // 1. Method receives a passed node object
        // 2. Overwrite the passed node's DATA and NEXT fields with
        //    the values of the next node's DATA and NEXT.
        //    The current node is now a clone of the next node.
        //    The next node is now orphaned. Garbage collection will
        //    delete it.
        //     
        // Note:       This algo will not work on the last node of
        //             a list.
        //
        // Note:       This algo is a slight-of-hand trick. It doesn't
        //             actually delete the current node.
        // 
        // Complexity: Algorithm runs in O(1) time
        //             The number of steps is constant regardless of 
        //             input.
        //
        //             Algorithm requires O(1) space
        //             Memory is constant regardless of input.
        //
        private static void DeleteNode(Node node_to_delete)
        {
            if ((node_to_delete == null) || (node_to_delete.next == null))
            {
                // Cannot delete the last node in the list.
                // Should never receive null node to delete
                throw new Exception("Can delete neither the last node in list, nor a null node.");
            }

            // copy next node's values over current node's
            node_to_delete.Data = node_to_delete.next.Data;
            node_to_delete.next = node_to_delete.next.next;

            // (garbage collection will delete the orphaned next node)
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

        private static void PrintNodes(Node passed_n)
        {
            Console.WriteLine("Nodes in list:");

            while (passed_n != null)
            {
                Console.Write(passed_n.Data + ", ");

                passed_n = passed_n.next;
            }
            Console.WriteLine();
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
