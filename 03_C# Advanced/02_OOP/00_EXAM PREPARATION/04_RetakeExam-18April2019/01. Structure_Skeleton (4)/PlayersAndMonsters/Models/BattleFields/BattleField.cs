using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            //1
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            //2
            this.ModifyBeginnerPlayer(attackPlayer);
            this.ModifyBeginnerPlayer(enemyPlayer);

            //3
            attackPlayer = this.BoostPlayer(attackPlayer);
            enemyPlayer = this.BoostPlayer(enemyPlayer);

            //4
            FightingPlayers(attackPlayer, enemyPlayer);
        }

        private void FightingPlayers(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            while (true)
            {
                var attackerAttackPoints = attackPlayer
                    .CardRepository
                    .Cards
                    .Select(c => c.DamagePoints)
                    .Sum();
                enemyPlayer.TakeDamage(attackerAttackPoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyAttackPoints = enemyPlayer
                    .CardRepository
                    .Cards
                    .Select(c => c.DamagePoints)
                    .Sum();
                attackPlayer.TakeDamage(enemyAttackPoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private IPlayer BoostPlayer(IPlayer player)
        {
            player.Health += player.CardRepository
                .Cards
                .Select(c => c.HealthPoints)
                .Sum();

            return player;
        }

        private void ModifyBeginnerPlayer(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
