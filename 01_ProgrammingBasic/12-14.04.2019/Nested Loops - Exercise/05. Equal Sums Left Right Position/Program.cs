using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());


            for (int i = num1; i <= num2; i++)
            {
                
                string currentNum = i.ToString();
                int Sumleft = 0;
                int SumRight = 0;
                int Middle = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {                   
                    int currentDigit = int.Parse(currentNum[j].ToString());
                    if (j < 2)
                    {
                        Sumleft += currentDigit;
                    }
                    else if (j == 2)
                    {
                        Middle += currentDigit;
                    }
                    else if (j > 2)
                    {
                        SumRight += currentDigit;
                    }
                }
                if (Sumleft != SumRight)
                {
                    if (Sumleft > SumRight)
                    {
                        SumRight += Middle;
                    }
                    else
                    {
                        Sumleft += Middle;
                    }
                }
                if (Sumleft == SumRight)
                {
                    Console.Write(i + " ");                   
                }
            }
        }
    }
}
