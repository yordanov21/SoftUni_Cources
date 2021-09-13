using System;

namespace _03._Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dotes = new string('.', n + 1);
            var underscore = new string('_', n * 2 + 1);
            Console.WriteLine(dotes+underscore+dotes);
            int count = n * 2 - 1;
            for (int i = n; i >=1; i--)
            {
                Console.WriteLine(new string('.',i)+"//"+new string('_',count)+@"\\"+ new string('.', i));
                count += 2;

            }

            Console.WriteLine("//"+new string('_',n*2-3)+"STOP!" + new string('_', n * 2 - 3)+@"\\");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('.', i) + @"\\" + new string('_', count) + "//" + new string('.', i));
                count -= 2;

            }
        }
    }
}
