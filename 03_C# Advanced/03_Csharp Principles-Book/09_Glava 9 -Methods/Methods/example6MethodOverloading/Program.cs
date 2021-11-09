using System;

namespace example6MethodOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw("lala");
            Draw(6);
            Draw(6f);
            Draw(3.2m);
            Draw(3.2);
        }

        static void Draw(string str)
        {
            Console.WriteLine($"Draw {str} is string");
        }
        static void Draw(int num)
        {
            Console.WriteLine($"Draw {num} is integer");
        }
        static void Draw(decimal num)
        {
            Console.WriteLine($"Draw {num} is decimal");
        }
        static void Draw(double num)
        {
            Console.WriteLine($"Draw {num} is double");
        }
        static void Draw(float num)
        {
            Console.WriteLine($"Draw {num} is float");
        }
    }
}
