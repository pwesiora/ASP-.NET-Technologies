using NUnit.Framework;
using System;
using fvat;
using System.Collections.Generic;

namespace fvatTest {
    [TestFixture]
    class CartTest
    {
        public Product p1;
        public CartItem c1, c2, c3;
        public Company comp1;
        public Seller s1;
        [SetUp]
        public void Setup()
        {
            p1 = new Product("TestProduct", 11);
            c1 = new CartItem(p1, 1);
            c2 = new CartItem(p1, 3);
            c3 = new CartItem(p1, 5);
            comp1 = new Company("TestCompany1", "Warsaw", "0123456789");
            s1 = new Seller("12345678901234567890123456", "TestCompany2", "Berlin", "1122334455");
        }
        [Test]
        public void addToCart_ReturnCorrectResult()
        {
            Cart cart1 = new Cart(comp1, s1, c1, c2);
            cart1.addToCart(c3);
            List<CartItem> items = new List<CartItem>() { c1, c2, c3 };
            CollectionAssert.AreEqual(items, cart1.CartItems);
        }
    }
}