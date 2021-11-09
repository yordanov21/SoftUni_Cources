using System;

namespace _04Environment
{
    class Program
    {
        static void Main(string[] args)
        {
           var resultInSeconds = Environment.TickCount/1000.0;
            Console.WriteLine(resultInSeconds);
            TimeSpan t = TimeSpan.FromSeconds(resultInSeconds);

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                            t.Hours,
                            t.Minutes,
                            t.Seconds,
                            t.Milliseconds);

            Console.WriteLine(answer);
        }
    }
}
