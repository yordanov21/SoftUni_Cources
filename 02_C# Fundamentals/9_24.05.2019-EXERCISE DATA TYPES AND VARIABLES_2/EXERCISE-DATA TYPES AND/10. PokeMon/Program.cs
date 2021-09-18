using System;

namespace _10._PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int P = int.Parse(Console.ReadLine());
            int D = int.Parse(Console.ReadLine());
            int E = int.Parse(Console.ReadLine());

            int originalP = P;
            int Target = 0;

            while (P >= D)
            {
                P -= D;
                Target++;

                if(P==originalP*0.5 && E != 0)
                {
                    P /= E;
                }
            }
            Console.WriteLine(P);
            Console.WriteLine(Target);

            
        }
    }
}
