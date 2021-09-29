using NUnit.Framework;
using System;
using fvat;

namespace fvatTest {
    [TestFixture]
    class CompanyTest
    {
        [TestCase ("12345678901")]
        [TestCase("qwertyuiop")]
        [TestCase("1234567890a")]
        [TestCase("123456789a")]
        public void invalidNip_ThrowsException(string t)
        {
            Assert.Throws<ArgumentException>(() => new Company("Firma", "Warszawa", t));
        }
        [Test]
        public void validNip_RetrunsCorrectResult()
        {
            Company c1 = new Company("Firma", "Warszawa", "1234567890");
            Assert.That(c1.Nip, Is.EqualTo("1234567890"));
        }
    }
}