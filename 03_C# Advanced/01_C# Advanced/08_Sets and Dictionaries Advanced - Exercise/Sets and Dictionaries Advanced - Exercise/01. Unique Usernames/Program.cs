using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> nameSet = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                nameSet.Add(name);
            }

            foreach (var name in nameSet)
            {
                Console.WriteLine(name);
            }
        }

    }
}
