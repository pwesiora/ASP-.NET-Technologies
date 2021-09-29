using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class Buyer : IObserver<(Dictionary<SupplyProduct, int>, Shop)>, IObserver<BankData>
    {
        private BankData fdata = new BankData();
        public decimal money;
        private decimal _inflation;
        public int quantity;
        private Bank _bank;

        private List<DemandProduct> _expected_prices;
        public Buyer(List<DemandProduct> expected, Bank bank, decimal money)
        {
            _bank = bank;
            this.money = money;
            _expected_prices = expected;
        }


        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }
        public void OnNext(BankData bdata)
        {
            foreach (DemandProduct product in _expected_prices)
            {
                product.Tax = bdata.Tax;
                product.DemandPrice = product.DemandNetPrice + product.Tax;
                _inflation = bdata.Inflation;
                fdata.Inflation = bdata.Inflation;
            }
        }
        public void OnNext((Dictionary<SupplyProduct, int>, Shop) value)
        {
            Dictionary<SupplyProduct, int> products = new Dictionary<SupplyProduct, int>(value.Item1);

            Shop shop = value.Item2;
            foreach (DemandProduct desiredProduct in _expected_prices)
            {
                foreach (KeyValuePair<SupplyProduct, int> kv in products)
                {
                    if (desiredProduct.Name == kv.Key.Name)
                    {
                        decimal proportions = desiredProduct.DemandPrice / kv.Key.Price;
                        quantity = Convert.ToInt32((1.4m - proportions) * desiredProduct.DesiredQuantity);
                        if (_inflation > 0.1m)
                            quantity *= Convert.ToInt32(quantity * 1.1);
                        if (_inflation < -0.1m)
                            quantity *= Convert.ToInt32(quantity * 0.9);
                        if (kv.Value < quantity)
                            quantity = kv.Value;
                        if (kv.Key.Price * quantity > money)
                            quantity = Convert.ToInt32(Math.Floor(money/kv.Key.Price));
                        money -= shop.Buy(kv.Key, quantity);

                        desiredProduct.DesiredQuantity -= quantity;
                        desiredProduct.DemandPrice -= kv.Key.Price;
                        _bank.AddProduct(desiredProduct, quantity);
                    }
                }
            }
        }
    }
}
