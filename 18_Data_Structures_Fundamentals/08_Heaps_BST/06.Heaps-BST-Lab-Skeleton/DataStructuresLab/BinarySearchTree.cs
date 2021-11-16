using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLab
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree()
        {

        }
        public BinarySearchTree(Node<T> root)
        {
            Root = root;
        }
        public Node<T> Root { get; set; }


        public void Insert(T element, Node<T> node)
        {
            // create root
            if (node == null)
            {
                node = new Node<T>(element);
                Root = node;
                return;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(element);
                    return;
                }

                Insert(element, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(element);
                    return;
                }

                Insert(element, node.RightChild);
            }

        }

        public bool Contains(T element, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.CompareTo(element) == 0)
            {
                return true;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return  Contains(element, node.LeftChild);
            }
            else
            {
                return  Contains(element, node.RightChild);
            }

        }

        public Node<T> Search(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(element) == 0)
            {
                return node;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return Search(element, node.LeftChild);
            }
            else
            {
                return Search(element, node.RightChild);
            }

        }
    }
}
