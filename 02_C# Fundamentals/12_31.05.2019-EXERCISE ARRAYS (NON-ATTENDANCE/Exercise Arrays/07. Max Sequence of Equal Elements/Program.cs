using System;
using System.Linq;
namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();
            int counter = 1;
            int longCounter = 1;
            int longestEquelElement = numbers[0];
            int equalElements = numbers[0];
         
       
            for (int i = 0; i < numbers.Length-1; i++)
            {
                
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    equalElements=numbers[i];
                }
                else if (numbers[i] != numbers[i + 1])
                {
                    counter = 1;
                }
                if (counter > longCounter)
                {
                    longCounter = counter;
                    longestEquelElement = equalElements;  
                }   
            }
            for (int j = 0; j <longCounter; j++)
            {
                Console.Write(longestEquelElement+" ");
            }
        }
    }
}
