using System;

namespace _01._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int startExamInMinutes = examHour * 60 + examMinutes;
            int arriveExamInMinutes = arriveHour * 60 + arriveMinutes;

            int diffMinutes = startExamInMinutes -arriveExamInMinutes;

            if (diffMinutes == 0)
            {
                Console.WriteLine("On time");
            }
            else if (diffMinutes < 0)
            {
                diffMinutes = Math.Abs(diffMinutes);

                Console.WriteLine("Late");
                if (diffMinutes < 60)
                {
                    Console.WriteLine($"{diffMinutes} minutes after the start");
                }
                else
                {
                    int hourDiff = diffMinutes / 60;
                    int minutesDiff = diffMinutes % 60;

                    if (diffMinutes < 10)
                    {
                        Console.WriteLine($"{hourDiff}:0{minutesDiff} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourDiff}:{minutesDiff} hours after the start");
                    }
                   
                }
            }
            else if (diffMinutes > 0 && diffMinutes <= 30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{diffMinutes} minutes before the start");
            }
            else if (diffMinutes > 30)
            {            
                Console.WriteLine("Early");

                if (diffMinutes < 60)
                {
                    Console.WriteLine($"{diffMinutes} minutes before the start");
                }
                else
                {
                    int hourDiff = diffMinutes / 60;
                    int minutesDiff = diffMinutes % 60;
                    if (minutesDiff < 10)
                    {
                        Console.WriteLine($"{hourDiff}:0{minutesDiff} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourDiff}:{minutesDiff} hours before the start");
                    }
                   
                }
            }
        }
    }
}
