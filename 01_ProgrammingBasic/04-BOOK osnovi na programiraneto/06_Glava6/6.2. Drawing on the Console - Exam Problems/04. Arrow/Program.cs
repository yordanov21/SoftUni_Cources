using System;

namespace _04._Arrow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n>2&&n<80&&n%2!=0)
            {
                var dotes = (n * 2 - n) / 2;
                Console.WriteLine(new string('.', dotes) + new string('#', n) + new string('.', dotes));

                var midDote = n * 2 - (dotes + 1) * 2 - 1;
                for (int i = 1; i <= n - 2; i++)
                {
                    Console.WriteLine(new string('.', dotes) + "#" + new string('.', midDote) + "#" + new string('.', dotes));
                }

                Console.WriteLine(new string('#', dotes) + "#" + new string('.', midDote) + "#" + new string('#', dotes));


                var dotes2 = n * 2 - 5;
                for (int i = 1; i < n - 1; i++)
                {
                    Console.WriteLine(new string('.', i) + "#" + new string('.', dotes2) + "#" + new string('.', i));
                    dotes2 -= 2;
                }

                Console.WriteLine(new string('.', n - 1) + "#" + new string('.', n - 1));

            }
            
        }
    }
}
