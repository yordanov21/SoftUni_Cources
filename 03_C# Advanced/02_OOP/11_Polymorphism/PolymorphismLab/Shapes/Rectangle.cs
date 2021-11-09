using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public double Width
        {
            get { return width; }
           private set { width = value; }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return this.Height * 2+this.Width*2;
        }

        public override string Draw()
        {
            StringBuilder figure = new StringBuilder();
            DrawLine(this.width, '*', '*');
            for (int i = 1; i < this.height - 1; ++i)
                DrawLine(this.width, '*', ' ');
            DrawLine(this.width, '*', '*');

             void DrawLine(double width, char end, char mid)
            {
                figure.Append(end);
                for (int i = 1; i < width - 1; ++i)
                    figure.Append(mid);
                figure.AppendLine(end.ToString());
            }

            return figure.ToString().TrimEnd(); ;
        }
      

    }
}
