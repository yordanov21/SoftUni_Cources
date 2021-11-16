using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLab
{
    // Max Heap
    public class PreorityQueue<T> where T : IComparable<T>
    {
        // this List can be also with Nodes, but with the array(list) is faster !!!
        private List<T> heap;
        public PreorityQueue()
        {
            this.heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public T Peek()
        {
            return heap[0];
        }

        public void Add(T element)
        {
            heap.Add(element);

            Heapify(heap.Count - 1);
        }

        public T Dequeue()
        {
            T top = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap[heap.Count - 1] = top; // you can pass this row 
            heap.RemoveAt(heap.Count - 1);

            HeapifyDown(0);
            return top;
        }

        private void HeapifyDown(int index)
        {
            int leftChildIdx = 2 * index + 1;
            int rightChildIdx = 2 * index + 2;
            int maxChildIdx = leftChildIdx;

            if(leftChildIdx >= heap.Count)
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

        public string DFSInOrder(int index, int indent)
        {
            string result = "";
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < heap.Count)
            {
                result += DFSInOrder(leftChild, indent + 3);
            }

            result += new string(' ', indent) + heap[index] + Environment.NewLine;

            if (rightChild < heap.Count)
            {
                result += DFSInOrder(rightChild, indent + 3);
            }

            return result;
        }
    }
}
