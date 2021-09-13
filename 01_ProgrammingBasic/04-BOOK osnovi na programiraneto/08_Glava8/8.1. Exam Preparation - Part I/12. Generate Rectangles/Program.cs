using System;

namespace _12._Generate_Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int count = 0;

            for (int leftDownX = -n; leftDownX <=n; leftDownX++)
            {
                for (int leftDownY = -n; leftDownY <=n; leftDownY++)
                {
                    for (int rigthTopX = leftDownX+1; rigthTopX <= n; rigthTopX++)
                    {
                        for (int rightTopY = leftDownY+1; rightTopY <= n; rightTopY++)
                        {
                           int area= Math.Abs((rightTopY - leftDownY) * (rigthTopX - leftDownX));
                            if (area >= m)
                            {
                                Console.WriteLine($"({leftDownX}, {leftDownY}) ({rigthTopX}, {rightTopY}) -> {area}");
                                count++;
                            }
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
