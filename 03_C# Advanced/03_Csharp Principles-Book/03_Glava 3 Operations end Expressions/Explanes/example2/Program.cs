using System;

namespace example2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            bool b = false;
            Console.WriteLine(a && b);        //False
            Console.WriteLine(a || b);        //True
            Console.WriteLine(!b);            //True
            Console.WriteLine(b||true);       //True
            Console.WriteLine((5>7)^(a==b));  //False
            Console.WriteLine((5<7)^(a==b));  //True
            Console.WriteLine((5>7)^(a!=b));  //True

            string csharp = "C#";
            string dotnet = ".NET";
            string csharpDotNet = csharp + dotnet;
            Console.WriteLine(csharpDotNet); // C#.NET
            string csharpDotNet7 = csharpDotNet + " " + 7;
            Console.WriteLine(csharpDotNet7); // C#.NET 7


            //operatori za sravnenie
             int x = 10, y = 5;
            Console.WriteLine("x > y : " + (x > y)); // True
            Console.WriteLine("x < y : " + (x < y)); // False
            Console.WriteLine("x >= y : " + (x >= y)); // True
            Console.WriteLine("x <= y : " + (x <= y)); // False
            Console.WriteLine("x == y : " + (x == y)); // False
            Console.WriteLine("x != y : " + (x != y)); // True

            //kaskadno prisvoqvane
            int f,k,z;
            f = k = z = 25;

            //ternaren operator ?:
            int num1 = 6;
            int num2 = 4;
            Console.WriteLine(num1>num2? "num1>num2":"mum1<num2");
            int num = num1 == num2 ? 1 : -1;
            Console.WriteLine(num); //num=-1

            //operator ??
            int? d = 5;
            Console.WriteLine(d ?? -1); // 5
            int? e=null;
            Console.WriteLine(e ?? -1); // -1
            string name = null;
            Console.WriteLine(name ?? "(no name)"); // (no name)

            //drugi operatori
        
            string s = "Beer";
            Console.WriteLine(s is string); // True

            string notNullString = s;
            string nullString = null;
            Console.WriteLine(nullString ?? "Unspecified"); // Unspecified
            Console.WriteLine(notNullString ?? "Specified"); // Beer

            double myDouble = 5.1d;
            Console.WriteLine(myDouble); // 5.1
            long myLong = (long)myDouble;
            Console.WriteLine(myLong); // 5
            myDouble = 5e9d; // 5 * 10^9
            Console.WriteLine(myDouble); // 5000000000
            int myInt = (int)myDouble;
            Console.WriteLine(myInt); // -2147483648
            Console.WriteLine(int.MinValue); // -2147483648

            double t = 5e9d; // 5 * 10^9
            Console.WriteLine(t); // 5000000000
           // int i = checked((int)t); // System.OverflowException
           // Console.WriteLine(i);

            int aa = 5;
            int bb = ++aa;
            Console.WriteLine(aa); // 6
            Console.WriteLine(bb); // 6

            int num3 = 1;
            double denum = 0; // The value is 0.0 (real number)
            int zeroInt = (int)denum; // The value is 0 (integer number)
            Console.WriteLine(num3 / denum); // Infinity
            Console.WriteLine(denum / denum); // NaN
            Console.WriteLine(zeroInt / zeroInt); // DivideByZeroException
        }
    }
}
