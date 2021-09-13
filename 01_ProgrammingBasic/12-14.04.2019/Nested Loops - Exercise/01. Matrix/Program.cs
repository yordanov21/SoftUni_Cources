using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            for (int firstRowfirstNum = a; firstRowfirstNum <= b; firstRowfirstNum++)
            {
                for (int firstRowsecondNum = a; firstRowsecondNum <= b; firstRowsecondNum++)
                {
                    for (int secondRowfirstNum = c; secondRowfirstNum <= d; secondRowfirstNum++)
                    {
                        for (int secondRowsecondNum = c; secondRowsecondNum <= d; secondRowsecondNum++)
                        {
                            if ((firstRowfirstNum + secondRowsecondNum) == (firstRowsecondNum + secondRowfirstNum) && (firstRowfirstNum != firstRowsecondNum) && (secondRowfirstNum != secondRowsecondNum))
                            {
                                Console.WriteLine($"{firstRowfirstNum}{firstRowsecondNum}");
                                Console.WriteLine($"{secondRowfirstNum}{secondRowsecondNum}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
