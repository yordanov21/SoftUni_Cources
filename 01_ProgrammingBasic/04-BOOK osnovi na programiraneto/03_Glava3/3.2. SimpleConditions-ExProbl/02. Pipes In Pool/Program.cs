using System;

namespace _02._Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int poolVolum = int.Parse(Console.ReadLine());
            int debitPipe1perHour = int.Parse(Console.ReadLine());
            int debitPipe2perHour = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double flows = debitPipe1perHour * hours + debitPipe2perHour * hours;

            if (flows > poolVolum)
            {
                double overFlows = flows - poolVolum;
                Console.WriteLine($"For {hours} hours the pool overflows with {overFlows} liters.");
            }
            else
            {
                double allPercent =Math.Truncate( (flows / poolVolum) * 100);
                double percetPipe1 =Math.Truncate (((debitPipe1perHour * hours) / flows) * 100);
                double percetPipe2 = Math.Truncate(((debitPipe2perHour * hours) / flows) * 100);

                Console.WriteLine($"The pool is {allPercent}% full. Pipe 1: {percetPipe1}%. Pipe 2: {percetPipe2}%.");
            }
        }
    }
}
