using System;
using System.Linq;
using System.Collections.Generic;

namespace _01TrojanInvasion2
{
    class Program
    {
        static void Main(string[] args)
        {
            int walesNumber = int.Parse(Console.ReadLine());

            var plates = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();
            //Queue<int> platesQueue = new Queue<int>();

            Stack<int> warriors = new Stack<int>();

           // for (int i = 0; i < plates.Length; i++)
           // {
           //     platesQueue.Enqueue(plates[i]);
           // }

            for (int row = 1; row <= walesNumber; row++)
            {
                if (plates.Count == 0)
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
                   plates.Add(extraPlate);
                }

                for (int warrior = 0; warrior < currentWaveWarriors.Length; warrior++)
                {
                    warriors.Push(currentWaveWarriors[warrior]);
                }

                

                while (warriors.Count > 0 && plates.Count>0)
                {
                    int currentWarrior = warriors.Pop();
                    int currentPlate = plates[0];

                    if (currentPlate > currentWarrior)
                    {
                        currentPlate -= currentWarrior;
                        plates[0] = currentPlate;
                    }
                    else if (currentPlate < currentWarrior)
                    {
                        currentWarrior -= currentPlate;
                        warriors.Push(currentWarrior);
                        plates.RemoveAt(0);
                    }
                    else
                    {
                        plates.RemoveAt(0);
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
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
