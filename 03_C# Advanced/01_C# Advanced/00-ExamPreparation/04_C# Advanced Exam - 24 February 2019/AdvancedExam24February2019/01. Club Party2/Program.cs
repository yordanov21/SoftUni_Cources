using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Club_Party2
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

            while (inputStack.Any())
            {

                var currentInput = inputStack.Peek();
                int n;
                bool isDigit = int.TryParse(currentInput, out n);

                if(!char.IsDigit(currentInput[0]))
                {
                    char hallInput = char.Parse(currentInput);

                    halls[hallInput] = new List<int>();
                    hallsQueue.Enqueue(hallInput);
                
                    inputStack.Pop();
                    continue;
                }

                if (halls.Count == 0)
                {
                    inputStack.Pop();
                    continue;
                }
                foreach (var hall in halls)
                {
                    if (hall.Value.Sum() + int.Parse(currentInput) <= hallCapacity)
                    {
                        halls[hall.Key].Add(int.Parse(currentInput));
                        inputStack.Pop();
                        break;
                    }

                    if (hall.Value.Sum() + int.Parse(currentInput) >= hallCapacity && hallsQueue.Any())
                    {
                        Console.WriteLine($"{hallsQueue.Dequeue()} -> {string.Join(", ", hall.Value)}"); 
                        halls.Remove(hall.Key);
                    }

                    break;

                }
            }
        }
    }
}
