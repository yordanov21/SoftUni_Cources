using System;

namespace example5
{
    class Program
    {
        static void Main( string[] args)// тук можем да запишем params и компилатора ще си го приеме без проблеми
        {
            decimal[] prices = new decimal[] { 1m, 2m, 3m, 4m };
            PrintTotalAmountForBooks(prices);
            PrintTotalAmountForBooks(1m, 2m, 3m);
            PrintTotalAmountForBooks(10, 200, 200, 400);
            PrintTotalAmountForBooks();

            DoSometingForTest("sda", 2, 2, 2, 2, 5);

            SomeMethod(2);
            SomeMethod(5,2,2);
            SomeMethod(x:5, y:10, z:20);
            SomeMethod(y:15, z:20, x:25);
        }
        static void PrintTotalAmountForBooks(params decimal[] prices) //използваме ключовата дума params,за да използваме променлив брой аргументи
        {
            decimal totalAmount = 0;
            foreach (decimal singleBookPrice in prices)
            {
                totalAmount += singleBookPrice;
            }

            Console.WriteLine("The total amount of all books is: " + totalAmount);
        }

        static void DoSometingForTest(string stringParametar, params int[] x)  //params винаги на последно място от списъка с аргументи, и не можем да имаме повече от един params!
        {
            Console.WriteLine($"{stringParametar}, {string.Join(":_:", x)}");
        }

        static void SomeMethod(int x, int y=5, int z = 6)// незадължителни параметри
        {
            Console.WriteLine(x+y+z);
        }
    }
}
