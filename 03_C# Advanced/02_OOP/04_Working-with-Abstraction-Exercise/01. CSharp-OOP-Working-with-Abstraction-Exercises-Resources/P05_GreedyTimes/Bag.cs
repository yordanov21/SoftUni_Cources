using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        public Bag()
        {
            this.Capacity = 0;
            this.GoldStore = 0;
            this.GemStore = new Dictionary<string, Gem>();
            this.CashStore = new Dictionary<string, Cash>();
        }
        public long Capacity { get; set; }

        public long GoldStore { get; set; }

        public Dictionary<string, Gem> GemStore { get; set; }

        public Dictionary<string, Cash> CashStore { get; set; }

        public void AddGold(long goldQuantity)
        {
            GoldStore += goldQuantity;
        }

        public void AddGem(string gem, long quantity)
        {
            if (!GemStore.ContainsKey(gem))
            {
                GemStore[gem] =new Gem(gem);
            }
            GemStore[gem].AddGemQuantity(quantity);
            
        }

        public void AddCash(string cash, long quantity)
        {
            if (!CashStore.ContainsKey(cash))
            {
                CashStore[cash] = new Cash(cash);
            }
            CashStore[cash].AddCachQuantity(quantity);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (GoldStore > 0)
            {
                sb.AppendLine($"<Gold> ${GoldStore}");
            }

            if (GemStore.Any())
            {
                long allQuantityOfGems = 0;
                foreach (var gem in GemStore)
                {
                    var currentQuantityOfGems= gem.Value.Quantity;
                    allQuantityOfGems += currentQuantityOfGems;

                }
                sb.AppendLine($"<Gem> ${allQuantityOfGems}");
                foreach (var gem in GemStore)
                {
                    sb.AppendLine($"##{gem.Value.Name} - {gem.Value.Quantity}");
                }
            }

            if (CashStore.Any())
            {
                long allQuantityOfcash = 0;
                foreach (var cash in CashStore)
                {
                    var currentQuantityOfcash = cash.Value.Quantity;
                    allQuantityOfcash += currentQuantityOfcash;

                }
                sb.AppendLine($"<Cash> ${allQuantityOfcash}");
                foreach (var cash in CashStore)
                {
                    sb.AppendLine($"##{cash.Value.Name} - {cash.Value.Quantity}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
