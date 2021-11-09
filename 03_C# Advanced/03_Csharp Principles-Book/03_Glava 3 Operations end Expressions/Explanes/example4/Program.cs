using System;

namespace example4
{
    class Program
    {
        static void Main(string[] args)
        {
            float heightInMeters = 1.74f; // Explicit conversion
            double maxHeight = heightInMeters; // Implicit
            double minHeight = (double)heightInMeters; // Explicit
            float actualHeight = (float)maxHeight; // Explicit
                                                   //float maxHeightFloat = maxHeight; // Compilation error!

            double d = 5e9d; // 5 * 10^9
            Console.WriteLine(d); // 5000000000
            int i = checked((int)d); // System.OverflowException
            Console.WriteLine(i);


            int a = 5;
            int b = ++a;
            Console.WriteLine(a); // 6
            Console.WriteLine(b); // 6
        }
    }
}
