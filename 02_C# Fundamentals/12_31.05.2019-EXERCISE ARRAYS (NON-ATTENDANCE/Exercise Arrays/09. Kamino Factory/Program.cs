using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthSequences = int.Parse(Console.ReadLine());

            int arrLength = int.MinValue;
            bool finish = true;
            int finishLineCounter = 0;
            int[] bestDNA = new int[lengthSequences];
            int sum = 0;
            int bestSum = 0;
            int counter = 0;
            int lineCounter = 0;
            int numberLenght = 0;
            int minCounter = int.MaxValue;
            while (finish)
            {
                string line = Console.ReadLine();
                if (line == "Clone them!")
                {
                    finish = false;
                    break;
                }
                else
                {
                    int[] numbers = line
                 .Split("!", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

                    sum = numbers.Sum();
                    lineCounter++;
                    if (numbers.Length >= arrLength)
                    {
                        arrLength = numbers.Length;
                        for (int i = 0; i < numbers.Length - 1; i++)
                        {
                            counter++;
                            if (numbers[i] == numbers[i + 1] && numbers[i] != 0)
                            {

                                if (counter <= minCounter)
                                {
                                    minCounter = counter;
                                    bestDNA = numbers;
                                    bestSum = sum;
                                    finishLineCounter = lineCounter;
                                    counter = 0;
                                    numberLenght = numbers.Length;
                                    break;
                                }

                            }
                        }
                      
                        
                    }
                  
                     
                    
                }

            }
            Console.WriteLine($"Best DNA sample {finishLineCounter} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDNA));

        }
    }
}
