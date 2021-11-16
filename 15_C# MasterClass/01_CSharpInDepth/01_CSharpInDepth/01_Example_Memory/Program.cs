using System;

namespace _01_Example_Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 32;

            //  "boxing" num in Heap
            object obj = num;

            // "unboxing" 
            int newNum = (int)obj;
          
            Console.WriteLine(newNum);
              
        }
    }
}
