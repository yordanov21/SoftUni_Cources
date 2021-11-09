using System;
using System.Collections.Generic;
using System.Text;

namespace exapmple5Properties
{
   public class Rectangle
    {
        public const double PI=3.14;
        private float height;
        private float width;
        public Rectangle(float height, float width)
        {
            this.height = height;
            this.width = width;
        }

        //public float Area
        //{
        //    get { return this.height * this.width; }
        //}
        public float Area =>  this.height* this.width; //съкратен синтаксис на горното

    }
}
