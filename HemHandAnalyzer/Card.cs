using System;

namespace HemHandAnalyzer
{
    internal enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    };

    /// <summary>
    /// A card abstraction
    /// </summary>
    internal class Card
    {
        #region Class members
        private readonly char[] _acceptableCardValues = new[] {
            'A',
            'Q',
            'K',
            'J',
            'T',
            '9',
            '8',
            '7',
            '6',
            '5',
            '4',
            '3',
            '2'
        } ;
        
        private Suit _suit;
        private char _value;
        #endregion

        #region Constructors
        /// <summary>
        /// Instantatiates a card from a value and a suit
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="suit">Suit</param>
        public Card(char value, Suit suit)
        {
            Initialize(value, suit);
        }

        /// <summary>
        /// Instantiates a card from a value and a suit as char
        /// </summary>
        /// <param name="value">Value (char)</param>
        /// <param name="suit">Suit (char)</param>
        public Card(char value, char suit)
        {
            Initialize(value, CharToSuit(suit));
        }

        /// <summary>
        /// Instantiates a card from the string notation
        /// </summary>
        /// <param name="strCard">String representing the card like Ad, Ks, Th...</param>
        public Card(string strCard)
        {
            if (strCard == null)
                throw new ArgumentException("Can't instantiate a card from a null string");
            if (strCard.Length != 2)
                throw new ArgumentException("String length is not good (got " + strCard.Length + "; expected 2)");
            char v = strCard[0];
            var s = CharToSuit(strCard[1]);
            Initialize(v, s);
        }
        #endregion

        /// <summary>
        /// Initializes the card
        /// </summary>
        /// <param name="value">the card value</param>
        /// <param name="suit">the card suit</param>
        private void Initialize(char value, Suit suit)
        {
            value = Char.ToUpper(value);
            if (Array.IndexOf(_acceptableCardValues, value) == -1)
                throw new ArgumentException(value + " is not a valid card value");
            if (!Enum.IsDefined(typeof(Suit), suit))
                throw new ArgumentException(suit + " is not a valid card suit");
            _value = value;
            _suit = suit;
        }
        
        public override string ToString()
        {
            return (_value.ToString() + SuitToChar(_suit));
        }

        static char SuitToChar(Suit s)
        {
            switch (s)
            {
                case Suit.Heart:
                    return 'h';                    
                case Suit.Diamond:
                    return 'd';
                case Suit.Club:
                    return 'c';
                case Suit.Spade:
                    return 's';
            }
            throw new ArgumentException("Invalid suit : " + s);
        }

        static Suit CharToSuit(char c)
        {
            c = Char.ToLower(c);
            switch (c)
            {
                case 'h':
                    return Suit.Heart;
                case 'd':
                    return Suit.Diamond;
                case 'c':
                    return Suit.Club;
                case 's':
                    return Suit.Spade;
            }
            throw new ArgumentException("Invalid char for suit : " + c);
        }
    }
}
