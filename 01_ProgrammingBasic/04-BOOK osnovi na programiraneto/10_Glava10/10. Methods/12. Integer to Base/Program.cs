using System;
using System.Text;

namespace _12._Integer_to_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int toBase= int.Parse(Console.ReadLine());
            var result=IntegerToBase(number, toBase);
            Console.WriteLine(result);
        }

        static string IntegerToBase(int number, int toBase)
        {
            StringBuilder result = new StringBuilder();
            while (number != 0)
            {
                var ostatuk = number % toBase;
                result.Insert(0,ostatuk);
               
                number = number / toBase;
            }
            
            return result.ToString();

        }
    }
}
