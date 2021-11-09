using System;
using System.Collections.Generic;
using System.Text;

namespace _07FoodShortage
{
    interface IBuyer
    {
        string Name { get; }

        int Food { get; }

        void BuyFood();
    }
}
