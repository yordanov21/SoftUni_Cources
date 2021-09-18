using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string integer = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < integer.Length; i++)
            {
                int digit = int.Parse(integer[i].ToString());

                sum += digit;
            }
            Console.WriteLine(sum);
        }
    }
}
