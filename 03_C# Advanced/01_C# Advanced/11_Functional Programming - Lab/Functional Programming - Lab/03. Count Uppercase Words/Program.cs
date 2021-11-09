using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checkUpperCase = x => x[0] == x.ToUpper()[0];
            string input = Console.ReadLine();

            var words = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(checkUpperCase).ToArray();
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
