using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
          int n =int.Parse(Console.ReadLine());
            int curentVolum = 0;
            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                curentVolum += liters;
                if (curentVolum > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    curentVolum -= liters;
                }
            }
            Console.WriteLine(curentVolum);
        }
    }
}
