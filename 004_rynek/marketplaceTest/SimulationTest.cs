using NUnit.Framework;
using System;
using marketplace;
using System.Collections.Generic;

namespace marketTest
{
    [TestFixture]
    class SimulationTest
    {
        private Bank bank;
        private Shop shop;
        private SupplyProduct product1;
        private SupplyProduct product2;
        private DemandProduct product1d;
        private DemandProduct product2d;
        private Dictionary<SupplyProduct, int> shopStock;
        [SetUp]
        public void Setup()
        {
            bank = new Bank(0.02m, 0.23m, 0.0m);

            product1 = new SupplyProduct("Bread", 0.75m, 0.3m);
            product2 = new SupplyProduct("Milk", 0.75m, 0.3m);
            product1d = new DemandProduct("Bread", 1.2m, 1000);
            product2d = new DemandProduct("Milk", 0.1m, 1000);

            shopStock = new Dictionary<SupplyProduct, int>
            {
                [product1] = 50000,
                [product2] = 70000
            };
            shop = new Shop(shopStock, bank, 250);
        }


        [Test]
        public void MediumTest()
        {
            List<DemandProduct> demandedproducts = new List<DemandProduct>
            {
                product1d,
                product2d
            };
            Buyer buyer = new Buyer(demandedproducts, bank, 1000000);
            bank.Subscribe(shop);
            bank.Subscribe(buyer);
            shop.Subscribe(buyer);
            for (int i = 0; i < 5; i++)
            {
                bank.StartRound();
            }
            Assert.AreEqual(7461.95, (double)bank.Money, .1);
            Assert.AreEqual(4626.81, (double)shop.money, .1);
            Assert.AreEqual(995623.12, (double)buyer.money, .1);
        }
        [Test]
        public void SmallTest()
        {
            List<DemandProduct> demandedproducts = new List<DemandProduct>
            {
                product1d,
                product2d
            };
            Buyer buyer = new Buyer(demandedproducts, bank, 100);
            bank.Subscribe(shop);
            bank.Subscribe(buyer);
            shop.Subscribe(buyer);
            for (int i = 0; i < 2; i++)
            {
                bank.StartRound();
            }
            Assert.AreEqual(196.16, (double)bank.Money, .1);
            Assert.AreEqual(348.79, (double)shop.money, .1);
            Assert.AreEqual(1.2, (double)buyer.money, .1);
        }

        [Test]
        public void LongTest()
        {
            Bank bank = new Bank(0.02m, 0.23m, 0.0m);

            SupplyProduct product1 = new SupplyProduct("Bread", 0.75m, 0.3m);
            SupplyProduct product2 = new SupplyProduct("Milk", 0.75m, 0.3m);

            Dictionary<SupplyProduct, int> sellerproducts = new Dictionary<SupplyProduct, int>
            {
                [product1] = 50000,
                [product2] = 70000
            };

            Shop seller = new Shop(sellerproducts, bank, 250);
            DemandProduct product3 = new DemandProduct("Bread", 1.2m, 10000);
            DemandProduct product4 = new DemandProduct("Milk", 0.1m, 10000);
            List<DemandProduct> demandedproducts = new List<DemandProduct>
            {
                product3,
                product4
            };
            Buyer buyer = new Buyer(demandedproducts, bank, 1000000);
            bank.Subscribe(seller);
            bank.Subscribe(buyer);
            seller.Subscribe(buyer);
            for (int i = 0; i < 50; i++)
            {
                bank.StartRound();
            }
            Assert.AreEqual(74509.1, (double)bank.Money, .1);
            Assert.AreEqual(43949.79, (double)seller.money, .1);
            Assert.AreEqual(956300.2, (double)buyer.money, .1);
        }
    }
}