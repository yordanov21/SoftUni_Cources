using System;
using System.Linq;

namespace _07Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
          

            string[] inputPersonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputPersonBeer = Console.ReadLine().Split();
            string[] inputNumbersInfo = Console.ReadLine().Split();

            string fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string address = inputPersonInfo[2];

            string name = inputPersonBeer[0];
            int littersBeer = int.Parse(inputPersonBeer[1]);

            int integerNum = int.Parse(inputNumbersInfo[0]);
            double doubleNum = double.Parse(inputNumbersInfo[1]);

            MyTuple<string, string> personInfo = new MyTuple<string, string>(fullName, address);
            MyTuple<string, int> personBeer = new MyTuple<string, int>(name, littersBeer);
            MyTuple<int, double> numbersInfo = new MyTuple<int, double>(integerNum, doubleNum);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbersInfo);
        }
    }
}
