using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank, IMachine
    {
        private const int InitialHealthPoints = 100;
        private const int InitialAttack = 40;
        private const int InitialDefnse = 30;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints-InitialAttack, defensePoints+InitialDefnse, InitialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
            }
            else if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
            }

            if (this.DefenseMode == true)
            {
                this.AttackPoints -= InitialAttack;
                this.DefensePoints += InitialDefnse;
            }
            else
            {
                this.AttackPoints += InitialAttack;
                this.DefensePoints -= InitialDefnse;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
