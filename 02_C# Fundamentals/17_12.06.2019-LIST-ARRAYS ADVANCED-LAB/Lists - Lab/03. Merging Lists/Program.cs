using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            List<int> numbers2 = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();
            List<int> numbersResult=new List<int>();
              
            
            if (numbers1.Count == numbers2.Count)
            {
                for (int i = 0; i < numbers1.Count; i++)
                {   
                        numbersResult.Add(numbers1[i]);           
                        numbersResult.Add(numbers2[i]);

                }
           
            }
            else if(numbers1.Count > numbers2.Count)
            {
                for (int i = 0; i < numbers2.Count; i++)
                {                  
                        numbersResult.Add(numbers1[i]);
                        numbersResult.Add(numbers2[i]); 
                }
                for (int j = numbers2.Count; j < numbers1.Count; j++)
                {
                    numbersResult.Add(numbers1[j]);
                }

            }
            else if (numbers1.Count < numbers2.Count)
            {
                for (int i = 0; i < numbers1.Count; i++)
                {
                    numbersResult.Add(numbers1[i]);
                    numbersResult.Add(numbers2[i]);
                }
                for (int j = numbers1.Count; j < numbers2.Count; j++)
                {
                    numbersResult.Add(numbers2[j]);
                }

            }
            Console.WriteLine(string.Join(" ",numbersResult));

        }
    }
}
