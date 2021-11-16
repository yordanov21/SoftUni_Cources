using System;
using Problem01.List;
using Problem03.Queue;

namespace Liner_Data_Structures_Implement
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>();

            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(i + 1);
            //}

            Queue<int> newQueue = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                newQueue.Enqueue(i);
            }


            bool isThere = newQueue.Contains(9);

            Console.WriteLine(isThere);
        }
    }
}
