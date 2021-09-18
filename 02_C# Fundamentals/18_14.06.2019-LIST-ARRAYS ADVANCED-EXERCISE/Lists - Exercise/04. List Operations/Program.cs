using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._List_Operations
{
    class Program
    {
        static void ShiftLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.RemoveAt(0);
            }
        }
        static void ShiftRight(List<int> numbers, int count)
        {

            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count - 1);
            }
        }
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }
                string[] comand = line.Split();
                if (comand[0] == "Add")
                {
                    int comandNumber = int.Parse(comand[1]);
                    numbers.Add(comandNumber);
                }
                else if (comand[0] == "Insert"&& int.Parse(comand[2]) <= numbers.Count && int.Parse(comand[2]) >= 0)
                {
                    int comandNUmber = int.Parse(comand[1]);
                    int indexNUmber = int.Parse(comand[2]);
                    numbers.Insert(indexNUmber, comandNUmber);
                }
                else if (comand[0] == "Remove"&& int.Parse(comand[1])<=numbers.Count&& int.Parse(comand[1]) >= 0)
                {
                    int indexNumber = int.Parse(comand[1]);
                    numbers.RemoveAt(indexNumber);
                }
                else if(comand[1]=="left")
                {
                   
                        ShiftLeft(numbers, int.Parse(comand[2]));
                    
                }
                else if (comand[1] == "right")
                {
                    
                        ShiftRight(numbers, int.Parse(comand[2]));
                    
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            Console.WriteLine(string.Join(" ",numbers));

        }
    }
}
