using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace HemHandAnalyzer.UnitTests
{
    [TestFixture]
    class TestHand
    {
        [Test]
        public void InstantiateHand()
        {
            var h = new Hand(new Card("Ad"));
            Assert.IsTrue(h.Contains(new Card('A', Suit.Diamond)));
            Assert.IsFalse(h.Contains(new Card('K', Suit.Diamond)));
            h.AddCard("Kd");
            Assert.IsTrue(h.Contains(new Card('K', Suit.Diamond)));
            Assert.Throws(typeof (ArgumentException), delegate { h.AddCard("Kd"); });
            Assert.Throws(typeof(ArgumentException), delegate { h.AddCard(new Card("Ad")); });

            List<Card> l = new List<Card>();
            l.Add(new Card("Ad"));

            h = new Hand(l);
            
            l.Add(new Card("Ad"));
            Assert.Throws(typeof(ArgumentException), delegate { h = new Hand(l); });            
        }
    }
}
