using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();
            int counter1 = 0;
            int counter2 = 0;
            bool comandGame = true;
            while (comandGame)
            {
                string card1 = Console.ReadLine();
                if (card1 == "End of game")
                {
                    comandGame = false;
                    break;
                }
                string card2 = Console.ReadLine();
                if (card2== "End of game")
                {
                    comandGame = false;
                    break;
                }
                int card1ToInt = int.Parse(card1);
                int card2ToInt = int.Parse(card2);
                if (card1ToInt > card2ToInt)
                {
                    counter1 += card1ToInt - card2ToInt;
                }
                else if (card1ToInt < card2ToInt)
                {
                    counter2 += card2ToInt - card1ToInt;
                }
                else if (card1ToInt == card2ToInt)
                {
                    Console.WriteLine("Number wars!");
                    int secondCard1 = int.Parse(Console.ReadLine());
                    int secondCard2 = int.Parse(Console.ReadLine());
                    int razlika = Math.Abs(secondCard1 - secondCard2);
                    if (secondCard1 > secondCard2)
                    {
                        Console.WriteLine($"{player1} is winner with {counter1} points");
                    }
                    else
                    {
                        Console.WriteLine($"{player2} is winner with {counter2} points");
                    }
                    return;
                }
            }
            Console.WriteLine($"{player1} has {counter1} points");
            Console.WriteLine($"{player2} has {counter2} points");

        }
    }
}
