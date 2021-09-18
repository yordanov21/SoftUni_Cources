using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxWagonCapacity = int.Parse(Console.ReadLine());
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] lineParts = line.Split();
                if (lineParts.Length > 1)
                {
                    int peoplePerWagon = int.Parse(lineParts[1]);
                    wagons.Add(peoplePerWagon);
                }
                else
                {
                    int peoplePerWagon = int.Parse(lineParts[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] <= (maxWagonCapacity - peoplePerWagon))
                        {
                            wagons[i] += peoplePerWagon;
                            break;
                        }

                    }
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
