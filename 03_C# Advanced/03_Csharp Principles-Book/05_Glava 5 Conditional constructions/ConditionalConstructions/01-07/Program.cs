using System;
using System.Linq;

namespace _01_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int a= 10;
            int b = 5;

            if (a > b)
            {
                b = a;
                a = 5;
            }


            int c = 20;
            int d = 50;
            int e = 100;
            int[] arr = { a, b, c, d, e };
          arr=  arr.OrderByDescending(x => x).ToArray();
            Console.WriteLine(arr[0]);
        }
    }
}
