using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            var rl = new RandomList
            {
                "ggg",
                "dfd",
                "ttt",
                "tffgtt",
                "tfgfgtt",
                "ttssssssssssst"
            };

            Console.WriteLine(rl.RandomString());
        }
    }
}
