using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int sum = 0;
            int digits = 0;
            bool specialNum = false;
            for (int ch = 1; ch <= numbers; ch++)
            {
                digits = ch;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
                specialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", digits, specialNum);
                sum = 0;
                ch = digits;


            }
        }
    }
}
