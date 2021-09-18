using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] texts = Console.ReadLine().Split();

            for (int i = 0; i < texts.Length; i++)
            {
                Console.Write(texts[texts.Length-i-1]+" ");
            }
        }
    }
}
