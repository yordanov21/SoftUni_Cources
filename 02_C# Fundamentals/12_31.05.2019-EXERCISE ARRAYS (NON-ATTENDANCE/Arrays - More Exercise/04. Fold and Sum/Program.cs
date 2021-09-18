using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] number = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[] array1 = new int[number.Length / 4];
            int[] array2 = new int[number.Length / 2];
            int[] array3 = new int[number.Length / 4];
            int[] arrayFirst = new int[array1.Length + array3.Length];
            if (number.Length % 4 == 0)
            {

                for (int i = 0; i < number.Length; i++)
                {
                    if (i <=(double) number.Length *0.25)
                    {
                        array1[i] = number[i];
                    }
                    else if(i> (double)number.Length/4&& i < (double)number.Length * 0.75)
                    {
                        array2[i] = number[i];
                    }
                    else if(i>= (double)number.Length*0.75)
                    {
                        array3[i] = number[i];
                    }
                }
          
            }
            else
            {
                return;
            }
            
            Console.WriteLine(arrayFirst);
            Console.WriteLine(array2);
        }
    }
}
