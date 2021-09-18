using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Activ.key
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"[A-Za-z0-9]{16,25}";
            string regexDigit = @"[0-9]";

            string input = Console.ReadLine();

            List<string> keyList = new List<string>();
            MatchCollection matchKey = Regex.Matches(input, regex);

            foreach(Match match in matchKey)
            {
                string key = match.ToString();
                key = key.ToUpper();
                        
                if (match.Length == 16)
                {
                    for (int i = 4; i < key.Length; i+=5)
                    {
                        key=key.Insert(i, "-");
                    }

                }
                else if (match.Length == 25)
                {

                    for (int i = 5; i < key.Length; i += 6)
                    {
                        key=key.Insert(i, "-");
                    }
                }

                var fixedKey = new StringBuilder();

                for (int i = 0; i < key.Length; i++)
                {
                 
                    var symbol = key[i];
                   
                    if (char.IsDigit(symbol))
                    {
                        var digit = 9 - int.Parse(symbol.ToString());
                        digit = Math.Abs(digit);
                        fixedKey.Append(digit);
                    }
                    else
                    {
                        fixedKey.Append(symbol);
                    }
                }

                string finalKey = fixedKey.ToString();
                keyList.Add(finalKey);
            }

            Console.WriteLine(string.Join(", ",keyList));
        }
    }
}
