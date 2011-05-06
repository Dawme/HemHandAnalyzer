using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HemHandAnalyzer
{
    /// <summary>
    /// A hand abstraction.. Basically, a hand is a collection of 1 to N cards
    /// </summary>
    class Hand
    {
        private readonly List<Card> _cards = new List<Card>();

        // constructors...
        public Hand(params object[] args)
        {
            if (args.Length == 0)
                throw new ArgumentException("Hand need at least 1 card as argument");
            foreach (object arg in args)
            {
                if (!(arg is Card))
                    throw new ArgumentException("Hand only accept cards as argument");
                if (_cards.Contains((Card) arg))
                    throw new ArgumentException("Tried to add duplicate cards");
                _cards.Add((Card) arg);
            }
        }

        public Hand(Card c)
        {
            if (c == null)
                throw new ArgumentException("Hand cannot take a null card");
            _cards.Add(c);
        }

        public Hand(List<Card> lCard)
        {
            if (lCard == null || lCard.Count == 0)
                throw new ArgumentException("Hand needs a card to be instantiated");
            foreach (Card c in lCard)
                AddCard(c);
        }

        public bool Contains(Card c)
        {
            return _cards.Contains(c);
        }

        public void AddCard(String s)
        {
            Card c = new Card(s);
            if (_cards.Contains(c))
                throw new ArgumentException("Tried to add duplicate cards");
            _cards.Add(c);
        }

        public void AddCard(Card c)
        {
            if (_cards.Contains(c))
                throw new ArgumentException("Tried to add duplicate cards");
            _cards.Add(c);
        }

        public Int32 Count
        {
            get { return _cards.Count; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hand))
                throw new ArgumentException("Can only compare hands between themselves");
            Hand comparedTo = (Hand) obj;
            if (comparedTo.Count != Count)
                return false;
            foreach (Card c in _cards)
                if (!comparedTo.Contains(c))
                    return false;
            return true;
        }
    }
}
