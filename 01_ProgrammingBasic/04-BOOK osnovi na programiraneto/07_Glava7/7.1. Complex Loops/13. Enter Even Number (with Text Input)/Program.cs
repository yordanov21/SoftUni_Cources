using System;

namespace _13._Enter_Even_Number__with_Text_Input_
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter even number: ");
                    int n = int.Parse(Console.ReadLine());
                    if (n % 2 == 0)
                    {
                        Console.WriteLine("Even number entered: {0}", n);
                        break;
                    }
                    Console.WriteLine("The number is not even.");
                }
                catch
                {
                    Console.WriteLine("Invalide number.");
                }

            }
        }
    }
}
