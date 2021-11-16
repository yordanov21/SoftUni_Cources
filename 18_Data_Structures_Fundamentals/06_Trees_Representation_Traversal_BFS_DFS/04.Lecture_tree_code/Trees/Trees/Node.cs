using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public Node(T value, params Node<T>[] children)
        {
            this.Value = value;
            this.Children = children.ToList();
        }

        public T Value;

        public List<Node<T>> Children;
    }
}
