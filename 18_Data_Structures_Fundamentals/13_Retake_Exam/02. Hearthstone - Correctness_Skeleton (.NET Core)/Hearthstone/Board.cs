using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board : IBoard
{
    private List<Card> cards;

    public Board()
    {
        this.cards = new List<Card>();
    }

    // checks if a card with the given name is present in the deck
    public bool Contains(string name)
    {
        var temp = cards.FirstOrDefault(x => x.Name == name);
        if (temp != null)
        {
            return true;
        }
        return false;
    }



    public int Count()
    {
        return cards.Count;
    }

    //	Draw(Card card)– Add a card to the deck of cards.You will need to implement the Contains() method as well.
    //	If the card name already exists throw ArgumentException
    public void Draw(Card card)
    {
        if (!this.Contains(card.Name))
        {
            cards.Add(card);
        }
        else
        {
            throw new ArgumentException();
        }

    }

    //find all cards which have a score between the given two inclusive and ordered by
    //their level descending.If you don’t find any return empty collection.
    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        var tempcard = cards.Where(x => x.Score >= start && x.Score <= end).OrderByDescending(x => x.Level);
        //var cardList = new List<Card>();
        //foreach (var card in cards)
        //{
        //    if(card.)
        //}

        return tempcard;
    }

    // finds the card with the smallest health and increases it with the given health.Cards with negative health can get heal too.
    public void Heal(int health)
    {
        int idx = 0;
        int minHealth =int.MaxValue;
        for (int i = 0; i < cards.Count; i++)
        {
            if(cards[i].Health< minHealth)
            {
                minHealth = cards[i].Health;
                idx = i;
            }
        }

        cards[idx].Health += health;
    }


    //return all cards starting with the specified suffix(sorted by the ASCII code of the reversed name in
    //ascending order as a first criteria and by level in ascending order as a second criteria).
    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        return cards.Where(x => x.Name.StartsWith(prefix)).OrderBy(x => x.Name).ThenBy(x => x.Level);
    }

    //find the attacker card and make damage to the attacked card.The attacker card can only attack other card
    //if they both have the same level(otherwise throw ArgumentException).
    //If the attacked card gets damage more than its current health it is no more available to play with,
    //but it doesn’t get removed from the deck.If the attacker card kills the other card its score increases
    //with the level of the attacked card.If the attacker tries to attack card with 0 or less health nothing happens.
    //If any of the two provided cards does not exist throw ArgumentException

    public void Play(string attackerCardName, string attackedCardName)
    {
        if (cards.Find(x => x.Name == attackedCardName) == null)
        {
            throw new ArgumentException();
        }

        if (cards.Find(x => x.Name == attackerCardName) == null)
        {
            throw new ArgumentException();
        }
        if (!(cards.FirstOrDefault(x => x.Name == attackerCardName).Level == cards.FirstOrDefault(x => x.Name == attackedCardName).Level))
        {
            throw new ArgumentException();
        }

        //If the attacker tries to attack card with 0 or less health nothing happens.
        if (cards.FirstOrDefault(x => x.Name == attackedCardName).Health > 0)
        {
            cards.FirstOrDefault(x => x.Name == attackedCardName).Health -= cards.FirstOrDefault(x => x.Name == attackerCardName).Damage;

            //If the attacker card kills the other card its score increases with the level of the attacked card
            if (cards.FirstOrDefault(x => x.Name == attackedCardName).Health <= 0)
            {
                cards.FirstOrDefault(x => x.Name == attackerCardName).Score += cards.FirstOrDefault(x => x.Name == attackedCardName).Level;
            }
        }
        
    }


    // remove the card with the given name. If the card doesn’t exist return ArgumentException
    public void Remove(string name)
    {
        if (cards.Find(x => x.Name == name) == null)
        {
            throw new ArgumentException();
        }

        var card = cards.FirstOrDefault(x => x.Name == name);
        cards.Remove(card);
    }

    //– remove all cards with health under or equal to 0
    public void RemoveDeath()
    {
        for (int i = cards.Count-1; i >= 0; --i)
        {
            if(cards[i].Health<=0)
            {
                cards.RemoveAt(i);
            }

        }
    }

    // return all cards with the given level, order them by score descending
    public IEnumerable<Card> SearchByLevel(int level)
    {
        return cards.Where(x => x.Level == level).OrderByDescending(x => x.Score);
    }
}