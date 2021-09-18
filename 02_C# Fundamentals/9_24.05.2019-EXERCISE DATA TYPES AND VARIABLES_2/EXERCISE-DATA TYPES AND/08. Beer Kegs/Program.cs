using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bigestVolum = 0.0;
            string bigerkeg= string.Empty;
            for (int i = 0; i < number; i++)
            {
                string keg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double curentVolum = Math.PI * Math.Pow(radius,2) * height;
                if (bigestVolum < curentVolum)
                {
                    bigestVolum = curentVolum;
                    bigerkeg = keg;
                }
                      
            }
            Console.WriteLine(bigerkeg);
        }
    }
}
