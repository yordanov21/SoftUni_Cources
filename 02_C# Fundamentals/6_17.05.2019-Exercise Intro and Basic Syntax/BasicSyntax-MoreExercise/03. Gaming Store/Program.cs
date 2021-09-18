using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());

            double counter = 0.0;
            string command = Console.ReadLine();
            while (command != "Game Time")
            {

                if (command == "OutFall 4")
                {
                    counter += 39.99;
                    if (counter > currentBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        counter -= 39.99;
                    }
                    else
                    {
                        Console.WriteLine("Bought OutFall 4");
                    }

                }
                else if (command == "CS: OG")
                {
                    counter += 15.99;
                    if (counter > currentBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        counter -= 15.99;
                    }
                    else
                    {
                        Console.WriteLine("Bought CS: OG");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    counter += 19.99;
                    if (counter > currentBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        counter -= 19.99;
                    }
                    else
                    {
                        Console.WriteLine("Bought Zplinter Zell");

                    }
                }
                else if (command == "Honored 2")
                {
                    counter += 59.99;
                    if (counter > currentBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        counter -= 59.99;
                    }
                    else
                    {
                        Console.WriteLine("Bought Honored 2");

                    }
                }
                else if (command == "RoverWatch")
                {
                    counter += 29.99;
                    if (counter > currentBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        counter -= 29.99;
                    }
                    else
                    {
                        Console.WriteLine("Bought RoverWatch");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    counter += 39.99;
                    if (counter > currentBalance)
                    {
                        Console.WriteLine("Too Expensive");
                        counter -= 39.99;
                    }
                    else
                    {
                        Console.WriteLine("Bought RoverWatch Origins Edition");

                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                if (counter == currentBalance)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                command = Console.ReadLine();
            }

            double remaining = currentBalance - counter;
            Console.WriteLine($"Total spent: ${counter:f2}. Remaining: ${remaining:f2}");
        }
    }
}
