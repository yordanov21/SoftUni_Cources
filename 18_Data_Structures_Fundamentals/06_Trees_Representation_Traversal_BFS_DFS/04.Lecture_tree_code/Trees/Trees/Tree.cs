using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Tree<T>
    {
        public Node<T> Root { get; set; }

        public List<Node<T>> BFS(Node<T> root)
        {
            List<Node<T>> list = new List<Node<T>>();

            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return list;
        }

        public void DFS(Node<T> node, int level)
        {
            Console.Write(new string('-',level));
            Console.WriteLine(node.Value);

            foreach (var child in node.Children)
            {
                DFS(child, level + 2);
            }
        }

        public List<T> listDFS(Node<T> node, int level)
        {
            List<T> list = new List<T>();

            foreach (var child in node.Children)
            {
                list.AddRange(listDFS(child, level + 6));
            }

            list.Add(node.Value);

            return list;
        }
    }
}
