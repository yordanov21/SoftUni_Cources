using System;
using System.Globalization;
using System.Threading;

namespace example1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Four: " + 2 + 2;
            Console.WriteLine(s);
            // Four: 22
            string s1 = "Four: " + (2 + 2);
            Console.WriteLine(s1);
            // Four: 4


            string str = "Hello, World!";
            // Print (the normal way)
            Console.Write(str);
            // Print (through formatting string)
            Console.Write("{0}", str);
            // Print (through string interpolation)
            Console.Write($"{str}\n");  // това преминаване на нов ред не е редно, не работи на всички платформи.

            //преминаване на нов ред
            Console.WriteLine("First line");
            Console.Write("Second line" + Environment.NewLine);
            Console.Write("Third line"); Console.WriteLine();

            Console.WriteLine($"{1234,6}");
            Console.WriteLine("{0,6}", 1234);
            Console.WriteLine("{0,6}", 12);
            Console.WriteLine();

            Console.WriteLine("{0:C2}", 123.456);
            // Output: 123,46 лв.
            Console.WriteLine("{0:D6}", -1234);
            // Output: -001234
            Console.WriteLine("{0:E2}", 123);
            // Output: 1,23Е+002
            Console.WriteLine("{0:F2}", -123.456);
            // Output: -123,46
            Console.WriteLine("{0:N2}", 1234567.8);
            // Output: 1 234 567,80
            Console.WriteLine("{0:P}", 0.456666);
            // Output: 45,60 %
            Console.WriteLine("{0:X}", 254);
            // Output: FE
            Console.WriteLine();


            Console.WriteLine("{0:0.00}", 1);
            // Output: 1,00
            Console.WriteLine("{0:#.##}", 0.234);
            // Output: ,23
            Console.WriteLine("{0:#####}", 12345.67);
            // Output: 12346
            Console.WriteLine("{0:(0#) ### ## ##}", 29342525);
            // Output: (02) 934 25 25
            Console.WriteLine("{0:%##}", 0.234);
            // Output: %23
            Console.WriteLine();

            DateTime d = new DateTime(2018, 01, 01, 15, 30, 22);
            Console.WriteLine("{0:dd/MM/yyyy HH:mm:ss}", d);
            Console.WriteLine("{0:d.MM.yy г.}", d);
            Console.WriteLine();

            DateTime dd = new DateTime(2018, 05, 23, 15, 30, 22);
            Thread.CurrentThread.CurrentCulture =
            CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine("{0:N}", 1234.56);
            Console.WriteLine("{0:D}", dd);
            Thread.CurrentThread.CurrentCulture =
            CultureInfo.GetCultureInfo("bg-BG");
            Console.WriteLine("{0:N}", 1234.56);
            Console.WriteLine("{0:D}", dd);
            //do 186str.
        }
    }
}
