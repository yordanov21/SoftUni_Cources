﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream("copied.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int byteSize = reader.Read(buffer, 0, buffer.Length);

                        if (byteSize < 1)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, byteSize);
                    }
                }
            }
        }
    }
}
