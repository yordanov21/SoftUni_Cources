using System;

namespace _04Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            var numbers = Console.ReadLine().Split();
            for (int i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                Console.WriteLine(smartphone.Call(number));
            }

            var browsers = Console.ReadLine().Split();
            for (int i = 0; i < browsers.Length; i++)
            {
                var browse = browsers[i];
                Console.WriteLine(smartphone.Browse(browse));
            }
        }
    }
}
