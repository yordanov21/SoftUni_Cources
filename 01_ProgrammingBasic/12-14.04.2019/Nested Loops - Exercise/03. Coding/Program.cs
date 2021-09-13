using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = Console.ReadLine();

            for (int i = inputNum.Length-1; i >= 0; i--)
            {
                char currentDigit = inputNum[i];
                int currentDigitToNum = int.Parse(currentDigit.ToString());
                if (currentDigitToNum == 0)
                {
                    Console.WriteLine("ZERO");
                    continue;
                }
                for (int n = 1; n <= currentDigitToNum; n++)
                {
                    Console.Write((char)(currentDigitToNum+33));
                }
                Console.WriteLine();
            }
        }
    }
}
