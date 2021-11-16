using System;
using System.Collections.Generic;

namespace DataStructuresLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //       1
            //    5     7
            //  2   3 9   11

            Node<int> root = new Node<int>(1,
                                      new Node<int>(5,
                                            new Node<int>(2),
                                            new Node<int>(3)),
                                      new Node<int>(7,
                                            new Node<int>(9),
                                            new Node<int>(11))
                                      );

            BinaryTree<int> tree = new BinaryTree<int>(root);

            Console.WriteLine("PreOrder:");
            Console.WriteLine(tree.DFSPreOrder(tree.Root,0));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("InOrder:");
            Console.WriteLine(tree.DFSInOrder(tree.Root,0));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("PostOrder:");
            Console.WriteLine(tree.DFSPostOrder(tree.Root,0));


            // Heap
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(new string('-', 50));
            var integerHeap = new Heap<int>();
            var elements = new List<int> { 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Add(el);
            }

            Console.WriteLine(integerHeap.DFSInOrder(0,0));


            Console.WriteLine(new string('-', 50));
            Console.WriteLine(new string('-', 50));
            var integerPreorityQueue = new PreorityQueue<int>();
            var elementsQueue = new List<int> { 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerPreorityQueue.Add(el);
            }

            while(integerPreorityQueue.Size>0)
            {
                Console.WriteLine($"Max element: {integerPreorityQueue.Dequeue()}");
            }



            List<int> listBST = new List<int>();
            for (int i = 0; i < 50; i+=2)
            {
                listBST.Add(i);
            }

            BinarySearchTree<int> BST = new BinarySearchTree<int>();
         //   BST.Insert()

        } 
    }
}
