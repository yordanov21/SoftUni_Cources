using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int filmsNum = int.Parse(Console.ReadLine());
            string Film = string.Empty;
            string maxratingfilm = string.Empty;
            string minratingfilm = string.Empty;
            double rating = 0;
            double maxRating = double.MinValue;
            double minRating = double.MaxValue;
            double sumRating = 0;
            for (int i = 1; i <= filmsNum; i++)
            {
                Film = Console.ReadLine();
                rating = double.Parse(Console.ReadLine());
                sumRating += rating;
                if (rating < minRating)
                {
                    minRating = rating;
                    minratingfilm = Film;

                }
                if (rating > maxRating)
                {
                    maxRating = rating;
                    maxratingfilm = Film;
                }

            }
            Console.WriteLine($"{maxratingfilm} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{minratingfilm} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {sumRating/filmsNum:f1}");

        }
    }
}
