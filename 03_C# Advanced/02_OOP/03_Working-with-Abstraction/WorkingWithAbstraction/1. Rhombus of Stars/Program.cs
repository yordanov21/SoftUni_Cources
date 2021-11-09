using System;
using System.Text;

namespace _1._Rhombus_of_Stars
{
    public class Program
    {
        static void Main(string[] args)
        {
            int stars = int.Parse(Console.ReadLine());

            var rhombusDrawer = new RhombusAsStringDrawer();
            var rhombusAsString = rhombusDrawer.Draw(stars);

            Console.WriteLine(rhombusAsString);           
        }
    }
}
