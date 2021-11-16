using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Data
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> 
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            this.heap = new List<T>();
        }

        public List<T> GetList { get { return heap; } }

        public int Size { get { return heap.Count; } }

        public T Dequeue()
        {
            T top = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);
            return top;
        }

        public void Add(T element)
        {
            heap.Add(element);

            Heapify(heap.Count - 1);
        }

        public T Peek()
        {
            return heap[0];
        }


        private void HeapifyDown(int index)
        {
            int leftChildIdx = 2 * index + 1;
            int rightChildIdx = 2 * index + 2;
            int maxChildIdx = leftChildIdx;

            if (leftChildIdx >= heap.Count)
            {
                return;
            }

            if (rightChildIdx < heap.Count &&
                heap[leftChildIdx].CompareTo(heap[rightChildIdx]) < 0)
            {
                maxChildIdx = rightChildIdx;
            }

            if (heap[index].CompareTo(heap[maxChildIdx]) < 0)
            {

                T temp = heap[index];
                heap[index] = heap[maxChildIdx];
                heap[maxChildIdx] = temp;

                HeapifyDown(maxChildIdx);
            }
        }

        private void Heapify(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[parentIndex];
                heap[parentIndex] = temp;

                Heapify(parentIndex);
            }
        }
    }
}
