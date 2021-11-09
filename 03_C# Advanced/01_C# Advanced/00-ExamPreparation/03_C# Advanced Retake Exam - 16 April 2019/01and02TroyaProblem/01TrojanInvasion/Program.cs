using System;
using System.Linq;
using System.Collections.Generic;

namespace _01TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int walesNumber = int.Parse(Console.ReadLine());

            var plates = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();
            Queue<int> platesQueue = new Queue<int>();

            Stack<int> warriors = new Stack<int>();

            for (int i = 0; i < plates.Length; i++)
            {
                platesQueue.Enqueue(plates[i]);
            }

            for (int row = 1; row <= walesNumber; row++)
            {
                if (platesQueue.Count==0)
                {
                    break;
                }

                int[] currentWaveWarriors = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (row % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    platesQueue.Enqueue(extraPlate);
                }

                for (int warrior = 0; warrior < currentWaveWarriors.Length; warrior++)
                {
                    warriors.Push(currentWaveWarriors[warrior]);
                }

                int currentPlate = platesQueue.Peek();

                while (warriors.Count > 0 )
                {
                    int currentWarrior = warriors.Pop();
                
                    if (currentPlate > currentWarrior)
                    {
                        currentPlate -= currentWarrior;
                    }
                    else if (currentPlate < currentWarrior)
                    {
                        currentWarrior -= currentPlate;
                        warriors.Push(currentWarrior);
                        platesQueue.Dequeue();
                        if (platesQueue.Count == 0)
                        {
                            break;
                        }
                        currentPlate = platesQueue.Peek();
                    }
                    else
                    {
                        platesQueue.Dequeue();
                        if (platesQueue.Count == 0)
                        {
                            break;
                        }
                        currentPlate = platesQueue.Peek();
                    }
                }
            }

            if (warriors.Count > 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", warriors)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesQueue)}");
            }
        }
    }
}
