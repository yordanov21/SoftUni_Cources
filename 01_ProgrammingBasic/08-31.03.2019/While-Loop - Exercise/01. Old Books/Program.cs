using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string favoriteBook = Console.ReadLine();
            int numbersBook = int.Parse(Console.ReadLine());

            int counter = 0;
            bool bookisfound = false;

            string BookName = Console.ReadLine();
            while (counter < numbersBook)
            {
               
                if (BookName == favoriteBook)
                {
                    bookisfound = true;
                    break;
                }
                counter++;
                BookName = Console.ReadLine();
            }
            if (bookisfound == false)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");

            }
            else
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
        }
    }
}
