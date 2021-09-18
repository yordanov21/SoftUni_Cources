using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"^([A-Z]{1}[a-z ']+):([A-Z ]+)$";
            StringBuilder cryptedWord = new StringBuilder();

            while (input != "end")
            {
                Match match = Regex.Match(input, regex);
                if (match.Success)
                {
                    string[] inputArr = input.Split(":");
                    string artistName = inputArr[0];
                    string songName = inputArr[1];

                    int key = artistName.Length;
                    for (int i = 0; i < input.Length; i++)
                    {
                        char symbol = (char)input[i];
                        if (symbol == ' ' || symbol == '\'')
                        {
                            cryptedWord.Append(symbol);
                        }
                        else if (symbol == ':')
                        {
                            cryptedWord.Append('@');
                        }
                        else
                        {
                            if (symbol > 64 && symbol < 91)
                            {
                                symbol = (char)(symbol + key);
                                if (symbol > 'Z')
                                {
                                    symbol = (char)(symbol - 26);
                                    cryptedWord.Append(symbol);
                                }
                                else
                                {

                                    cryptedWord.Append(symbol);
                                }
                            }
                            else if (symbol > 96 && symbol < 123)
                            {
                                symbol = (char)(symbol + key);
                                if (symbol > 'z' )
                                {
                                    symbol = (char)(symbol - 26);
                                    cryptedWord.Append(symbol);
                                }
                                else
                                {

                                    cryptedWord.Append(symbol);
                                }
                            }

                        }
                    }
                    string crypt = cryptedWord.ToString();
                    cryptedWord.Clear();
                    Console.WriteLine($"Successful encryption: {crypt}");

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
