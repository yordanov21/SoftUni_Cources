using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumEggsPlayr1 = int.Parse(Console.ReadLine());
            int NumEggsPlayr2 = int.Parse(Console.ReadLine());
            string command = string.Empty;
            int counterP1 = NumEggsPlayr1;
            int counterP2 = NumEggsPlayr2;
            while(command!= "End of battle")
            {
                command = Console.ReadLine();
                if(command== "End of battle")
                {
                    Console.WriteLine($"Player one has {counterP1} eggs left.");
                    Console.WriteLine($"Player two has {counterP2} eggs left.");
                    break;
                }
                else if (command == "one")
                {
                    counterP2--;
                    if (counterP2 == 0)
                    {
                        Console.WriteLine($"Player two is out of eggs. Player one has {counterP1} eggs left.");
                        break;
                    }
                    
                }
                else if (command == "two")
                {
                    counterP1--;
                    if (counterP1 == 0)
                    {
                        Console.WriteLine($"Player one is out of eggs. Player two has {counterP2} eggs left.");
                        break;
                    }
                   
                }
            }
        }
    }
}
