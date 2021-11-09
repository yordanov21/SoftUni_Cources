using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        //private readonly IRepository<IDecoration> decorationRepository;
        //private readonly List<IAquarium> aquariums;

        private readonly IRepository<IDwarf> dwarfRepository;
        private readonly IRepository<IPresent> presentRepository;
        private readonly Workshop workshop;
        public Controller()
        {
            this.dwarfRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            //Adds a Dwarf. Valid types are: "HappyDwarf" and "SleepyDwarf".
            //If the Dwarf type is invalid, you have to throw an InvalidOperationException with the following message:
            //•	"Invalid dwarf type."
            //If the Dwarf is added successfully, the method should return the following string:
            //•	"Successfully added {dwarfType} named {dwarfName}."
            if (dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            if (dwarfType == "HappyDwarf")
            {
                Dwarf dwarf = new HappyDwarf(dwarfName);
                dwarfRepository.Add(dwarf);
            }
            else
            {
                Dwarf dwarf = new SleepyDwarf(dwarfName);
                dwarfRepository.Add(dwarf);
            }

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            //Creates an instrument with the given power and adds it to the collection of the dwarf.
            //If the dwarf doesn't exist, throw an InvalidOperationException with message:
            //"The dwarf you want to add an instrument to doesn't exist!"
            //The method should return the following message:
            //"Successfully added instrument with power {instrumentPower} to dwarf {dwarfName}!"

            var checkForDwarf = dwarfRepository.FindByName(dwarfName);
            if (checkForDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            var instrument = new Instrument(power);
            dwarfRepository.FindByName(dwarfName).Instruments.Add(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            //Creates a present with the provided name and required energy.
            //The method should return the following message:
            //"Successfully added Present: {presentName}!"

            var present = new Present(presentName, energyRequired);
            presentRepository.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            //When the craft command is called, the action happens.
            //You should start crafting the given present, by assigning dwarfs 
            //which are most ready(first the dwarfs with the most energy):
            //•	The dwarfs that you should select are the ones with energy equal to or above 50 units.
            //•	The suitable ones start working on the given present.
            //•	If a dwarf’s energy becomes 0, remove it from the repository.
            //•	If no dwarfs are ready, throw InvalidOperationException with the following message: 
            //"There is no dwarf ready to start crafting!"
            //•	After the work is done, you must return the following message, 
            //reporting whether the present is done:
            //"Present {presentName} is {done/not done}."
            //Note: The name of the present you receive will always be a valid one.

         
            var present = presentRepository.FindByName(presentName);
            int countOfDwarfForWork = dwarfRepository.Models.Where(x => x.Energy >= 50).Count();
            if (countOfDwarfForWork == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            foreach (var dwarf in dwarfRepository.Models.Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy))
            {
                
                    dwarf.Work();
                    workshop.Craft(present, dwarf);
                    //if (dwarf.Energy == 0)
                    //{
                    //    dwarfRepository.Remove(dwarf);
                    //}
               
              
            }

            if (present.EnergyRequired == 0)
            {
                return string.Format(OutputMessages.PresentIsDone, present.Name);

            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, present.Name);
            }
        }

        public string Report()
        {
            //  Returns information about crafted presents and dwarfs:

            //"{countCraftedPresents} presents are done!"
            //"Dwarfs info:"
            //"Name: {dwarfName1}"
            //"Energy: {dwarfEnergy1}"
            //"Instruments {countInstruments} not broken left"
            //…
            //"Name: {dwarfNameN}"
            //"Energy: {dwarfEnergyN}"
            //"Instruments {countInstruments} not broken left"
            //Note: Use \r\n or Environment.NewLine for a new line.
            string message = $"{presentRepository.Models.Where(x => x.EnergyRequired == 0).Count()} presents are done!" + Environment.NewLine;
            message += "Dwarfs info:" + Environment.NewLine;
            foreach (var dwarf in dwarfRepository.Models)
            {
                message += $"Name: {dwarf.Name}" + Environment.NewLine;
                message += $"Energy: {dwarf.Energy}" + Environment.NewLine;
                message += $"Instruments {dwarf.Instruments.Where(x => x.IsBroken() == false).Count()} not broken left" + Environment.NewLine;
            }

            return message.TrimEnd();
        }
    }
}
