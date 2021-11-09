using System;
using System.Linq;
using System.Text;

namespace _08
{
    class Program
    {
        static void Main(string[] args)
        {
            string numOneAsString = Console.ReadLine();
            string numTwoAsString = Console.ReadLine();

            var numOnearray = ConversionToArray(numOneAsString);
            var numTwoarray = ConversionToArray(numTwoAsString);
            Console.WriteLine(GetSumOfTwoArraysNumbers(numOnearray, numTwoarray));
        }

        static int[] ConversionToArray(string numberAsString)
        {

            int[] numArray = new int[numberAsString.Length];
            for (int i = 0; i < numberAsString.Length; i++)
            {
                numArray[i] = int.Parse(numberAsString[i].ToString());
            }

            numArray = numArray.Reverse().ToArray();
            return numArray;

        }

        static int GetSumOfTwoArraysNumbers(int[] numArray1, int[] numArray2)
        {
            StringBuilder sbNum1 = new StringBuilder();
            for (int i = numArray1.Length - 1; i >= 0; i--)
            {
                sbNum1.Append(numArray1[i]);
            }

            StringBuilder sbNum2 = new StringBuilder();
            for (int i = numArray2.Length - 1; i >= 0; i--)
            {
                sbNum2.Append(numArray2[i]);
            }

            int number1 = int.Parse(sbNum1.ToString().TrimEnd());
            int number2 = int.Parse(sbNum2.ToString().TrimEnd());

            return number1 + number2;
        }
    }
}

