using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Problem_1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineCounter = 0;
            var symbolsToReplace = new[] { "-", ",", ".", "!", "?" };

            var sb = new StringBuilder();
            using (var streamReader = new StreamReader("text.txt")) //open the stream
            {
                using (var streamWriter = new StreamWriter("output.txt"))
                {
                    while (!streamReader.EndOfStream)  // we read until the end of the file is reached
                    {
                        string line = streamReader.ReadLine();
                        //if (line == null)    equivalent to the above in brackets 
                        //{                    we read until it has reached the end of the file
                        //    break;          
                        //}    
                        
                        if (lineCounter % 2 == 0)
                        {
                            if (lineCounter != 0)
                            {
                                streamWriter.WriteLine();
                            }
                            var words = line.Split();
                            for (int i = 0; i < words.Length; i++)
                            {
                                var currentWord = words[i];

                                foreach (var symbol in symbolsToReplace)
                                {
                                    currentWord = currentWord.Replace(symbol, "@");
                                }

                                words[i] = currentWord;
                            }

                            var result = string.Join(" ", words.Reverse());
                            streamWriter.Write(result);
                        }

                        lineCounter++;
                    }

                }
            }//close the stream
        }
    }
}
