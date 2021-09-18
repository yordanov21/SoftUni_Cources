using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbols = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder characters = new StringBuilder();

            for (int i = 0; i < symbols.Length; i++)
            {
                char symbol = symbols[i];
                if (symbol >= 48 && symbol <= 57)
                {
                    digits = digits.Append(symbol);
                }
                else if (symbol >= 65 && symbol <= 90 || symbol >= 97 && symbol <= 122)
                {
                    letters = letters.Append(symbol);
                }
                else
                {
                    characters = characters.Append(symbol);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(characters);

        }
    }
}
