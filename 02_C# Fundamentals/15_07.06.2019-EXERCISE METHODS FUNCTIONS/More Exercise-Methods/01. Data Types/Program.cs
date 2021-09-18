using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if (type == "int")
            {
                int rezult = 0;
                Console.WriteLine(MultiplyIntegerByTwo(rezult));
            }
            else if (type == "real")
            {
                double rezult = 0;

                Console.WriteLine($"{MultiplyReal(rezult):f2}");
            }
            else if (type == "string")
            {
                string surrounded = string.Empty;
                Console.WriteLine(Surround(surrounded));
            }

        }
        static int MultiplyIntegerByTwo(int rezult)
        {
            int number = int.Parse(Console.ReadLine());
            rezult = 2 * number;
            return rezult;
        }
        static double MultiplyReal(double rezult)
        {
            double number = double.Parse(Console.ReadLine());
            rezult = 1.5 * number;
            return rezult;
        }
        static string Surround(string surrounded)
        {
            string name = Console.ReadLine();
            surrounded = "$" + name + "$";
            return surrounded;
        }
    }
}

