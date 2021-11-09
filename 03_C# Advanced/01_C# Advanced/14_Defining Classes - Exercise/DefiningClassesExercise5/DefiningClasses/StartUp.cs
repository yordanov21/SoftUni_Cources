using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            double result = dateModifier.GetDifferenceInDaysBetweenTwoDates(firstDate, secondDate);

            Console.WriteLine(result);
        }
    }
}
