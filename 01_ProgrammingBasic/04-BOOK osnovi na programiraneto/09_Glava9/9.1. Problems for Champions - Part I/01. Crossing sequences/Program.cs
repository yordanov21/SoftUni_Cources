using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Crossing_sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1Tribonachi = int.Parse(Console.ReadLine());
            int n2Tribonachi = int.Parse(Console.ReadLine());
            int n3Tribonachi = int.Parse(Console.ReadLine());

            int n1Matrix = int.Parse(Console.ReadLine());
            int stepMatrix = int.Parse(Console.ReadLine());

            var tribonachiList = new List<int>() { n1Tribonachi, n2Tribonachi, n3Tribonachi };
            var tribunachiCurrent = n3Tribonachi;

            while (tribunachiCurrent < 1000000)
            {
                tribunachiCurrent = n1Tribonachi + n2Tribonachi + n3Tribonachi;
                tribonachiList.Add(tribunachiCurrent);

                n1Tribonachi = n2Tribonachi;
                n2Tribonachi = n3Tribonachi;
                n3Tribonachi = tribunachiCurrent;
            }

            var spiralList = new List<int>() { n1Matrix };
            var spiralCurent = n1Matrix;
            var spiralCount = 0;
            var spiralStepMul = 1;

            while (spiralCurent < 1000000)
            {
                spiralCurent += stepMatrix * spiralStepMul;

                spiralList.Add(spiralCurent);
                spiralCount++;
                if (spiralCount % 2 == 0)
                {
                    spiralStepMul++;
                }
            }
            bool faund = false;
            for (int i = 0; i < tribonachiList.Count; i++)
            {
                for (int j = 0; j < spiralList.Count; j++)
                {
                    if (tribonachiList[i] == spiralList[j]&&tribonachiList[i]<=1000000)
                    {
                        Console.WriteLine(tribonachiList[i]);
                        faund = true;
                        break;
                    }
                   
                }
                if (faund)
                {
                    break;
                }
            }

            if (!faund)
            {
                Console.WriteLine("No");
            }
        }
    }
}
