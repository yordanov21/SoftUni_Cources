using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var setsLenght = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int setN = setsLenght[0];
            int setM = setsLenght[1];
           List < int >numbersN= new List<int>();
           List < int >numbersM= new List<int>();

            for (int i = 0; i < setN; i++)
            {
             int num=int.Parse(Console.ReadLine());
                 numbersN.Add(num);               
            }
            for (int i = 0; i < setM; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbersM.Add(num);
            }
            HashSet<int> repeatNumbers = new HashSet<int>();
            if (setN >= setM)
            {
                foreach (var num in numbersN)
                {
                    if (numbersM.Contains(num))
                    {
                        repeatNumbers.Add(num);
                    }
                }
            }
            else
            {
                foreach (var num in numbersM)
                {
                    if (numbersN.Contains(num))
                    {
                        repeatNumbers.Add(num);
                    }
                }
            }
            Console.WriteLine(string.Join(" ",repeatNumbers));
        }
    }
}
