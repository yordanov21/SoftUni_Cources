﻿using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration , IDecoration
    {
        private const int ComfortConst = 1;
        private const decimal PriceConst = 5;

        public Ornament() 
            : base(ComfortConst, PriceConst)
        {
        } 
    }
}
