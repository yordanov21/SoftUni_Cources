using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> originalNumbers = numbers;
            bool count = true;
            while (true)
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
                        count=false;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(parts[1]);
                        numbers.Remove(numberToRemove);
                        count = false;
                        break;
                    case "RemoveAt":
                        int indexsToRemove = int.Parse(parts[1]);
                        numbers.RemoveAt(indexsToRemove);
                        count = false;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(parts[1]);
                        int indexsToInsert = int.Parse(parts[2]);
                        numbers.Insert(indexsToInsert, numberToInsert);
                        count = false;
                        break;

                    case "Contains":
                        int numberToContain = int.Parse(parts[1]);
                        if (numbers.Contains(numberToContain))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        List<int> evenNumbers = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {

                            if (numbers[i] % 2 == 0)
                            {
                                evenNumbers.Add(numbers[i]);

                            }
                        }
                        Console.WriteLine(string.Join(" ", evenNumbers));
                        break;
                    case "PrintOdd":
                        List<int> oddNumbers = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {

                            if (numbers[i] % 2 != 0)
                            {
                                oddNumbers.Add(numbers[i]);

                            }
                        }
                        Console.WriteLine(string.Join(" ", oddNumbers));
                        break;
                    case "GetSum":
                        numbers.Sum();
                        Console.WriteLine(numbers.Sum());
                        break;
                    case "Filter":
                        string symbol = parts[1];
                        int numberToCheck = int.Parse(parts[2]);
                        if (symbol == "<")
                        {
                            List<int> checkedNumbers = new List<int>();
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numberToCheck > numbers[i])
                                {
                                    checkedNumbers.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", checkedNumbers));

                        }
                        else if (symbol == ">")
                        {
                            List<int> checkedNumbers = new List<int>();
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numberToCheck < numbers[i])
                                {
                                    checkedNumbers.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", checkedNumbers));

                        }
                        if (symbol == "<=")
                        {
                            List<int> checkedNumbers = new List<int>();
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numberToCheck >= numbers[i])
                                {
                                    checkedNumbers.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", checkedNumbers));

                        }
                        else if (symbol == ">=")
                        {
                            List<int> checkedNumbers = new List<int>();
                            for (int i = 0; i < numbers.Count; i++)
                            {
                                if (numberToCheck <= numbers[i])
                                {
                                    checkedNumbers.Add(numbers[i]);
                                }
                            }
                            Console.WriteLine(string.Join(" ", checkedNumbers));

                        }
                        break;
                }
                      
            }
            if (count == false)
            {
                Console.WriteLine(string.Join(" ", numbers));

            }
        }
    }
}
