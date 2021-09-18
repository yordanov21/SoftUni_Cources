using System;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails2
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";

            string input = Console.ReadLine();
            MatchCollection mails = Regex.Matches(input, regex);

            foreach (Match mail in mails)
            {

                Console.WriteLine(mail);
            }
        }
    }
}