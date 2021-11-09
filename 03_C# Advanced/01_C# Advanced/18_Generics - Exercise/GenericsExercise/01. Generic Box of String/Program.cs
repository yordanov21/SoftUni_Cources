namespace _01._Generic_Box_of_String
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box);
            }
            
        }
    }
}
