using System;

namespace _15._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var num = 1;
            for (int row = 1; row <=n; row++)
            {
                for (int coll = 1; coll <=row; coll++)
                {
                 if (coll > 1)
                 {
                     Console.Write(" ");
                 }
                    Console.Write(num);
                    num++;
                    if (num > n)
                    {
                        break;
                    }
                }
                Console.WriteLine();
                if (num > n)
                {
                    break;
                }
            }
              
        
        }
    }
}
