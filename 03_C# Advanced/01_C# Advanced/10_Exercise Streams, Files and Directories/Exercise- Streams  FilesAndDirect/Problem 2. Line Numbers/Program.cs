using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var punctuationMarks = new[] { '-', ',', '.', '!', '?', ';', '\'' };

            using (var reader = new StreamReader("text.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int counter = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        int punctMarksCount = 0;
                        int letersCount = 0;

                        if (counter != 1)
                        {
                            writer.WriteLine();
                        }
                        var words = line.ToCharArray();
                     
                        for (int i = 0; i < words.Length; i++)
                        {
                            char ch = words[i];
                            if (punctuationMarks.Contains(ch))
                            {
                               punctMarksCount++;
                            }
                         
                            if (Char.IsLetter(ch))
                            {
                                letersCount++;
                            }
                        }

                        line = $"Line {counter}: {line} ({letersCount})({ punctMarksCount})";
                        counter++;
                        writer.Write(line);
                    }
                }
            }
        }
    }
}

