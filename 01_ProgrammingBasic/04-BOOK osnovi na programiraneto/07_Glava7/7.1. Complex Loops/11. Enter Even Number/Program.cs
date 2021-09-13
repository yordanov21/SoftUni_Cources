using System;

namespace _11._Enter_Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 0;
            while (true)
            {
                Console.WriteLine("Enter even number: ");
                n = int.Parse(Console.ReadLine());
                if (n % 2 == 0)
                {
                    break;
                }
            }
            Console.WriteLine("Even number: {0}",n);
        }
    }
}
