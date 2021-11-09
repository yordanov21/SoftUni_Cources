namespace _04HotelReservation
{
    using System;
    using static _04HotelReservation.PriceCalculator;

    public class Program
    {
        static void Main()
        {

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(input[0]);
            int numberOfDays = int.Parse(input[1]);
            string season = input[2];
            string discountType = "None";

            if (input.Length > 3) discountType = input[3];

            decimal totalPrice = PriceCalculator.CalculatePrice(pricePerDay,
                numberOfDays,
                Enum.Parse<Season>(season),
                Enum.Parse<Discount>(discountType));

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
