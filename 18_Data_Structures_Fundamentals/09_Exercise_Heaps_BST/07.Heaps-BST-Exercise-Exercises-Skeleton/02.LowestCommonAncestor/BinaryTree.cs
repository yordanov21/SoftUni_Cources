namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;  // attach parent the present tree in this way
            }
            this.RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this; // attach parent the present tree in this way
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
           
            var firstNode = this.Search(first);
            var secondNode = this.Search(second);
            var firstNodeAncestors = GetAncestors(firstNode);
            var secondNodeAncestors = GetAncestors(secondNode);

            var intersection = firstNodeAncestors.Intersect(secondNodeAncestors);
            return intersection.ToArray()[0];
        }



        private List<T> GetAncestors(IAbstractBinaryTree<T> node)
        {
            List<T> ancerstors = new List<T>();
            while(node != null)
            {
                ancerstors.Add(node.Value);
                node = node.Parent;
            }

            return ancerstors;
        }


        public IAbstractBinaryTree<T> Search(T element)
        {
            return Search(element, this);
        }

        public IAbstractBinaryTree<T> Search(T element, BinaryTree<T> node)
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
