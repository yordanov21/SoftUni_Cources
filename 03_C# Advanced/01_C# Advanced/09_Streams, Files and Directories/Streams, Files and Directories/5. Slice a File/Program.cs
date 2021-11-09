using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            int fileCount = int.Parse(Console.ReadLine());

            using (var reader = new FileStream("Resources/05. Slice File/sliceMe.txt", FileMode.Open))
            {
                var partLength = Math.Ceiling((double)reader.Length / fileCount);
                for (int i = 1; i <= fileCount; i++)
                {
                    var currentFileName = $"slice-{i}.txt";
                    var currentFileTotalBytes = 0;

                    using (var writer = new FileStream($"Resources/05. Slice File/{currentFileName}", FileMode.Create))
                    {
                        while (true)
                        {
                            var bufer = new byte[4096]; // 4 KB

                            var totalRead = reader.Read(bufer, 0, bufer.Length);

                            if (totalRead == 0)
                            {
                                break;
                            }

                            currentFileTotalBytes += totalRead;

                            writer.Write(bufer, 0, totalRead);

                            if (currentFileTotalBytes >= partLength)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
