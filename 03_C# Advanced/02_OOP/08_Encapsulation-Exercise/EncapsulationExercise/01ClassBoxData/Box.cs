namespace _01ClassBoxData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box
    {
        //You are given a geometric figure box with parameters length, width and height.
        //Model a class Box that that can be instantiated by the same three parameters.
        //Expose to the outside world only methods for its surface area,lateral surface area and its volume
        //(formulas: http://www.mathwords.com/r/rectangular_parallelepiped.htm).
        //A box’s side should not be zero or a negative number.
        //Аdd data validation for each parameter given to the constructor.
        //Make a private setter that performs data validation internally.

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return this.length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }
        //        Volume = lwh
        //Lateral Surface Area = 2lh + 2wh
        //Surface Area = 2lw + 2lh + 2wh
        public string SurfaceArea()
        {
            double area = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Height * this.Width;
            return $"Surface Area - {area:f2}";
        }

        public string LateralSurfaceArea()
        {
            double literalsurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return $"Lateral Surface Area - {literalsurfaceArea:f2}";
        }

        public string Volume()
        {
            double volume = this.Length * this.Height * this.Width;
            return $"Volume - {volume:f2}";
        }
    }
}
