using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card, ICard
    {
        private const int TrapCardInicialDamagePoints = 120;
        private const int TrapCardInicialHealthPoints = 5;
        public TrapCard(string name)
            : base(name, TrapCardInicialDamagePoints, TrapCardInicialHealthPoints)
        {
        }
    }
}
