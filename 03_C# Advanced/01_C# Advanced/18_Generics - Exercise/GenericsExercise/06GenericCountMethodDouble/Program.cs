using System;

namespace _06GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Values.Add(input);
            }

            double targetItem = double.Parse(Console.ReadLine());

            int result = box.GreaterValuesThan(targetItem);
            Console.WriteLine(result);
        }
    }
}
