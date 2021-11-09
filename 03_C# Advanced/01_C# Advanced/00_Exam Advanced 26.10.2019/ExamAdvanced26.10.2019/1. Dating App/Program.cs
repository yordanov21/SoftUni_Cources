using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var malesArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var femalesArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> females = new Queue<int>();
            Stack<int> males = new Stack<int>();


            for (int i = 0; i <malesArr.Length ; i++)
            {
                males.Push(malesArr[i]);
            }

            for (int i = 0; i < femalesArr.Length; i++)
            {
                females.Enqueue(femalesArr[i]);
            }

            int matchesCount = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                int currentMale = males.Peek();
                int currentFemale = females.Peek();

                if (currentMale <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (currentFemale <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {
                    males.Pop();
                    males.Pop();
                    continue;
                }
                if (currentFemale% 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }
                   
                    continue;
                }

                if (currentMale == currentFemale)
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Pop();
                    males.Push(currentMale - 2);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");
            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ",females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
