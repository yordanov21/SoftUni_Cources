namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value,
             IAbstractBinaryTree<T> leftChild,
             IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            return DFSPreOrder(this, indent);
        }

        public string DFSPreOrder(IAbstractBinaryTree<T> node, int indent)
        {
            string result = new string(' ', indent) + node.Value + "\r\n";

            if (node.LeftChild != null)
            {
                result += DFSPreOrder(node.LeftChild, indent + 2);
            }

            if (node.RightChild != null)
            {
                result += DFSPreOrder(node.RightChild, indent + 2);
            }

            return result;
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var root = this;
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            InOrder(root, ref result);
            return result;
        }

        public void InOrder(IAbstractBinaryTree<T> node, ref List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                InOrder(node.LeftChild, ref result);
            }

            result.Add(node);

            if (node.RightChild != null)
            {
                InOrder(node.RightChild, ref result);
            }
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var root = this;
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PostOrder(root, ref result);
            return result;
        }

        public void PostOrder(IAbstractBinaryTree<T> node, ref List<IAbstractBinaryTree<T>> result)
        {
            if (node.LeftChild != null)
            {
                PostOrder(node.LeftChild, ref result);
            }

            if (node.RightChild != null)
            {
                PostOrder(node.RightChild, ref result);
            }

            result.Add(node);
        }


        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var root = this;
            List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();
            PreOrder(root, ref result);
            return result;
        }

        public void PreOrder(IAbstractBinaryTree<T> node, ref List<IAbstractBinaryTree<T>> result)
        {
            result.Add(node);

            if (node.LeftChild != null)
            {
                PreOrder(node.LeftChild, ref result);
            }

            if (node.RightChild != null)
            {
                PreOrder(node.RightChild, ref result);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }

        }
    }
}
