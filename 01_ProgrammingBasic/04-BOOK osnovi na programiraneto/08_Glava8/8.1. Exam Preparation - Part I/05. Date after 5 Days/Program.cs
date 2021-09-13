using System;

namespace _05._Date_after_5_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());

            days += 5;
            switch (month)
            {
                case 1 :
                case 3 :
                case 5 :
                case 7 :
                case 8 :
                case 10 :
               
                    if (days > 31)
                    {
                        days -= 31;
                        month++;
                    }

                    break;
                case 12 :
                    if (days > 31)
                    {
                        days -= 31;
                        month=1;
                    }
                    
                    break;

                case 2:
                    if (days > 28)
                    {
                        days -= 28;
                        month++;
                    }
                    break;

                case 4 :
                case 6 :
                case 9 :
                case 11 :
                    if (days > 30)
                    {
                        days -= 30;
                        month++;
                    }
                    break;
            }
            if (month > 9)
            {
                Console.WriteLine($"{days}.{month}");
            }
            else
            {
                Console.WriteLine($"{days}.0{month}");
            }
        }
    }
}
