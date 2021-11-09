namespace _01._Generic_Box_of_String
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
