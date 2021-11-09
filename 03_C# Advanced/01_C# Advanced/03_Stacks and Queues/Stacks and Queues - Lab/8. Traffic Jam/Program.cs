using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerGreenLight = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int countOfCasr = 0;
            StringBuilder sb = new StringBuilder();
            string command;

            while ((command=Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    var carsForPassing = Math.Min(carsPerGreenLight, queue.Count);
                    for (int i = 0; i <carsForPassing; i++)
                    {
                        var currentCar = queue.Dequeue();
                        sb.AppendLine($"{currentCar} passed!");
                        countOfCasr++;
                    }
                   
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            sb.AppendLine($"{countOfCasr} cars passed the crossroads.");

            Console.Write(sb);
        }
    }
}
