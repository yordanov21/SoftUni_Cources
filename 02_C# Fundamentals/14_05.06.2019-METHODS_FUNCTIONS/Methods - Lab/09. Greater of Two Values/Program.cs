using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        private static int GetMaxInt(int a, int b)
        {
     
           return Math.Max(a, b);
        }
        private static char GetMaxChar(char first, char second)
        {
            if (first.CompareTo(second) >= 0)
            {
                return first;
            }
            else
            {
                return second;
            }
           
        }
        private static string GetMaxString(string firstS, string secondS)
        {
            if (firstS.CompareTo(secondS) >= 0)
            {
                return firstS;
            }
            else
            {
                return secondS;
            }

        }


        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMaxInt(a,b));
                    break;
                case "char":
                    char first = char.Parse(Console.ReadLine());
                    char second = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMaxChar(first, second));
                    break;
                case "string":
                    string firstS = Console.ReadLine();
                    string secondS = Console.ReadLine();
                    Console.WriteLine(GetMaxString(firstS, secondS));
                    break;
            }
        }
    }
}
