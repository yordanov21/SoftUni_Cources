using System;
using System.Text;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(ReverceNumber(number));
            Console.WriteLine(GetАverage(number));

            Console.WriteLine(GetX(3,10));
        }

        static int ReverceNumber(int number)
        {
            string stringNum = number.ToString();
            StringBuilder sb = new StringBuilder();

            for (int i = stringNum.Length - 1; i >= 0; i--)
            {
                sb.Append(stringNum[i]);
            }
            int revercedNum = int.Parse(sb.ToString());

            return revercedNum;
        }

        static double GetАverage(int number)
        {
            string stringNum = number.ToString();
            int sum = 0;

            for (int i = stringNum.Length - 1; i >= 0; i--)
            {
                sum += int.Parse(stringNum[i].ToString());
            }
           double avarage = sum*1.0 / stringNum.Length;

            return avarage;
        }

        static double GetX(int a, int b)
        {
            double x = b * 1.0 / a;
            return x;
        }
    }
}
