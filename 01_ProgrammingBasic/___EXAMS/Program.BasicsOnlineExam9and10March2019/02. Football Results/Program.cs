using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string mach1 = Console.ReadLine();
            string mach2 = Console.ReadLine();
            string mach3 = Console.ReadLine();
            int counterWin = 0;
            int counterLoss = 0;
            int counterDraw = 0;
            int dig = mach1.Length;
            if (mach1[0] > mach1[2])
            {
                counterWin++;
            }
            else if (mach1[0] < mach1[2])
            {
                counterLoss++;
            }
            else if (mach1[0] == mach1[2])
            {
                counterDraw++;
            }

            if (mach2[0] > mach2[2])
            {
                counterWin++;
            }
            else if (mach2[0] < mach2[2])
            {
                counterLoss++;
            }
            else if (mach2[0] == mach2[2])
            {
                counterDraw++;
            }

            if (mach3[0] > mach3[2])
            {
                counterWin++;
            }
            else if (mach3[0] < mach3[2])
            {
                counterLoss++;
            }
            else if (mach3[0] == mach3[2])
            {
                counterDraw++;
            }

            Console.WriteLine($"Team won {counterWin} games.");
            Console.WriteLine($"Team lost {counterLoss} games.");
            Console.WriteLine($"Drawn games: {counterDraw}");
        }
    }
}
