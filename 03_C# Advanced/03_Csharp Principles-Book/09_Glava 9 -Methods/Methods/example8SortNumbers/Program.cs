using System;
using System.Linq;

namespace example8SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Sort(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        static int[] Sort(params int[] numbers)
        {
            int temp;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                // traverse i+1 to array length 
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    // compare array element with  
                    // all next element 
                    if (numbers[i] > numbers[j])
                    {

                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            return numbers;
        }
    }
}
