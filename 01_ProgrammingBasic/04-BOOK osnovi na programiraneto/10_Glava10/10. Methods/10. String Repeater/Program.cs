using System;
using System.Text;

namespace _10._String_Repeater
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int repeatNum = int.Parse(Console.ReadLine());
            RepeatString(str, repeatNum);
            
        }

        static void RepeatString(string str,int a)
        {
            var word = new StringBuilder();
            for (int i = 0; i < a; i++)
            {
                word.Append(str);
            }
            Console.WriteLine(word);
        }
    }
}
