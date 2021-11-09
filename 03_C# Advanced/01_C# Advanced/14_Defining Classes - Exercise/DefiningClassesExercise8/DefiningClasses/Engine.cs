using System.Text;
namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficienty;

        public Engine(string model, int power, int displacement, string efficienty)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficienty = efficienty;
        }
        public Engine(string model, int power, int displacement)
            : this(model,power,displacement,"n/a")
        {
        }
        public Engine(string model, int power, string efficienty)
           : this(model, power, -1, efficienty)
        {
        }
        public Engine(string model, int power)
         : this(model, power, -1, "n/a")
        {
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficienty
        {
            get { return efficienty; }
            set { efficienty = value; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"  {Model}:");
            stringBuilder.AppendLine($"    Power: {Power.ToString()}");
            stringBuilder.AppendLine(this.Displacement==-1
                ? $"    Displacement: n/a"
                : $"    Displacement: {Displacement.ToString()}");
            stringBuilder.Append(this.Efficienty=="-1"
                ? $"    Efficiency: n/a"
                : $"    Efficiency: {Efficienty}" );

            return stringBuilder.ToString();
        }
    }
}
