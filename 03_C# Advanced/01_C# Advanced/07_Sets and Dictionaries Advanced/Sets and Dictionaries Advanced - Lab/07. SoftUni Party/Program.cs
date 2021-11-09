using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> VIPList = new List<string>();
            List<string> regularList = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }

                char ch = input[0];
                if (char.IsDigit(ch))
                {
                    VIPList.Add(input);
                }
                else
                {
                    regularList.Add(input);
                }
            }

            while (true)
            {
                var input2 = Console.ReadLine();
                if (input2 == "END")
                {
                    break;
                }

                char ch = input2[0];
                if (char.IsDigit(ch))
                {
                    VIPList.Remove(input2);
                }
                else
                {
                    regularList.Remove(input2);
                }
            }

            int allGuestDidntCame = VIPList.Count + regularList.Count;
            Console.WriteLine(allGuestDidntCame);
            foreach (var guest in VIPList)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
