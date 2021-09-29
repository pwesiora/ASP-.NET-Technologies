using NUnit.Framework;
using System;
using fvat;

namespace fvatTest {
    [TestFixture]
    class CartItemTest
    {
        private Product p1;
        [SetUp]
        public void Setup()
        {
            p1 = new Product("TestProduct", 11);
        }
        [TestCase(1, 100)]
        [TestCase(10, 11)]
        public void totalPrice_ReturnCorrectResult(int t, int t2)
        {
            p1.Price = t;
            p1.Vat = t2;
            Assert.That(p1.AfterTaxPrice, Is.EqualTo(t+t*t2));
        }
        [TestCase(null)]
        [TestCase(-1)]
        [TestCase(0)]
        public void invalidQuantity_ThrowsException(int t)
        {
            Assert.Throws<ArgumentException>(() => new CartItem(p1, t));
        }
    }
}