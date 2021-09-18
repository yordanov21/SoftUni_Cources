using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfString = int.Parse(Console.ReadLine());

            int[] stringArray = new int[numbersOfString];

            for (int i = 0; i < numbersOfString; i++)
            {
                string names = Console.ReadLine();
                int sum = 0;
                for (int j = 0; j < names.Length; j++)
                {
                  
                    if (names[j] == 'a' || names[j] == 'e' || names[j] == 'i' || names[j] == 'o' || names[j] == 'u' || names[j] == 'A' || names[j] == 'E' || names[j] == 'I' || names[j] == 'O' || names[j] == 'U')
                    {
                        sum += (int)names[j] * names.Length;
                    }
                    else
                    {
                        sum += (int)names[j] / names.Length;
                    }
                }

                stringArray[i] = sum;
                sum = 0;
            }

            Array.Sort(stringArray);
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine(stringArray[i]);
            }
            
        }
    }
}
