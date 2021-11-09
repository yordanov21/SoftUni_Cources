using System;
using System.Linq;

namespace _01._2_Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string[]> print = items => Console.WriteLine(string.Join
                (Environment.NewLine, items));

            string input = Console.ReadLine();
            string[] names = input.Split().ToArray();

            print(names);
        }
    }
}
