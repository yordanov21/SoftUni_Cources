using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._2_Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenPredicate = num => num % 2 == 0;
            Func<int, bool> isEvenFunc = myNum => myNum % 2 == 0; //може и по този начин и след това функцията ще я вкараме в Where()-ра;

            Action<List<int>> printNumbers = nums => Console.WriteLine(string.Join(" ",nums));

            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            List<int> numbers = new List<int>();
            int startNumber = input[0];
            int endNumber = input[1];

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            string numberType = Console.ReadLine();
            if (numberType == "even")
            {
                numbers.RemoveAll(x => !isEvenPredicate(x));//може и със FildAll , но връща списък от числа и трябва да го запишем отделно,
            }                                               //и това ще ние разултата на задачата
            else
            {
                numbers.RemoveAll(x => isEvenPredicate(x));//може и със FildAll , но връща списък от числа и трябва да го запишем отделно
            }                                              //и това ще ние разултата на задачата

            printNumbers(numbers);

          //  АКО ИЗПОЛЗВАМЕ ФУНКЦИЯ (Func)
          //  List<int> result = new List<int>();
          //  if (numberType == "even")
          //  {
          //      result = numbers.Where(isEvenFunc).ToList();
          //  }                                               
          //  else
          //  {
          //      result = numbers.Where(x=>!isEvenFunc(x)).ToList();
          //  }
          //
          //  printNumbers(result);
        }
    }
}
