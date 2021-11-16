namespace _02.LegionSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IEnemy : IComparable, IComparable<IEnemy>  // hint: added IComparable<IEnemy> for making colections from IEnemis in preorityqueue
    {
        int AttackSpeed { get; set; }

        int Health { get; set; }
    }
}
