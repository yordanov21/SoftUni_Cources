using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            for (int i = 0; i < usernames.Length; i++)
            {
                string currentUsername = usernames[i];

                bool isLenghtValid = true;
                bool isContentValid = true;
                
                if (currentUsername.Length < 3|| currentUsername.Length > 16)
                {
                    isLenghtValid = false;
                }

                for (int j = 0; j < currentUsername.Length; j++)
                {

                    char currentSymbol = currentUsername[j];
                    if (!char.IsLetterOrDigit(currentSymbol) && currentSymbol != '-' && currentSymbol != '_')
                    {
                        isContentValid = false;
                        break;
                    }
                }

                if(isContentValid && isLenghtValid)
                {
                    Console.WriteLine(currentUsername);
                }
            }

        }
    }
}
