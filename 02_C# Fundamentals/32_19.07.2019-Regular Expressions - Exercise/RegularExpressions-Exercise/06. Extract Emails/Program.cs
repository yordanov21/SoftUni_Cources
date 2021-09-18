using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))[0-9A-Za-z]*?\.?\-?_?[0-9A-Za-z]+?\d*?@[A-za-z]+\-?[0-9A-za-z]+\.[A-za-z]+\.?[A-Za-z]+";

            string input = Console.ReadLine();
            MatchCollection mails = Regex.Matches(input, regex);

            foreach(Match mail in mails)
            {
                
                Console.WriteLine(mail);
            }
        }
    }
}
