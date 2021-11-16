using System;
using System.Collections.Generic;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node<int> note1 = new Node<int>(1);
            //Node<int> note2 = new Node<int>(2);
            //Node<int> note3 = new Node<int>(3);
            //Node<int> note4 = new Node<int>(4);
            //Node<int> note5 = new Node<int>(5);
            //Node<int> note6 = new Node<int>(10);
            //Node<int> note7 = new Node<int>(15);

            //note1.Children.Add(note2);
            //note1.Children.Add(note3);
            //note2.Children.Add(note4);
            //note2.Children.Add(note5);
            //note3.Children.Add(note6);
            //note3.Children.Add(note7);

            Node<int> rootTree = new Node<int>(7,
                                new Node<int>(19,
                                    new Node<int>(1),
                                    new Node<int>(12),
                                    new Node<int>(31)),
                                new Node<int>(21),
                                new Node<int>(14,
                                    new Node<int>(23),
                                    new Node<int>(6))
                                            );

            Tree<int> tree = new Tree<int>();
            tree.Root = rootTree;

            List<Node<int>> treeAsList = tree.BFS(tree.Root);

            foreach (var item in treeAsList)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine(new string( '*', 20));
            tree.DFS(tree.Root, 0);

            List<int> treeList = tree.listDFS(tree.Root, 0);
            for (int i = 0; i <treeList.Count; i++)
            {
                Console.Write(treeList[i] +" ");
            }
        }
    }
}
