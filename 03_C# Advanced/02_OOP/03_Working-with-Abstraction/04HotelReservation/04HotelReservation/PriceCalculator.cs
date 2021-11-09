namespace _04HotelReservation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PriceCalculator
    {
        public enum Season
        {
            Spring = 2,
            Summer = 4,
            Autumn = 1,
            Winter = 3
        }

        public enum Discount
        {
            None,
            SecondVisit = 10,
            VIP = 20
        }
        public static decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Season season, Discount discountType)
        {
            int priceMultiplier = (int)season;
            decimal discountMultiplier = (decimal)discountType / 100;
            decimal price = pricePerDay * (decimal)numberOfDays * priceMultiplier;
            decimal discount = price * discountMultiplier;
            decimal totalPrice = price - discount;

            return totalPrice;
        }
    }
}
    

