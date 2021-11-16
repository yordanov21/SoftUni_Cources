namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size { get { return _elements.Count; } }

        public T Dequeue()
        {
            if(this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            // swap elements
            T top = this._elements[0];
            this._elements[0] = this._elements[this._elements.Count - 1];

            // remove last element
            this._elements.RemoveAt(this._elements.Count - 1);

            HeapifyDown(0);

            return top;
        }

        public void Add(T element)
        {
            _elements.Add(element);

            HeapifyDown(_elements.Count - 1);
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return _elements[0];
        }

        private void HeapifyUp(int index)
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

                HeapifyUp(parentIndex);
            }
        }

        private void HeapifyDown(int index)
        {
            var leftChildIndex = index * 2 + 1;
            if(leftChildIndex >= this.Size)
            {
                leftChildIndex = -1;
            }
            var rightChildIndex = index * 2 + 2;
            var smallerChildIndex = leftChildIndex;
            if(_elements[leftChildIndex].CompareTo(_elements[rightChildIndex]) > 0)
            {
                smallerChildIndex = rightChildIndex;
            }

            while(leftChildIndex!=-1&& _elements[index].CompareTo(_elements[smallerChildIndex]) > 0)
            {
                T temp = _elements[index];
                 _elements[index] = _elements[smallerChildIndex];
                 _elements[smallerChildIndex] = temp;
            }
            //if (index == 0)
            //{
            //    return;
            //}

            //int parentIndex = (index - 1) / 2;

            //if (_elements[index].CompareTo(_elements[parentIndex]) < 0)
            //{
            //    T temp = _elements[index];
            //    _elements[index] = _elements[parentIndex];
            //    _elements[parentIndex] = temp;

            //    HeapifyDown(parentIndex);
            //}
        }

        private int FindSmallerChildIndex(int leftChildIndex, int rightChildIndex)
        {
            throw new NotImplementedException();
        }
    }
}
