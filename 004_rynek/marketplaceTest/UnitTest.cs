using NUnit.Framework;
using System;
using marketplace;
using System.Collections.Generic;
using System.Linq;

namespace marketTest {
    [TestFixture]
    class UnitTest
    {
        private Bank bank;
        private Shop shop;
        private SupplyProduct product1;
        private SupplyProduct product2;
        private DemandProduct product1d;
        private DemandProduct product2d;
        private Dictionary<SupplyProduct, int> shopStock;
        private List<DemandProduct> demandedproducts;
        private Buyer buyer;
        [SetUp]
        public void Setup()
        {
            bank = new Bank(0.02m, 0.23m, 0.0m);

            product1 = new SupplyProduct("Bread", 0.75m, 0.3m);
            product2 = new SupplyProduct("Milk", 0.75m, 0.3m);

            shopStock = new Dictionary<SupplyProduct, int>
            {
                [product1] = 50000,
                [product2] = 70000
            };

            shop = new Shop(shopStock, bank, 250);

            product1d = new DemandProduct("Bread", 1.2m, 10000);
            product2d = new DemandProduct("Milk", 0.1m, 10000);

            demandedproducts = new List<DemandProduct>
            {
                product1d,
                product2d
            };
            buyer = new Buyer(demandedproducts, bank, 1000000);

            bank.Subscribe(shop);
            bank.Subscribe(buyer);
            shop.Subscribe(buyer);
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }
        [Test]
        public void CheckIfCanCreateBank()
        {
            bank = new Bank(0.02m, 0.23m, 0.0m);
            Assert.That(bank, Is.Not.Null);
        }
        [Test]
        public void CheckIfCanCreateShop()
        {
            shop = new Shop(shopStock, bank, 250);
            Assert.That(bank, Is.Not.Null);
        }
        [Test]
        public void CheckIfCanCreateBuyer()
        {
            buyer = new Buyer(demandedproducts, bank, 1000000);
            Assert.That(bank, Is.Not.Null);
        }
        [Test]
        public void CheckIfDemandListCreatesCorrectly()
        {
            demandedproducts = new List<DemandProduct>
            {
                product1d,
                product2d
            };
            Assert.That(demandedproducts[0], Is.EqualTo(product1d));
            Assert.That(demandedproducts[1], Is.EqualTo(product2d));
        }
        [Test]
        public void CheckIfSupplyListCreatesCorrectly()
        {

            shopStock = new Dictionary<SupplyProduct, int>
            {
                [product1] = 50000,
                [product2] = 70000
            };

            Assert.That(shopStock.Keys.First(), Is.EqualTo(product1));
            Assert.That(shopStock.Keys.Last(), Is.EqualTo(product2));

        }
        [Test]
        public void CheckIfTurnChanges()
        {
            bank.StartRound();
            Assert.That(bank.Turn.Equals(1));
        }
        [Test]
        public void CheckIfInflationChangesCorrectly()
        {
            bank.StartRound();
            Assert.That(bank.fdata.Inflation, Is.EqualTo(0.04m));
        }
        [Test]
        public void CheckIfTaxChangesCorrectly()
        {
            bank.StartRound();
            Assert.That(bank.fdata.Tax, Is.EqualTo(0.22m));
        }
    }
}