using System;

namespace example3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrArg = new int[] { 1, 2, 3, 4 };

            Console.WriteLine("Before ModifyArray() the argument is: ");
            PrintArray(arrArg);

            ModifyArray(arrArg);

            Console.WriteLine("After ModifyArray() the argument is: ");
            PrintArray(arrArg);

         
        }

        static void ModifyArray(int [] arrParam)
        {
            arrParam[0] = 5;

            Console.WriteLine("In ModifyArray() the param is: ");
            PrintArray(arrParam);
        }

        static void PrintArray(int [] arrParam)
        {
            int length = arrParam.Length;
            Console.Write("[");

            if (length > 0)
            {
                Console.Write(string.Join(", ",arrParam));
            }

            Console.WriteLine("]");
        }
    }
}
