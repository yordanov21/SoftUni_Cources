using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.__Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLigthTime = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();
            int count = 0;
            int countGreenLight = 0;
            bool greenend = false;
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{count} total cars passed the crossroads.");
                    return;
                }

                if (line == "green")
                {
                    var carInCrossRoad = queue.Peek();
                    countGreenLight = 0;
                    Queue<char> currentCar = new Queue<char>(carInCrossRoad);
                    for (int i = 0; i < greenLigthTime; i++)
                    {
                        currentCar.Dequeue();
                        countGreenLight++;

                        if (countGreenLight == greenLigthTime)
                        {
                            for (int j = 0; j < freeWindow; j++)
                            {
                                currentCar.Dequeue();
                                if (currentCar.Count == 0)
                                {
                                    queue.Dequeue();
                                    count++;
                                    greenend = true;
                                    break;
                                }

                            }
                            if (currentCar.Count > 0)
                            {
                                Console.WriteLine("A crash happened!");
                                var crashcar = queue.Peek();
                                var crashSymbol = currentCar.Peek();
                                Console.WriteLine($"{crashcar} was hit at {crashSymbol}.");
                                return;
                            }

                        }

                        if (currentCar.Count == 0 && queue.Any() && greenend == false)
                        {
                            queue.Dequeue();
                            count++;
                            if (queue.Any())
                            {
                                carInCrossRoad = queue.Peek();
                                foreach (var item in carInCrossRoad)
                                {
                                    currentCar.Enqueue(item);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                    }
                }
                else
                {
                    queue.Enqueue(line);
                }
            }
        }
    }
}

