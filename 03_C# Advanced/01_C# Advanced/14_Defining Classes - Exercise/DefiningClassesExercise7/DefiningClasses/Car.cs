namespace DefiningClasses
{
    class Car
    {
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;
        private string model;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
           this. Model = model;
           this. Engine = engine;
           this. Cargo = cargo;
           this. Tires = tires;
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

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }


    }
}
