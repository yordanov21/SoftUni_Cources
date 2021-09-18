using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int repeatCount = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(line, repeatCount));
        }
        private static string RepeatString(string line, int repeatCount)
        {
            string result = string.Empty;
            for (int i = 0; i < repeatCount; i++)
            {
                result += line;
            }
            return result;

        }
    }
}
