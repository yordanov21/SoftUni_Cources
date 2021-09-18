using System;

namespace _11._Math_operations
{
    class Program
    {

        private static double Calculate(int num1, string command, int num2)
        {
            double result = 0;
            switch (command)
            {
                case "/":
                    result = (double)num1 / num2;
                    break;
                case "*":
                    result = (double)num1 * num2;
                    break;
                case "+":
                    result = (double)num1 + num2;
                    break;
                case "-":
                    result = (double)num1 - num2;
                    break;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string command =Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate( num1, command, num2));

        }
    }
}
