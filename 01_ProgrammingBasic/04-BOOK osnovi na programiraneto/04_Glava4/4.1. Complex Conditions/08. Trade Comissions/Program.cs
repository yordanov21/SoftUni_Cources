using System;

namespace _08._Trade_Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower(); ;
            double sales = double.Parse(Console.ReadLine());

            double comission = -1;

            if (city == "sofia")
            {
                if (sales >= 0 && sales <= 500)
                {
                    comission = sales * 0.05;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 500 && sales <= 1000)
                {
                    comission = sales * 0.07;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    comission = sales * 0.08;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 10000)
                {
                    comission = sales * 0.12;
                    Console.WriteLine("{0:f2}", comission);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "varna")
            {
                if (sales >= 0 && sales <= 500)
                {
                    comission = sales * 0.045;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 500 && sales <= 1000)
                {
                    comission = sales * 0.075;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    comission = sales * 0.1;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 10000)
                {
                    comission = sales * 0.13;
                    Console.WriteLine("{0:f2}", comission);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "plovdiv")
            {
                if (sales >= 0 && sales <= 500)
                {
                    comission = sales * 0.055;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 500 && sales <= 1000)
                {
                    comission = sales * 0.08;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 1000 && sales <= 10000)
                {
                    comission = sales * 0.12;
                    Console.WriteLine("{0:f2}", comission);
                }
                else if (sales > 10000)
                {
                    comission = sales * 0.145;
                    Console.WriteLine("{0:f2}", comission);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }


        }
    }
}
