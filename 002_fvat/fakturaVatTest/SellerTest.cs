using NUnit.Framework;
using System;
using fvat;

namespace fvatTest {
    [TestFixture]
    class SellerTest
    {
        [TestCase ("-12345678901234567890123456")]
        [TestCase("NaN")]
        [TestCase("123456789012345678901234567890123456")]
        [TestCase("1")]
        public void invalidAccountNumber_ThrowsException(string t)
        {
            Assert.Throws<ArgumentException>(() => new Seller(t, "Firma", "Warszawa", "12345678901"));
        }
    }
}