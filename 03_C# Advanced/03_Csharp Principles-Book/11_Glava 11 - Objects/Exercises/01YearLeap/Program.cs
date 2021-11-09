using System;

namespace _01YearLeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.IsLeapYear(2000)); 
            Console.WriteLine(DateTime.IsLeapYear(2001)); 
            Console.WriteLine(DateTime.IsLeapYear(2002)); 
            Console.WriteLine(DateTime.IsLeapYear(2003)); 
            Console.WriteLine(DateTime.IsLeapYear(2004)); 
        }
    }
}
