using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Stack<string> inputStack = new Stack<string>(input);
            Queue<char> hallsQueue = new Queue<char>();
            Dictionary<char, List<int>> halls = new Dictionary<char, List<int>>();

            int currentCapacity = 0;
            char currentHall = char.MinValue;

            while (true)
            {
                if (inputStack.Count == 0)
                {
                    break;
                }

                var currentInput = inputStack.Peek();
                int n;
                bool isDigit = int.TryParse(currentInput, out n);
                if (isDigit == true)
                {

                    currentCapacity += n;
                    if (currentCapacity <= hallCapacity && halls.Count > 0)
                    {
                        if (halls.Count > 0)
                        {
                            halls[currentHall].Add(n);
                            inputStack.Pop();
                            continue;
                        }

                    }
                    else if (halls.Count > 0 && halls[currentHall].Count > 0)
                    {
                        Console.Write($"{currentHall} -> ");
                        var people = halls[currentHall];
                        Console.WriteLine(string.Join(", ", people));
                        halls.Remove(currentHall);
                        hallsQueue.Dequeue();

                        if (hallsQueue.Count > 0)
                        {
                            currentHall = hallsQueue.Peek();
                        }

                        currentCapacity = n;
                        if (currentCapacity <= hallCapacity && halls.Count > 0)
                        {
                            if (halls.Count > 0)
                            {
                                halls[currentHall].Add(n);
                            }

                        }

                        inputStack.Pop();
                        continue;
                    }
                    else
                    {
                        currentCapacity = 0;
                        inputStack.Pop();
                        continue;
                    }

                }
                else
                {
                    char hallInput = char.Parse(currentInput);

                    halls[hallInput] = new List<int>();
                    hallsQueue.Enqueue(hallInput);

                    if (halls.Count == 1)
                    {
                        currentHall = hallInput;
                    }

                    inputStack.Pop();
                    continue;
                }
            }
        }
    }
}
