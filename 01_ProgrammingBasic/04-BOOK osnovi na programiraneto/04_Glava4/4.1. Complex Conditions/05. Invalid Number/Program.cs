using System;

namespace _05._Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            bool inRange = (num >= 100 && num <= 200) || num == 0;

            if (!inRange)
            {
                Console.WriteLine("invalid");
            }

        }
    }
}
