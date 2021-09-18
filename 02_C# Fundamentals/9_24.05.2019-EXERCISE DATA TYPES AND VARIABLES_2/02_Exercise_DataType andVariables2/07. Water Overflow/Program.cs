using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int lines = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= lines; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                counter += liters;

                if (counter >255)
                {
                    Console.WriteLine($"Insufficient capacity!");
                }
                
                if (counter > 255)
                {
                    counter -= liters;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
