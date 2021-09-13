using System;

namespace _01._Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            double speed = int.Parse(Console.ReadLine());
            double time1 = int.Parse(Console.ReadLine())/60.0;

            double time2 = int.Parse(Console.ReadLine())/60.0;
            double time3 = int.Parse(Console.ReadLine())/60.0;

            double distance = speed * time1;
            speed = speed + 0.1 * speed;
            distance += speed * time2;
            speed = speed - 0.05 * speed;
            distance += speed * time3;

            Console.WriteLine($"{distance:f2}");
        }
    }
}
