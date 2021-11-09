using System;
using System.Collections.Generic;
using System.Text;

namespace example3
{
    public class Collar
    {
        private int size;
        public Collar(int size)       
        {
            this.size = size;
        }
        public int Size
        {
            get { return size; }
        }
    }
}
