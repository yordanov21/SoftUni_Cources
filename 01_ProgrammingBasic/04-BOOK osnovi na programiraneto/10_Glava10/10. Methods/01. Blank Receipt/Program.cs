using System;

namespace _01._Blank_Receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintReceip();
        }
        static void PrintReceptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }

        static void PrintReceptFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("(c) SoftUni");
        }

        static void PrintReceptBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }

        static void PrintReceip()
        {
            PrintReceptHeader();
            PrintReceptBody();
            PrintReceptFooter();
        }
    }
}
