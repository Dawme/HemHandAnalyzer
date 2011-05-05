using System;
using NUnit.Framework;

namespace HemHandAnalyzer.UnitTests
{
    // Test useless GIT commit
    [TestFixture]
    class TestCard
    {        
        [Test]
        public void InstantiateCard()
        {
            var c = new Card('A', Suit.Diamond);
            Assert.AreEqual("Ad", c.ToString());

            c = new Card('A', 'd');
            Assert.AreEqual("Ad", c.ToString());

            c = new Card('a', 'S');
            Assert.AreEqual("As", c.ToString());

            c = new Card('t', Suit.Heart);
            Assert.AreEqual("Th", c.ToString());

            c = new Card('2', Suit.Spade);
            Assert.AreEqual("2s", c.ToString());

            c = new Card("As");
            Assert.AreEqual("As", c.ToString());
            
            c = new Card("as");
            Assert.AreEqual("As", c.ToString());

            c = new Card("2H");
            Assert.AreEqual("2h", c.ToString());
        }

        [Test]
        public void InstantiateInvalidCard()
        {
            Assert.Throws(typeof(ArgumentException), delegate { new Card('g', Suit.Diamond); });
            Assert.Throws(typeof(ArgumentException), delegate { new Card('a', (Suit) 8); });
            Assert.Throws(typeof(ArgumentException), delegate { new Card("bd"); });
            Assert.Throws(typeof(ArgumentException), delegate { new Card("ak"); });
            Assert.Throws(typeof(ArgumentException), delegate { new Card("As2"); });
            Assert.Throws(typeof(ArgumentException), delegate { new Card("A"); });
            Assert.Throws(typeof(ArgumentException), delegate { new Card("2"); });
        }
    }
}

