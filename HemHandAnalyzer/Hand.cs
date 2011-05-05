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
        List<Card> cards = new List<Card>();

        // constructors...
        Hand(params object[] args)
        {
            foreach (object arg in args)
            {
                if (!(arg is Card))
                    throw new ArgumentException("");
            }
        }
    }
}
