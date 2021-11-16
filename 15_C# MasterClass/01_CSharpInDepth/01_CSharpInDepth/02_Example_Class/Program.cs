using System;

namespace _02_Example_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Creator();
            GC.Collect();

            Console.ReadLine();
        }

        static void Creator()
        {
            TestObj obj = new TestObj(42);
          //  GC.Collect(); // if call GC here  the heap will not be cleaned because the method is not finished yet, and the stack is not empty. 
        }
    }
}
