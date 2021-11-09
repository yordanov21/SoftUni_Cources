namespace CustomStack
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new StackOfStrings();

            stack.AddRange("sdsd");
            stack.AddRange("sdddsdfsd");
            stack.AddRange("sddsd");
            Console.WriteLine(stack.IsEmpty()); 
        }
    }
}
