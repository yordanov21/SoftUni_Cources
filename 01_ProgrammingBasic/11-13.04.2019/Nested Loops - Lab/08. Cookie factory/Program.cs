using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int batch = int.Parse(Console.ReadLine());
            string comand = string.Empty;
            int counter = 0;

            for (int i = 1; i <= batch; i++)
            {
                while (comand != "Bake!" || i <= batch)
                {
                    comand = Console.ReadLine();
                    if (comand == "flour" || comand == "eggs" || comand == "sugar")
                    {
                        counter++;
                    }
                    if (counter < 3 && comand == "Bake!")
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    }
                    else if (comand == "Bake!")
                    {
                        Console.WriteLine($"Baking batch number {i}...");
                        break;
                    }
                }
            }
        }
    }
}
