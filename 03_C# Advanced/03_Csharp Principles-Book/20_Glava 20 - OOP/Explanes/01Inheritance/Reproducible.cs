using System;
using System.Collections.Generic;
using System.Text;

namespace _01Inheritance
{
    public interface Reproducible<T> where T:Felidae
    {
        T[] Reprodice(T mate);
    }
}
