using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int partyPeople = int.Parse(Console.ReadLine());
            List<string> partyGueest = new List<string>();

            for (int i = 1; i <= partyPeople; i++)
            {
                string[] gueest = Console.ReadLine().Split();

                if (gueest[2] == "going!")
                {
                    if (partyGueest.Contains(gueest[0]))
                    {
                        Console.WriteLine($"{gueest[0]} is already in the list!");
                        
                    }
                    else
                    {
                        partyGueest.Add(gueest[0]);
                    }
                    
                }
                if(gueest[2] == "not")
                {
                    if (partyGueest.Contains(gueest[0]))
                    {
                        partyGueest.Remove(gueest[0]);

                    }
                    else
                    {
                        Console.WriteLine($"{gueest[0]} is not in the list!");
                    }
                }

            }
            Console.Write(string.Join(Environment.NewLine,partyGueest));
        }
    }
}
