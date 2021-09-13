using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int BAZA = int.Parse(Console.ReadLine());
            int baza0 = BAZA - 30;
            int gump = 0;
            int counterGumps = 0;
            int counterfaleGumps = 0;
            int COUNTERBAZA = 0;
            while (BAZA >= gump || COUNTERBAZA <= 6)

            {
                gump = int.Parse(Console.ReadLine());
                counterGumps++;
                if (gump > baza0)
                {
                    counterfaleGumps = 0;
                    if (BAZA < gump && COUNTERBAZA==6)
                    {
                        Console.WriteLine($"Tihomir succeeded, he jumped over {baza0}cm after {counterGumps} jumps.");
                        break;
                    }
                    baza0 += 5;
                    COUNTERBAZA++;  
                }
                else if (baza0 >= gump)
                {
                    counterfaleGumps++;

                    if (counterfaleGumps == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {baza0}cm after {counterGumps} jumps.");
                        break;
                    }
                }

            }

        }
    }
}
