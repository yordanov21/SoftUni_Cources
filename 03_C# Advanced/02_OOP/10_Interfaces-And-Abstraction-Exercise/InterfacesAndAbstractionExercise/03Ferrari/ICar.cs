using System;
using System.Collections.Generic;
using System.Text;

namespace _03Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }

        string Breakes();
        string Gas();
    }
}
