using System;

namespace _05._Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int n1 = n /100%10;
            int n2 = n /10%10;
            int n3 = n %10;
            

            int row = n1 + n2;
            int cel = n1 + n3;

            for (int r = 1; r <= row; r++)
            {
                for (int c = 1; c <=cel; c++)
                {
                    if (n % 5 == 0)
                    {
                        n -= n1;
                        Console.Write(n+" ");
                    }
                    else if (n % 3 == 0)
                    {
                        n -= n2;
                        Console.Write(n + " ");
                    }
                    else
                    {
                        n += n3;
                        Console.Write(n + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
