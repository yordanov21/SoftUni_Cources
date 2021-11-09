using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        {
        }
        public Car(string model, Engine engine, string color)
           : this(model, engine, -1, color)
        {
        }
        public Car(string model, Engine engine)
             : this(model, engine, -1, "n/a")
        {
        }

        public Car()
        {
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{Model}:");
            stringBuilder.AppendLine(Engine.ToString());
            stringBuilder.AppendLine(this.Weight == -1
                ? $"  Weight: n/a"
                : $"  Weight: {Weight.ToString()}");
            stringBuilder.Append(this.Color == "-1"
                ? $"  Color: n/a"
                : $"  Color: {Color}");

            return stringBuilder.ToString();

        }
    }
}
