using NUnit.Framework;
using System;
using fvat;

namespace fvatTest {
    [TestFixture]
    class InvoiceTest
    {
        public Product p1, p2, p3;
        public Company comp1;
        public Seller s1;
        public Cart cart1;
        public CartItem cartIt1, cartIt2, cartIt3;
        public Invoice inv1, inv2;
        [SetUp]
        public void Setup()
        {
            p1 = new Product("TestProduct", 11m);
            p2 = new Product("TestProduct2", 13.00m);
            p3 = new Product("TestProduct3", 1.00m);
            comp1 = new Company("TestCompany1", "Warsaw", "0123456789");
            s1 = new Seller("12345678901234567890123456", "TestCompany2", "Berlin", "1122334455");
            cartIt1 = new CartItem(p1, 2);
            cartIt2 = new CartItem(p2, 2);
            cartIt3 = new CartItem(p3, 2);
            cart1 = new Cart(comp1, s1, cartIt1, cartIt2, cartIt3);
        }
        [Test]
        public void compareInvoiceID_ReturnCorrectResult()
        {
            inv1 = new Invoice();
            inv2 = new Invoice();
            Assert.True(inv1.invId != inv2.invId);
        }
        [Test]
        public void calculateFinalPrice_ReturnCorrectResult()
        {
            inv1 = new Invoice();
            Assert.That(inv1.calculateFinalPrice(cart1), Is.EqualTo(61.5m));
        }
    }
}