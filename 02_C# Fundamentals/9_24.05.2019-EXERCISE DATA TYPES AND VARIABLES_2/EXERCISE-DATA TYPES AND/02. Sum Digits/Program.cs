using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string numberAsString = Console.ReadLine();
            for (int i = 0; i < numberAsString.Length; i++)
            {
                int digit = int.Parse(numberAsString[i].ToString());
                sum += digit;
            }
            Console.WriteLine(sum);
        }
    }
}
