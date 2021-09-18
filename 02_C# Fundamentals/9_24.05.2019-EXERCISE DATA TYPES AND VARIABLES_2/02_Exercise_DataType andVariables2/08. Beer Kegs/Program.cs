using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            double volum = 0.0;
            double bigestVolum = 0.0;
            string bigestKeg = string.Empty;
            for (int i = 1; i <= lines; i++)

            {
                string kegs = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                volum = Math.PI * radius*radius * height;
                if (bigestVolum < volum)
                {
                    bigestVolum = volum;
                    bigestKeg = kegs;
                }

            }

            Console.WriteLine(bigestKeg);
        }
    }
}
