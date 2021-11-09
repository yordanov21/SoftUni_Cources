using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;

        private IController controller;
        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();

            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string astrotype = input[1];
                        string astroName = input[2];

                        var result = controller.AddAstronaut(astrotype, astroName);
                        writer.WriteLine(result);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        //string[] items = new string[input.Length - 2];
                        //for (int i = 2; i < input.Length; i++)
                        //{
                        //    items[i - 2] = input[i];
                        //}

                        var result= controller.AddPlanet(planetName, input.Skip(2).ToArray());
                        writer.WriteLine(result);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {                      
                        string astroName = input[1];

                        var result = controller.RetireAstronaut(astroName); 
                        writer.WriteLine(result);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];
                        var result = controller.ExplorePlanet(planetName);
                        writer.WriteLine(result);
                    }
                    else if(input[0] == "Report")
                    {
                        var result = controller.Report();
                        writer.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }


            }
        }
    }
}
