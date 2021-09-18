using System;

namespace _01._Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            while (input != "END")
            {
                bool intTryParseIsSucceess = int.TryParse(input, out int intValie);
                bool doubleTryParseIsSucceess = double.TryParse(input, out double doubleValie);
                bool charTryParseIsSucceess = char.TryParse(input, out char charValie);
                bool boolTryParseIsSucceess = bool.TryParse(input, out bool boolValie);

                if (intTryParseIsSucceess)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (doubleTryParseIsSucceess)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (boolTryParseIsSucceess)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else if (charTryParseIsSucceess)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
