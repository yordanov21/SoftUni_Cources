using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Example_Class
{
    class TestObj
    {
        //property
        public int Size { get; set; }

        // constructor
        public TestObj(int size)
        {
            this.Size = size;
            Console.WriteLine($"My object is created. The size is {Size}");
        }

        //destructor
        ~TestObj()
        {
            Console.WriteLine("My object is destroyed");
        }
    }
}
