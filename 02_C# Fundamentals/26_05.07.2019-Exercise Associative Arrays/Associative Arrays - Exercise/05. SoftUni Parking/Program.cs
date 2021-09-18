using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, string>();
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();

                if(input[0]== "register")
                {
                    if (!cars.ContainsKey(input[1]))
                    {
                        cars.Add(input[1], input[2]);
                        Console.WriteLine($"{input[1]} registered {input[2]} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {input[2]}");
                       
                    }
                }
                else if(input[0] == "unregister")
                {
                    if (!cars.ContainsKey(input[1]))
                    {
                        Console.WriteLine($"ERROR: user {input[1]} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{input[1]} unregistered successfully");
                        cars.Remove(input[1]);

                    }

                }
            }
            foreach(var car in cars)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
