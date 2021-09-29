using System;
using System.Collections.Generic;

namespace fvat
{
    public class Product
    {
        private string _name { get; set; }
        public decimal Vat { get; set; }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (value > 0)
                    _price = value;
                else
                    throw new ArgumentException();
            }
        }
        public decimal AfterTaxPrice => Price + Price * Vat;

        public Product(string name, decimal price, decimal vat = 0.23m)
        {
            _name = name;
            Vat = vat;
            Price = price;
        }
    }
}