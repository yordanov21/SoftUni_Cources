namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private MaxPriorityQueue<IEnemy> maxAttackEnemies;
        private MinPriorityQueue<IEnemy> minAttackEnemies;
        private List<IEnemy> enemiesList;
        private SortedDictionary<int,IEnemy> enemiesDic;

        public int Size => enemiesDic.Count;

        public Legion()
        {
            this.maxAttackEnemies = new MaxPriorityQueue<IEnemy>();
            this.minAttackEnemies = new MinPriorityQueue<IEnemy>();
            this.enemiesList = new List<IEnemy>();
            this.enemiesDic = new SortedDictionary<int, IEnemy>();
        }

        public bool Contains(IEnemy enemy)
        {
            // todo may be faster with a dictionary
            return this.enemiesDic.ContainsKey(enemy.AttackSpeed);
        }

        public void Create(IEnemy enemy)
        {
            if(!enemiesDic.ContainsKey(enemy.AttackSpeed))
            {
                maxAttackEnemies.Add(enemy);
                minAttackEnemies.Add(enemy);
                enemiesList.Add(enemy);
                enemiesDic.Add(enemy.AttackSpeed, enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            if (enemiesDic.ContainsKey(speed))
            {
                return enemiesDic[speed];
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            return enemiesList.Where(x => x.AttackSpeed > speed).ToList();
        }

        public IEnemy GetFastest()
        {
            if(Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            return maxAttackEnemies.Peek();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            return enemiesList.OrderByDescending(x => x.Health).ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            return enemiesList.Where(x => x.AttackSpeed<speed).ToList();
        }

        public IEnemy GetSlowest()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            return minAttackEnemies.Peek();
        }

        public void ShootFastest()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var enemy = maxAttackEnemies.Dequeue();
            enemiesList.Remove(enemy);
            enemiesDic.Remove(enemy.AttackSpeed);
        }

        public void ShootSlowest()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            var enemy = minAttackEnemies.Dequeue();
            enemiesList.Remove(enemy);
            enemiesDic.Remove(enemy.AttackSpeed);
        }
    }
}
