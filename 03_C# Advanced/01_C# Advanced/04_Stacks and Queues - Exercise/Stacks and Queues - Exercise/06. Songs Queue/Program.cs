using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queueSongs = new Queue<string>(Console.ReadLine().Split(", "));

            while (queueSongs.Count > 0)
            {
                var line = Console.ReadLine().Split().ToList();
                var command = line[0];

                if (command == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (command == "Add")
                {
                    line.RemoveAt(0);
                    StringBuilder Song = new StringBuilder(string.Join(' ',line));
                    string currentSong = Song.ToString();
                    if (queueSongs.Contains(currentSong))
                    {
                        Console.WriteLine($"{currentSong} is already contained!");
                    }
                    else
                    {
                        queueSongs.Enqueue(currentSong);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ",queueSongs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
