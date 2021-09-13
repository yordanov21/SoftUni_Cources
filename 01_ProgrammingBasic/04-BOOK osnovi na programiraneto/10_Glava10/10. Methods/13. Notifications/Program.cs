using System;

namespace _13._Notifications
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            ReadAndProcessMessage(n);

        }
        static void ShowSuccessMessage()
        {
            string operation = Console.ReadLine();
            string message = Console.ReadLine();
            operation = "Successfully executed " + operation + ".";
            var lines = new string('=', operation.Length);

            Console.WriteLine(operation);
            Console.WriteLine(lines);
            Console.WriteLine("{0}.",message);
            Console.WriteLine();
        }

        static void ShowSuccessWarning()
        {
            string operation = Console.ReadLine();
            
            operation = "Warning: " + operation + ".";
            var lines = new string('=', operation.Length);

            Console.WriteLine(operation);
            Console.WriteLine(lines);
            Console.WriteLine();
        }

        static void ShowSuccessError()
        {
            string operation = Console.ReadLine();
            string message = Console.ReadLine();
            int errorCode = int.Parse(Console.ReadLine());

            operation = "Error: Failed to execute " + operation + ".";
            var lines = new string('=', operation.Length);

            Console.WriteLine(operation);
            Console.WriteLine(lines);
            Console.WriteLine("Reason: {0}.", message);
            Console.WriteLine("Error code: {0}.",errorCode);
            Console.WriteLine();
        }

        static void ReadAndProcessMessage(int n)
        {

            for (int i = 0; i < n; i++)
            {
                string messageType = Console.ReadLine();

                if (messageType == "success")
                {
                    ShowSuccessMessage();
                }
                else if (messageType == "warning")
                {
                    ShowSuccessWarning();
                }
                else if (messageType == "error")
                {
                    ShowSuccessError();
                }
            }
        }
    }
}
