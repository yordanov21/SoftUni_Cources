using System;

namespace _10._Rectangle_with_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new string('%',n*2));
            Console.WriteLine();

            if (n % 2 == 0)
            {
                
                for (int i = 1; i < n; i++)
                {
                    if (n / 2 == i)
                    {
                        Console.Write('%' + (new string(' ', (n * 2 - 3)/2)+"**" +new string(' ', (n * 2 - 3) / 2) +  '%'));
                        Console.WriteLine();
                       
                    }
                    else
                    {
                        Console.Write('%' + (new string(' ', n * 2 - 2) + '%'));
                        Console.WriteLine();
                     
                    }
                  
                }
            }
            else
            {
               
                for (int i = 1; i <= n; i++)
                {
                    if (n / 2 == i-1)
                    {
                        Console.Write('%' + (new string(' ', (n * 2 - 3) / 2) + "**" + new string(' ', (n * 2 - 3) / 2) + '%'));
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.Write('%' + (new string(' ', n * 2 - 2) + '%'));
                        Console.WriteLine();

                    }

                }
            }

            Console.Write(new string('%', n * 2));
            Console.WriteLine();
        }
    }
}
