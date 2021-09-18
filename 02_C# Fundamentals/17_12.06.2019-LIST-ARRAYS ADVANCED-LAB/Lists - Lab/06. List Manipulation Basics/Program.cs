using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while(true)
            {
                string comand = Console.ReadLine();
                if (comand == "end")
                {
                    break;
                }
                string[] parts = comand.Split().ToArray();
               
                switch (parts[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(parts[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(parts[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int indexsToRemove = int.Parse(parts[1]);
                        numbers.RemoveAt(indexsToRemove);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(parts[1]);
                        int indexsToInsert = int.Parse(parts[2]);
                        numbers.Insert(indexsToInsert, numberToInsert);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
