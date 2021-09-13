using System;

namespace _14._Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {       
            int num = int.Parse(Console.ReadLine());
            int f0 = 1;
            int f1 = 1;
            
            for (int i = 0; i < num-1; i++)
            {
               var fnext = f0 + f1;
                f0 = f1;
                f1 = fnext;
            }
            Console.WriteLine(f1);
        }
    }
}
