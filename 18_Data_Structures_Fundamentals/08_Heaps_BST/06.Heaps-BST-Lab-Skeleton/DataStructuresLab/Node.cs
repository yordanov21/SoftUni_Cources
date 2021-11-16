using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLab
{
    //Bimary node
    public class Node<T>
    {
        public Node()
        {

        }

        public Node(T value, Node<T> leftChild = null, Node<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }
    }
}
