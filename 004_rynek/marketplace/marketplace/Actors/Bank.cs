using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marketplace
{
    public class Bank : IObservable<BankData>
    {
        public BankData fdata = new BankData();
        private List<IObserver<BankData>> _persons;
        private Dictionary<IProduct, int> _products;
        private decimal _money;
        private VisitorImplementation _visitorImpl = new VisitorImplementation();
        private int _turn;

        public int Turn => _turn;
        public decimal Money => _money;

        public Bank(decimal inflation, decimal tax, decimal money)
        {
            fdata.Inflation = inflation;
            fdata.Tax = tax;
            _money = money;
            this._turn = 0;
            _persons = new List <IObserver <BankData> >();
            _products = new Dictionary<IProduct, int>();
        }

        public void StartRound()
        {
            _turn++;
            decimal income = 0;
            AnnounceBankData(fdata);
            _visitorImpl.SellerTax = fdata.Tax;
            _visitorImpl.BuyerTax = fdata.Tax - .07m;
            foreach (KeyValuePair<IProduct, int> kv in _products)
            {
                income += kv.Value * kv.Key.Accept(_visitorImpl);
            }
            _money += income;
            _products = new Dictionary<IProduct, int>();
            if (income < 1m)
            {
                fdata.Tax += .02m;
                fdata.Inflation -= .01m;
            }
            else if (income > 1m)
            {
                fdata.Tax -= .01m;
                fdata.Inflation += .02m;
            }
        }
        public IDisposable Subscribe(IObserver<BankData> observer)
        {
            _persons.Add(observer);
            return new Unsubscriber<BankData>(_persons, observer);
        }

        private void AnnounceBankData(BankData fdata)
        {
            _visitorImpl.SellerTax = fdata.Tax;
            _visitorImpl.BuyerTax = fdata.Tax - .05m;

            foreach (IObserver<BankData> person in _persons)
            {
                person.OnNext(fdata);
            }
        }
        public void AddProduct(IProduct product, int quantity)
        {
            if (_products.ContainsKey(product))
            {
                _products[product] += quantity;
            }
            else
            {
                _products[product] = quantity;
            }
        }
    }
}
