using System;
using System.Linq;

namespace _03._2_Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = x=>x.Min() ;
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int result = minNum(numbers);
            Console.WriteLine(result);
         
        }      
    } 
}
