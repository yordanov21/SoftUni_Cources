using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private Dictionary<string, ICard> cardByName;

        public CardRepository()
        {
            this.cardByName = new Dictionary<string, ICard>();
        }
        public int Count => this.cardByName.Count;

        public IReadOnlyCollection<ICard> Cards =>
            cardByName.Values.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            ThrowIfCardIsNull(card, "Card cannot be null!");

            if (cardByName.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cardByName.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;
            if (this.cardByName.ContainsKey(name))
            {
                card = this.cardByName[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            ThrowIfCardIsNull(card, "Card cannot be null!");

            return this.cardByName.Remove(card.Name);
        }

        private void ThrowIfCardIsNull(ICard card, string massage)
        {
            if (card == null)
            {
                throw new ArgumentException(massage);
            }
        }
    }
}
