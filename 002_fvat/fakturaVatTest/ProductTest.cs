using NUnit.Framework;
using System;
using fvat;

namespace fvatTest {
    [TestFixture]
    class ProductTest
    {
        [TestCase (-1)]
        [TestCase(-0.000001)]
        [TestCase(null)]
        public void invalidPrice_ThrowsException(decimal t)
        {
            Assert.Throws<ArgumentException>(() => new Product("Item", t));
        }
    }
}