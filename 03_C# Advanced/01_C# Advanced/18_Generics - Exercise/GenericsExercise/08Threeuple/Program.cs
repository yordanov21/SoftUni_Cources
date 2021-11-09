using System;

namespace _08Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputPersonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputPersonBeer = Console.ReadLine().Split();
            string[] inputBankInfo = Console.ReadLine().Split();

            string fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string address = inputPersonInfo[2];
            string city = inputPersonInfo[3];
            if (inputPersonInfo.Length == 5)
            {
                city += " " + inputPersonInfo[4];
            }

            string name = inputPersonBeer[0];
            int littersBeer = int.Parse(inputPersonBeer[1]);
            string drunkOrNot = inputPersonBeer[2];
            bool isDrunk = drunkOrNot == "drunk" ? true : false;
                
            string personName = inputBankInfo[0];
            double balance = double.Parse(inputBankInfo[1]);
            string bankName = inputBankInfo[2];
      
            Treeuple<string, string, string> personInfo = new Treeuple<string, string, string>(fullName, address, city);
            Treeuple<string, int, bool> personBeer = new Treeuple<string, int, bool>(name, littersBeer, isDrunk);
            Treeuple<string, double, string> numbersInfo = new Treeuple<string, double, string>(personName, balance, bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(personBeer);
            Console.WriteLine(numbersInfo);
        }
    }
}
