using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string Player = string.Empty;
            string bestPlayer = string.Empty;
            int maxGoal = int.MinValue;
            while (Player != "END")
            {
                Player = Console.ReadLine();
                if (Player == "END")
                {
                    break;
                }
                else
                {
                    int goals = int.Parse(Console.ReadLine());
              
                    if( goals >= 10)
                    {
                        bestPlayer = Player;
                        maxGoal = goals;
                        break;
                    }
                    if (goals > maxGoal)
                    {
                        bestPlayer = Player;
                        maxGoal = goals;
                        if (goals >=3 )
                        {
                            bestPlayer = Player;
                            maxGoal = goals;
                        }
                    }
                    
                }
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (maxGoal >= 3)
            {
                Console.WriteLine($"He has scored {maxGoal} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoal} goals.");
            }
            
        }
    }
}
