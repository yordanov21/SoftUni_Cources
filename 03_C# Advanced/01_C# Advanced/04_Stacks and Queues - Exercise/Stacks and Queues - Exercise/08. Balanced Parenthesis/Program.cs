using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            int lineHalfLength = line.Length / 2;

            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();

            if (line.Length % 2 != 0||line.Length<1||line.Length>1000)
            {
                Console.WriteLine("NO");
                return;
            }

            bool balannsed = true;

            for (int i = 0; i < line.Length / 2; i++)
            {
                if (line[i] == '{' || line[i] == '}' || line[i] == '(' || line[i] == ')' || line[i] == '[' || line[i] == ']')
                {
                    stack.Push(line[i]);
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            for (int i = lineHalfLength; i < line.Length; i++)
            {
                if (line[i] == '{' || line[i] == '}' || line[i] == '(' || line[i] == ')' || line[i] == '[' || line[i] == ']')
                {
                    queue.Enqueue(line[i]);
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }

            }
            while (stack.Count>0)
            {
                var stackItem = stack.Pop();
                var queueItem = queue.Dequeue();
                
                if (stackItem != queueItem)
                {
                    balannsed = false;
                }
            }
            if (balannsed)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
