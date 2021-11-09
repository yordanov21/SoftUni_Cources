using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> namesSet = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                namesSet.Add(input);
            }

            foreach ( string name in namesSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
