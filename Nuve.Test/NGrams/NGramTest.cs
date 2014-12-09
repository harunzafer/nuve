using System.Collections.Generic;
using NUnit.Framework;
using Nuve.NGrams;

namespace Nuve.Test.NGrams
{
    [TestFixture]
    internal class NGramTest
    {
        [Test]
        public void TestEquals()
        {
            var trigram1 = new NGram(new List<string> {"one", "two", "three"} );
            var trigram2 = new NGram(new List<string> {"one", "two", "three"} );

            Assert.AreEqual(trigram1, trigram2);
            Assert.AreEqual(trigram1.GetHashCode(),trigram2.GetHashCode());


            trigram1 = new NGram(new List<string> { "two", "one", "three" });
            trigram2 = new NGram(new List<string> { "one", "two", "three" });

            Assert.AreNotEqual(trigram1, trigram2);
            Assert.AreNotEqual(trigram1.GetHashCode(), trigram2.GetHashCode());


            trigram1 = new NGram( "one", "two", "three");
            trigram2 = new NGram( "one", "two", "three");

            Assert.AreEqual(trigram1, trigram2);
            Assert.AreEqual(trigram1.GetHashCode(), trigram2.GetHashCode());


            trigram1 = new NGram( "two", "one", "three" );
            trigram2 = new NGram( "one", "two", "three" );

            Assert.AreNotEqual(trigram1, trigram2);
            Assert.AreNotEqual(trigram1.GetHashCode(), trigram2.GetHashCode());
            
            
        }
    }
}