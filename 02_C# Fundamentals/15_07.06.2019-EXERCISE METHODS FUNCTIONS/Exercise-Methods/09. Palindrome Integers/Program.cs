using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main()
        {
            string number = Console.ReadLine();

            while (number != "END")
            {
                string reverseNumber = ReverseString(number);
                int compare = string.Compare(number, reverseNumber);

                if (compare == 0)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                number = Console.ReadLine();
            }
        }

        static string ReverseString(string number)
        {
            char[] stringToChar = number.ToCharArray();
            Array.Reverse(stringToChar);
            return new string(stringToChar);
        }
    }
}
