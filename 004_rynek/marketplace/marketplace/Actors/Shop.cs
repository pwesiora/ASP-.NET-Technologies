using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class Shop : IObserver<BankData> 
    {
        public decimal money;
        private VisitorImplementation _visitorImpl = new VisitorImplementation();
        private Bank _bank;

        private Dictionary<SupplyProduct, int> _products;
        private List<IObserver<(Dictionary<SupplyProduct, int>, Shop)>> _buyers;


        public Shop(Dictionary<SupplyProduct, int> products, Bank bank, decimal money)
        {
            _bank = bank;
            this.money = money;
            _products = products;
            this._buyers = new List<IObserver<(Dictionary<SupplyProduct, int>, Shop)>>();
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
            Dictionary<SupplyProduct, int> products = new Dictionary<SupplyProduct, int>(_products);
            foreach (SupplyProduct product in _products.Keys)
            {                
                SupplyProduct newKey = product;
                newKey.Tax = bdata.Tax;
                newKey.ManufacturingCost = (1 + bdata.Inflation);
                newKey.Price = newKey.ManufacturingCost * (1 + newKey.Margin) * (1 + newKey.Tax);
                int quantity = _products[product];
                products.Remove(product);
                products[newKey] = quantity;
            }
            _products = products;
            AnnouncePrice(_products);
        }

        public IDisposable Subscribe(IObserver<(Dictionary<SupplyProduct, int>, Shop)> observer)
        {
            _buyers.Add(observer);
            return new Unsubscriber<(Dictionary<SupplyProduct, int>, Shop)>(_buyers, observer);
        }


        private  void AnnouncePrice(Dictionary<SupplyProduct, int> _productss)
        {
            foreach (IObserver<(Dictionary<SupplyProduct, int>, Shop)> buyer in _buyers)
            {
                buyer.OnNext((_products, this));
            }
        }

        public decimal Buy(SupplyProduct product, int quantity)
        {
            _products[product] -= quantity;
            decimal cost = product.Price * quantity;

            money += cost;
            _bank.AddProduct(product, quantity);
            return cost;
        }
    }
}
