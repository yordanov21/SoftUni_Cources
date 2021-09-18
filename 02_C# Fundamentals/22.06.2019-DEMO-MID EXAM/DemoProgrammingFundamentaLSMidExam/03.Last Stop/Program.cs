using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToList();
            bool paint1 = false;
            bool paint2 = false;
            int SwitchNum1 = 0;
            int SwitchNum2 = 0;
            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "END")
                {
                    break;
                }
                string[] instruction = comand
                    .Split()
                    .ToArray();
                if (instruction[0] == "Change")
                {
                    int paintingNumber = int.Parse(instruction[1]);
                    int changedNumber = int.Parse(instruction[2]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (paintingNumber == numbers[i])
                        {
                            numbers[i] = changedNumber;
                            continue;
                        }
                    }
                }
                else if (instruction[0] == "Hide")
                {
                    int paintingNumber = int.Parse(instruction[1]);

                    numbers.Remove(paintingNumber);
                    //for (int i = 0; i < numbers.Count; i++)
                    //{
                    //    if (paintingNumber == numbers[i])
                    //    {
                    //        numbers.RemoveAt(i);
                    //    }
                    //}
                }
                else if (instruction[0] == "Switch")
                {
                    int paintingNumber = int.Parse(instruction[1]);
                    int paintingNumber2 = int.Parse(instruction[2]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (paintingNumber == numbers[i])
                        {
                            SwitchNum1 = i;
                            paint1 = true;
                        }
                        if (paintingNumber2 == numbers[i])
                        {
                            SwitchNum2 = i;
                            paint2 = true;
                        }
                        if (paint1 && paint2)
                        {
                            numbers[SwitchNum1] = paintingNumber2;
                            numbers[SwitchNum2] = paintingNumber;
                        }
                    }
                }
                else if (instruction[0] == "Insert")
                {
                    int place = int.Parse(instruction[1]);
                    int paintingNumber = int.Parse(instruction[2]);

                    if (place >= -1 && place < numbers.Count - 1)
                    {
                        numbers.Insert(place + 1, paintingNumber);
                        continue;
                    }

                }

                else if (instruction[0] == "Reverse")
                {
                    numbers.Reverse();
                }
                else
                {
                    continue;
                }

            }
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
