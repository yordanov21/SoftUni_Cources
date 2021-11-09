using System;
using System.Collections.Generic;
using System.Text;

namespace example2
{
    public class ConstReadonlyModifiersTest
    {
        public const double PI = 3.1415926535897932385;
        public readonly double size;
        public ConstReadonlyModifiersTest(int size)
        {
            this.size = size; // Cannot be further mgodified!
        }
       
        public int Size { get; }


    }
}
