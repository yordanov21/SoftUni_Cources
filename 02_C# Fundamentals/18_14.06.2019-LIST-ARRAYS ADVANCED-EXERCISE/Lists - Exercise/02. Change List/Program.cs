using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "end")
                {
                    break;
                }
                string[] element = comand.Split();
                int elementNumber = int.Parse(element[1]);
               
                if (element[0] == "Delete")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers.Remove(elementNumber);
                    }
                 
                }
                if (element[0] == "Insert")
                {
                    int positionNumber = int.Parse(element[2]);
                    numbers.Insert(positionNumber,elementNumber);
                }
            }
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
