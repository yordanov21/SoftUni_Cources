namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public BinarySearchTree()
        {
            this._elements = new List<T>();
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this._elements = new List<T>();
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Contains(T element)
        {
            return Contains(element, this.Root);
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
                return Contains(element, node.LeftChild);
            }
            else
            {
                return Contains(element, node.RightChild);
            }

        }

        public void Insert(T element)
        {
            Insert(element, this.Root);

            // insert element in preority queue
            _elements.Add(element);
            Heapify(_elements.Count - 1);
            for (int i = 0; i < _elements.Count; i++)
            {
                Console.WriteLine(_elements[i]);
            }
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (_elements[index].CompareTo(_elements[parentIndex]) > 0)
            {
                T temp = _elements[index];
                _elements[index] = _elements[parentIndex];
                _elements[parentIndex] = temp;

                Heapify(parentIndex);
            }
        }

        public void Insert(T element, Node<T> node)
        {
            // create root
            if (node == null)
            {
                node = new Node<T>(element, null, null);
                this.Root = node;
                this.Count++;
                return;
            }
            else
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = new Node<T>(element, null, null);
                        this.Count++;
                        return;
                    }

                    Insert(element, node.LeftChild);
                }
                else
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = new Node<T>(element, null, null);
                        this.Count++;
                        return;
                    }

                    Insert(element, node.RightChild);
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return Search(element, this.Root);
        }

        public IAbstractBinarySearchTree<T> Search(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(element) == 0)
            {
                return new BinarySearchTree<T>(node);
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


        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.Root);
        }

        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.LeftChild);
            action(node.Value);
            this.EachInOrder(action, node.RightChild);

        }

        public List<T> Range(T lower, T upper)
        {
            List<T> result = new List<T>();

            Range(lower, upper, this.Root, ref result); // it's work also without ref, debug to understant why

            return result;
        }

        private void Range(T startRange, T endRange, Node<T> node, ref List<T> result)
        {
            if (node == null)
            {
                return;
            }

            var inStartRange = startRange.CompareTo(node.Value);
            var inEndRange = endRange.CompareTo(node.Value);

            if (inStartRange < 0)
            {
                this.Range(startRange, endRange, node.LeftChild, ref result);
            }

            if (inStartRange <= 0 && inEndRange >= 0)
            {
                result.Add(node.Value);
            }

            if (inEndRange > 0)
            {
                this.Range(startRange, endRange, node.RightChild, ref result);
            }
        }

        public void DeleteMin()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("NO elements");
            }
            this.Root.LeftChild = this.DeleteMin(this.Root.LeftChild);
        }

        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                this.Count--;
                return node.RightChild;
            }

            node.LeftChild = this.DeleteMin(node.LeftChild);
            return node;

        }

        public void DeleteMax()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("NO elements");
            }

            this.Root.RightChild = this.DeleteMax(this.Root.RightChild);

        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if (node.RightChild == null)
            {
                this.Count--;
                return node.LeftChild;
            }

            node.RightChild = this.DeleteMax(node.RightChild);
            return node;

        }

        private void HeapifyDown(int index)
        {
            int leftChildIdx = 2 * index + 1;
            int rightChildIdx = 2 * index + 2;
            int maxChildIdx = leftChildIdx;

            if (leftChildIdx >= _elements.Count)
            {
                return;
            }

            if (rightChildIdx < _elements.Count &&
                _elements[leftChildIdx].CompareTo(_elements[rightChildIdx]) < 0)
            {
                maxChildIdx = rightChildIdx;
            }

            if (_elements[index].CompareTo(_elements[maxChildIdx]) < 0)
            {

                T temp = _elements[index];
                _elements[index] = _elements[maxChildIdx];
                _elements[maxChildIdx] = temp;

                HeapifyDown(maxChildIdx);
            }
        }

        public int GetRank(T element)
        {
            // Implement a method which returns the count of elements smaller than a given value. 
            int tempCount = 0;

            GetRank(element, this.Root, ref tempCount);

            return tempCount;
        }

        private void GetRank(T element, Node<T> node, ref int count)
        {
            if (node == null)
            {
                return;
            }

            if (element.CompareTo(node.Value) > 0)
            {
                count++;
            }

            if (node.LeftChild != null && element.CompareTo(node.LeftChild.Value) > 0)
            {
                GetRank(element, node.LeftChild, ref count);

            }

            if (node.RightChild != null && element.CompareTo(node.RightChild.Value) > 0)
            {
                GetRank(element, node.RightChild, ref count);
            }

            // go to right node to check right part of the node
            if (node.RightChild != null && element.CompareTo(node.RightChild.Value) < 0)
            {
                GetRank(element, node.RightChild, ref count);
            }

        }


    }
}
