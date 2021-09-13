using System;

namespace _04._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 1111; i < 10000; i++)
            {
                var n4 = i / 1000 % 10;
                if (n4!=0 && N % n4 == 0)
                {
                    var n3 = i / 100 % 10;
                    if (n3!=0 && N % n3 == 0)
                    {
                        var n2 = i / 10 % 10;
                        if (n2!=0 && N % n2 == 0)
                        {
                            var n1 = i % 10;
                            if (n1 != 0 && N % n1 == 0)
                            {
                                Console.Write(i + " ");
                            }
                        }
                    }
                }
            }
        }
    }
}
