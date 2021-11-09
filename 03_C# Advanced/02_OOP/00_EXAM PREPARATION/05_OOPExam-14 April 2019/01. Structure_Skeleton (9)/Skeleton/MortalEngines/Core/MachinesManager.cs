namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {

        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;
        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);

            // It's work correctly in two ways!
            //var AlreadyHire = pilots.Contains(pilots.FirstOrDefault(x => x.Name == name));
            var AlreadyHire = pilots.Any(x => x.Name == name);

            if (AlreadyHire)
            {
                return $"Pilot {name} is hired already";
            }

            this.pilots.Add(pilot);
            return $"Pilot {name} hired";

        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            //var AlreadyExist = machines.Contains(machines.FirstOrDefault(x => x.Name == name));
            var AlreadyExist = machines.Any(x => x.Name == name);
            if (AlreadyExist)
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine tank = new Tank(name, attackPoints, defensePoints);
            machines.Add(tank);

            return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var AlreadyExist = machines.Contains(machines.FirstOrDefault(x => x.Name == name));
            if (AlreadyExist)
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(fighter);

            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: {(fighter.AggressiveMode == true ? "ON" : "OFF")}";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {

            var occupiedMachins = new List<string>();
            var occupiedMachine = occupiedMachins
                .Contains(occupiedMachins.FirstOrDefault(x => x == selectedMachineName));
            var existMachine = machines.Contains(machines.FirstOrDefault(x => x.Name == selectedMachineName));
            var existPilot = pilots.Contains(pilots.FirstOrDefault(x => x.Name == selectedPilotName));
            if (!existPilot)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            else if (!existMachine)
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            else if (occupiedMachine)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                occupiedMachins.Add(selectedMachineName);

                var machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);
                pilots.FirstOrDefault(x => x.Name == selectedPilotName).AddMachine(machine);

                return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var existAttackMachine = machines.Contains(machines.FirstOrDefault(x => x.Name == attackingMachineName));
            var existDefenceMachine = machines.Contains(machines.FirstOrDefault(x => x.Name == defendingMachineName));
            var healthPointsAttackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName).HealthPoints;
            var healthPointsDefenceMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName).HealthPoints;

            if (!existAttackMachine)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            else if (!existDefenceMachine)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            else if (healthPointsAttackingMachine == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if (healthPointsDefenceMachine == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            else
            {
                machines.FirstOrDefault(x => x.Name == attackingMachineName).Attack(machines.FirstOrDefault(x => x.Name == defendingMachineName));
                 healthPointsAttackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName).HealthPoints;
                 healthPointsDefenceMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName).HealthPoints;

                return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {healthPointsDefenceMachine:F2}";
            }
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = pilots.FirstOrDefault(x => x.Name == pilotReporting);
            var report = pilot.Report();
            return report;
        }

        public string MachineReport(string machineName)
        {
            var machine = machines.FirstOrDefault(x => x.Name == machineName);
            var report = machine.ToString();
            return report;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var CheckExist = machines.Contains(machines.FirstOrDefault(x => x.Name == fighterName));
            if (!CheckExist)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            //Toggle
            IFighter fighter = (Fighter)this.machines.FirstOrDefault(m => m.Name == fighterName);
            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var CheckExist = machines.Contains(machines.FirstOrDefault(x => x.Name == tankName));
            if (!CheckExist)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            // Toggle
            ITank tank = (Tank)this.machines.FirstOrDefault(m => m.Name == tankName);
            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
    }
}