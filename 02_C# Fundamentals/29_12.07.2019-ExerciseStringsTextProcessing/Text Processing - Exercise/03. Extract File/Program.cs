using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;



namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = Console.ReadLine()
                .Split('.');

            string substract = file[1];

            string fileList = file[0];
            int fileFolder = fileList.LastIndexOf('\u005c');
            string fileName = fileList.Substring(fileFolder + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {substract}");
        }
    }
}
