using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            var phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, regex);

            var matchedPhones = phoneMatches
                .Cast<Match>()
                .Select(a=>a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));

        }
    }
}
