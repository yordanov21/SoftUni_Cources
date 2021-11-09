using System;

namespace _03Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();

            // ICar car = new Ferrari(driverName);  //може да се имплементира и така!
            // Console.WriteLine(car.ToString());

            Ferrari ferrari = new Ferrari(driverName);
            Console.WriteLine(ferrari.ToString());
        }
    }
}
