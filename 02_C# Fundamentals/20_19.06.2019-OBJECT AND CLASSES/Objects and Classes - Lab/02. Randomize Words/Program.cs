using System;
using System.Linq;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            string[] textArr = text
                .Split()
                .ToArray();

            Random random = new Random();

            for (int i = 0; i < textArr.Length; i++)
            {
                var randomIndex = random.Next(0, textArr.Length);

                var randomEl = textArr[randomIndex];
                var el = textArr[i];

                textArr[randomIndex] = el;
                textArr[i] = randomEl;
            }

            foreach (var number in textArr)
            {
                Console.WriteLine(number);
            }
        }
    }
}
